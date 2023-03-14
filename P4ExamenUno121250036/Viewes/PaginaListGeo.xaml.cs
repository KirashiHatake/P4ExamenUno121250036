using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P4ExamenUno121250036.Viewes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListGeo : ContentPage
    {
        public PaginaListGeo()
        {
            InitializeComponent();
        }

        private void listlocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var page = new Viewes.PaginaMapa();
            Navigation.PushAsync(page);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listlocal.ItemsSource = await App.Database.GetListLocalizacion();
        }
    }


}