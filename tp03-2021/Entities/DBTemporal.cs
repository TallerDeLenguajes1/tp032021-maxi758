using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp03_2021.Entities
{
    public class DBTemporal
    {
        public Cadeteria Cadeteria { get; set; }
        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
        }
    }
}
