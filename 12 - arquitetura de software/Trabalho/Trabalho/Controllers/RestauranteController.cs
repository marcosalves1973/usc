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
    [RoutePrefix("api/restaurante")]
    public class RestauranteController : ApiController
    {
        /// <summary>
        /// Serviço responsável por consultar o restaurante através do id
        /// </summary>
        /// <param name="id"> ID do restaurante </param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("consultar/{id}")]
        [HttpGet]
        public HttpResponseMessage get(long id)
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = restauranteBO.consultar(id);
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
        /// Serviço responsável por listar todos os restaurante
        /// </summary>
        /// <returns> Lista de Objeto padrão de retorno </returns>
        [Route("listar")]
        [HttpGet]
        public HttpResponseMessage get()
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = restauranteBO.listar();
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
        /// Serviço responsável por salvar os dados do restaurante
        /// </summary>
        /// <param name="restaurante">Objeto RESTAURANTE</param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("salvar")]
        [HttpPost]
        public HttpResponseMessage post([FromBody] RESTAURANTE restaurante)
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = restauranteBO.salvar(restaurante);

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
        /// Serviço responsável por alterar os dados do restaurante
        /// </summary>
        /// <param name="restaurante">Objeto RESTAURANTE</param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("alterar")]
        [HttpPut]
        public HttpResponseMessage put([FromBody] RESTAURANTE restaurante)
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = restauranteBO.salvar(restaurante);

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