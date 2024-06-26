﻿using SilverReports.Context;
using SilverReports.Forms;
using SilverReports.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure.Interception;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SilverReports
{
    public partial class MainWindow : Form
    {
        public enum ReportsType { byOrderSilver, byOrderCover, byDepartment }

        private string placeholderSearch = "Введите запрос";

        private string searchQuery = "";

        private bool noSearchResults = false;

        private IQueryable<Check> check;

        private int selectedYear;

        private SortableBindingList<CheckResponse> checkResult;

        public MainWindow()
        {

            InitializeComponent();
            InitDatagrid();

            dgvSilver.AutoResizeColumns();
            dgvSilver.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;        
        }

        public void InitDatagrid()
        {
            using (var db = new SilverREContext())
            {
                check = db.Check.OrderByDescending(x => x.Date_Check);

                switch (selectedYear)
                {
                    case 2023:
                        check = check.Where(x => x.Date_Check.Year == 2023);

                        if (check == null)
                        {
                            MessageBox.Show("Записи не найдены");
                        }

                        break;
                    case 2024:
                        check = check.Where(x => x.Date_Check.Year == 2024);

                        if (check == null)
                        {
                            MessageBox.Show("Записи не найдены");
                        }

                        break;
                    case 2025:
                        check = check.Where(x => x.Date_Check.Year == 2025);

                        if (check == null)
                        {
                            MessageBox.Show("Записи не найдены");
                        }

                        break;
                    default:
                        break;
                }

                var result = from check in check
                             .Where(x => x.SilverType_CheckNavigation.Title_SilverType.Contains(searchQuery)
                                || x.Decimal_CheckNavigation.Title_Decimal.Contains(searchQuery)
                                || x.Number_Check.Contains(searchQuery)
                                || x.Order_Check.Contains(searchQuery)
                                || searchQuery == ""
                                || searchQuery == placeholderSearch).AsEnumerable()
                             select new CheckResponse
                             {
                                 ID_Check = check.ID_Check,
                                 Date_Check = check.Date_Check.Date,//.ToString("d"),
                                 Department_Check = check.Department_Check,
                                 Order_Check = check.Order_Check,
                                 Decimal_Check = db.DecimalNumber.FirstOrDefault(x => x.ID_Decimal == check.Decimal_Check).Title_Decimal,
                                 Amount_Check = check.Amount_Check,
                                 Norm_Check = check.Norm_Check,
                                 SilverType_Check = db.SilverType.FirstOrDefault(x => x.Code_SilverType == check.SilverType_Check).Title_SilverType,
                                 Number_Check = check.Number_Check,
                                 Coverage_Check = check.Coverage_Check,
                             };

                if (result.Any())
                {
                    checkResult = new SortableBindingList<CheckResponse>(result);

                    dgvSilver.DataSource = checkResult;

                    dgvSilver.Columns["ID_Check"].HeaderText = "Идентификатор";
                    dgvSilver.Columns["ID_Check"].Visible = false;

                    dgvSilver.Columns["Number_Check"].HeaderText = "Номер чека";
                    dgvSilver.Columns["Date_Check"].HeaderText = "Дата чека";
                    dgvSilver.Columns["Department_Check"].HeaderText = "Номер цеха";
                    dgvSilver.Columns["Norm_Check"].HeaderText = "Норма серебра";
                    dgvSilver.Columns["SilverType_Check"].HeaderText = "Вид серебра";
                    dgvSilver.Columns["Coverage_Check"].HeaderText = "Площадь покрытия";
                    dgvSilver.Columns["Amount_Check"].HeaderText = "Количество";
                    dgvSilver.Columns["Decimal_Check"].HeaderText = "Децимальный номер";
                    dgvSilver.Columns["Order_Check"].HeaderText = "Номер заказа";

                    noSearchResults = false;
                }
                else
                {
                    noSearchResults = true;
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

            InitDatagrid();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var selected = Convert.ToInt32(dgvSilver.Rows[dgvSilver.SelectedRows[0].Index].Cells[0].Value);
                var editCheck = db.Check.Include("Decimal_CheckNavigation")
                    .Include("SilverType_CheckNavigation")
                    .FirstOrDefault(x => x.ID_Check == selected);

                if (editCheck != null)
                {
                    var editForm = new AddCheckForm(editCheck);
                    editForm.ShowDialog();

                    InitDatagrid();

                }
                else MessageBox.Show("Выберите чек для редактирования");
            }
        }

        private void countSilverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager silverReport = new ReportManager(ReportsType.byOrderSilver);
            silverReport.Show();
        }

        private void countCoverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager coverReport = new ReportManager(ReportsType.byOrderCover);
            coverReport.Show();
        }

        private void byDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager departmentReport = new ReportManager(ReportsType.byDepartment);
            departmentReport.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var allSelected = dgvSilver.SelectedRows;

                if (allSelected != null)
                {
                    DialogResult confirm = MessageBox.Show("Вы уверены, что хотите удалить выделенные записи?", "Внимание!", MessageBoxButtons.OKCancel);

                    if (confirm == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in allSelected)
                        {
                            var selected = Convert.ToInt32(row.Cells[0].Value);

                            var deleteCheck = db.Check.FirstOrDefault(x => x.ID_Check == selected);

                            db.Check.Remove(deleteCheck);
                            db.SaveChanges();
                        }

                        textBoxSearch.Text = "";
                        InitDatagrid();
                    }
                }
                else MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (textBoxSearch.Text == placeholderSearch)
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

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(placeholderSearch))
            {
                textBoxSearch.Text = string.Empty;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(string.Empty))
            {
                textBoxSearch.Text = placeholderSearch;
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new SilverREContext())
            {
                var checks = db.Check.OrderBy(x => x.ID_Check).ToList();

                foreach (DataGridViewRow row in dgvSilver.Rows)
                {
                    string stringComparing = row.Cells[4].Value.ToString();
                    var correctNorm = db.Norm.FirstOrDefault(x => x.Decimal_NormNavigation.Title_Decimal == stringComparing);

                    string silverComparing = row.Cells[7].Value.ToString();
                    var rowSilver = db.SilverType.FirstOrDefault(x => x.Title_SilverType == silverComparing);
                    if (correctNorm != null)
                        if (correctNorm.Title_Norm.ToString() != row.Cells[6].Value.ToString()
                            || correctNorm.SilverType_Norm != rowSilver.Code_SilverType)
                            dgvSilver.Rows[row.Index].DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")//|| textBoxSearch.Text == placeholderSearch)
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            selectedYear = 2023;
            InitDatagrid();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            selectedYear = 2024;
            InitDatagrid();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            selectedYear = 2025;
            InitDatagrid();
        }

        private void everyYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedYear = 0;
            InitDatagrid();
        }
    }
}
