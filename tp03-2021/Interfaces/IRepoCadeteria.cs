using System.Collections.Generic;
using tp03_2021.Entities;

namespace tp03_2021.Interfaces
{
    public interface IRepoCadeteria
    {
        void CreateCadeteria(Cadeteria cadeteria);
        void DeleteCadeteria(int id);
        List<Cadeteria> getAll();
        Cadeteria getCadeteriaById(int id);
        void UpdateCadeteria(Cadeteria cadeteria);
    }
}