using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;

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
        public ActionResult CrearPedido(string observaciones, Estado estado, int CadeteId)
        {
            try
            {
                var cadeteAsignado = _DB.Cadeteria.Cadetes.Find(x => x.Id == CadeteId);
                var pedidoNuevo = new Pedido();

                pedidoNuevo.Id = _DB.GetMaxPedidoId() + 1;
                pedidoNuevo.Observaciones = observaciones;
                pedidoNuevo.Estado = estado;
                _DB.Cadeteria.Pedidos.Add(pedidoNuevo);
                _DB.SavePedido(_DB.Cadeteria.Pedidos);
                cadeteAsignado.ListadoPedidos.Add(pedidoNuevo);
                _DB.SaveCadete(_DB.Cadeteria.Cadetes);
                return View("../Home/Index");
            }
            catch (Exception ex)
            {
                return View("Index", ex.ToString());
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
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

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
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
