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
        }
        public void SaveCadete(List<Cadete> cadete)
        {
            string path = @"Cadetes.Json";
            string cadetesJson = JsonSerializer.Serialize(cadete);
            using (FileStream cadetesFile = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter strReader = new StreamWriter(cadetesFile))
                {
                    strReader.Write(cadetesJson);
                    strReader.Close();
                    strReader.Dispose();
                }
            }
        }

        public List<Cadete> GetAllCadetes()
        {
            List<Cadete> CadetesJson = new();
            string path = @"Cadetes.Json";

            if (File.Exists(path))
            {
                using (FileStream cadetesFile = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamReader strReader = new StreamReader(cadetesFile))
                    {
                        string strCadetes = strReader.ReadToEnd();
                        CadetesJson = JsonSerializer.Deserialize<List<Cadete>>(strCadetes);
                    }
                }
            }
            return CadetesJson;
        }

        public void DeleteCadete()
        {
            string path = @"Cadetes.Json";

            using (FileStream cadetesFile = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter strReader = new StreamWriter(cadetesFile))
                {
                    foreach (Cadete item in Cadeteria.Cadetes)
                    {
                        string CadeteJson = JsonSerializer.Serialize(item);
                        strReader.Write(CadeteJson);
                    }
                    strReader.Close();
                    strReader.Dispose();
                }
            }
        }

        public int GetMaxId()
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
                    }
                }
            }
            return maxId;
        }
    }
}
