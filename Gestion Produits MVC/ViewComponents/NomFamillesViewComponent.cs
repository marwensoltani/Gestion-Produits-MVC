using Gestion_Produits_MVC.Models;
using Gestion_Produits_MVC.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.ViewComponents
{
    public class NomFamillesViewComponent: ViewComponent
    {
        private readonly IRepository<Famille> _repository;
        public NomFamillesViewComponent(IRepository<Famille> repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var nomsFamille = _repository.Lister().Select(c => c.nom).ToList();
            return View(nomsFamille);
        }
    }
}
