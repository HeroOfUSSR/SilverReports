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
    public partial class NormForm : Form
    {
        public NormForm()
        {
            InitializeComponent();
            InitDatagrid();
        }

        private void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                var result = from norm in db.Norm
                             .Where(x => x.Decimal_NormNavigation.Title_Decimal.Contains(textBoxSearch.Text)
                             || textBoxSearch.Text == "")
                             select new
                             {
                                 ID_Norm = norm.ID_Norm,
                                 Title_Norm = norm.Title_Norm,
                                 SilverType_Norm = db.SilverType.FirstOrDefault(x => x.Code_SilverType == norm.SilverType_Norm).Title_SilverType,
                                 Decimal_Norm = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == norm.Decimal_Norm).Title_Decimal,
                                 Department_Norm = db.Department.FirstOrDefault(x => x.Code_Department == norm.Department_Norm).Code_Department,
                             };

                if (result.Any())
                {
                    dgvNorm.DataSource = result.ToList();

                    dgvNorm.Columns["ID_Norm"].HeaderText = "Идентификатор нормы";
                    dgvNorm.Columns["ID_Norm"].Visible = false;

                    dgvNorm.Columns["Title_Norm"].HeaderText = "Норма";
                    dgvNorm.Columns["SilverType_Norm"].HeaderText = "Тип серебра";
                    dgvNorm.Columns["Decimal_Norm"].HeaderText = "Децимальный номер";
                    dgvNorm.Columns["Department_Norm"].HeaderText = "Цех";
                }
                else
                {
                    MessageBox.Show("Не найдено ни одной записи");
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNormForm addNorm = new AddNormForm();
            addNorm.ShowDialog();
            if (addNorm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Успешное добавление нормы");
                InitDatagrid();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvNorm.Rows[dgvNorm.SelectedRows[0].Index].Cells[0].Value);
                var editNorm = db.Norm.FirstOrDefault(x => x.ID_Norm == selected);

                if (editNorm != null)
                {
                    var editForm = new AddNormForm(editNorm);
                    editForm.ShowDialog();
                    if (editForm.DialogResult == DialogResult.OK)
                    {
                        InitDatagrid();
                    }
                }
                else MessageBox.Show("Выберите норму для редактирования");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvNorm.Rows[dgvNorm.SelectedRows[0].Index].Cells[0].Value);

                var deleteNorm = db.Norm.FirstOrDefault(x => x.ID_Norm == selected);

                if (deleteNorm != null)
                {
                    DialogResult confirm;


                    confirm = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание!", MessageBoxButtons.OKCancel);


                    if (confirm == DialogResult.OK)
                    {
                        db.Norm.Remove(deleteNorm);
                        db.SaveChanges();

                        InitDatagrid();
                    }
                }
                else MessageBox.Show("Выберите запись для удаления");

            }
        }
    }
}
