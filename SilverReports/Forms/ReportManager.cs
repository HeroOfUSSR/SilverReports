using SilverReports.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SilverReports.MainWindow;

namespace SilverReports.Forms
{
    public partial class ReportManager : Form
    {

        private string ExportProgramm = "pdf";
        public string Hyper = "http://birt-serv:8080/birt/frameset?__report=Silver/";
        public string fileName;

        public Uri Uri;
        SilverREContext db = new SilverREContext();

        public ReportManager()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            DateTime dateStart = new DateTime(today.Year, today.Month, 1);
            dateTimePickerFrom.Value = dateStart;
            dateTimePickerUntil.Value = today;

            comboBoxDepartment.DisplayMember = nameof(Department.Code_Department);
            comboBoxDepartment.Items.AddRange(db.Department.Where(x => x.IsAtWork_Department).ToArray());
            buttonCreate.Enabled = false;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;
                 
                if (dateTimePickerFrom.Value > dateTimePickerUntil.Value)
            {
                MessageBox.Show("Неверный диапазон дат!");
                return;
            }
            if (comboBoxDepartment.SelectedItem == null
                || !db.Department.Any(x => x.Code_Department == ((Department)comboBoxDepartment.SelectedItem).Code_Department))
            {
                MessageBox.Show("Цех не выбран");
                return;
            }

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.OverwritePrompt = true;
            SFD.Filter = "Файлы " + (ExportProgramm == "xls" ? "Excel" : "Adobe") + " (*." + ExportProgramm + ")|*." + ExportProgramm + "";

            string temp = comboBoxDepartment.Text + "&dateStart=" + dateTimePickerFrom.Text + "&dateEnd=" + dateTimePickerUntil.Text + "&__format=" + ExportProgramm;
            switch (listView1.SelectedItems[0].Text)
            {
                case "Обсчёт серебра по заказам":
                    {
                        SFD.FileName = "Обсчет серебра по цеху " + comboBoxDepartment.Text + " за период " + dateTimePickerFrom.Text.Replace(".", "") + "_" + dateTimePickerUntil.Text.Replace(".", "") + " по заказам";
                        if (comboBoxDepartment.Text == "7") Uri = new Uri(Hyper + "SilverNormByOrderAndMonth07.rptdesign&shop=" + temp);
                        else Uri = new Uri(Hyper + "SilverNormByOrderAndMonth13.rptdesign&shop=" + temp);
                        break;
                    }
                case "Обсчёт площади серебрения":
                    {
                        SFD.FileName = "Обсчет площади серебрения по цеху " + comboBoxDepartment.Text + " за период " + dateTimePickerFrom.Text.Replace(".", "") + "_" + dateTimePickerUntil.Text.Replace(".", "") + " по заказам";
                        Uri = new Uri(Hyper + "SilverPLPByOrderAndShopAndMonth.rptdesign&shop=" + temp);
                        break;
                    }
                case "Обсчет серебра по цеху":
                    {
                        SFD.FileName = "Обсчет серебра по цеху " + comboBoxDepartment.Text + " за период " + dateTimePickerFrom.Text.Replace(".", "") + "_" + dateTimePickerUntil.Text.Replace(".", "");
                        if (comboBoxDepartment.Text == "7") Uri = new Uri(Hyper + "SilverNormByShopAndMonth07.rptdesign&shop=" + temp);
                        else Uri = new Uri(Hyper + "SilverNormByShopAndMonth13.rptdesign&shop=" + temp);
                        break;
                    }
                default:
                    {
                        SFD.FileName = "Обсчет серебра по цеху " + comboBoxDepartment.Text + " за период " + dateTimePickerFrom.Text.Replace(".", "") + "_" + dateTimePickerUntil.Text.Replace(".", "") + " по заказам";
                        Uri = new Uri(Hyper + "SilverNormByOrderAndMonth13.rptdesign&shop=" + temp);
                        break;
                    }
            }

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                if (SFD.FileName.Substring(SFD.FileName.Length - 4, 4) != "." + ExportProgramm + "")
                    SFD.FileName = SFD.FileName + "." + ExportProgramm;
                fileName = SFD.FileName;
                toolStripProgressReport.Visible = true;
                toolStripProgressReport.Style = ProgressBarStyle.Marquee;
                backgroundWorkerLoadReport.RunWorkerAsync(SFD.FileName);

            }
        }

        private void backgroundWorkerLoadReport_DoWork(object sender, DoWorkEventArgs e)
        {
            WebDownload webClient = new WebDownload();
            try
            {
                webClient.DownloadFile(Uri, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorkerLoadReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressReport.Visible = false;
            toolStripProgressReport.Style = ProgressBarStyle.Blocks;
            Process.Start(fileName);
            /*var p = new Process();
            p.StartInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true
            };
            p.Start();*/
        }

        public class WebDownload : WebClient
        {
            /// <summary>
            /// Time in milliseconds
            /// </summary>
            public int Timeout { get; set; }

            public WebDownload() : this(700000000) { }

            public WebDownload(int timeout)
            {
                this.Timeout = timeout;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address);
                if (request != null)
                {
                    request.Timeout = this.Timeout;
                }
                return request;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCreate.Enabled = true;
        }

    }
}
