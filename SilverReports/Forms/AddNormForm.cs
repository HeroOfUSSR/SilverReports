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

namespace SilverReports.Forms
{
    public partial class AddNormForm : Form
    {
        private Norm editNorm;

        public AddNormForm()
        {
            InitializeComponent();

            using (var db = new SilverREContext())
            {
                comboBoxDecimal.DataSource = db.DecimalNumber.ToList();
                comboBoxDepart.DataSource = db.Department.Where(x => x.IsAtWork_Department == true).ToList();
                comboBoxType.DataSource = db.SilverType.ToList();

                comboBoxDecimal.DisplayMember = nameof(DecimalNumber.Title_Decimal);
                comboBoxDepart.DisplayMember = nameof(Department.Code_Department);
                comboBoxType.DisplayMember = nameof(SilverType.Title_SilverType);
                comboBoxDecimal.ValueMember = nameof(DecimalNumber.ID_Decimal);
                comboBoxDepart.ValueMember = nameof(Department.Code_Department);
                comboBoxType.ValueMember = nameof(SilverType.Code_SilverType);

                comboBoxDecimal.SelectedValue = 0;
                comboBoxDepart.SelectedValue = 0;
                comboBoxType.SelectedValue = 0;

            }
        }

        public AddNormForm(Norm norm) : this()
        {
            Text = "Редактирование нормы";

            numericUpDownNorm.Value = norm.Title_Norm;
            comboBoxDecimal.SelectedItem = norm.Decimal_Norm;
            comboBoxDepart.SelectedItem = norm.Department_Norm;
            comboBoxType.SelectedItem = norm.SilverType_Norm;

            editNorm = norm;

            comboBoxDepart.Text = norm.Department_Norm.ToString();

            var index = comboBoxType.FindString(editNorm.SilverType_NormNavigation.Title_SilverType.ToString());

            comboBoxType.SelectedIndex = index;

            index = comboBoxDecimal.FindString(editNorm.Decimal_NormNavigation.Title_Decimal.ToString());

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

                if (comboBoxDepart.Text == "")
                {
                    MessageBox.Show("Цех не выбран");
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

                var decimalQuery = db.DecimalNumber.FirstOrDefault(x => x.Title_Decimal.ToLower().Trim() == comboBoxDecimal.Text.ToLower().Trim());

                if (decimalQuery == null)
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

                        var lastDecimal = db.DecimalNumber.OrderBy(x => x.ID_Decimal).ToList();
                        checkDecimal = lastDecimal.Last().ID_Decimal;
                    }
                    else return;   
                }
                else
                { 
                    checkDecimal = decimalQuery.ID_Decimal;
                }

                if (Text == "Редактирование нормы")
                {
                    editNorm = db.Norm.FirstOrDefault(x => x.ID_Norm == editNorm.ID_Norm);

                    editNorm.Title_Norm = numericUpDownNorm.Value;
                    editNorm.SilverType_Norm = ((SilverType)comboBoxType.SelectedItem).Code_SilverType;
                    editNorm.Decimal_Norm = checkDecimal;
                    editNorm.Department_Norm = Convert.ToInt32(comboBoxDepart.Text);


                    //db.Norm.Update(editNorm);
                    db.SaveChanges();

                    MessageBox.Show($"Успешное редактирование нормы");
                    this.Close();

                }
                else
                {
                    Norm norm = new Norm
                    {
                        Decimal_Norm = checkDecimal,
                        SilverType_Norm = ((SilverType)comboBoxType.SelectedItem).Code_SilverType,
                        Title_Norm = numericUpDownNorm.Value,
                        Department_Norm = Convert.ToInt32(comboBoxDepart.Text)
                    };


                    db.Norm.Add(norm);
                    db.SaveChanges();

                    MessageBox.Show("Успешное добавление");
                    this.Close();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
