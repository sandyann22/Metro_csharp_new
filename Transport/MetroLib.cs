using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Transport
{
    public class MetroLib
    {


        public static List<DataRoute> GetRoutes()//methode pour lancer les requêtes et récupérer les reponses de l'api
        {
            //creation de la requete pour l url
            WebRequest request = WebRequest.Create("http://data.metromobilite.fr/api/routers/default/index/routes ");

            //Avoir une réponse
            WebResponse response = request.GetResponse();
            // visualisation du status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //obtenir le contenu du container de flux  retourné par le serveur.  
            Stream dataStream = response.GetResponseStream();
            // Ouvrir le flux en utilisant un Lecteur de flux pour un access facile.  
            StreamReader reader = new StreamReader(dataStream);
            // Lire le contenu  
            string responseFromServer = reader.ReadToEnd();

            List<DataRoute> DonneeRoutes = JsonConvert.DeserializeObject<List<DataRoute>>(responseFromServer);

            // Afficher le contenu.  
            //Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            return (DonneeRoutes);
        }
        public static List<StructureJson> GetBus(string adresse = null)//methode pour lancer les requêtes et récupérer les reponses de l'api
        {
            //creation de la requete pour l url
            WebRequest request = WebRequest.Create(adresse);

            //Avoir une réponse
            WebResponse response = request.GetResponse();
            // visualisation du status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //obtenir le contenu du container de flux  retourné par le serveur.  
            Stream dataStream = response.GetResponseStream();
            // Ouvrir le flux en utilisant un Lecteur de flux pour un access facile.  
            StreamReader reader = new StreamReader(dataStream);
            // Lire le contenu  
            string responseFromServer = reader.ReadToEnd();

            List<StructureJson> DonneeBus =JsonConvert.DeserializeObject<List<StructureJson>>(responseFromServer);

            // Afficher le contenu.  
            //Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            return (DonneeBus);
        }

    }
}
