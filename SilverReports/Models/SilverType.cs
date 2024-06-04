using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverReports.Context
{
    public partial class SilverType
    {

        public int Code_SilverType { get; set; }

        [DisplayName("Вид серебра")]
        [Required]
        public string Title_SilverType { get; set; }

        public virtual ICollection<Check> Checks { get; set; }

        public virtual ICollection<Norm> Norms { get; set; }

    }
}
