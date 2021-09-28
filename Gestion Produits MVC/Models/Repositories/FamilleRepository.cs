using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.Models.Repositories
{
    public class FamilleRepository : IRepository<Famille>
    {
        public  IList<Famille> familles;

        public FamilleRepository()
        {
            familles = new List<Famille>()
            {
                new Famille
                {
                    id= 1, nom="Imprimantes"
                },
                new Famille
                {
                    id= 2, nom="PC"
                },
                new Famille
                {
                    id= 3, nom="Caméra"
                }
            };
        }
        public void Ajouter(Famille element)
        {
            familles.Add(element);
        }

        public IList<Famille> Lister()
        {
            return familles;
        }

        public Famille ListerSelonId(int id)
        {
            return familles.Single(a => a.id == id);
        }
        

        public void Modifier(int id, Famille element)
        {
            // var ancienneFamille = familles.SingleOrDefault(a => a.id == id);
            //optimisation
            var ancienneFamille = ListerSelonId(id);
             ancienneFamille.nom = element.nom;
        }

        public void Supprimer(int id)
        {
            // var famille = familles.SingleOrDefault(a => a.id == id);
            //optimisation
            var famille = ListerSelonId(id);
            familles.Remove(famille);
        }
    }
}
