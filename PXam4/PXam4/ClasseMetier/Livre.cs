using System;
using System.Collections.Generic;
using System.Text;

namespace PXam4.ClasseMetier
{
    public class Livre
    {
        public int IdLivre { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public GenreLivre Genre { get; set; }
        public ThemeLivre Theme { get; set; }
        public string Image { get; set; }
        public int Quantite { get; set; }
    }
}
