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
using System.Windows.Forms.VisualStyles;

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

                comboBoxDepart.ValueMember = nameof(Department.Code_Department);
                comboBoxType.ValueMember = nameof(SilverType.Code_SilverType);
                comboBoxDecimal.ValueMember = nameof(DecimalNumber.ID_Decimal);

                comboBoxDecimal.SelectedValue = 0;
                comboBoxDepart.SelectedValue = 0;
                comboBoxType.SelectedValue = 0;

            }
        }

        public AddCheckForm(Check check) : this()
        {
            buttonAdd.Text = "Редактировать";
            Text = "Редактирование чека";

            maskedTextBoxNorm.Text = check.Norm_Check.ToString();
            textBoxNumber.Text = check.Number_Check;
            maskedTextBoxCover.Text = check.Coverage_Check.ToString();
            numericUpDownAmount.Value = Convert.ToDecimal(check.Amount_Check);
            textBoxOrder.Text = check.Order_Check;

            

            if (check.Date_Check != null)
            {
                dtCheck.Value = (DateTime)check.Date_Check;
            }
            //dtCheck.Value = check.Date_Check;

            editCheck = check;

            var index = comboBoxDepart.FindString(editCheck.Department_Check.ToString());

            comboBoxDepart.SelectedIndex = index;

            index = comboBoxType.FindString(editCheck.SilverType_Check.ToString());

            comboBoxType.SelectedIndex = index;

            index = comboBoxDecimal.FindString(editCheck.Decimal_Check.ToString());

            comboBoxDecimal.SelectedIndex = index;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                int checkDecimal;

                if (!db.DecimalNumber.Any(x => x.Title_Decimal.ToLower().Trim() == comboBoxDecimal.Text.ToLower().Trim()))
                {
                    var confirmAdd = MessageBox.Show("Децимальный номер не найден, добавить?", "Внимание", MessageBoxButtons.OKCancel);
                    if (confirmAdd == DialogResult.OK)
                    {
                        DecimalNumber newDecimal = new DecimalNumber
                        {
                            Title_Decimal = comboBoxDecimal.Text
                        };
                        db.DecimalNumber.Add(newDecimal);
                        db.SaveChanges();

                        var decimalQuery = db.DecimalNumber.OrderBy(x => x.ID_Decimal).ToList();
                        checkDecimal = decimalQuery.Last().ID_Decimal;
                    }
                    else return;
                }

                else return;

                if (Text == "Редактирование чека")
                {
                    editCheck.Norm_Check = Convert.ToDecimal(maskedTextBoxCover.Text);
                    editCheck.Order_Check = textBoxOrder.Text;
                    editCheck.Number_Check = textBoxNumber.Text;
                    editCheck.Decimal_Check = checkDecimal;
                    editCheck.Coverage_Check = Convert.ToDecimal(maskedTextBoxCover.Text);
                    editCheck.SilverType_Check = ((SilverType)comboBoxType.SelectedItem).Code_SilverType;
                    editCheck.Department_Check = ((Department)comboBoxDepart.SelectedItem).Code_Department;
                    editCheck.Amount_Check = Convert.ToInt32(numericUpDownAmount.Value);

                    //db.Check.Update(editCheck);
                    //db.Check.AddOrUpdate(editCheck);
                    db.SaveChanges();

                    MessageBox.Show($"Успешное редактирование чека №{editCheck.Number_Check}");

                }
                else
                {

                    Check newCheck = new Check
                    {
                        Date_Check = dtCheck.Value,
                        Department_Check = ((Department)comboBoxDepart.SelectedItem).Code_Department,
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
