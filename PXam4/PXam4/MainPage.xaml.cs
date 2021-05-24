using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PXam4.Pages;

namespace PXam4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnVoirLivre_Clicked(object sender, EventArgs e)
        {
            VoirLivre page = new VoirLivre();
            await Navigation.PushModalAsync(new NavigationPage(page));
        }

        private async void btnCreerLivre_Clicked(object sender, EventArgs e)
        {
            PageCreerLivre page = new PageCreerLivre();
            await Navigation.PushModalAsync(new NavigationPage(page));
        }
    }
}
