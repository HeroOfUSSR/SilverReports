using SilverReports.Context;
using SilverReports.Models;
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
        private string searchQuery = "";

        private bool noSearchResults = false;

        public NormForm()
        {
            InitializeComponent();
            InitDatagrid();

            dgvNorm.AutoResizeColumns();
            dgvNorm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                var result = from norm in db.Norm
                             .Where(x => x.Decimal_NormNavigation.Title_Decimal.Contains(searchQuery)
                             || searchQuery == ""
                             || searchQuery == "Введите запрос")
                             select new NormResponse
                             {
                                 ID_Norm = norm.ID_Norm,
                                 Decimal_Norm = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == norm.Decimal_Norm).Title_Decimal,
                                 Title_Norm = norm.Title_Norm,
                                 SilverType_Norm = db.SilverType.FirstOrDefault(x => x.Code_SilverType == norm.SilverType_Norm).Title_SilverType,
                                 Department_Norm = norm.Department_Norm,
                             };

                if (result.Any())
                {
                    var normResult = new SortableBindingList<NormResponse>(result);

                    dgvNorm.DataSource = normResult;

                    dgvNorm.Columns["ID_Norm"].Visible = false;

                    dgvNorm.Columns["Decimal_Norm"].HeaderText = "Децимальный номер";
                    dgvNorm.Columns["Title_Norm"].HeaderText = "Норма";
                    dgvNorm.Columns["SilverType_Norm"].HeaderText = "Тип серебра";
                    dgvNorm.Columns["Department_Norm"].HeaderText = "Цех";

                    noSearchResults = false;
                }
                else
                {
                    noSearchResults = true;
                }
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNormForm addNorm = new AddNormForm();
            addNorm.ShowDialog();

            InitDatagrid();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                int firstRowIndex = dgvNorm.FirstDisplayedCell.RowIndex;
                var selected = Convert.ToInt32(dgvNorm.Rows[dgvNorm.SelectedRows[0].Index].Cells[0].Value);
                var editNorm = db.Norm.Include("Decimal_NormNavigation")
                    .Include("SilverType_NormNavigation")
                    .FirstOrDefault(x => x.ID_Norm == selected);

                if (editNorm != null)
                {
                    var editForm = new AddNormForm(editNorm);
                    editForm.ShowDialog();

                    InitDatagrid();
                    dgvNorm.FirstDisplayedScrollingRowIndex = firstRowIndex;

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
                        int firstRowIndex = dgvNorm.FirstDisplayedCell.RowIndex;
                        db.Norm.Remove(deleteNorm);
                        db.SaveChanges();

                        textBoxSearch.Text = "";
                        InitDatagrid();
                        dgvNorm.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    }
                }
                else MessageBox.Show("Выберите запись для удаления");

            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals("Введите запрос"))
            {
                textBoxSearch.Text = string.Empty;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(string.Empty))
            {
                textBoxSearch.Text = "Введите запрос";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (textBoxSearch.Text == "Введите запрос")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }

            searchQuery = textBoxSearch.Text;

            InitDatagrid();

            if (noSearchResults)
            {
                MessageBox.Show("Не найдено ни одной записи");
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                searchQuery = textBoxSearch.Text;

                InitDatagrid();
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
