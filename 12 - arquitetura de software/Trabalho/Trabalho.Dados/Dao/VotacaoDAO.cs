using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados.Interface;
using Trabalho.Helpers;

namespace Trabalho.Dados.Dao
{
    public class VotacaoDAO : IVotacaoDAO
    {
        /// <summary>
        /// Retorna o id do restaurante mais votado em um determinado dia
        /// </summary>
        /// <param name="dia">DateTime dia</param>
        /// <returns>long id do restaurante | long 0 (zero) se nao tiver nenhum restaurante votado no dia</returns>
        public long getRestauranteGanhador(DateTime dia)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var ganhadores = ctxTrabalho.VOTACAO
                        .Where(w => w.DATA == dia.Date)
                        .GroupBy(g => g.RESTAURANTE_ID)
                        .Select(s => new
                        {
                            RESTAURANTE_ID = s.Key,
                            qnt = s.Count()
                        })
                        .ToList();

                    int maior = 0;
                    long restaurante = 0;
                    int n = 0;
                    if (ganhadores.Count() > 0)
                    {
                        while (n < ganhadores.Count())
                        {
                            if (ganhadores[n].qnt > maior)
                            {
                                maior = ganhadores[n].qnt;
                                restaurante = ganhadores[n].RESTAURANTE_ID;
                            }
                            n++;
                        }
                    }

                    return restaurante;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Resposável por salvar os dados da votacao
        /// </summary>
        /// <param name="votacao"> objeto votacao </param>
        /// <returns> long </returns>
        public long salvar(VOTACAO votacao)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    ctxTrabalho.VOTACAO.Add(votacao);
                    ctxTrabalho.SaveChanges();
                    return votacao.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Responsável por retornar a votacao do dia do usuario
        /// </summary>
        /// <param name="usuario"> usuario desejado </param>
        /// <param name="senha"> senha do usuario </param>
        /// <returns></returns>
        public List<VOTACAO> getVotacaoPorUsuarioDia(long login_id, DateTime dia)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from votacao in ctxTrabalho.VOTACAO
                                  where
                                  votacao.LOGIN_ID == login_id
                                  && votacao.DATA == dia.Date
                                  select votacao).ToList();
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
