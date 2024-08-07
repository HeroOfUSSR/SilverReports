using SilverReports.Context;
using SilverReports.Forms;
using SilverReports.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
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
        public enum FilterType { year, month, week, day, custom, nope }

        FilterType current = FilterType.nope;

        private string searchQuery = "";

        private bool noSearchResults = false;

        private IQueryable<Check> check;

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

                switch (current)
                {
                    case FilterType.year:

                        check = check.Where(x => x.Date_Check.Year == DateTime.Now.Year);

                        break;
                    case FilterType.month:

                        check = check.Where(x => x.Date_Check.Month == DateTime.Now.Month && x.Date_Check.Year == DateTime.Now.Year);

                        break;
                    case FilterType.week:

                        var dateValue = DateTime.Today;
                        var culture = CultureInfo.CurrentCulture;
                        var weekOffset = culture.DateTimeFormat.FirstDayOfWeek - dateValue.DayOfWeek;
                        var startOfWeek = dateValue.AddDays(weekOffset);

                        var weekDays = Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i));
                            
                        check = check.Where(x => x.Date_Check >= weekDays.Min() &&
                            x.Date_Check <= weekDays.Max());

                        break;
                    case FilterType.day:

                        check = check.Where(x => x.Date_Check == DateTime.Now);

                        break;
                    case FilterType.custom:

                        check = check.Where(x => x.Date_Check >= dtFrom.Value && x.Date_Check <= dtUntil.Value);

                        break;
                    default:
                        
                        break;
                }

                var result = from check in check
                             .Where(x => x.SilverType_CheckNavigation.Title_SilverType.Contains(searchQuery)
                                || x.Decimal_CheckNavigation.Title_Decimal.Replace(".", "").Contains(searchQuery)
                                || x.Number_Check.Contains(searchQuery)
                                || x.Order_Check.Contains(searchQuery)
                                || searchQuery == ""
                                || searchQuery == "Введите запрос").AsEnumerable()
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
                    MessageBox.Show("Записи не найдены");

                    ClearSearch();
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
                int firstRowIndex = dgvSilver.FirstDisplayedCell.RowIndex;
                var selected = Convert.ToInt32(dgvSilver.Rows[dgvSilver.SelectedRows[0].Index].Cells[0].Value);
                var editCheck = db.Check.Include("Decimal_CheckNavigation")
                    .Include("SilverType_CheckNavigation")
                    .FirstOrDefault(x => x.ID_Check == selected);

                if (editCheck != null)
                {
                    var editForm = new AddCheckForm(editCheck);
                    editForm.ShowDialog();

                    InitDatagrid();
                    dgvSilver.FirstDisplayedScrollingRowIndex = firstRowIndex;

                }
                else MessageBox.Show("Выберите чек для редактирования");
            }
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
                        int firstRowIndex = dgvSilver.FirstDisplayedCell.RowIndex;
                        foreach (DataGridViewRow row in allSelected)
                        {
                            var selected = Convert.ToInt32(row.Cells[0].Value);

                            var deleteCheck = db.Check.FirstOrDefault(x => x.ID_Check == selected);

                            db.Check.Remove(deleteCheck);
                            db.SaveChanges();
                        }

                        textBoxSearch.Text = "";
                        InitDatagrid();
                        dgvSilver.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    }
                }
                else MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search() // Переписать этот метод
        {
            if (textBoxSearch.Text == "Введите запрос")
            {
                MessageBox.Show("Введите данные для поиска");
                return;
            }

            searchQuery = textBoxSearch.Text;

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


        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportManager silverReport = new ReportManager();
            silverReport.Show();
        }

        private void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioYear.Checked == false)
                return;

            current = FilterType.year;

            ButtonDisabler();
            InitDatagrid();
        }

        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonth.Checked == false)
                return;

            current = FilterType.month;

            ButtonDisabler();
            InitDatagrid();
        }

        private void radioWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWeek.Checked == false)
                return;

            current = FilterType.week;

            ButtonDisabler();
            InitDatagrid();
        }

        private void radioToday_CheckedChanged(object sender, EventArgs e)
        {
            if (radioToday.Checked == false)
                return;

            dtUntil.Enabled = false;
            dtFrom.Enabled = false;

            current = FilterType.day;

            ButtonDisabler();
            InitDatagrid();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            dtUntil.MinDate = dtFrom.Value;

            if (dtUntil.Value < dtFrom.Value) return;

            InitDatagrid();
        }

        private void dtUntil_ValueChanged(object sender, EventArgs e)
        {
            dtFrom.MaxDate = dtUntil.Value;

            if (dtUntil.Value < dtFrom.Value) return;

            InitDatagrid();
        }

        private void radioCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (dtFrom.Enabled == true || radioCustom.Checked == false) return;

            current = FilterType.custom;

            ButtonDisabler();

            dtFrom.Enabled = true;
            dtUntil.Enabled = true;
        }

        private void ButtonDisabler()
        {
            switch (current)
            {
                case FilterType.year:
                    radioWeek.Checked = false;
                    radioMonth.Checked = false;
                    radioToday.Checked = false;
                    radioCustom.Checked = false;
                    break;
                case FilterType.month:
                    radioWeek.Checked = false;
                    radioYear.Checked = false;
                    radioToday.Checked = false;
                    radioCustom.Checked = false;
                    break;
                case FilterType.week:
                    radioYear.Checked = false;
                    radioMonth.Checked = false;
                    radioToday.Checked = false;
                    radioCustom.Checked = false;
                    break;
                case FilterType.day:
                    radioWeek.Checked = false;
                    radioMonth.Checked = false;
                    radioYear.Checked = false;
                    radioCustom.Checked = false;
                    break;
                case FilterType.custom:
                    radioYear.Checked = false;
                    radioWeek.Checked = false;
                    radioMonth.Checked = false;
                    radioToday.Checked = false;
                    return;
                case FilterType.nope:
                    radioYear.Checked = false;
                    radioWeek.Checked = false;
                    radioMonth.Checked = false;
                    radioToday.Checked = false;
                    radioCustom.Checked = false;
                    break;
            }

            dtUntil.Enabled = false;
            dtFrom.Enabled = false;
        }

        private void ClearSearch()
        {
            current = FilterType.nope;
            textBoxSearch.Text = "Введите запрос";
            searchQuery = string.Empty;

            ButtonDisabler();
            InitDatagrid();
        }

        private void dgvSilver_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (var db = new SilverREContext())
            {
                int firstRowIndex = dgvSilver.FirstDisplayedCell.RowIndex;
                var selected = Convert.ToInt32(dgvSilver.Rows[dgvSilver.SelectedRows[0].Index].Cells[0].Value);
                var editCheck = db.Check.Include("Decimal_CheckNavigation")
                    .Include("SilverType_CheckNavigation")
                    .FirstOrDefault(x => x.ID_Check == selected);

                if (editCheck != null)
                {
                    var editForm = new AddCheckForm(editCheck);
                    editForm.ShowDialog();

                    InitDatagrid();
                    dgvSilver.FirstDisplayedScrollingRowIndex = firstRowIndex;

                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            helperMainMenu.SetHelpString(textBoxSearch, "Вводите сюда данные для поиска. Поиск производится одновременно по: номеру чека, номеру заказа, децимальному номеру. По завершению ввода нажмите клавишу ENTER на клавиатуре или кнопку ПОИСК в окне курсором");

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process helpProcess = new Process();
            helpProcess.StartInfo.FileName = "winword.exe";
            helpProcess.StartInfo.Arguments = "Help.docx";
            helpProcess.Start();

        }

        private void ReloadClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void ReloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitDatagrid();
        }

        private void incorrectToolStripMenuItem_Click(object sender, EventArgs e) // Вроде как неправильно
        {
            using (var db = new SilverREContext())
            {
                var checks = db.Check.OrderBy(x => x.ID_Check).ToList();

                foreach (DataGridViewRow row in dgvSilver.Rows)
                {
                    string decimalToCompare = row.Cells[4].Value.ToString();
                    var correctNorm = db.Norm.FirstOrDefault(x => x.Decimal_NormNavigation.Title_Decimal == decimalToCompare);

                    string silverToCompare = row.Cells[7].Value.ToString();
                    var rowSilver = db.SilverType.FirstOrDefault(x => x.Title_SilverType == silverToCompare);

                    if (correctNorm != null)
                        if (correctNorm.Title_Norm.ToString() != row.Cells[6].Value.ToString()
                            || correctNorm.SilverType_Norm != rowSilver.Code_SilverType)
                            dgvSilver.Rows[row.Index].DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }
    }
}
