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
using System.Windows.Shapes;
using WpfApp3.DataSet1TableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Rega.xaml
    /// </summary>
    public partial class Rega : Window
    {
        public Rega()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == null || password.Password == null || login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            new userTableAdapter().InsertQuery(login.Text, password.Password, 3);

            new Auth().Show();
            this.Close();
        }
    }
}
