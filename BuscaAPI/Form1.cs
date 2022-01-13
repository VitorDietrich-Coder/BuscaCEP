using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
 
namespace BuscaAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            var client = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/", textBox1.Text));
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            textBox2.Text = new JsonDeserializer().Deserialize<BuscaCep>(response).cep;
            textBox3.Text = new JsonDeserializer().Deserialize<BuscaCep>(response).logradouro;
        }
    }
 


}
