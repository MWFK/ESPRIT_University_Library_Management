using BibDomain.Entities;
using BibliothequeWeb.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliothequeWeb.Controllers
{
    public class AuteurController : Controller
    {
        IAuteurService AS = new AuteurService();
        // GET: Auteur
        public ActionResult Index()
        {

            return View();
        }

        // GET: Auteur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteur/Create
        [HttpPost]
        public ActionResult Create(AuteurViewModel AVM)
        {
            Auteur A = new Auteur();
            A.AuteurCode = AVM.AuteurCode;
            A.nomComplet = new NomComplet { Nom = AVM.nomComplet.Nom, Prenom = AVM.nomComplet.Prenom };
            AS.Add(A);
            AS.Commit();
            return RedirectToAction("Index");
           
        }

        // GET: Auteur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auteur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auteur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auteur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
