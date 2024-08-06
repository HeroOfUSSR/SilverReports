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
            Text = "Редактирование дец номера";

            editDecimal = decimalNumber;

            textBoxDecimal.Text = editDecimal.Title_Decimal;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                if (textBoxDecimal.Text == "")
                {
                    MessageBox.Show("Введите значение");
                    return;
                }

                if (Text == "Редактирование дец номера")
                {
                    editDecimal = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == editDecimal.ID_Decimal);
                    editDecimal.Title_Decimal = textBoxDecimal.Text;

                    //db.DecimalNumber.Update(editDecimal);
                    MessageBox.Show("Децимальный номер изменён");
                    db.SaveChanges();
                }
                else
                {
                    if (db.DecimalNumber.Any(x => x.Title_Decimal == textBoxDecimal.Text))
                    {
                        MessageBox.Show("Указанный децимальный номер уже существует");
                        return;
                    }

                    DecimalNumber newDecimal = new DecimalNumber
                    {
                        Title_Decimal = textBoxDecimal.Text,
                    };

                    MessageBox.Show("Децимальный номер добавлен");

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
