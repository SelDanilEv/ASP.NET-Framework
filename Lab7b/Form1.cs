using Lab7b.ServiceReference1;
using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace Lab7b
{
    public partial class Form1 : Form
    {
        WebServiceSoapClient client;

        public Form1()
        {
            InitializeComponent();

            this.client = new WebServiceSoapClient();
        }

        private void Get_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            dynamic array = this.client.GetDict();
            int counter = 0;
            foreach (var item in array)
            {
                this.richTextBox1.Text += $"{++counter}) Name: {item.Name}, Phone: {item.Phone}\n";
            }
        }

        private void Post_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.name.Text;
                string number = this.number.Text;

                if (this.client.AddDict(name, number) == "OK")
                {
                    Get_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Fill required fields");
            }
        }

        private void Put_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.name.Text;
                string number = this.number.Text;

                if (this.client.UpdDict(name, number) == "OK")
                {
                    Get_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed update");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Fill required fields");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.name.Text;

                if (this.client.DelDict(name) == "OK")
                {
                    Get_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed delete");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Fill required fields");
            }
        }
    }
}
