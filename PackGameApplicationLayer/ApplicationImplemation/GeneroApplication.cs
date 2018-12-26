using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameApplicationLayer.ApplicationImplemation
{
    public class GeneroApplication
    {

        private GeneroRepository GeneroRepository = new GeneroRepository();


        public GeneroApplication()
        {

        }


        public List<Genero> GetGenero(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return GeneroRepository.GetTodos().ToList();

                }
                else
                {
                    return GeneroRepository.Get(l => l.idGenero == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarGenero(Genero Genero)
        {
            try
            {
                GeneroRepository.Adicionar(Genero);
                GeneroRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Genero ProcurarGenero(int? id)
        {
            try
            {
                return GeneroRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirGenero(Genero Genero)
        {
            try
            {

                GeneroRepository.Deletar(l => l == Genero);
                GeneroRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarGenero(Genero Genero)
        {
            try
            {
                GeneroRepository.Atualizar(Genero);
                GeneroRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
