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

namespace MovieSystem
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        MoviesEntities db = new MoviesEntities();
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            if (Password_Input.Text == ConfimPass_Input.Text)
            {
                User user = new User();
                user.UserName = UserName_Input.Text;
                user.UserPassword = Password_Input.Text;
                user.Email = Email_Input.Text;
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Registered succesfully !");




                Login login = new Login();
                this.NavigationService.Navigate(login);
            }
            else
            {
                MessageBox.Show("Password is not the same !!");
            }
        }
    }
}
