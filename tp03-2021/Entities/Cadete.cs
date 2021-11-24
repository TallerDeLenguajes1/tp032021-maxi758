using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public enum Vehiculo
    {
        bicicleta, auto, moto
    }
    public class Cadete : Persona
    {
        public int CadeteriaId { get; set; }
        public List<Pedido> ListaPedidos { get; set; }
        public Cadete(){
            
        }
        public Cadete(List<Pedido> listaPedidos)
        {
            ListaPedidos = listaPedidos;
        }
    }
}
