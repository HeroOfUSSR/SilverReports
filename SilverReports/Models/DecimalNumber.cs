using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilverReports.Context
{
    public partial class DecimalNumber
    {
        public int ID_Decimal { get; set; }

        [Required]
        public string Title_Decimal { get; set; }

        public string dni { get; set; } = string.Empty;

        public string dn { get; set; } = string.Empty;


        public virtual ICollection<Check> Checks { get; set; }

        public virtual ICollection<Norm> Norms { get; set; }

    }
}
