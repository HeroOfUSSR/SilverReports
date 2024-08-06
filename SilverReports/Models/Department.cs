using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilverReports.Context
{
    public partial class Department
    {
        public int Code_Department { get; set; }

        [Required]
        public bool IsAtWork_Department { get; set; }

        public virtual ICollection<Check> Checks { get; set; }

        public virtual ICollection<Norm> Norms { get; set; }

    }
}
