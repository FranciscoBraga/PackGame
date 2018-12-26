using PackGameData.DataContext;
using PackGameData.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameData.RepositoryImplemetation
{
    public class PerfilRepository:GenericRepository<Perfil>,IPerfilRepository
    {

        private PackGameBD context = new PackGameBD();

        public  Perfil BuscarPerfil(string busca)
        {
            var verificar = (Perfil)context.Perfil.Where(p => p.nomePerfil.Equals(busca)).FirstOrDefault();

            if(verificar != null)
            {
                Perfil perfil = verificar;
                return perfil;
            }
            return null;
;        } 
    }
}
