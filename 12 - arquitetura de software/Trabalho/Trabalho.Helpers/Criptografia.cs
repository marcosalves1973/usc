using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Helpers
{
    public class Criptografia
    {
        #region Variáveis

        /// <summary>
        /// CRIANDO OS VETORES QUE SERÃO UTILIZADOS COMO CHAVE
        /// </summary>
        private static readonly Byte[] _key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private static readonly Byte[] _iv = { 65, 110, 68, 26, 69, 178, 200, 219 };

        /// <summary>
        /// CRIANDO O PROVIDER TRIPLE DES
        /// </summary>
        readonly static TripleDESCryptoServiceProvider _desc = new TripleDESCryptoServiceProvider();

        /// <summary>
        /// CRIANDO O MANIPULADOR DE STRING
        /// </summary>
        private static readonly UTF8Encoding _utf8 = new UTF8Encoding();

        #endregion

        #region Métodos

        /// <summary>
        /// CRIPTOGRAFA ENTRADA DE ARRAY DE BYTE
        /// </summary>
        /// <param name="input"></param>
        /// <returns>byte[]</returns>
        public static byte[] criptografar(byte[] input)
        {
            try
            {
                return converter(input, _desc.CreateEncryptor(_key, _iv));
            }
            catch (Exception ex)
            {
                //Relançando a Exception
                throw ex;
            }
        }

        /// <summary>
        /// DESCRIPTOGRAFA ENTRADA DE ARRAY DE BYTE
        /// </summary>
        /// <param name="_input"></param>
        /// <returns>byte[]</returns>
        public static byte[] descriptografar(byte[] _input)
        {
            try
            {
                return converter(_input, _desc.CreateDecryptor(_key, _iv));
            }
            catch (Exception ex)
            {
                //Relançando a Exception
                throw ex;
            }
        }

        /// <summary>
        /// CRIPTOGRAFA ENTRADA DE STRING
        /// </summary>
        /// <param name="_text"></param>
        /// <returns>string</returns>
        public static string criptografar(string _text)
        {
            try
            {
                byte[] _input = _utf8.GetBytes(_text);
                byte[] _output = converter(_input, _desc.CreateEncryptor(_key, _iv));

                return Convert.ToBase64String(_output);
            }
            catch (Exception ex)
            {
                //Relançando a Exception
                throw ex;
            }
        }

        /// <summary>
        /// DESCRIPTOGRAFA ENTRADA DE STRING
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string descriptografar(string text)
        {
            try
            {
                byte[] input = Convert.FromBase64String(text);
                byte[] output = converter(input, _desc.CreateDecryptor(_key, _iv));

                return _utf8.GetString(output);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// CONVERTE OS BYTES PARA A CRIPTOGRAFIA
        /// </summary>
        /// <param name="input"></param>
        /// <param name="cryptoTrasnform"></param>
        /// <returns>byte[]</returns>
        private static byte[] converter(byte[] input, ICryptoTransform cryptoTrasnform)
        {
            // CRIA OS STREAMS NECESSÁRIOS
            MemoryStream stream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(stream, cryptoTrasnform, CryptoStreamMode.Write);

            try
            {
                // CONVERTE OS BYTES QUE FORAM REQUISITADOS
                cryptStream.Write(input, 0, input.Length);
                cryptStream.FlushFinalBlock();

                // LÊ O MEMORY STREAM  E CONVERTE DE VOLTA PARA O ARRAY DE BYTES
                stream.Position = 0;
                byte[] lbytResultado = new byte[Convert.ToInt32(stream.Length - 1) + 1];
                stream.Read(lbytResultado, 0, Convert.ToInt32(lbytResultado.Length));

                // FECHA E LIBERA OS STREAMS
                stream.Close();
                cryptStream.Close();

                // DEVOLVE O RESULTADO
                return lbytResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
