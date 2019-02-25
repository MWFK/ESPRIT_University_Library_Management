using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliothequeWeb.Controllers
{
    public class AdherantController : Controller
    {
        // GET: Adherant
        public ActionResult Index()
        {
            return View();
        }

        // GET: Adherant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Adherant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adherant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Adherant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Adherant/Edit/5
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

        // GET: Adherant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Adherant/Delete/5
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
