using System;
using System.Collections.Generic;
using System.Linq;
using Transport;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // MetroLib metroLib = new MetroLib();//INSTANCIATION
            //APPEL DE LA METHODE QUI SE TROUVE DANS LA BIBLIOTHEQUE POUR LA 1ERE API
            //string routier = class1.GetConnect();
            // déserialisation on met dans une variable donnees le résultat de l'opération depuis la ResponseFromServer
            // List<StructureJson> donnees = JsonConvert.DeserializeObject<List<StructureJson>>(routier);

            //APPEL DE LA METHODE QUI SE TROUVE DANS LA BIBLIOTHEQUE POUR LA 2EME API

            // List<DataRoute> routes = Metro.GetRoutes();
            List<DataRoute> routes = MetroLib.GetRoutes();
            //DESERIALISATION DES JSON

            //AFFICHAGE EN CONSOLE DES ELEMENTS CHOISIS DE LA 2EME API
            foreach (DataRoute test in routes)
            {

                Console.WriteLine("\nNom " + " " + test.longName
                    + "\nNom du bus " + " " + test.shortName + "\n"
                    + "\nCouleur du texte" + " " + test.textColor
                    + "\nCouleur" + " " + test.color
                    + "\nId" + " " + test.id
                    + "\nMode" + " " + test.mode
                    + "\nType" + " " + test.type
                    );

            }

            //AFFICHAGE EN CONSOLE DES ELEMENTS CHOISIS DE LA 1ERE API

            //Dans la variable ArretSansDouble les données groupé par nom, on prend le nom une fois (doublon)
            List<StructureJson> donnees = MetroLib.GetBus();

            List<StructureJson> ArretSansDouble = donnees.GroupBy(n => n.Name).Select(grp => grp.First()).ToList();

            // Ranger et afficher les objets depuis la liste sans doublon 

            foreach (StructureJson donnee in ArretSansDouble)
            {
                /*pour chaque élement de la structureJson dans données on récupère 
                dans la variable donnee, id, nom... et on affiche*/


                Console.WriteLine("\nArrêt" + " " + donnee.Name

                    + "\nLongitude " + " " + donnee.Lon
                    + "\nLatitude " + " " + donnee.Lat + "\n"
                    + "\nLignes" + " " + donnee.Id);

                //les lignes de bus comportant un tableau, on refait un foreach
                foreach (string Lines in donnee.Lines)
                {
                    Console.WriteLine("Lignes" + " " + Lines);
                }

            }

            //Lecture en console 
            Console.Read();
            //Nettoyer le flux et les réponses 

            Console.ReadKey();

        }
    }
}
