using PackGameData.DataContext;
using PackGameData.RepositoryImplemetation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackGameApplicationLayer
{
    public class EtapaApplication
    {

        private EtapaRepository EtapaRepository = new EtapaRepository();


        public EtapaApplication()
        {

        }


        public List<Etapa> GetEtapa(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return EtapaRepository.GetTodos().ToList();

                }
                else
                {
                    return EtapaRepository.Get(l => l.idEtapa == ID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AdicionarEtapa(Etapa Etapa)
        {
            try
            {
                EtapaRepository.Adicionar(Etapa);
                EtapaRepository.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Etapa ProcurarEtapa(int? id)
        {
            try
            {
                return EtapaRepository.Procurar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ExcluirEtapa(Etapa Etapa)
        {
            try
            {

                EtapaRepository.Deletar(l => l == Etapa);
                EtapaRepository.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarEtapa(Etapa Etapa)
        {
            try
            {
                EtapaRepository.Atualizar(Etapa);
                EtapaRepository.Commit();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
