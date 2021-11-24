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
    public class PedidoController : Controller
    {
        private readonly RepoPedido _repoPedido;
        private readonly RepoCadete _repoCadete;
        private readonly RepoCliente _repoCliente;
        private readonly IMapper _mapper;

        public PedidoController(RepoPedido repoPedido, RepoCadete repoCadete, RepoCliente repoCliente, IMapper mapper)
        {
            _repoPedido = repoPedido;
            _repoCadete = repoCadete;
            _repoCliente = repoCliente;
            _mapper = mapper;
        }

        // GET: PedidoController
        public ActionResult Index()
        {
            var listadoPedidos = _repoPedido.getAll();
            return View(listadoPedidos);
        }


        public ActionResult AltaPedido()
        {
            var pedidoVM = new PedidoViewModel();
            pedidoVM.Cadetes = _repoCadete.getAll();
            pedidoVM.Clientes = _repoCliente.getAll();
            return View(pedidoVM);
        }
        // GET: PedidoController/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPedido(PedidoPostViewModel pedidoVM)
        {
            try
            {
                _repoPedido.CreatePedido(pedidoVM);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var error = new ErrorViewModel(ex.Message);
                return View("Error", error);
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            var pedidoAEditar = _repoPedido.getPedidoById(id);
            var pedidoVM = _mapper.Map<Pedido, PedidoViewModel>(pedidoAEditar);
            pedidoVM.Cadetes = _repoCadete.getAll();
            pedidoVM.Clientes = _repoCliente.getAll();
            return View(pedidoVM);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPedido(PedidoPostViewModel pedidoVM)
        {
            try
            {
                _repoPedido.UpdatePedido(pedidoVM);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            _repoPedido.DeletePedido(id);
            return RedirectToAction(nameof(Index)); 
        }

        
    }
}
