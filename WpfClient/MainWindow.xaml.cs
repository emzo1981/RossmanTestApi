using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.Models;
using WpfClient.Services;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiClient apiClient;
        private List<Product> products;

        public List<Product> Products 
        {
            get { return products; }
            set { products = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitApiData();
        }

        private  void InitApiData()
        {
            apiClient = new ApiClient();
            
         
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var uri = apiClient.CreateRequestUri("products", $"skip={txtSkip.Text}&take={TxtTake.Text}");
            var Products = await apiClient.GetAsync<List<Product>>(uri);
            dgvProductList.DataContext = Products;
           // dgvProductList.relo
        }
    }
}
