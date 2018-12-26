using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameApplicationLayer.ApplicationImplemation
{
    public class JogoApplication
    {

        private JogoRepository JogoRepository = new JogoRepository();


        public JogoApplication()
        {

        }


        public List<Jogo> GetJogo(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return JogoRepository.GetTodos().ToList();
                
                }
                else
                {
                    return JogoRepository.Get(l => l.idJogo == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarJogo(Jogo Jogo)
        {
            try
            {
                JogoRepository.Adicionar(Jogo);
                JogoRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Jogo ProcurarJogo(int? id)
        {
            try
            {
                return JogoRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirJogo(Jogo Jogo)
        {
            try
            {

                JogoRepository.Deletar(l => l == Jogo);
                JogoRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarJogo(Jogo Jogo)
        {
            try
            {
                JogoRepository.Atualizar(Jogo);
                JogoRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
