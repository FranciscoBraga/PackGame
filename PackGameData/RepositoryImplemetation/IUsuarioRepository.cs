using PackGameData.DataContext;
using PackGameData.GenericRepository;

namespace PackGameData.RepositoryImplemetation
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
       Usuario BuscarLogin(string senha, string email);
    }
}