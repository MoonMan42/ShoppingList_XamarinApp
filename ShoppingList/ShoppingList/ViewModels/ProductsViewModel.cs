using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {

        private Product _selectedProduct;

        public ObservableCollection<Product> Products { get; }

        public Command LoadProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command<Product> ProductTapped { get; }

        public ProductsViewModel()
        {
            Title = "Remind me";
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecutLoadProductsCommands());

            ProductTapped = new Command<Product>(OnProductSelected);

            AddProductCommand = new Command(OnAddProduct);
        }

        async Task ExecutLoadProductsCommands()
        {
            IsBusy = true;

            try
            {
                Products.Clear();

                // retrive database
                var products = await App.Data.GetProductsAsync();

                // add to view list
                foreach (var p in products)
                {
                    Products.Add(p);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            _selectedProduct = null;
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }

        private void OnProductSelected(Product obj)
        {
            if (obj == null)
            {
                return;
            }

            // TODO open selected item in new view
            throw new NotImplementedException();
        }

        private void OnAddProduct(object obj)
        {
            // TODO open new item view
            throw new NotImplementedException();
        }
    }
}
