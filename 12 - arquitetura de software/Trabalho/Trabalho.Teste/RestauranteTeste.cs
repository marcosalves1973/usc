using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabalho.Dados;
using Trabalho.Dados.Dao;
using Trabalho.Dados.Interface;
using Trabalho.Negocios.BO;
using Trabalho.Negocios.Interface;
using Trabalho.Helpers;

namespace Trabalho.Teste
{
    [TestClass]
    public class RestauranteTeste
    {
        /// <summary>
        /// Teste - salva dados do restaurante
        /// </summary>
        [TestMethod]
        public void testeSalvar()
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            RESTAURANTE restaurante = new RESTAURANTE();
            Retorno retorno = new Retorno();

            restaurante.NOME = "flipper";

            retorno = restauranteBO.salvar(restaurante);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - Altera dados do restaurante
        /// </summary>
        [TestMethod]
        public void testeAlterar()
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            RESTAURANTE restaurante = new RESTAURANTE();
            Retorno retorno = new Retorno();

            restaurante.ID = 1;
            restaurante.NOME = "Sappore";

            retorno = restauranteBO.salvar(restaurante);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - consulta dados do restaurante
        /// </summary>
        [TestMethod]
        public void testeConsultar()
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            RESTAURANTE restaurante = new RESTAURANTE();
            Retorno retorno = new Retorno();

            retorno = restauranteBO.consultar(1);

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }

        /// <summary>
        /// Teste - lista dados do restaurante
        /// </summary>
        [TestMethod]
        public void testeListar()
        {
            IRestauranteBO restauranteBO = new RestauranteBO();
            RESTAURANTE restaurante = new RESTAURANTE();
            Retorno retorno = new Retorno();

            retorno = restauranteBO.listar();

            Assert.AreEqual(true, retorno.status, retorno.mensagem);
        }
    }
}
