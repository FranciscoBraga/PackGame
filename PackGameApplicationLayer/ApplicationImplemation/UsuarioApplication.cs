using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameApplicationLayer.ApplicationImplemation
{
    public class UsuarioApplication
    {

        private UsuarioRepository UsuarioRepository = new UsuarioRepository();


        public UsuarioApplication()
        {

        }


        public List<Usuario> GetUsuario(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return UsuarioRepository.GetTodos().ToList();

                }
                else
                {
                    return UsuarioRepository.Get(l => l.idUsuario == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarUsuario(Usuario Usuario)
        {
            try
            {
                UsuarioRepository.Adicionar(Usuario);
                UsuarioRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario ProcurarUsuario(int? id)
        {
            try
            {
                return UsuarioRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirUsuario(Usuario Usuario)
        {
            try
            {

                UsuarioRepository.Deletar(l => l == Usuario);
                UsuarioRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarUsuario(Usuario Usuario)
        {
            try
            {
                UsuarioRepository.Atualizar(Usuario);
                UsuarioRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Usuario Logar(string senha, string email)
        {
            try
            {
                Usuario usuario = UsuarioRepository.BuscarLogin(senha, email);
                return usuario;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
