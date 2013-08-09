using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DayOfWeekParser
{
    
    public class ServiceParser : IServiceParser
    {
        public string GetDayOfWeek(DateTime date)
        {
            
            string dayOfWeek = date.ToString("dddd",
                              new CultureInfo("bg-BG"));

            return dayOfWeek;
        }
    }
}
