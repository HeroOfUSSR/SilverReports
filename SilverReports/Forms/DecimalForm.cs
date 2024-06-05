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
    public partial class DecimalForm : Form
    {
        public DecimalForm()
        {
            InitializeComponent();
            InitDatagrid();
        }



        public void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                dgvDict.DataSource = db.DecimalNumber.ToList();

                dgvDict.Columns["ID_Decimal"].HeaderText = "Идентификатор номера";
                dgvDict.Columns["Title_Decimal"].HeaderText = "Децимальный номер";
                dgvDict.Columns["Checks"].Visible = false;
                dgvDict.Columns["Norms"].Visible = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addDecimal = new AddDecimalForm();
            addDecimal.ShowDialog();

            if (addDecimal.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Успешное добавление");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvDict.Rows[dgvDict.SelectedRows[0].Index].Cells[0].Value);
                var editDecimal = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == selected);

                AddDecimalForm editDecimalForm = new AddDecimalForm(editDecimal);


                if (editDecimalForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Децимальный номер успешно изменён");
                    InitDatagrid();
                }

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvDict.Rows[dgvDict.SelectedRows[0].Index].Cells[0].Value);
                var deleteDecimal = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == selected);

                var deleteDialog = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание!", MessageBoxButtons.OKCancel);

                if (deleteDialog == DialogResult.OK)
                {
                    db.DecimalNumber.Remove(deleteDecimal);
                    MessageBox.Show("Децимальный номер успешно изменён");
                    InitDatagrid();
                }

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                if (textBoxSearch.Text != "")
                {

                    dgvDict.DataSource = db.DecimalNumber.Where(x => x.Title_Decimal.Contains(textBoxSearch.Text)).ToList();

                }
                else
                {
                    InitDatagrid();
                }
            }
        }
    }
}
