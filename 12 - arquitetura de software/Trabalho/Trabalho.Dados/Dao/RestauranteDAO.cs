using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados.Interface;

namespace Trabalho.Dados.Dao
{
    public class RestauranteDAO : IRestauranteDAO
    {
        /// <summary>
        /// Resposável por salvar os dados do restaurante
        /// </summary>
        /// <param name="restaurante"> objeto restaurante </param>
        /// <returns> long </returns>
        public long salvar(RESTAURANTE restaurante)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    ctxTrabalho.RESTAURANTE.Add(restaurante);
                    ctxTrabalho.SaveChanges();
                    return restaurante.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Responsável por atualizar os dados do restaurante
        /// </summary>
        /// <param name="restaurante"> objeto restaurante </param>
        public void atualizar(RESTAURANTE restaurante)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    ctxTrabalho.RESTAURANTE.Attach(restaurante);
                    ctxTrabalho.Entry(restaurante).State = EntityState.Modified;
                    ctxTrabalho.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Responsável por retornar os dados de um restaurante
        /// </summary>
        /// <param name="id"> id do restaurante </param>
        /// <returns> objeto restaurante </returns>
        public RESTAURANTE consultar(long id)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from restaurante in ctxTrabalho.RESTAURANTE
                                  where
                                  restaurante.ID == id
                                  select restaurante).FirstOrDefault();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Responsável por retornar todos os dados de todos os restaurantes
        /// </summary>
        /// <returns> lista de objeto restaurante </returns>
        public List<RESTAURANTE> listar()
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                    var result = (from restaurante in ctxTrabalho.RESTAURANTE
                                  select restaurante).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RESTAURANTE> listarPorGanhores(List<long> ganhadores)
        {
            try
            {
                using (TRABALHOEntities ctxTrabalho = new TRABALHOEntities())
                {
                     var result = (from restaurante in ctxTrabalho.RESTAURANTE
                                  where
                                  !ganhadores.Any(RESTAURANTE_ID => RESTAURANTE_ID == restaurante.ID)
                                  select restaurante).ToList();
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
