using Gestion_Produits_MVC.Models;
using Gestion_Produits_MVC.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.Controllers
{
    public class FamilleController : Controller
    {
        //Injection du service FamilleRepository
        public IRepository<Famille> Repository { get;  }

        public FamilleController(IRepository<Famille> repository)
        {
            Repository = repository;
        }

        //exemple de (endpoint) : comment accéder à l'action ("Index") suivante?
        // il faut taper dans le navigateur:
        // http://localhost:NuméroPort/Famille/Index
        public IActionResult Index()
        {
            var familles = Repository.Lister();
            return View(familles);
        }
        public IActionResult Details(int id)
        {
            var famille = Repository.ListerSelonId(id);
            return View(famille);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Famille famille)
        {
            try
            {
                Repository.Ajouter(famille);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var famille = Repository.ListerSelonId(id);
            return View(famille);
        }

        [HttpPost]
        public ActionResult Edit(int id,Famille famille)
        {
            try
            {
                Repository.Modifier(id, famille);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var famille = Repository.ListerSelonId(id);
            return View(famille);
        }
        [HttpPost]
        public ActionResult Delete(int id, Famille famille)
        {
            try
            {
                Repository.Supprimer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
