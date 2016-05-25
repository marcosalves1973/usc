using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Trabalho.Dados;
using Trabalho.Helpers;
using Trabalho.Negocios.BO;
using Trabalho.Negocios.Interface;

namespace Trabalho.Controllers
{
    [RoutePrefix("api/relatorio")]
    public class RelatorioController : ApiController
    {
        /// <summary>
        /// Serviço responsável por consultar o relatorio parcial do dia
        /// </summary>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("pacial")]
        [HttpGet]
        public HttpResponseMessage parcial()
        {
            IRelatorioBO relatorioBO = new RelatorioBO();
            Retorno retorno = new Retorno();
            DateTime thisDay = DateTime.Now;

            try
            {
                retorno = relatorioBO.getVotacaoParcialByData(thisDay);
                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new ObjectContent<Retorno>(retorno,
                                new JsonMediaTypeFormatter(),
                                new MediaTypeWithQualityHeaderValue("application/json"))
                };

            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;

                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ObjectContent<Retorno>(retorno,
                                new JsonMediaTypeFormatter(),
                                new MediaTypeWithQualityHeaderValue("application/json"))
                };
            }
        }

        /// <summary>
        /// Serviço responsável por consultar o relatorio dos restaurantes ganhadores da semana passada
        /// </summary>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("semanaPassada")]
        [HttpGet]
        public HttpResponseMessage semanaPassada()
        {
            IRelatorioBO relatorioBO = new RelatorioBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = relatorioBO.getGanhadoresSemanaAnterior();
                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new ObjectContent<Retorno>(retorno,
                                new JsonMediaTypeFormatter(),
                                new MediaTypeWithQualityHeaderValue("application/json"))
                };

            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;

                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ObjectContent<Retorno>(retorno,
                                new JsonMediaTypeFormatter(),
                                new MediaTypeWithQualityHeaderValue("application/json"))
                };
            }
        }

        /// <summary>
        /// Serviço responsável por consultar o relatorio dos 10 restaurantes que mais ganhou a votação
        /// </summary>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("maisVotado")]
        [HttpGet]
        public HttpResponseMessage maisVotado()
        {
            IRelatorioBO relatorioBO = new RelatorioBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = relatorioBO.getGanhadoresMaisVotados();
                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new ObjectContent<Retorno>(retorno,
                                new JsonMediaTypeFormatter(),
                                new MediaTypeWithQualityHeaderValue("application/json"))
                };

            }
            catch (Exception ex)
            {
                retorno.status = false;
                retorno.mensagem = ex.Message;

                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ObjectContent<Retorno>(retorno,
                                new JsonMediaTypeFormatter(),
                                new MediaTypeWithQualityHeaderValue("application/json"))
                };
            }
        }
	}
}