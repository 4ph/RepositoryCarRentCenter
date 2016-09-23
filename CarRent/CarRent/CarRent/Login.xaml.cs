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

namespace CarRent
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.ComboBoxLogin.ItemsSource = (from c in context.TableUsers select c).ToArray();
            this.ComboBoxLogin.DisplayMemberPath = "Lgin";            
        }

        CarRentalCenterDBEntities context = new CarRentalCenterDBEntities();

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = this.ComboBoxLogin.Text;
            string password = this.PasswordBoxPass.Password;

            TableUsers user = new TableUsers();
            user = (from c in context.TableUsers
                    where c.Lgin == login
                    select c).First();

            bool isUser = user != null;
            bool rightPassword = user.Pass.Substring(0,password.Length)== password;

            if (isUser && rightPassword) {
                new WorkPlace(login).ShowDialog();
                this.Close();
            } else {
                MessageBox.Show("Login or password are incorrect !!!");
            }

        }
    }
}
