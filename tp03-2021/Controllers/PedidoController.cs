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
        static int id = 0;

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
                var cadeteAsignado = _DB.Cadeteria.Cadetes.Find(x => x.Id == CadeteId);
                var pedidoNuevo = new Pedido();

                pedidoNuevo.Id = _DB.GetMaxPedidoId() + 1;
                pedidoNuevo.Observaciones = observaciones;
                pedidoNuevo.Estado = estado;
                pedidoNuevo.Cliente = new Cliente(nombre, direccion, telefono);
                               
                _DB.Cadeteria.Pedidos.Add(pedidoNuevo);
                _DB.SavePedido(_DB.Cadeteria.Pedidos);
                cadeteAsignado.ListadoPedidos.Add(pedidoNuevo);
                _DB.SaveCadete(_DB.Cadeteria.Cadetes);
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
                var pedidoToEdit = _DB.Cadeteria.Pedidos.Find(x => x.Id == pedidoVM.Id);
                pedidoToEdit.Cliente = pedidoVM.Cliente;
                pedidoToEdit.Estado = pedidoVM.Estado;
                pedidoToEdit.Observaciones = pedidoVM.Observaciones;
                _DB.SavePedido(_DB.Cadeteria.Pedidos);
                var cadeteAsignado = _DB.Cadeteria.Cadetes.Find(x => x.Id == pedidoVM.Cadete.Id);
                if (cadeteAsignado.ListadoPedidos.Contains(pedidoToEdit))
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var cadete in _DB.Cadeteria.Cadetes)
                {
                    var elemento = cadete.ListadoPedidos.Find(x => x.Id == pedidoVM.Id);
                    if (elemento != null)
                    {
                        cadete.ListadoPedidos.Remove(elemento);
                    }
                }
                cadeteAsignado.ListadoPedidos.Add(pedidoToEdit);
                _DB.SaveCadete(_DB.Cadeteria.Cadetes);
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
                _DB.Cadeteria.Pedidos.RemoveAll(x => x.Id == id);
                _DB.DeletePedido();
                foreach (var cadete in _DB.Cadeteria.Cadetes)
                {
                    var elemento = cadete.ListadoPedidos.Find(x => x.Id == id);
                    if ( elemento != null)
                    {
                        cadete.ListadoPedidos.Remove(elemento);
                    }
                }
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
