using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.Helpers
{
    public class DataVotacao
    {
        public List<DateTime> retornarData()
        {
            DateTime thisDay = DateTime.Now;
            int dayWeek = (int)thisDay.DayOfWeek;

            if (dayWeek == 0){ dayWeek = -7; }
            else{ dayWeek = dayWeek - (dayWeek * 2);  }            

            DateTime dataStart = thisDay.AddDays(dayWeek);
            DateTime dataEnd = thisDay.AddDays(-1);

            List<DateTime> dias = new List<DateTime>();
            dias.Add(dataStart);
            dias.Add(dataEnd);

            return dias;
        }

        public List<DateTime> retornaDataSemanaPassada()
        {
            DateTime thisDay = DateTime.Now;
            int dayWeek = (int)thisDay.DayOfWeek;

            dayWeek = (dayWeek - (dayWeek * 2)) - 7;

            DateTime dataStart = thisDay.AddDays(dayWeek);
            DateTime dataEnd = dataStart.AddDays(6);

            List<DateTime> dias = new List<DateTime>();
            dias.Add(dataStart);
            dias.Add(dataEnd);

            return dias;
        }
    }
}
