using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;
using tp03_2021.Models;
using tp03_2021.ViewModels;

namespace tp03_2021.Controllers
{
    public class CadeteController : Controller
    {
        private readonly RepoCadete _repoCadete;
        private readonly RepoCadeteria _repoCadeteria;
        private readonly IMapper _mapper;
        public CadeteController(RepoCadete repoCadete, IMapper mapper, RepoCadeteria repoCadeteria)
        {
            _repoCadete = repoCadete;
            _mapper = mapper;
            _repoCadeteria = repoCadeteria;
        }

        // GET: CadeteController
        public ActionResult Index()
        {
            return View(_repoCadete.getAll());
        }

        // GET: CadeteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("AltaCadetes")]
        public ActionResult AltaCadete()
        {
            var cadeteVM = new CadeteViewModel();
            cadeteVM.Cadeterias = _repoCadeteria.getAll();
            return View(cadeteVM);
        }

        // POST: CadeteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCadete(CadeteViewModel cadete)
        {
            try
            {
                _repoCadete.CreateCadete(cadete);
                return RedirectToAction("AltaCadete");
            }
            catch(Exception ex)
            {
                var error = new ErrorViewModel(ex.Message);
                return View("Error", error);
            }
        }

        // GET: CadeteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 1) return View("Index");
            var cadete = _repoCadete.getCadeteById(id);
            var cadeteVM = _mapper.Map<Cadete, CadeteViewModel>(cadete);
            cadeteVM.Cadeterias = _repoCadeteria.getAll();
            return View(cadeteVM);
        }

        // POST: CadeteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCadete(CadeteViewModel cadete)
        {
            if (cadete == null)
            {
                return View("Index");
            }
            try
            {
                _repoCadete.UpdateCadete(cadete);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var error = new ErrorViewModel(ex.Message);
                return View("Error", error);
            }
        }

        // GET: CadeteController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            
            if(id<1) return View("Index");
            try
            {
                _repoCadete.DeleteCadete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var error = new ErrorViewModel(ex.Message);
                return View("Error", error);
            }
        }


    }
}
