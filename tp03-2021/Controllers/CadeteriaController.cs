using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.Controllers
{
    
    public class CadeteriaController : Controller
    {
        private readonly DBTemporal _DB;

        public CadeteriaController(DBTemporal dB)
        {
            _DB = dB;
        }

        // GET: CadeteriaController
        public ActionResult Index()
        {
            return View(_DB.Cadeteria);
        }

        // GET: CadeteriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadeteriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadeteriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadeteriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadeteriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadeteriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadeteriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
