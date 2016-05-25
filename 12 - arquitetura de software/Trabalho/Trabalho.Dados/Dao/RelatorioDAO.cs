using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados.Interface;

namespace Trabalho.Dados.Dao
{
    public class RelatorioDAO : IRelatorioDAO
    {
        public List<VOTACOES> getVotacaoParcialByData(DateTime dia)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from votacoes in ctxTrabalho.VOTACOES
                                  where
                                  (votacoes.DATA == dia.Date)
                                  select votacoes).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<GANHADORES> getGanhadoresByDates(List<DateTime> dias)
        {
            DateTime inicio = dias[0];
            DateTime final = dias[1];
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from ganhadores in ctxTrabalho.GANHADORES
                                  where
                                  (ganhadores.DATA >= inicio.Date && ganhadores.DATA <= final.Date)
                                  orderby ganhadores.DATA
                                  select ganhadores).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MAIS_VOTADOS> getGanhadoresMaisVotados()
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from mv in ctxTrabalho.MAIS_VOTADOS
                                  select mv).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
