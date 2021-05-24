using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Xam4Classe
{
    public class GstBdd
    {
        // cnx sert à se connecter à la BDD
        private MySqlConnection cnx;
        // cmd sert à écrire nos requêtes
        private MySqlCommand cmd;
        // dr me permet de récupérer le jeu d'enregistrement(s) de ma requête (select)
        private MySqlDataReader dr;

        // Constructeur
        public GstBdd()
        {
            // La chaine va nous permettre de donner
            // 1) le nom du serveur
            // 2) le nom de la base de données
            // 3) le nom de l'utilisateur
            // 4) le mot de passe
            string chaine = "Server=localhost;Database=xambibliotheque;Uid=root;Pwd=";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }
    }
}
