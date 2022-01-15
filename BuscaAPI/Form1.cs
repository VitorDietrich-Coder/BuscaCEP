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
          
            var client = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/", textBox1.Text));
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            string cep = new JsonDeserializer().Deserialize<BuscaCep>(response).cep;
            string logradouro = new JsonDeserializer().Deserialize<BuscaCep>(response).logradouro;
            string complemento = new JsonDeserializer().Deserialize<BuscaCep>(response).complemento;
            string bairro = new JsonDeserializer().Deserialize<BuscaCep>(response).bairro;
            string localidade = new JsonDeserializer().Deserialize<BuscaCep>(response).localidade;
            string uf = new JsonDeserializer().Deserialize<BuscaCep>(response).uf;
            string ibge = new JsonDeserializer().Deserialize<BuscaCep>(response).ibge;
            string gia = new JsonDeserializer().Deserialize<BuscaCep>(response).gia;
            string ddd = new JsonDeserializer().Deserialize<BuscaCep>(response).ddd;
            string siafi = new JsonDeserializer().Deserialize<BuscaCep>(response).siafi;
            ListViewItem item = new ListViewItem(new[] { cep, logradouro, complemento, bairro, localidade, uf, ibge, gia, ddd, siafi });
            listView1.Items.Add(item);
        }
    }
}
