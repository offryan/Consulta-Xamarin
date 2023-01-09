using Newtonsoft.Json;//
using System.Net.Http;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consultas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        //Limpar
        public void Limpar()
        {
            txtCEP.Text = string.Empty;
            txtCEP.Focus();
            lblCEP.Text =
            lblLogradouro.Text =
            lblComplemento.Text =
            lblBairro.Text =
            lblLocalidade.Text =
            lblEstado.Text = "-";
        }

        private void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            string strURL = string.Format("https://viacep.com.br/ws/{0}/json/", txtCEP.Text);
            HttpClient client = new HttpClient();
            try
            {
                var response = client.GetAsync(strURL).Result;
                //string de resultado
                var result = response.Content.ReadAsStringAsync().Result;
                Cep lugar = JsonConvert.DeserializeObject<Cep>(result);
                lblCEP.Text = lugar.cep.ToString();
                lblLogradouro.Text = lugar.logradouro.ToString();
                lblComplemento.Text = lugar.complemento.ToString();
                lblBairro.Text = lugar.bairro.ToString();
                lblLocalidade.Text = lugar.localidade.ToString();
                lblEstado.Text = lugar.uf.ToString();

            }
            catch (Exception)
            {
                DisplayAlert("Erro", "CEP Inválido !!", "OK");
                Limpar();
            }
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}