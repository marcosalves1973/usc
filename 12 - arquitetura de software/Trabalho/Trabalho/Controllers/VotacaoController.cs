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
    [RoutePrefix("api/votacao")]
    public class VotacaoController : ApiController
    {
        /// <summary>
        /// Serviço responsável por listar os restaurante com a regra necessaria para a votacao
        /// </summary>
        /// <returns> Lista de Objeto padrão de retorno </returns>
        [Route("listar/restaurantes/{usuario_id}")]
        [HttpGet]
        public HttpResponseMessage get(long usuario_id)
        {
            IVotacaoBO votacaoBO = new VotacaoBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = votacaoBO.listarRestaurante(usuario_id);
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
        /// Serviço responsável por salvar os dados da votacao
        /// </summary>
        /// <param name="votacao">Objeto VOTACAO</param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("votar")]
        [HttpPost]
        public HttpResponseMessage post([FromBody] VOTACAO votacao)
        {
            IVotacaoBO votacaoBO = new VotacaoBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = votacaoBO.votar(votacao);
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