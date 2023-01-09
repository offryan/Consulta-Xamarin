using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;//
using System.Net.Http;//

namespace Consultas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Limpar
        public void Limpar()
        {
            lblCompra.Text =
            lblVenda.Text =
            lblVariacao.Text = "-";
        }

        private void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            //criando as variaveis
            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=c3b6b2f6";
            HttpClient client = new HttpClient();

            try
            {
                var response = client.GetAsync(strURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    //string de resultado
                    var result = response.Content.ReadAsStringAsync().Result;
                    Market market = JsonConvert.DeserializeObject<Market>(result);

                    //imprimindo nas labels
                    lblCompra.Text = market.currency.Buy.ToString("C");
                    lblVenda.Text = market.currency.Sell.ToString("C");
                    lblVariacao.Text = (market.currency.Variation / 100).ToString("P");
                }
                else
                {
                    Limpar();
                }

            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Informe os valores", "OK");
                Limpar();
                return;
            }
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
