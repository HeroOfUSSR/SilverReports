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
            buttonAdd.Text = "Редактировать";
            Text = "Редактирование нормы";

            maskedTextBoxNorm.Text = norm.Title_Norm.ToString();
            comboBoxDecimal.SelectedItem = norm.Decimal_Norm;
            comboBoxDepart.SelectedItem = norm.Department_Norm;
            comboBoxType.SelectedItem = norm.SilverType_Norm;

            editNorm = norm;
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
                else
                {
                    checkDecimal = ((DecimalNumber)comboBoxDecimal.SelectedItem).ID_Decimal;
                }

                if (Text == "Редактирование нормы")
                {
                    editNorm.Title_Norm = Convert.ToDecimal(maskedTextBoxNorm.Text);
                    editNorm.SilverType_Norm = ((SilverType)comboBoxType.SelectedItem).Code_SilverType;
                    editNorm.Decimal_Norm = checkDecimal;
                    editNorm.Department_Norm = ((Department)comboBoxDepart.SelectedItem).Code_Department;


                    //db.Norm.Update(editNorm);
                    db.SaveChanges();

                    MessageBox.Show($"Успешное редактирование нормы №{editNorm.ID_Norm}");

                }
                else
                {
                    Norm norm = new Norm
                    {
                        Decimal_Norm = checkDecimal,
                        SilverType_Norm = ((SilverType)comboBoxType.SelectedItem).Code_SilverType,
                        Title_Norm = Convert.ToDecimal(maskedTextBoxNorm.Text),
                        Department_Norm = ((Department)comboBoxDepart.SelectedItem).Code_Department
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
