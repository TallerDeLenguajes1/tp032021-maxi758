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
        private readonly DBTemporal _DB;

        public PedidoController(DBTemporal dB)
        {
            _DB = dB;
        }

        // GET: PedidoController
        public ActionResult Index()
        {
            return View(_DB.Cadeteria.Pedidos);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult AltaPedido()
        {
            return View(_DB.Cadeteria.Cadetes);
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPedido(string observaciones, Estado estado, int CadeteId,
             string nombre, string direccion, string telefono)
        {
            try
            {
                var cadeteAsignado = _DB.GetCadeteById(CadeteId);
                var pedidoNuevo = new Pedido();

                pedidoNuevo.Id = _DB.GetMaxPedidoId() + 1;
                pedidoNuevo.Observaciones = observaciones;
                pedidoNuevo.Estado = estado;
                pedidoNuevo.Cliente = new Cliente(nombre, direccion, telefono);
                               
                _DB.Cadeteria.Pedidos.Add(pedidoNuevo);
                _DB.SavePedido(_DB.Cadeteria.Pedidos);
                cadeteAsignado.ListadoPedidos.Add(pedidoNuevo);
                _DB.SaveCadete();
                return View("../Home/Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            var pedidoToEdit = _DB.Cadeteria.Pedidos.Find(x => x.Id == id);
            var pedidoVM = new EditPedidoRequest();
            pedidoVM.Cadetes = _DB.Cadeteria.Cadetes;
            pedidoVM.Cliente = pedidoToEdit.Cliente;
            pedidoVM.Estado = pedidoToEdit.Estado;
            pedidoVM.Observaciones = pedidoToEdit.Observaciones;
            return View(pedidoVM);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPedido(EditPedidoResponse pedidoVM)
        {
            if (pedidoVM == null)
            {
                return View("Index");
            }
            try
            {
                var pedidoToEdit = _DB.GetPedidoById(pedidoVM.Id);
                pedidoToEdit.Cliente = pedidoVM.Cliente;
                pedidoToEdit.Estado = pedidoVM.Estado;
                pedidoToEdit.Observaciones = pedidoVM.Observaciones;
                _DB.SavePedido(_DB.GetAllPedidos());
                var cadeteAsignado = _DB.GetCadeteById(pedidoVM.Cadete.Id);
                if (cadeteAsignado.ListadoPedidos.Contains(pedidoToEdit))
                {
                    return RedirectToAction(nameof(Index));
                }
                _DB.DeletePedidoEnCadete(pedidoVM.Id);
                cadeteAsignado.ListadoPedidos.Add(pedidoToEdit);
                _DB.SaveCadete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {                              
                _DB.DeletePedido(id);
                _DB.SaveCadete();                
                return View("Index", _DB.GetAllPedidos());                      
            }
            catch(Exception ex)
            {
                var error = new ErrorViewModel();
                return View("Error", error);
            }
        }
    }
}
