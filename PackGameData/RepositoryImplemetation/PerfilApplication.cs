using PackGameData.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameData.RepositoryImplemetation
{
    public class PerfilApplication
    {

        private PerfilRepository PerfilRepository = new PerfilRepository();


        public PerfilApplication()
        {

        }


        public List<Perfil> GetPerfil(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return PerfilRepository.GetTodos().ToList();

                }
                else
                {
                    return PerfilRepository.Get(l => l.idPerfil== ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarPerfil(Perfil Perfil)
        {
            try
            {
                PerfilRepository.Adicionar(Perfil);
                PerfilRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Perfil ProcurarPerfil(int? id)
        {
            try
            {
                return PerfilRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirPerfil(Perfil Perfil)
        {
            try
            {

                PerfilRepository.Deletar(l => l == Perfil);
                PerfilRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarPerfil(Perfil Perfil)
        {
            try
            {
                PerfilRepository.Atualizar(Perfil);
                PerfilRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
