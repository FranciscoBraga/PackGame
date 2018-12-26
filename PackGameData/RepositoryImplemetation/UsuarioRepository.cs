using PackGameData.DataContext;
using PackGameData.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameData.RepositoryImplemetation
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
       private BdPackGameWeb context = new BdPackGameWeb();

        public Usuario BuscarLogin(string senha, string email)
        {
        
            var verificar = context.Usuario.Where(u=>u.email.Equals(email) && u.senha.Equals(senha)).FirstOrDefault();

            if (verificar != null)
            {
                Usuario usuario = verificar;
              
                return usuario;
            }
            return  null;
        }
    }
}
