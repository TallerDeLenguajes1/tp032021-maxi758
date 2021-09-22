﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

namespace tp03_2021.Controllers
{
    public class CadeteController : Controller
    {
        private readonly DBTemporal _DB;
        static int id = 0;

        public CadeteController(DBTemporal DB)
        {
            _DB = DB;
        }

        // GET: CadeteController
        public ActionResult Index()
        {
            return View(_DB.Cadeteria.ListadoDeCadetes);
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
                cadete.Id = id++;
                _DB.Cadeteria.ListadoDeCadetes.Add(cadete);
                return View("../Home/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadeteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadeteController/Edit/5
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

        // GET: CadeteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadeteController/Delete/5
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