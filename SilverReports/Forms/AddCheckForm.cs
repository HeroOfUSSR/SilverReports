using SilverReports.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilverReports.Forms
{
    public partial class AddCheckForm : Form
    {
        private Check editCheck;

        public AddCheckForm()
        {
            InitializeComponent();

            using (var db = new SilverREContext())
            {
                comboBoxDepart.DataSource = db.Department.Where(x => x.IsAtWork_Department == true).ToList();
                comboBoxType.DataSource = db.SilverType.ToList();
                comboBoxDecimal.DataSource = db.DecimalNumber.ToList();

                comboBoxDepart.DisplayMember = nameof(Department.Code_Department);
                comboBoxType.DisplayMember = nameof(SilverType.Title_SilverType);
                comboBoxDecimal.DisplayMember = nameof(DecimalNumber.Title_Decimal);

            }
        }

        public AddCheckForm(Check check) : this()
        {
            buttonAdd.Text = "Редактировать";
            Text = "Редактирование чека";

            maskedTextBoxCover.Text = check.Norm_Check.ToString();
            textBoxNumber.Text = check.Number_Check;
            comboBoxDepart.SelectedItem = check.Department_Check;
            comboBoxType.Text = check.SilverType_Check.ToString();
            comboBoxDecimal.SelectedItem = check.Decimal_Check;
            maskedTextBoxCover.Text = check.Coverage_Check.ToString();
            numericUpDownAmount.Value = Convert.ToDecimal(check.Amount_Check);
            textBoxOrder.Text = check.Order_Check;
            //dtCheck.Value = check.Date_Check;

            editCheck = check;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                if (Text == "Редактирование чека")
                {
                    editCheck.Norm_Check = Convert.ToDecimal(maskedTextBoxCover.Text);
                    editCheck.Order_Check = textBoxOrder.Text;
                    editCheck.Number_Check = textBoxNumber.Text;
                    editCheck.Decimal_Check = ((DecimalNumber)comboBoxDecimal.SelectedItem).ID_Decimal;
                    editCheck.Coverage_Check = Convert.ToDecimal(maskedTextBoxCover.Text);
                    editCheck.SilverType_Check = ((SilverType)comboBoxType.SelectedItem).Code_SilverType;
                    editCheck.Department_Check = Convert.ToInt32(comboBoxDepart.SelectedItem);
                    editCheck.Amount_Check = Convert.ToInt32(numericUpDownAmount.Value);

                    //db.Check.Update(editCheck);
                    //db.Check.AddOrUpdate(editCheck);
                    db.SaveChanges();

                    MessageBox.Show($"Успешное редактирование чека №{editCheck.Number_Check}");

                }
                else
                {
                    int checkDecimal;

                    if (!db.DecimalNumber.Any(x => x.Title_Decimal.ToLower().Trim() == comboBoxDecimal.Text.ToLower().Trim()))
                    {
                        DecimalNumber newDecimal = new DecimalNumber
                        {
                            Title_Decimal = comboBoxDecimal.Text
                        };
                        db.DecimalNumber.Add(newDecimal);
                        db.SaveChanges();

                        checkDecimal = db.DecimalNumber.OrderBy(x => x.ID_Decimal).Last().ID_Decimal;
                    }
                    else
                    {
                        checkDecimal = ((DecimalNumber)comboBoxDecimal.SelectedItem).ID_Decimal;
                    }

                    Check newCheck = new Check
                    {
                        Date_Check = dtCheck.Value,
                        Department_Check = Convert.ToInt32(comboBoxDepart.SelectedItem),
                        Number_Check = textBoxNumber.Text,
                        Norm_Check = Convert.ToDecimal(maskedTextBoxCover.Text),
                        SilverType_Check = ((SilverType)comboBoxType.SelectedItem).Code_SilverType,
                        Coverage_Check = Convert.ToDecimal(maskedTextBoxCover.Text),
                        Amount_Check = Convert.ToInt32(numericUpDownAmount.Value),
                        Decimal_Check = checkDecimal,
                        Order_Check = textBoxOrder.Text
                    };

                    db.Check.Add(newCheck);
                    db.SaveChanges();

                    MessageBox.Show("Успешное добавление");

                    this.Close();
                }
            }
        }

        private void maskedTextBoxNorm_KeyDown(object sender, KeyEventArgs e)
        {
            char digit = Convert.ToChar(e.KeyCode);

            if (!Char.IsDigit(digit) || e.KeyCode == Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            char digit = Convert.ToChar(e.KeyCode);

            if (!Char.IsDigit(digit) || e.KeyCode == Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void maskedTextBoxCover_KeyDown(object sender, KeyEventArgs e)
        {
            char digit = Convert.ToChar(e.KeyCode);

            if (!Char.IsDigit(digit) || e.KeyCode == Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
