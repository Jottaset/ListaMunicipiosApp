using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace ListaMunicipioApp
{
    public partial class MainPage : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            string uf = lbl_uf.Text.ToUpper();
            var client = new HttpClient();
            var json = await client.GetStringAsync($"http://ibge.herokuapp.com/municipio/?val={uf}");
            //var dados = JsonConvert.DeserializeObject<Object>(json);

            JObject municipios = JObject.Parse(json);

            Dictionary<string, string> dadosMunicipios = municipios.ToObject<Dictionary<string, string>>();

            ArrayList lista = new ArrayList();

            foreach (KeyValuePair<string, string> municipio in dadosMunicipios)
            {
                lista.Add(municipio.Key);
            }

            listaMunicipios.ItemsSource = lista;
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
