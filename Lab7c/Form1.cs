using Lab7b.PhoneServiceReference;
using System;
using System.Windows.Forms;

namespace Lab7b
{
    public partial class Form1 : Form
    {
        IService client;

        public Form1()
        {
            InitializeComponent();

            this.client = new ServiceClient();
        }

        private void Get_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            dynamic array = this.client.GetAll();
            int counter = 0;
            foreach (var item in array)
            {
                this.richTextBox1.Text += $"{++counter}) Name: {item.Namek__BackingField}, Phone: {item.Phonek__BackingField}\n";
            }
        }

        private void Post_Click(object sender, EventArgs e)
        {
            try
            {
                var telephoneNote = new TelephoneNote()
                {
                    Namek__BackingField = this.name.Text,
                    Phonek__BackingField = this.number.Text
                };

                this.client.Add(telephoneNote);
                Get_Click(sender, e);
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
                var telephoneNote = new TelephoneNote()
                {
                    Namek__BackingField = this.name.Text,
                    Phonek__BackingField = this.number.Text
                };

                this.client.Update(telephoneNote);
                Get_Click(sender, e);
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
                var telephoneNote = new TelephoneNote()
                {
                    Namek__BackingField = this.name.Text,
                    Phonek__BackingField = this.number.Text
                };

                this.client.Delete(telephoneNote);
                Get_Click(sender, e);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Fill required fields");
            }
        }
    }
}
