using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Runtime.InteropServices;

namespace P4ExamenUno121250036.Viewes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaLocalizacion : ContentPage
    {
        Location location = null;
        public PaginaLocalizacion()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            

            try
            {
                 location = await Geolocation.GetLocationAsync();

                if (location != null &&
                    !String.IsNullOrEmpty (descripcion_corta.Text) &&
                    !String.IsNullOrEmpty (descripcion_larga.Text))
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    var local = new Models.Localizacion
                    {
                        latitud = location.Latitude,
                        longitud = location.Longitude,
                        descripcion_corta = descripcion_corta.Text,
                        descripcion_larga = descripcion_larga.Text,
                        

                    };

                    if (await App.Database.SaveGeo(local) > 0)
                    {
                        await DisplayAlert("Aviso!", "Localizacion guardada", "OK");
                    }
                }
                else
                {
                    if (location == null)
                    {
                        await DisplayAlert("Error!", "El GPS esta desactivado", "OK");
                    }
                    else if (!String.IsNullOrEmpty(descripcion_corta.Text))
                    {
                        await DisplayAlert("Error!", "Sin descripcion corta", "OK");
                    }
                    else if (!String.IsNullOrEmpty(descripcion_larga.Text))
                    {
                        await DisplayAlert("Error!", "Sin descripcion larga", "OK");
                    }

                }
            }

            catch (Exception ex)
            {
                if (location == null)
                {
                    await DisplayAlert("Error!", "El GPS esta desactivado", "OK");
                }
            }
        }

        private async void btnverubicacion_Clicked(object sender, EventArgs e)
        {

            var page = new Viewes.PaginaListGeo();

            await Navigation.PushAsync(page);
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);
                }
                
            }
            catch (Exception ex)
            {
            }
        }
    }
}