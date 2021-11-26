using tp03_2021.Entities;

namespace tp03_2021.Interfaces
{
    public interface IRepoUsuario
    {
        Usuario Login(Usuario usuario);
        void Register(Usuario usuario);
    }
}