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
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Serviço responsável por realizar o login
        /// </summary>
        /// <param name="usuario"> USUARIO </param>
        /// <param name="senha"> SENHA </param>
        /// <returns> Objeto padrão de retorno, com o objeto usuario com o token preenchido </returns>
        [Route("logar")]
        [HttpPost]
        public HttpResponseMessage postLogin([FromBody] LOGIN login)
        {
            ILoginBO loginBO = new LoginBO();
            Retorno retorno = new Retorno();

            String usuario = login.USUARIO;
            String senha = login.SENHA;

            try
            {
                retorno = loginBO.logar(usuario, senha);
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
        /// Serviço responsável por consultar o usuário através do id
        /// </summary>
        /// <param name="id"> ID do usuário </param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("consultar/{id}")]
        [HttpGet]
        public HttpResponseMessage get(long id)
        {
            ILoginBO loginBO = new LoginBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = loginBO.consultar(id);
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
        /// Serviço responsável por listar os usuários
        /// </summary>
        /// <returns> Lista de Objeto padrão de retorno </returns>
        [Route("listar")]
        [HttpGet]
        public HttpResponseMessage get()
        {
            ILoginBO loginBO = new LoginBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = loginBO.listar();
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
        /// Serviço responsável por salvar os dados do usuário
        /// </summary>
        /// <param name="login">Objeto LOGIN</param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("salvar")]
        [HttpPost]
        public HttpResponseMessage post([FromBody] LOGIN login)
        {
            ILoginBO loginBO = new LoginBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = loginBO.salvar(login);

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
        /// Serviço responsável por alterar os dados do usuário
        /// </summary>
        /// <param name="login">Objeto LOGIN</param>
        /// <returns> Objeto padrão de retorno </returns>
        [Route("alterar")]
        [HttpPut]
        public HttpResponseMessage put([FromBody] LOGIN login)
        {
            ILoginBO loginBO = new LoginBO();
            Retorno retorno = new Retorno();

            try
            {
                retorno = loginBO.salvar(login);

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
