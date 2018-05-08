using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL2
{
    public class Model
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Model(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Display
        {
            get
            {
                return ($"{Name}");
            }
        }
    }
}
