using Gestion_Produits_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.ViewModels
{
    public class ProduitFamilleViewModel
    {
        public int ProduitId { get; set; }
        public string reference { get; set; }
        public string designation { get; set; }
        public string description { get; set; }
        public bool disponible { get; set; }
        public int FamilleId { get; set; }

        public IList<Famille> Familles { get; set; }
    }
}
