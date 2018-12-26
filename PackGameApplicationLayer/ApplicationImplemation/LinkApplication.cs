using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameApplicationLayer.ApplicationImplemation
{
    public class LinkApplication
    {

        private LinkRepository LinkRepository = new LinkRepository();


        public LinkApplication()
        {

        }


        public List<Link> GetLink(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return LinkRepository.GetTodos().ToList();

                }
                else
                {
                    return LinkRepository.Get(l => l.idLink == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarLink(Link Link)
        {
            try
            {
                LinkRepository.Adicionar(Link);
                LinkRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Link ProcurarLink(int? id)
        {
            try
            {
                return LinkRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirLink(Link Link)
        {
            try
            {

                LinkRepository.Deletar(l => l == Link);
                LinkRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarLink(Link Link)
        {
            try
            {
                LinkRepository.Atualizar(Link);
                LinkRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
