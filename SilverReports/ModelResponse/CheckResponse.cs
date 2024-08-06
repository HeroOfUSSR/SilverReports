using SilverReports.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverReports.Models
{
    public partial class CheckResponse
    {

        public int ID_Check { get; set; }

        public DateTime Date_Check { get; set; }

        public int Department_Check { get; set; }

        public string Order_Check { get; set; } = string.Empty;

        public string Decimal_Check { get; set; } = string.Empty;

        public int Amount_Check { get; set; }

        public decimal? Norm_Check { get; set; }

        public string SilverType_Check { get; set; } = string.Empty;

        public string Number_Check { get; set; } = string.Empty;

        public decimal Coverage_Check { get; set; }




    }
}
