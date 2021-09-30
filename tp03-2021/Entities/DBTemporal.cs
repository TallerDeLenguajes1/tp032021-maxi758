using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public class DBTemporal
    {
        string pathCadetes = "";
        string pathPedidos = "";
        public Cadeteria Cadeteria { get; set; }
        public DBTemporal()
        {
            pathCadetes = @"Cadetes.Json";
            pathPedidos = @"Pedidos.Json";
            Cadeteria = new Cadeteria();
            if (GetAllCadetes() != null)
            {
                Cadeteria.Cadetes = GetAllCadetes();
            }
            if (GetAllPedidos() != null)
            {
                Cadeteria.Pedidos = GetAllPedidos();
            }
        }
        public void SaveCadete(List<Cadete> cadete)
        {
            string cadetesJson = JsonSerializer.Serialize(cadete);
            using (FileStream cadetesFile = new FileStream(pathCadetes, FileMode.Create))
            {
                using (StreamWriter strReader = new StreamWriter(cadetesFile))
                {
                    strReader.WriteLine(cadetesJson);
                    strReader.Close();
                    strReader.Dispose();
                }
            }
        }
        public void SavePedido(List<Pedido> pedidos)
        {
            string pedidosJson = JsonSerializer.Serialize(pedidos);
            using (FileStream pedidosFile = new FileStream(pathPedidos, FileMode.Create))
            {
                using (StreamWriter strReader = new StreamWriter(pedidosFile))
                {
                    strReader.WriteLine(pedidosJson);
                    strReader.Close();
                    strReader.Dispose();
                }
            }
        }
        public List<Cadete> GetAllCadetes()
        {
            List<Cadete> CadetesJson = null;

            if (File.Exists(pathCadetes))
            {
                using (FileStream cadetesFile = new FileStream(pathCadetes, FileMode.Open))
                {
                    using (StreamReader strReader = new StreamReader(cadetesFile))
                    {
                        string strCadetes = strReader.ReadToEnd();
                        CadetesJson = JsonSerializer.Deserialize<List<Cadete>>(strCadetes);
                        strReader.Close();
                        strReader.Dispose();
                    }
                }
            }
            return CadetesJson;
        }

        public List<Pedido> GetAllPedidos()
        {
            List<Pedido> PedidosJson = null;

            if (File.Exists(pathPedidos))
            {
                using (FileStream pedidosFile = new FileStream(pathPedidos, FileMode.Open))
                {
                    using (StreamReader strReader = new StreamReader(pedidosFile))
                    {
                        string strPedidos = strReader.ReadToEnd();
                        PedidosJson = JsonSerializer.Deserialize<List<Pedido>>(strPedidos);
                        strReader.Close();
                        strReader.Dispose();
                    }
                }
            }
            return PedidosJson;
        }


        public void DeleteCadete()//refactorización de deleteCadete
        {
            if (!GetAllCadetes().Any()) //revisar si es el mejor approach, de todas formas no se ejecuta
            {
                File.Delete(pathCadetes);
                return;
            }
            SaveCadete(Cadeteria.Cadetes);
        }

        public void DeletePedido()
        {
            if (!GetAllPedidos().Any())
            {
                File.Delete(pathPedidos);
                return;
            }
            SavePedido(Cadeteria.Pedidos);
        }

        public int GetMaxCadeteId()
        {
            int maxId = 0;
            if (GetAllCadetes() == null) return 0;
            var listadoCadetes = GetAllCadetes();
            foreach (Cadete item in listadoCadetes)
            {
                if (maxId < item.Id)
                {
                    maxId = item.Id;
                }
            }           
            return maxId;
        }
        public int GetMaxPedidoId()
        {   
            int maxId = 0;
            if (GetAllPedidos() == null) return 0;
            var listadoPedidos = GetAllPedidos();
            foreach (Pedido item in listadoPedidos)
            {
                if (maxId < item.Id)
                {
                    maxId = item.Id;
                }
            }
            return maxId;
        }
    }
}
