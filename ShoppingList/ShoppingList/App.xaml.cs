using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingList.Services;
using ShoppingList.Views;
using System.Data;
using System.IO;

namespace ShoppingList
{
    public partial class App : Application
    {
        private static ProductData _data;

        public static ProductData Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new ProductData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                        , "Products.db3"));
                }
                return _data;
            }
        }


        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
