using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Page
    {
        MoviesEntities db = new MoviesEntities();
        public ForgetPassword()
        {
            InitializeComponent();
        }

        
        private void Forgot_Pass(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user = db.Users.FirstOrDefault(x => x.Email == EmailB.Text);
            if (user != null)
            {
                user.UserPassword = PasswordB.Text;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                MessageBox.Show("Password Changed Succesfuly");
            }
            else
            {
                MessageBox.Show("Email Not Found !");
            }
        }
    }
}
