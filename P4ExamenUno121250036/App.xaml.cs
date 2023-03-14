using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P4ExamenUno121250036
{
    public partial class App : Application
    {

        static Controllers.LocalizacionControl database;

        public static Controllers.LocalizacionControl Database
        {
            get
            {
                if (database == null)
                {
                    var pathdatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Prog4.db3";
                    var fullpath = Path.Combine(pathdatabase, dbname);
                    database = new Controllers.LocalizacionControl(fullpath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Viewes.PaginaLocalizacion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
