using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverReports.Context
{
    public partial class Check
    {
        [DisplayName("Номер чека")]
        public int ID_Check { get; set; }

        public string Number_Check { get; set; }


        [DisplayName("Дата создания чека ")]
        public DateTime Date_Check { get; set; }


        [DisplayName("Номер цеха")]
        public int Department_Check { get; set; }
        public Department Department_CheckNavigation { get; set; }


        [DisplayName("Норма Серебра")]
        public decimal? Norm_Check { get; set; }

        [DisplayName("Вид серебра")]
        public int SilverType_Check { get; set; }
        public SilverType SilverType_CheckNavigation { get; set; }


        [DisplayName("Площадь покрытия")]
        public decimal Coverage_Check { get; set; }


        [DisplayName("Количество")]
        public int Amount_Check { get; set; }


        [DisplayName("Децимальный номер")]
        public int Decimal_Check { get; set; }
        public DecimalNumber Decimal_CheckNavigation { get; set; }


        [DisplayName("Номер заказа")]
        public string Order_Check { get; set; } = string.Empty;

    }
}
