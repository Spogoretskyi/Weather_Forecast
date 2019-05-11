using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Forecast.Tests.Controllers
{
    public class NormalizeJSON
    {
        public string NormalizeObj(string content)
        {
            var tmp = content.Replace(@"\", String.Empty);
            return tmp.Trim().Substring(1, tmp.Length - 2);
        }
    }
}
