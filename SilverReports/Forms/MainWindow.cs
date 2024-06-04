using SilverReports.Context;
using SilverReports.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilverReports
{
    public partial class MainWindow : Form
    {
        private string searchRequest;
        public enum ReportsType { byOrderSilver, byOrderCover, byDepartment }

        public MainWindow()
        {
            InitializeComponent();
            InitDatagrid();
        }

        public void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                var result = from check in db.Check
                             .Where(x => x.Number_Check.Contains(textBoxSearch.Text)
                                || x.Decimal_CheckNavigation.Title_Decimal.Contains(textBoxSearch.Text)
                                || textBoxSearch.Text == "")
                             select new
                             {
                                 ID_Check = check.ID_Check,
                                 Number_Check = check.Number_Check,
                                 Date_Check = check.Date_Check,
                                 Department_Check = check.Department_Check,
                                 Norm_Check = check.Norm_Check,
                                 SilverType_Check = db.SilverType.FirstOrDefault(x => x.Code_SilverType == check.SilverType_Check).Title_SilverType,
                                 Coverage_Check = check.Coverage_Check,
                                 Amount_Check = check.Amount_Check,
                                 Decimal_Check = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == check.Decimal_Check).Title_Decimal,
                                 Order_Check = check.Order_Check,
                             };

                if (result != null)
                {
                    dgvSilver.DataSource = result.ToList();

                    dgvSilver.Columns["ID_Check"].HeaderText = "Идентификатор чека";
                    dgvSilver.Columns["ID_Check"].Visible = false;

                    dgvSilver.Columns["Number_Check"].HeaderText = "Номер чека";
                    dgvSilver.Columns["Date_Check"].HeaderText = "Дата чека";
                    dgvSilver.Columns["Date_Check"].SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvSilver.Columns["Department_Check"].HeaderText = "Номер цеха";
                    dgvSilver.Columns["Norm_Check"].HeaderText = "Норма серебра";
                    dgvSilver.Columns["SilverType_Check"].HeaderText = "Вид серебра";
                    dgvSilver.Columns["Coverage_Check"].HeaderText = "Площадь покрытия";
                    dgvSilver.Columns["Amount_Check"].HeaderText = "Количество";
                    dgvSilver.Columns["Decimal_Check"].HeaderText = "Децимальный номер";
                    dgvSilver.Columns["Order_Check"].HeaderText = "Номер заказа";
                }

                else
                {
                    MessageBox.Show("Не найдено ни одной записи");
                }

                

            }
        }

        private void buttonIncorrect_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var checks = db.Check.OrderBy(x => x.ID_Check).ToList();

                foreach (DataGridViewRow row in dgvSilver.Rows)
                {
                    var correctNorm = db.Norm.FirstOrDefault(x => x.Decimal_NormNavigation.Title_Decimal == row.Cells[8].Value.ToString());

                    if (correctNorm != null)
                        if (correctNorm.Title_Norm.ToString() != row.Cells[4].Value.ToString()
                            || correctNorm.SilverType_Norm.ToString() != row.Cells[5].Value.ToString()) // Тут надо позор с ToString как то переделать
                            dgvSilver.Rows[row.Index].DefaultCellStyle.BackColor = Color.IndianRed; // P.S. Decimal.Compare не работает, потому что nullable в моделях
                }
            }
        }

        private void buttonNorm_Click(object sender, EventArgs e)
        {
            var normForm = new NormForm();
            normForm.Show();
        }

        private void buttonDictionary_Click(object sender, EventArgs e)
        {
            var dictDec = new DecimalForm();
            dictDec.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addCheck = new AddCheckForm();
            addCheck.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvSilver.Rows[dgvSilver.SelectedRows[0].Index].Cells[0].Value);
                var editCheck = db.Check.FirstOrDefault(x => x.ID_Check == selected);

                if (editCheck != null)
                {
                    var editForm = new AddCheckForm(editCheck);
                    editForm.ShowDialog();
                    if (editForm.DialogResult == DialogResult.OK)
                    {
                        InitDatagrid();
                    }
                }
                else MessageBox.Show("Выберите чек для редактирования");
            }

 
        }

        private void обсчётСеребраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager silverReport = new ReportManager(ReportsType.byOrderSilver);
            silverReport.Show();
        }

        private void обсчётПлощадиСеребренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager coverReport = new ReportManager(ReportsType.byOrderCover);
            coverReport.Show();
        }

        private void поЦехуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager departmentReport = new ReportManager(ReportsType.byDepartment);
            departmentReport.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvSilver.Rows[dgvSilver.SelectedRows[0].Index].Cells[0].Value);

                var deleteCheck = db.Check.FirstOrDefault(x => x.ID_Check == selected);

                if (deleteCheck != null)
                {
                    DialogResult confirm = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание!", MessageBoxButtons.OKCancel);

                    if (confirm == DialogResult.OK)
                    {
                        db.Check.Remove(deleteCheck);
                        db.SaveChanges();

                        InitDatagrid();
                    }
                }
                else MessageBox.Show("Выберите запись для удаления");

            }
        }
    }
}
