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
using Transport;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private String Xvalide { get; set; }//Longitude
        private String Yvalide { get; set; }//Latitude
        private String Zvalide { get; set; }//distance


        private void Button_Click(object sender, RoutedEventArgs e)

        {
            Xvalide = lon.Text;
            Yvalide = lat.Text;
            Zvalide = dist.Text;
            // MessageBox.Show("Bonjour");
            try
            {


                List<StructureJson> donnees = MetroLib.GetBus("http://data.metromobilite.fr/api/linesNear/json?x=" + Xvalide + "&y=" + Yvalide + "&dist=" + Zvalide + "&details=true");

                List<StructureJson> ArretSansDouble = donnees.GroupBy(n => n.Name).Select(grp => grp.First()).ToList();


                /* itération ligne par ligne pour récupérer infos dans Lines
                * soit lines soit lineSansDoublons
                */

               // Result.ItemsSource = ArretSansDouble;

                foreach (StructureJson donnee in ArretSansDouble)
                {
                    /*pour chaque élement de la structureJson dans données on récupère 
                    dans la variable donnee, id, nom... et on affiche*/
                    Result.Items.Add(donnee.Name);

                    //Console.WriteLine("\nArrêt" + " " + donnee.Name

                    //    + "\nLongitude " + " " + donnee.lon
                    //    + "\nLatitude " + " " + donnee.lat + "\n"
                    //    + "\nLignes" + " " + donnee.id);

                    //les lignes de bus comportant un tableau, on refait un foreach
                    foreach (string line in donnee.Lines)
                    {
                        //Console.WriteLine("Lignes" + " " + line);
                    }
                }
            }

            catch (Exception ex)
            {
                Result.Items.Add("Numbers Only. Press reset to try again!");
                Console.WriteLine(ex.GetType().FullName);
            }
        }
    }
}

