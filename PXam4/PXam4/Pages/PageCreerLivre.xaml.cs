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
using Android.Widget;

namespace PXam4.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCreerLivre : ContentPage
    {
        public PageCreerLivre()
        {
            InitializeComponent();
        }
        HttpClient ws;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<GenreLivre> lesGenres = new List<GenreLivre>();
            List<ThemeLivre> lesThemes = new List<ThemeLivre>();

            ws = new HttpClient();
            var reponse = await ws.GetAsync("http://192.168.1.19/Bibliotheque/APIGSB/DAOLivres.php?id=1");
            var content = await reponse.Content.ReadAsStringAsync();
            lesGenres = JsonConvert.DeserializeObject<List<GenreLivre>>(content);
            cboGenre.ItemsSource = lesGenres;

            var reponse2 = await ws.GetAsync("http://192.168.1.19/Bibliotheque/APIGSB/DAOLivres.php?id=2");
            var content2 = await reponse2.Content.ReadAsStringAsync();
            lesThemes = JsonConvert.DeserializeObject<List<ThemeLivre>>(content2);
            cboTheme.ItemsSource = lesThemes;
        }
        private async void btnAjouter_Clicked(object sender, EventArgs e)
        {
            if (txtTitreLivre.Text == null)
            {
                Toast.MakeText(Android.App.Application.Context, "Saisir un titre de livre", ToastLength.Short).Show();
            }
            else
            {
                if (txtAuteurLivre.Text == null)
                {
                    Toast.MakeText(Android.App.Application.Context, "Saisir un auteur de livre", ToastLength.Short).Show();
                }
                else
                {
                    if (txtImageLivre.Text == null)
                    {
                        Toast.MakeText(Android.App.Application.Context, "Saisir un lien d'image", ToastLength.Short).Show();
                    }
                    else
                    {
                        ws = new HttpClient();
                        //Secteur newSecteur = new Secteur();
                        //newSecteur.Nom = txtNomSecteur.Text;
                        JObject liv = new JObject
                        {
                            {"titre", txtTitreLivre.Text },
                            {"auteur", txtAuteurLivre.Text },
                            {"genre", (cboGenre.SelectedItem as GenreLivre).IdGenre },
                            {"theme", (cboTheme.SelectedItem as ThemeLivre).IdTheme },
                            {"image", txtImageLivre.Text},
                            {"quantite", Convert.ToInt32(txtQuantiteLivre.Text) }
                        };
                        string json = JsonConvert.SerializeObject(liv);
                        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        var reponse = await ws.PostAsync("http://192.168.1.19/Bibliotheque/APIGSB/livres/", content);


                    }
                }
            }

        }
    }
}