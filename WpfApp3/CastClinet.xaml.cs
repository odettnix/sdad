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
    /// Логика взаимодействия для CastClinet.xaml
    /// </summary>
    public partial class CastClinet : Window
    {
        public CastClinet(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            loadProduct();
        }

        private int userId;

        private void loadProduct()
        {
            ProductView.Items.Clear();

            CastViewTableAdapter adapter = new CastViewTableAdapter();
            DataSet1.CastViewDataTable productRows = new DataSet1.CastViewDataTable();

            adapter.Fill(productRows);

            for (int i = 0; i < adapter.GetData().Count; i++)
            {
                BitmapImage bitmapImage = new BitmapImage();
                MemoryStream stream = new MemoryStream(adapter.GetData()[i].imageData);

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();

                Cast cast = new Cast()
                {
                    ImageData = bitmapImage,
                    Name = adapter.GetData()[i].name.ToString(),
                    Description = adapter.GetData()[i].description.ToString(),
                    Manufacture = adapter.GetData()[i].mamufacture.ToString(),
                    Count = adapter.GetData()[i].count,
                    EndCost = adapter.GetData()[i].endCost,
                    SaleValue = adapter.GetData()[i].saleValue,
                    idUser = adapter.GetData()[i].idUser,
                    idCast = adapter.GetData()[i].idCast,
                    idProduct = adapter.GetData()[i].idProduct,
                    Status = adapter.GetData()[i].status,
                };

                if (cast.idUser == userId)
                {
                    if (cast.Status == 0)
                    {
                        ProductView.Items.Add(cast);
                    }
                    
                }

                
            }
        }

        private void ProductView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cast cast = ProductView.SelectedItem as Cast;   
            if (cast != null) { 
                value.Text = cast.Count.ToString();
            }
        }

        private void MakeAnOrder_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < ProductView.Items.Count; i++)
            {
                Cast cast = ProductView.Items[i] as Cast;
                
                new orderTableAdapter().InsertQuery(DateTime.Now, random.Next(100,999), Convert.ToInt32(cast.idCast), 1);
                new castsTableAdapter().UpdateQuery(cast.idProduct, cast.idUser, cast.Count, cast.EndCost, cast.SaleValue, 1, cast.idCast);


            }
            MessageBox.Show("Заказ оформлен");
            loadProduct();

        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            Cast cast = ProductView.SelectedItem as Cast;
            if (ProductView.SelectedItem == null)
            {
                MessageBox.Show("Выберете элемент");
                return;
            }

            new castsTableAdapter().UpdateQuery(cast.idProduct, cast.idUser, int.Parse(value.Text),cast.EndCost, cast.SaleValue, cast.Status, cast.idCast);
            MessageBox.Show("Количество изменено");
            loadProduct();
        }
    }
}
