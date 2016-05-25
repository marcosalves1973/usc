using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Helpers
{
    public class Retorno
    {
        public Retorno()
        {
            lista = new List<object>();
        }

        public string mensagem { get; set; }

        public object objeto { get; set; }

        public List<object> lista { get; set; }

        public bool status { get; set; }
    }
}
