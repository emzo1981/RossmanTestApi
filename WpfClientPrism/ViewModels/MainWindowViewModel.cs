using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using WpfClientPrism.Models;
using WpfClientPrism.Services;

namespace WpfClientPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IApiClient _apiClient;
      
        public MainWindowViewModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
            Skip = 1;
            Take = 2;
            GetProductsAsync();
        }
        public DelegateCommand SendCommand => new DelegateCommand(Send);
        private void Send()
        {
            GetProductsAsync();
        }
        private async void GetProductsAsync()
        {
            try
            {
                var uri = _apiClient.CreateRequestUri("products", $"skip={Skip}&take={Take}");
                Products = await _apiClient.GetAsync<List<Product>>(uri);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
                
        }
        private string _error;

        public string Error
        {
            get { return _error; }
            set { SetProperty(ref _error, value); }
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
        private string _title = "Rossman test aplication - Wpf MVVM Client";
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
    }
}
