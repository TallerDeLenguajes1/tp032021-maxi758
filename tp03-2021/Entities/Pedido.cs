using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public enum Estado
    {
        Recibido = 1, Realizandose, Entregado, Desconocido
    }
    
    public enum TipoPedido
    {
        Express = 1,
        Delicado,
        Ecologico,
    }
    public class Pedido
    {
        static int aux = 0;
        int id;
        String observaciones;
        Cliente cliente;
        Cadete cadete;
        Estado estadoPedido;
        TipoPedido tipo;
        bool cupon;
        double costoPedido;

        public Pedido()
        {
            this.Id = aux++;
        }

        public Pedido(string observaciones, Cliente cliente, Cadete cadete, Estado estadoPedido, TipoPedido tipo, bool cupon, double costoPedido)
        {
            this.Id = aux++;
            this.Observaciones = observaciones;
            this.Cliente = cliente;
            this.EstadoPedido = estadoPedido;
            this.Tipo = tipo;
            this.Cupon = cupon;
            this.CostoPedido = costoPedido;
        }

        public int Id { get => id; set => id = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public TipoPedido Tipo { get => tipo; set => tipo = value; }
        public bool Cupon { get => cupon; set => cupon = value; }
        public double CostoPedido { get => costoPedido; set => costoPedido = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }
    }
}
