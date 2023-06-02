using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp3.DataSet1TableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(bool active, int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.active = active;

            if (active)
            {
                Exit.Visibility = Visibility.Hidden;
                Enter.Visibility = Visibility.Hidden;
                Exit1.Visibility = Visibility.Visible;
            }

            castsTableAdapter adapter = new castsTableAdapter();
            DataSet1.castsDataTable castsRows = new DataSet1.castsDataTable();
            adapter.Fill(castsRows);
            DataSet1.castsRow cast = castsRows.Where(usersId => usersId.user_id.Equals(userId)).FirstOrDefault();
            if (cast != null)
            {
                RoCast.IsEnabled = true;
            }
            loadProduct();
        }

        private int userId;
        private bool active;

        public MainWindow()
        {
            InitializeComponent();
            loadProduct();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            new Auth().Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new Rega().Show();
            this.Close();
        }

        private void loadProduct()
        {
            ProductView.Items.Clear();

            productTableAdapter adapter = new productTableAdapter();
            DataSet1.productDataTable productRows = new DataSet1.productDataTable();

            adapter.Fill(productRows);

            for (int i = 0; i < adapter.GetData().Count; i++)
            {
                BitmapImage bitmapImage = new BitmapImage();
                MemoryStream stream = new MemoryStream(adapter.GetData()[i].imageData);

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();

                Product product = new Product()
                {
                    ImageData = bitmapImage,
                    Name = adapter.GetData()[i].name.ToString(),
                    Description = adapter.GetData()[i].description.ToString(),
                    Manufacture = adapter.GetData()[i].mamufacture.ToString(),
                    Value = adapter.GetData()[i].value,
                    Cost = adapter.GetData()[i].cost,
                    Discont = adapter.GetData()[i].discont,
                    Id = adapter.GetData()[i].id,
                };

                ProductView.Items.Add(product);
            }
        }

        private void addToCast_Click(object sender, RoutedEventArgs e)
        {
            if (active == false)
            {
                MessageBox.Show("Войдите в систему");
                return;
            }
            if (ProductView.SelectedItem == null)
            {
                MessageBox.Show("Элемент не выбран");
                return;
            }
            RoCast.IsEnabled = true;

            Product product = ProductView.SelectedItem as Product;
            decimal saleValue = (product.Cost * Convert.ToDecimal(product.Discont)) / 100;
            decimal endCost = product.Cost - saleValue;
            if (product != null)
            {
                new castsTableAdapter().InsertQuery(product.Id, userId, 1, endCost, saleValue, 0);
            }
            MessageBox.Show("Товар добавлен в корзину");



        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            new Auth().Show();
            this.Close();
        }

        private void RoCast_Click(object sender, RoutedEventArgs e)
        {
            new CastClinet(userId).Show();
            this.Close();
        }
    }
}
