using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameApplicationLayer.ApplicationImplemation
{
    public class StudioApplication
    {

        private StudioRepository StudioRepository = new StudioRepository();


        public StudioApplication()
        {

        }


        public List<Studio> GetStudio(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return StudioRepository.GetTodos().ToList();

                }
                else
                {
                    return StudioRepository.Get(l => l.idStudio == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarStudio(Studio Studio)
        {
            try
            {
                StudioRepository.Adicionar(Studio);
                StudioRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Studio ProcurarStudio(int? id)
        {
            try
            {
                return StudioRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirStudio(Studio Studio)
        {
            try
            {

                StudioRepository.Deletar(l => l == Studio);
                StudioRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarStudio(Studio Studio)
        {
            try
            {
                StudioRepository.Atualizar(Studio);
                StudioRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
