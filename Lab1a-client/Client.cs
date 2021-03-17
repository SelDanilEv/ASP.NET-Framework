using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;

namespace Lab1a_client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();

        private async void button1_Click(object sender, EventArgs e)
        {
            //var responseString = await "http://172.16.193.234:46114/Lab1a/sum.SDE"
    //.PostUrlEncodedAsync(new { x = textBox1.Text, y = textBox2.Text })
    //.ReceiveString();
            var responseString = await "https://localhost:44376/sum.SDE"
    .PostUrlEncodedAsync(new { x = textBox1.Text, y = textBox2.Text })
    .ReceiveString();
            //            var values = new Dictionary<string, string>
            //{
            //    { "x", textBox1.Text },
            //    { "y", textBox2.Text }
            //};

            //            var content = new FormUrlEncodedContent(values);

            //            var response = await client.PostAsync("http://172.16.193.234:46114/Lab1a/sum.SDE", content);

            //            var responseString = await response.Content.ReadAsStringAsync();
            //Uri target = new Uri("http://172.16.193.234:46114/Lab1a/sum.SDE");
            //WebRequest request = WebRequest.Create(target);
            //string postData = "x=" + textBox1.Text + "&y=" + textBox2.Text;
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = byteArray.Length;

            //Stream dataStream = request.GetRequestStream();
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //dataStream.Close();

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader rdr = new StreamReader(response.GetResponseStream());
            textBox3.Text = responseString;
        }
    }
}
