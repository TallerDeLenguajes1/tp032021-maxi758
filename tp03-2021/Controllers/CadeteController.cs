using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;
using tp03_2021.Models;

namespace tp03_2021.Controllers
{
    public class CadeteController : Controller
    {
        private readonly DBTemporal _DB;

        public CadeteController(DBTemporal DB)
        {
            _DB = DB;
        }

        // GET: CadeteController
        public ActionResult Index()
        {
            return View(_DB.Cadeteria.Cadetes);
        }

        // GET: CadeteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("AltaCadetes")]
        public ActionResult AltaCadete()
        {
            return View();
        }

        // POST: CadeteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCadete(Cadete cadete)
        {
            try
            {
                cadete.Id = _DB.GetMaxCadeteId()+1;
                _DB.Cadeteria.Cadetes.Add(cadete);
                _DB.SaveCadete();
                return RedirectToAction("AltaCadete");
            }
            catch(Exception ex)
            {
                var error = new ErrorViewModel();
                return View("Error", error);
            }
        }

        // GET: CadeteController/Edit/5
        public ActionResult Edit(int id)
        {
            var cadeteToEdit = _DB.Cadeteria.Cadetes.Find(x => x.Id == id);
            return View(cadeteToEdit);
        }

        // POST: CadeteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCadete(Cadete cadete)
        {
            if (cadete == null)
            {
                return View("Index");
            }
            try
            {
                var cadeteToEdit = _DB.Cadeteria.Cadetes.Find(x => x.Id == cadete.Id);
                cadeteToEdit.Nombre = cadete.Nombre;
                cadeteToEdit.Direccion = cadete.Direccion;
                cadeteToEdit.Telefono = cadete.Telefono;
                _DB.SaveCadete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadeteController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _DB.DeleteCadete(id);
            return View("Index", _DB.GetAllCadetes());
        }


    }
}
