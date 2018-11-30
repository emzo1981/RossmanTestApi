using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using WpfClientPrism.Models;
using WpfClientPrism.Services;

namespace WpfClientPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Rossman test aplication - Wpf MVVM Client";
        private IApiClient _apiClient;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private List<Product> _products;

        public List<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }
        public MainWindowViewModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
            Skip = 1;
            Take = 2;
            GetProducts();
        }
        public DelegateCommand SendCommand => new DelegateCommand(Send);
        private void Send()
        {
            GetProducts();
        }
        private async void GetProducts()
        {
            var uri = _apiClient.CreateRequestUri("products", $"skip={Skip}&take={Take}");
            Products = await _apiClient.GetAsync<List<Product>>(uri);           
        }
        private int _skip;

        public int Skip
        {
            get { return _skip; }
            set {
                SetProperty(ref _skip, value);
            }
        }
        private int _take;

        public int Take
        {
            get { return _take; }
            set { SetProperty(ref _take, value); }
        }

    }
}
