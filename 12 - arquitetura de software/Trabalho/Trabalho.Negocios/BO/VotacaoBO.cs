using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Dados;
using Trabalho.Dados.Dao;
using Trabalho.Dados.Interface;
using Trabalho.Helpers;
using Trabalho.Negocios.Interface;

namespace Trabalho.Negocios.BO
{
    public class VotacaoBO : IVotacaoBO
    {
        /// <summary>
        /// Responsavel por realizar a votacao
        /// </summary>
        /// <param name="votacao">objeto votacao</param>
        /// <returns>obj retorno</returns>
        public Retorno votar(VOTACAO votacao)
        {
            IVotacaoDAO votacaoDAO = new VotacaoDAO();
            Retorno retorno = new Retorno();

            DateTime thisDay = DateTime.Now;
            try
            {

                retorno.status = true;

                if (thisDay.Hour > 12 || (thisDay.Hour == 11 && thisDay.Minute > 29))
                {
                    retorno.status = false;
                    retorno.mensagem = "Votação encerrada por hoje.";
                    return retorno;
                }

                if (string.IsNullOrEmpty(votacao.LOGIN_ID.ToString()))
                {
                    retorno.status = false;
                    retorno.mensagem = "Usuário inválido.";
                    return retorno;
                }
                if (string.IsNullOrEmpty(votacao.RESTAURANTE_ID.ToString()))
                {
                    retorno.status = false;
                    retorno.mensagem = "Restaurante inválido.";
                    return retorno;
                }
                if (string.IsNullOrEmpty(votacao.DATA.ToString()))
                {
                    thisDay = votacao.DATA;
                }
                else
                {
                    votacao.DATA = thisDay;
                }

                // testa se o usuario ja votou hoje
                List<VOTACAO> votacao_dia = votacaoDAO.getVotacaoPorUsuarioDia(votacao.LOGIN_ID, thisDay);
                if (votacao_dia.Count() > 0)
                {
                    retorno.status = false;
                    retorno.mensagem = "Usuário já votou hoje.";
                    return retorno;
                }

                long id = votacaoDAO.salvar(votacao);

                retorno.objeto = votacao.ID = id;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }


            retorno.mensagem = "Registro salvo com sucesso.";
            return retorno;
        }

        /// <summary>
        /// Lista os restaurantes se o horario for menor 11:30
        /// Se o horario for maior ou igual a 11:30, devolve apenas o ganhador do dia
        /// </summary>
        /// <returns></returns>
        public Retorno listarRestaurante(long usuario_id)
        {
            IVotacaoDAO votacaoDAO = new VotacaoDAO();
            IGanhadorDAO ganhadorDAO = new GanhadorDAO();
            IRestauranteDAO restauranteDAO = new RestauranteDAO();
            DataVotacao dataVotacao = new DataVotacao();
            Retorno retorno = new Retorno();

            DateTime thisDay = DateTime.Now;

            try
            {
                if (thisDay.Hour > 12 || (thisDay.Hour == 11 && thisDay.Minute > 29))
                {
                    List<GANHADOR> ganhadores = ganhadorDAO.getGanhador(thisDay);
                    if (ganhadores.Count() == 1)
                    {
                        retorno.status = true;
                        retorno.objeto = restauranteDAO.consultar(ganhadores[0].RESTAURANTE_ID);
                        retorno.mensagem = "Listagem realizada com sucesso.";
                    }
                    else if (ganhadores.Count() == 0)
                    {
                        long restaurante_ganhador = votacaoDAO.getRestauranteGanhador(thisDay);

                        if (restaurante_ganhador > 0)
                        {
                            GANHADOR ganhador = new GANHADOR();
                            ganhador.DATA = thisDay;
                            ganhador.RESTAURANTE_ID = restaurante_ganhador;
                            long id = ganhadorDAO.salvar(ganhador);

                            retorno.status = true;
                            retorno.objeto = restauranteDAO.consultar(restaurante_ganhador);
                            retorno.mensagem = "Listagem realizada com sucesso.";                            
                        }
                        else
                        {
                            retorno.status = true;
                            retorno.objeto = "";
                            retorno.mensagem = "Nenhum restaurante foi votado hoje.";
                        }

                    }
                    else
                    {
                        retorno.status = false;
                        retorno.objeto = "";
                        retorno.mensagem = "Ocorreu um erro. Comunique o administrador. Mais de um ganhador nesse dia: " + thisDay.Date;
                    }
                }
                else
                {
                    // testa se o usuario ja votou hoje
                    List<VOTACAO> votacao_dia = votacaoDAO.getVotacaoPorUsuarioDia(usuario_id, thisDay);
                    if (votacao_dia.Count() > 0)
                    {
                        retorno.status = false;
                        retorno.mensagem = "Usuário já votou hoje. Aguarde o fim da votação.";
                        return retorno;
                    }

                    List<DateTime> dias = dataVotacao.retornarData();
                    // recupera o id de todos os restaurantes que ganharam na semana
                    List<long> ganhadores = ganhadorDAO.listaRestauranteId(dias);
                    List<RESTAURANTE> restaurantes = restauranteDAO.listarPorGanhores(ganhadores);

                    retorno.status = true;
                    retorno.objeto = restaurantes;
                    retorno.mensagem = "Listagem realizada com sucesso.";
                }
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;
                return retorno;
            }
        }
    }
}
