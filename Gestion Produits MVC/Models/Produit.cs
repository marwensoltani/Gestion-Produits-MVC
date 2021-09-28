using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.Models
{
    public class Produit
    {
        public int id { get; set; }
        public string reference { get; set; }
        public string designation { get; set; }
        public string description { get; set; }
        public bool disponible { get; set; }
        public Famille famille { get; set; }
    }
}
