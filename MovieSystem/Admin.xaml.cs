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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        MoviesEntities db = new MoviesEntities();
        Movy movy = new Movy();
        public Admin()
        {
            InitializeComponent();
            Dg2.ItemsSource = db.Movies.ToList();
        }
        public void refresh()
        {
            Dg2.ItemsSource = db.Movies.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
           
            movy.MovieName = MovieB.Text;
            movy.MovieCat = CatB.Text;
            movy.MovieProd = ProdB.Text;
            movy.MovieYear = int.Parse(YearB.Text);
            db.Movies.Add(movy);
            db.SaveChanges();
            refresh();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(IDBox.Text);
            movy = db.Movies.FirstOrDefault(x => x.MovieID == ID);
            db.Movies.Remove(movy);
            db.SaveChanges();
            refresh();
            MessageBox.Show("Removed!");



        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(IDBox.Text);
            movy = db.Movies.FirstOrDefault(x => x.MovieID == ID);
            movy.MovieName = MovieB.Text;
            movy.MovieCat = CatB.Text;
            movy.MovieProd = ProdB.Text;
            movy.MovieYear = int.Parse(YearB.Text);
            db.Movies.AddOrUpdate(movy);
            db.SaveChanges();
            refresh();
            MessageBox.Show("Updated!");
        }
    }
}
