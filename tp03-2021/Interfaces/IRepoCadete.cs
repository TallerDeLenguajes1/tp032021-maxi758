using System.Collections.Generic;
using tp03_2021.Entities;
using tp03_2021.ViewModels;

namespace tp03_2021.Interfaces
{
    public interface IRepoCadete
    {
        void CreateCadete(CadeteViewModel cadete);
        void DeleteCadete(int id);
        List<CadeteViewModel> getAll();
        Cadete getCadeteById(int id);
        void UpdateCadete(CadeteViewModel cadete);
    }
}