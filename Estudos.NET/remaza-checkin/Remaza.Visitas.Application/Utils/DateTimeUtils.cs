using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remaza.Visitas.Application.Utils
{
    internal class DateTimeUtils
    {
        public static DateTimeOffset GetBrazilTime()
        {
            try
            {
                var timeZoneId = OperatingSystem.IsWindows() ? "E. South America Standard Time" : "America/Sao_Paulo";
                var brazilianTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                var utcNow = DateTimeOffset.UtcNow;

                return TimeZoneInfo.ConvertTime(utcNow, brazilianTimeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                return DateTimeOffset.UtcNow;
            }
        }
    }
}
