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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MoviesEntities db = new MoviesEntities();
        public Login()
        {
            InitializeComponent();
        }

       
        private void login_click(object sender, RoutedEventArgs e)
        {
            string adminu = "Admin";
            string adminp = "4444";
            User user = new User();
            user = db.Users.FirstOrDefault(x => x.UserName == UserName_Input.Text && x.UserPassword == Password_Input.Text);
            if (user != null)
            {
                AllMovies allMovies = new AllMovies();
                this.NavigationService.Navigate(allMovies);
            }
            else if(UserName_Input.Text == adminu && Password_Input.Text == adminp)
            {
                Admin admin = new Admin();
                this.NavigationService.Navigate(admin);
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password!");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.NavigationService.Navigate(register);
        }

        private void ForgotPass(object sender, RoutedEventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            this.NavigationService.Navigate(forgetPassword);
        }
    }
}
