using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private List<Model> model = new List<Model>();

        public Form1()
        {
            InitializeComponent();
            UpdateBinding();
        }

        void UpdateBinding()
        {
            listBox1.DataSource = model;
            listBox1.ValueMember = "Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = new DataAccess();
            model = data.GetPeople();
            UpdateBinding();// It's a MUST
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = new DataAccess();
            Model selectedItem = (Model)listBox1.SelectedItem;
            data.Delete(selectedItem);
            UpdateBinding();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var data = new DataAccess();          
            model = data.GetName(textBox1.Text);
            UpdateBinding();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var data = new DataAccess();
            var name = textBox1.Text;
            var model = new Model(Guid.NewGuid(), name);
            data.Insert(model);                      
            UpdateBinding();
        }
    }
}
