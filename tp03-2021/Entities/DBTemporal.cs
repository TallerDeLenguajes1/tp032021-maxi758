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
        public Cadeteria Cadeteria { get; set; }
        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
            if (GetAllCadetes()!=null)
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
            string path = @"Cadetes.Json";
            string cadetesJson = JsonSerializer.Serialize(cadete);
            using (FileStream cadetesFile = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter strReader = new StreamWriter(cadetesFile))
                {
                    strReader.WriteLine(cadetesJson);
                    /*strReader.Close();
                    strReader.Dispose();*/
                }
            }
        }
        public void SavePedido(List<Pedido> pedidos)
        {
            string path = @"Pedidos.Json";
            string pedidosJson = JsonSerializer.Serialize(pedidos);
            using (FileStream pedidosFile = new FileStream(path, FileMode.OpenOrCreate))
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
            string path = @"Cadetes.Json";

            if (File.Exists(path))
            {
                using (FileStream cadetesFile = new FileStream(path, FileMode.OpenOrCreate))
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
            string path = @"Pedidos.Json";

            if (File.Exists(path))
            {
                using (FileStream pedidosFile = new FileStream(path, FileMode.OpenOrCreate))
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
        
        public void DeleteCadete()
        {
            string path = @"Cadetes.Json";
            if (Cadeteria.Cadetes.Count() == 0)
            {
                File.Delete(path);
                return;
            }
            string CadeteJson = JsonSerializer.Serialize(Cadeteria.Cadetes);
            using (FileStream cadetesFile = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter strReader = new StreamWriter(cadetesFile))
                {
                    strReader.WriteLine(CadeteJson);
                    strReader.Close();
                    strReader.Dispose();
                }
            }
        }

        public void DeletePedido()
        {
            string path = @"Pedidos.Json";
            if (Cadeteria.Pedidos.Count()==0)
            {
                File.Delete(path);
                return;
            }
            string PedidoJson = JsonSerializer.Serialize(Cadeteria.Cadetes);
            using (FileStream pedidosFile = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter strReader = new StreamWriter(pedidosFile))
                {
                    strReader.WriteLine(PedidoJson);                   
                    strReader.Close();
                    strReader.Dispose();
                }
            }
        }
        
        public int GetMaxCadeteId()
        {
            List<Cadete> CadetesJson = new();
            string path = @"Cadetes.Json";
            int maxId = 0;
            if (File.Exists(path))
            {
                using (FileStream cadetesFile = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader strReader = new StreamReader(cadetesFile))
                    {
                        string strCadetes = strReader.ReadToEnd();
                        CadetesJson = JsonSerializer.Deserialize<List<Cadete>>(strCadetes);
                        foreach (Cadete item in CadetesJson)
                        {
                            if (maxId<item.Id)
                            {
                                maxId = item.Id;
                            }
                        }
                        strReader.Close();
                        strReader.Dispose();
                    }
                }
            }
            return maxId;
        }
        public int GetMaxPedidoId()
        {
            List<Pedido> PedidosJson = new();
            string path = @"Pedidos.Json";
            int maxId = 0;
            if (File.Exists(path))
            {
                using (FileStream pedidosFile = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader strReader = new StreamReader(pedidosFile))
                    {
                        string strPedidos = strReader.ReadToEnd();
                        PedidosJson = JsonSerializer.Deserialize<List<Pedido>>(strPedidos);
                        foreach (Pedido item in PedidosJson)
                        {
                            if (maxId < item.Id)
                            {
                                maxId = item.Id;
                            }
                        }
                        strReader.Close();
                        strReader.Dispose();
                    }
                }
            }
            return maxId;
        }
    }
}
