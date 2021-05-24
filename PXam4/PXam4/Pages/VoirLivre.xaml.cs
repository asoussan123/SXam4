using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PXam4.ClasseMetier;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PXam4.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoirLivre : ContentPage
    {
        public VoirLivre()
        {
            InitializeComponent();
        }
        HttpClient ws;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Livre> lesLivres = new List<Livre>();

            ws = new HttpClient();
            var reponse = await ws.GetAsync("http://192.168.1.19/Bibliotheque/APIGSB/livres");
            var content = await reponse.Content.ReadAsStringAsync();
            lesLivres = JsonConvert.DeserializeObject<List<Livre>>(content);
            lvLivres.ItemsSource = lesLivres;
        }
    }
}