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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
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

            userTableAdapter adapter = new userTableAdapter();
            DataSet1.userDataTable userRows = new DataSet1.userDataTable();

            adapter.Fill(userRows);

            DataSet1.userRow user = userRows.Where(users => users.login.Equals(login.Text) || users.password.Equals(password.Password)).FirstOrDefault();

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            switch (user.role_id)
            {
                case 1: new AdminPage().Show();
                    break;
                case 2: new MenegerPage().Show();
                    break;
                case 3: new MainWindow(true, user.id).Show();
                    break;
            }

            this.Close();


        }
    }
}
