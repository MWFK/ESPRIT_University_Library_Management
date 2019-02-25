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
    public class DocumentController : Controller
    {
        DocumentService DS = new DocumentService();
        BibliothequeService bs = new BibliothequeService();
        // GET: Document
        public ActionResult Index()
        {
            List<DocumentViewModel> lists = new List<DocumentViewModel>();
            foreach (var item in DS.GetAll())
            {
                DocumentViewModel dvm = new DocumentViewModel();
                dvm.Categorie = item.Categorie;
                dvm.DocumentCode = item.DocumentCode;
                dvm.Titre = item.Titre;
                dvm.Etat = (BibliothequeWeb.Models.Etat)item.Etat;
                //dvm.Etat.Equals(item.Etat);
                lists.Add(dvm);

            }
            return View(lists);
        }
        [HttpPost]
        public ActionResult Index(string searchString, int id )
        {
            
            List<DocumentViewModel> lists = new List<DocumentViewModel>();
            foreach (var item in DS.GetAll())
            {
                DocumentViewModel dvm = new DocumentViewModel();
                dvm.Categorie = item.Categorie;
                dvm.DocumentCode = item.DocumentCode;
                dvm.Titre = item.Titre;
                dvm.Etat = (BibliothequeWeb.Models.Etat)item.Etat;
                //dvm.Etat.Equals(item.Etat);
                lists.Add(dvm);

            }
           // return View(lists);
            if (!String.IsNullOrEmpty(searchString))
            {
                lists = lists.Where(m => m.Titre.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                lists = lists.Where(m => m.DocumentCode==id).ToList();
            }
          
            return View(lists);
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
           
            var bib = DS.GetById(id);
         
            
                DocumentViewModel bvm = new DocumentViewModel();
                bvm.Categorie = bib.Categorie;
                bvm.DocumentCode = bib.DocumentCode;
            bvm.Etat = (BibliothequeWeb.Models.Etat)bib.Etat;
            bvm.Titre = bib.Titre;
            bvm.BibliothequeFK = bib.BibliothequeFK;
            
            return View(bvm);

            
        }

        // GET: Document/Create
        public ActionResult Create()
        {
           

            var bib = bs.GetAll();
            List<BibliothequeViewModel> lbvm = new List<BibliothequeViewModel>();
            foreach (var item in bib)
            {
                BibliothequeViewModel bvm = new BibliothequeViewModel();
                bvm.BibliothequeCode = item.BibliothequeCode;
                bvm.NbrDoc = item.BibliothequeCode;
                lbvm.Add(bvm);

            }
           
            ViewData["Biblio"] = new SelectList(lbvm, "BibliothequeCode", "BibliothequeCode");
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(DocumentViewModel DVM)
        { 
            Document d = new Document() { Etat=(BibDomain.Entities.Etat)DVM.Etat};
           
            d.DocumentCode = DVM.DocumentCode;

            d.Titre = DVM.Titre;
            d.Categorie = DVM.Categorie;
            //d.BibliothequeFK = DVM.BibliothequeFK;
            d.Bibliotheque = new Bibliotheque { BibliothequeCode=DVM.BibliothequeFK};
            
            DS.Add(d);
            DS.Commit();
            return RedirectToAction("Index");


        }

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
            var bib = DS.GetById(id);


            DocumentViewModel bvm = new DocumentViewModel();
            bvm.Categorie = bib.Categorie;
            bvm.DocumentCode = bib.DocumentCode;
            bvm.Etat.Equals(bib.Etat);
            bvm.Titre = bib.Titre;
            bvm.BibliothequeFK = bib.BibliothequeFK;

            var bib1 = bs.GetAll();
            List<BibliothequeViewModel> lbvm = new List<BibliothequeViewModel>();
            foreach (var item in bib1)
            {
                BibliothequeViewModel bvm1 = new BibliothequeViewModel();
                bvm1.BibliothequeCode = item.BibliothequeCode;
                bvm1.NbrDoc = item.BibliothequeCode;
                lbvm.Add(bvm1);

            }

           

            ViewData["Biblio"] = new SelectList(lbvm, "BibliothequeCode", "BibliothequeCode");

            return View(bvm);
        }

        // POST: Document/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DocumentViewModel DVM)
        {
          
            Document d = DS.GetById(id);

            d.Etat = (BibDomain.Entities.Etat)DVM.Etat;
            //DVM.Etat = Etat.Disponible;
            //DVM.Etat = Models.Etat.Emprunte;
            d.DocumentCode = DVM.DocumentCode;
             



            d.Titre = DVM.Titre;
            d.Categorie = DVM.Categorie;
          
            Bibliotheque c = bs.GetById(id);

            c = new Bibliotheque { BibliothequeCode = DVM.BibliothequeFK };

           
            DS.Update(d);
           DS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            var bib = DS.GetById(id);


            DocumentViewModel bvm = new DocumentViewModel();
            bvm.Categorie = bib.Categorie;
            bvm.DocumentCode = bib.DocumentCode;
            bvm.Etat.Equals(bib.Etat);
            bvm.Titre = bib.Titre;
          
            return View(bvm);
        }

        // POST: Document/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DocumentViewModel DVM)
        {
            Document d = DS.GetById(id);
            DVM.DocumentCode = d.DocumentCode;
            DVM.Etat.Equals(d.Etat);
            DVM.Titre = d.Titre;
            DVM.Categorie = d.Categorie;
           Bibliotheque c = bs.GetById(id);

            DVM.BibliothequeFK = d.BibliothequeFK;

            DS.Delete(d);
           DS.Commit();
            return RedirectToAction("Index");
        }
    }
}
