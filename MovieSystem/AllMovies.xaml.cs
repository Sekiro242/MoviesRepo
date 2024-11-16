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
    /// Interaction logic for AllMovies.xaml
    /// </summary>
    public partial class AllMovies : Page
    {
        MoviesEntities db = new MoviesEntities();
        public AllMovies()
        {
            InitializeComponent();
            Dg2.ItemsSource = db.Movies.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Movy movy = new Movy();
            int ID = int.Parse(IDBOX.Text);


            movy = db.Movies.FirstOrDefault(x => x.MovieID == ID);
            MovieDetails movieDetails = new MovieDetails(movy);
            this.NavigationService.Navigate(movieDetails);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Movy movy = new Movy();
            if (combobox.Text == "All")
            {
                Dg2.ItemsSource = db.Movies.ToList();
            }
            else
            {
                Dg2.ItemsSource = db.Movies.Where(x => x.MovieCat == combobox.Text).Select(x => new { x.MovieID, x.MovieName, x.MovieCat, x.MovieProd, x.MovieYear }).ToList();
            }
        }
    }
}
