using SilverReports.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverReports.Models
{
    public partial class NormResponse
    {
        public int ID_Norm { get; set; }

        public string Decimal_Norm { get; set; }

        public string SilverType_Norm { get; set; }

        public decimal Title_Norm { get; set; }

        public int? Department_Norm { get; set; }

    }
}
