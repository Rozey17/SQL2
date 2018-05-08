using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SQL2
{
    public class DataAccess
    {
        public List<Model> GetPeople()// you specify list<> when you want to retrieve some data
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CustomerManagerDb")))
            {
                var output = connection.Query<Model>($"dbo.retrievecustomertypes").ToList();

                return output;
            }
        }

        public void Insert(Model model) // on veut inserer un élement de type Model
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CustomerManagerDb")))
            {   
                // les paramètres sont séparés par des virgules et on utilise Execute (à cause du void)
                var output = connection.Execute($" dbo.InsertCustomerType @Id, @Name", model);
            }
        }

        public void Delete(Model name) // toujours se demander quest ce que je delete (un Model)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CustomerManagerDb")))
            {
                //on utilise Execute (à cause du void)
                var output = connection.Execute($"DeleteCustomerTypes @Name", name);                
            }
        }

        public List<Model> GetName(string name)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("CustomerManagerDb")))
            {
                var output = connection.Query<Model>($"GetName @Name", new { Name = name }).ToList();

                return output ;
            }
        }


    }
}
