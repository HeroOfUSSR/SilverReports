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
            buttonAdd.Text = "Изменить";
            Text = "Редактирование чека";

            if (check.Norm_Check != null)
            {
                numericUpDownNorm.Value = Convert.ToDecimal(check.Norm_Check);
            }
            textBoxNumber.Text = check.Number_Check;
            numericUpDownCoverage.Value = check.Coverage_Check;
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

            index = comboBoxType.FindString(editCheck.SilverType_CheckNavigation.Title_SilverType.ToString());

            comboBoxType.SelectedIndex = index;

            index = comboBoxDecimal.FindString(editCheck.Decimal_CheckNavigation.Title_Decimal.ToString());

            comboBoxDecimal.SelectedIndex = index;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            using (var db = new SilverREContext())
            {
                if (comboBoxType.SelectedItem == null)
                {
                    MessageBox.Show("Выберите вид серебра");
                    return;
                }

                if (comboBoxDecimal.Text == "")
                {
                    MessageBox.Show("Введите децимальный номер");
                    return;
                }

                var department = Convert.ToInt32(comboBoxDepart.Text);

                var isDepartment = db.Department.FirstOrDefault(x => x.Code_Department == department);

                if (isDepartment == null)
                {
                    MessageBox.Show("Введён некорректный цех");
                    return;
                }

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
                    else
                    {
                        MessageBox.Show("Добавление чека отменено");
                        return;
                    }
                }
                else
                {
                    checkDecimal = ((DecimalNumber)comboBoxDecimal.SelectedItem).ID_Decimal;

                }

                if (Text == "Редактирование чека")
                {
                    editCheck = db.Check.FirstOrDefault(x => x.ID_Check == editCheck.ID_Check);

                    editCheck.Norm_Check = numericUpDownNorm.Value;
                    editCheck.Order_Check = textBoxOrder.Text;
                    editCheck.Number_Check = textBoxNumber.Text;
                    editCheck.Decimal_Check = checkDecimal;
                    editCheck.Coverage_Check = numericUpDownCoverage.Value;
                    editCheck.SilverType_Check = ((SilverType)comboBoxType.SelectedItem).Code_SilverType;
                    editCheck.Department_Check = department;
                    editCheck.Amount_Check = Convert.ToInt32(numericUpDownAmount.Value);

                    //db.Check.Update(editCheck)
                    db.SaveChanges();

                    MessageBox.Show($"Успешное редактирование чека №{editCheck.Number_Check}");
                    this.Close();

                }
                else
                {

                    Check newCheck = new Check
                    {
                        Date_Check = dtCheck.Value,
                        Department_Check = department,
                        Number_Check = textBoxNumber.Text,
                        Norm_Check = numericUpDownNorm.Value,
                        SilverType_Check = ((SilverType)comboBoxType.SelectedItem).Code_SilverType,
                        Coverage_Check = numericUpDownCoverage.Value,
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
