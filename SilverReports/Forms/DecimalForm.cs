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

namespace SilverReports.Forms
{
    public partial class DecimalForm : Form
    {
        private bool noSearchResults = false;
        public DecimalForm()
        {
            InitializeComponent();
            InitDatagrid();
        }

        public void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                dgvDict.AutoResizeColumns();
                dgvDict.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                var result = from decnum in db.DecimalNumber
                             .Where(x => x.Title_Decimal.Contains(textBoxSearch.Text)
                                || textBoxSearch.Text == ""
                                || textBoxSearch.Text == MainWindow.placeholderSearch)
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

                var deleteDialog = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание!", MessageBoxButtons.OKCancel);

                if (deleteDialog == DialogResult.OK)
                {
                    db.DecimalNumber.Remove(deleteDecimal);
                    db.SaveChanges();

                    MessageBox.Show("Децимальный номер удалён");
                    InitDatagrid();
                }

            } 
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            InitDatagrid();

            if (noSearchResults)
            {
                MessageBox.Show("Записи не найдены");
            }
        }

        private void перезагрузитьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitDatagrid();
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(MainWindow.placeholderSearch))
            {
                textBoxSearch.Text = string.Empty;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(string.Empty))
            {
                textBoxSearch.Text = MainWindow.placeholderSearch;
            }
        }
    }
}
