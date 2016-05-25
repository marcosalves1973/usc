using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados.Interface;

namespace Trabalho.Dados.Dao
{
    public class GanhadorDAO : IGanhadorDAO
    {
        /// <summary>
        /// Retorna o id de todos os restaurantes que ganharam a votacao
        /// </summary>
        /// <param name="dias"> lista de dias </param>
        /// <returns> lista de id de restaurantes</returns>
        public List<long> listaRestauranteId(List<DateTime> dias)
        {
            DateTime inicio = dias[0];
            DateTime final = dias[1];
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from ganhador in ctxTrabalho.GANHADOR
                                     where
                                     (ganhador.DATA >= inicio.Date && ganhador.DATA <= final.Date)
                                     select ganhador.RESTAURANTE_ID).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna o ganhador de um determinado dia
        /// </summary>
        /// <param name="dia">DateTime com a data do dia desejado</param>
        /// <returns> objeto GANHADOR</returns>
        public List<GANHADOR> getGanhador(DateTime dia)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from ganhador in ctxTrabalho.GANHADOR
                                  where
                                  (ganhador.DATA == dia.Date)
                                  select ganhador).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Resposável por salvar os dados do ganhador
        /// </summary>
        /// <param name="ganhador"> objeto ganhador </param>
        /// <returns> long </returns>
        public long salvar(GANHADOR ganhador)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    ctxTrabalho.GANHADOR.Add(ganhador);
                    ctxTrabalho.SaveChanges();
                    return ganhador.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
