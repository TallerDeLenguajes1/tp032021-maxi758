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
    public class UsuarioController : Controller
    {
        private readonly RepoUsuario _repoUsuario;
        private readonly IMapper _mapper;
        public UsuarioController(RepoUsuario repoUsuario, IMapper mapper)
        {
            _repoUsuario = repoUsuario;
            _mapper = mapper;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(RegisterViewModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Register");
                }
                var nuevoUsuario = _mapper.Map<RegisterViewModel, Usuario>(usuario);
                _repoUsuario.Register(nuevoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(Usuario usuario)
        {
            try
            {
                var user = _repoUsuario.Login(usuario); 
                if (user == null) return View("Login");
                HttpContext.Session.SetInt32("ID", user.Id);
                HttpContext.Session.SetInt32("Rol", user.Id);
                HttpContext.Session.SetString("username", user.Username);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                var error = new ErrorViewModel(ex.Message);
                return View("Error", error);
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
