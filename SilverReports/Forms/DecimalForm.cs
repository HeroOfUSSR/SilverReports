using SilverReports.Context;
using SilverReports.ModelResponse;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SilverReports.Forms
{
    public partial class DecimalForm : Form
    {
        private string searchQuery = "";

        private bool noSearchResults = false;

        private IQueryable<DecimalNumber> decimalQuery;

        public DecimalForm()
        {
            InitializeComponent();
            InitDatagrid();

            
        }

        public void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                decimalQuery = db.DecimalNumber.OrderBy(x => x.Title_Decimal);

                var result = from decnum in decimalQuery
                             .Where(x => x.Title_Decimal.Contains(searchQuery)
                                || searchQuery == ""
                                || searchQuery == "Введите запрос")
                             select new DecimalNumberResponse
                             {
                                 ID_Decimal = decnum.ID_Decimal,
                                 Title_Decimal = decnum.Title_Decimal,
                             };

                if (result.Any())
                {
                    var decimalResult = new SortableBindingList<DecimalNumberResponse>(result);

                    dgvDict.DataSource = decimalResult;

                    noSearchResults = false;

                }
                else
                {
                    noSearchResults = true;
                }

                dgvDict.Columns["ID_Decimal"].HeaderText = "Идентификатор";
                dgvDict.Columns["ID_Decimal"].Visible = false;

                dgvDict.Columns["Title_Decimal"].HeaderText = "Децимальный номер";

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addDecimal = new AddDecimalForm();
            addDecimal.ShowDialog();

            
            InitDatagrid();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvDict.Rows[dgvDict.SelectedRows[0].Index].Cells[0].Value);
                var editDecimal = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == selected);

                if (editDecimal == null)
                {
                    MessageBox.Show("Не выбрана запись для редактирования");
                    return;
                }

                AddDecimalForm editDecimalForm = new AddDecimalForm(editDecimal);
                editDecimalForm.ShowDialog();

                InitDatagrid();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvDict.Rows[dgvDict.SelectedRows[0].Index].Cells[0].Value);
                var deleteDecimal = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == selected);

                if (deleteDecimal == null)
                {
                    MessageBox.Show("Не выбрана запись для удаления");
                    return;
                }

                if (db.Check.Any(x => x.Decimal_Check == deleteDecimal.ID_Decimal))
                {
                    MessageBox.Show("Невозможно удалить децимальный номер, так как с ним существует чек");
                    return;
                }

                if (db.Norm.Any(x => x.Decimal_Norm == deleteDecimal.ID_Decimal))
                {
                    MessageBox.Show("Невозможно удалить децимальный номер, так как с ним существует норма");
                    return;
                }

                var deleteDialog = MessageBox.Show($"Вы уверены, что хотите удалить дец. номер: {deleteDecimal.Title_Decimal}?", "Внимание!", MessageBoxButtons.OKCancel);

                if (deleteDialog == DialogResult.OK)
                {
                    db.DecimalNumber.Remove(deleteDecimal);
                    db.SaveChanges();

                    MessageBox.Show("Децимальный номер удалён");

                    textBoxSearch.Text = "";

                    InitDatagrid();
                }

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

        private void перезагрузитьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDatagrid();
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

        private void dgvDict_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvDict.Rows[dgvDict.SelectedRows[0].Index].Cells[0].Value);
                var editDecimal = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == selected);

                if (editDecimal == null)
                {
                    MessageBox.Show("Не выбрана запись для редактирования");
                    return;
                }

                AddDecimalForm editDecimalForm = new AddDecimalForm(editDecimal);
                editDecimalForm.ShowDialog();

                InitDatagrid();

            }
        }

        private void DecimalForm_Load(object sender, EventArgs e)
        {
            dgvDict.AutoResizeColumns();
            dgvDict.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
