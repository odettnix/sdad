using Microsoft.Win32;
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
using System.Windows.Shapes;
using WpfApp3.DataSet1TableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
            loadProduct();
        }

        private byte[] imageData;

        private void addTovar_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == null || description.Text == null || manufacture.Text == null || value.Text == null
                || cost.Text == null || imageData == null)
            {
                MessageBox.Show("Все поля должны быть заполнены"); 
                return;
            }

            if (name.Text.Length > 50)
            {
                MessageBox.Show("Поле наименование не должно превышать 50 символов");
                return;
            }

            if (description.Text.Length > 250 || manufacture.Text.Length > 250)
            {
                MessageBox.Show("Поле описание и производитель не должно превышать 250 символов");
                return;
            }
            if (Double.Parse(discont.Text) > 99)
            {
                MessageBox.Show("Скидка не должна превышать 99%");
                return;
            }

            if (Double.Parse(discont.Text) < 0 || Decimal.Parse(cost.Text) < 0 || int.Parse(value.Text) < 0)
            {
                MessageBox.Show("Числовые значения не могут быть ниже 0");
                return;
            }

            new productTableAdapter().InsertQuery(imageData, name.Text, description.Text, manufacture.Text, Decimal.Parse(cost.Text), Double.Parse(discont.Text), int.Parse(value.Text));
            loadProduct();
        }

        private void editTovar_Click(object sender, RoutedEventArgs e)
        {

            if (ProductView.SelectedItem == null)
            {
                MessageBox.Show("Выберете элемент");
                return;
            }

            if (name.Text == null || description.Text == null || manufacture.Text == null || value.Text == null
                || cost.Text == null || imageData == null)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            if (name.Text.Length > 50)
            {
                MessageBox.Show("Поле наименование не должно превышать 50 символов");
                return;
            }

            if (description.Text.Length > 250 || manufacture.Text.Length > 250)
            {
                MessageBox.Show("Поле описание и производитель не должно превышать 250 символов");
                return;
            }
            if (Double.Parse(discont.Text) > 99)
            {
                MessageBox.Show("Скидка не должна превышать 99%");
                return;
            }

            if (Double.Parse(discont.Text) < 0 || Decimal.Parse(cost.Text) < 0 || int.Parse(value.Text) < 0)
            {
                MessageBox.Show("Числовые значения не могут быть ниже 0");
                return;
            }


            Product product = ProductView.SelectedItem as Product;
            new productTableAdapter().UpdateQuery(imageData, name.Text, description.Text, manufacture.Text, Decimal.Parse(cost.Text), Double.Parse(discont.Text), int.Parse(value.Text), product.Id);
            

            loadProduct();

        }

        private byte[] getImage(BitmapImage image)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream stream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            return stream.ToArray();
        }

        private void ProductView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = ProductView.SelectedItem as Product;

            if (product != null)
            {
                name.Text = product.Name; 
                description.Text = product.Description;
                manufacture.Text = product.Manufacture;
                cost.Text = product.Cost.ToString();
                discont.Text = product.Discont.ToString();
                value.Text = product.Value.ToString();
                imageData = getImage(product.ImageData);
            }

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

        private void addImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                imageData = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void deleteTovar_Click(object sender, RoutedEventArgs e)
        {
            if (ProductView.SelectedItem == null)
            {
                MessageBox.Show("Выберете элемент");
                return;
            }

            Product product = ProductView.SelectedItem as Product;

            new productTableAdapter().DeleteQuery(product.Id);
            loadProduct();
        }
    }
}
