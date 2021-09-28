using Gestion_Produits_MVC.Models;
using Gestion_Produits_MVC.Models.Repositories;
using Gestion_Produits_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Produits_MVC.Controllers
{
    public class ProduitController : Controller
    {
        public IRepository<Famille> FamilleRepository { get; }
        public IRepository<Produit> ProduitRepository { get; }

        public ProduitController(IRepository<Produit> produitRepository,IRepository<Famille> familleRepository)
        {
            ProduitRepository = produitRepository;
            FamilleRepository = familleRepository;
        }

        public IActionResult Index()
        {
            var produits = ProduitRepository.Lister();
            return View(produits);
        }
        public IActionResult Details(int id)
        {
            var produit = ProduitRepository.ListerSelonId(id);
            return View(produit);
        }

        public IActionResult Create()
        {
            ProduitFamilleViewModel viewModel = new ProduitFamilleViewModel
            {
                Familles = FamilleRepository.Lister()
            };
            return View(viewModel);
     
            
        }
        [HttpPost]
        public IActionResult Create(ProduitFamilleViewModel viewModel)
        {
            try
            {
                var produit = new Produit
                {
                    reference = viewModel.reference,
                    designation = viewModel.designation,
                    description = viewModel.description,
                    disponible = viewModel.disponible,
                    famille = new Famille
                    {
                        id = viewModel.FamilleId,
                        nom = FamilleRepository.ListerSelonId(viewModel.FamilleId).nom
                    }
                };
                ProduitRepository.Ajouter(produit);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var produit = ProduitRepository.ListerSelonId(id);
            ProduitFamilleViewModel viewModel = new ProduitFamilleViewModel
            {
                ProduitId = produit.id,
                reference = produit.reference,
                designation = produit.designation,
                description = produit.description,
                disponible = produit.disponible,
                FamilleId = produit.famille.id,
                Familles = FamilleRepository.Lister()
            };
            return View(viewModel);
        }
     [HttpPost]
     public IActionResult Edit(int id,ProduitFamilleViewModel viewModel)
        {
            try
            {
                var editedProduit = new Produit
                {
                    id = viewModel.ProduitId,
                    reference = viewModel.reference,
                    designation = viewModel.designation,
                    description = viewModel.description,
                    disponible = viewModel.disponible,
                    famille = new Famille
                    {
                        id = viewModel.FamilleId,
                        nom = FamilleRepository.ListerSelonId(viewModel.FamilleId).nom
                    }
                };
                ProduitRepository.Modifier(id, editedProduit);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var produit = ProduitRepository.ListerSelonId(id);
            ProduitFamilleViewModel viewModel = new ProduitFamilleViewModel
            {
                ProduitId = produit.id,
                reference = produit.reference,
                designation = produit.designation,
                description = produit.description,
                disponible = produit.disponible,
                FamilleId = produit.famille.id,
                Familles = FamilleRepository.Lister()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Delete(int id, ProduitFamilleViewModel produit)
        {
            try
            {
                ProduitRepository.Supprimer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
