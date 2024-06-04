using SilverReports.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SilverReports.Forms
{
    public partial class AddDecimalForm : Form
    {
        private DecimalNumber editDecimal;
        public AddDecimalForm()
        {
            InitializeComponent();
        }
        public AddDecimalForm(DecimalNumber decimalNumber) : this() 
        {
            Text = "Редактирование";
            buttonAdd.Text = "Изменить";

            editDecimal = decimalNumber;

            textBoxDecimal.Text = editDecimal.Title_Decimal;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                if (buttonAdd.Text == "Изменить")
                {
                    editDecimal.Title_Decimal = textBoxDecimal.Text;

                    //db.DecimalNumber.Update(editDecimal);
                    db.SaveChanges();
                }
                else
                {
                    DecimalNumber newDecimal = new DecimalNumber
                    {
                        Title_Decimal = textBoxDecimal.Text,
                    };

                    db.DecimalNumber.Add(newDecimal);
                    db.SaveChanges();
                }


                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
