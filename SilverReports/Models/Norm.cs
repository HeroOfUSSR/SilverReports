using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverReports.Context
{
    public partial class Norm
    {
        public int ID_Norm { get; set; }

        public int Decimal_Norm { get; set; }
        public DecimalNumber Decimal_NormNavigation { get; set; }

        public int SilverType_Norm { get; set; }
        public SilverType SilverType_NormNavigation { get; set; }


        public decimal Title_Norm { get; set; }

        public int? Department_Norm { get; set; }
        public Department Department_NormNavigation { get; set; }

    }
}
