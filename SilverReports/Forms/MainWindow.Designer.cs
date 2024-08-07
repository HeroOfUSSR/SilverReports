namespace SilverReports
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNorm = new System.Windows.Forms.Button();
            this.buttonDictionary = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioYear = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioMonth = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radioWeek = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radioToday = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtUntil = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incorrectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvSilver = new System.Windows.Forms.DataGridView();
            this.contextMSReload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helperMainMenu = new System.Windows.Forms.HelpProvider();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSilver)).BeginInit();
            this.contextMSReload.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonNorm);
            this.panel1.Controls.Add(this.buttonDictionary);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(841, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 527);
            this.panel1.TabIndex = 1;
            // 
            // buttonNorm
            // 
            this.buttonNorm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonNorm.Location = new System.Drawing.Point(0, 443);
            this.buttonNorm.Name = "buttonNorm";
            this.buttonNorm.Size = new System.Drawing.Size(322, 42);
            this.buttonNorm.TabIndex = 5;
            this.buttonNorm.Text = "Таблица норм";
            this.buttonNorm.UseVisualStyleBackColor = true;
            this.buttonNorm.Click += new System.EventHandler(this.buttonNorm_Click);
            // 
            // buttonDictionary
            // 
            this.buttonDictionary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonDictionary.Location = new System.Drawing.Point(0, 485);
            this.buttonDictionary.Name = "buttonDictionary";
            this.buttonDictionary.Size = new System.Drawing.Size(322, 42);
            this.buttonDictionary.TabIndex = 4;
            this.buttonDictionary.Text = "Справочник дец номеров";
            this.buttonDictionary.UseVisualStyleBackColor = true;
            this.buttonDictionary.Click += new System.EventHandler(this.buttonDictionary_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonDelete.Location = new System.Drawing.Point(0, 331);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(322, 42);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить чек";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonEdit.Location = new System.Drawing.Point(0, 289);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(322, 42);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Редактировать чек";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonAdd.Location = new System.Drawing.Point(0, 247);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(322, 42);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить чек";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelFilter);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Controls.Add(this.textBoxSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 247);
            this.panel2.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.flowLayoutPanel1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFilter.Location = new System.Drawing.Point(0, 71);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(322, 140);
            this.panelFilter.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фильтровать за:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(322, 114);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radioYear);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(139, 29);
            this.panel5.TabIndex = 6;
            // 
            // radioYear
            // 
            this.radioYear.AutoSize = true;
            this.radioYear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.radioYear.Location = new System.Drawing.Point(8, 4);
            this.radioYear.Name = "radioYear";
            this.radioYear.Size = new System.Drawing.Size(113, 22);
            this.radioYear.TabIndex = 0;
            this.radioYear.TabStop = true;
            this.radioYear.Text = "Текущий год";
            this.radioYear.UseVisualStyleBackColor = true;
            this.radioYear.CheckedChanged += new System.EventHandler(this.radioYear_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radioMonth);
            this.panel6.Location = new System.Drawing.Point(148, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(153, 29);
            this.panel6.TabIndex = 7;
            // 
            // radioMonth
            // 
            this.radioMonth.AutoSize = true;
            this.radioMonth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.radioMonth.Location = new System.Drawing.Point(8, 4);
            this.radioMonth.Name = "radioMonth";
            this.radioMonth.Size = new System.Drawing.Size(132, 22);
            this.radioMonth.TabIndex = 0;
            this.radioMonth.TabStop = true;
            this.radioMonth.Text = "Текущий месяц";
            this.radioMonth.UseVisualStyleBackColor = true;
            this.radioMonth.CheckedChanged += new System.EventHandler(this.radioMonth_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.radioWeek);
            this.panel7.Location = new System.Drawing.Point(3, 38);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(159, 29);
            this.panel7.TabIndex = 8;
            // 
            // radioWeek
            // 
            this.radioWeek.AutoSize = true;
            this.radioWeek.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.radioWeek.Location = new System.Drawing.Point(8, 4);
            this.radioWeek.Name = "radioWeek";
            this.radioWeek.Size = new System.Drawing.Size(144, 22);
            this.radioWeek.TabIndex = 0;
            this.radioWeek.TabStop = true;
            this.radioWeek.Text = "Текущую неделю";
            this.radioWeek.UseVisualStyleBackColor = true;
            this.radioWeek.CheckedChanged += new System.EventHandler(this.radioWeek_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.radioToday);
            this.panel8.Location = new System.Drawing.Point(168, 38);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(108, 29);
            this.panel8.TabIndex = 9;
            // 
            // radioToday
            // 
            this.radioToday.AutoSize = true;
            this.radioToday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.radioToday.Location = new System.Drawing.Point(8, 4);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(85, 22);
            this.radioToday.TabIndex = 0;
            this.radioToday.TabStop = true;
            this.radioToday.Text = "Сегодня";
            this.radioToday.UseVisualStyleBackColor = true;
            this.radioToday.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioCustom);
            this.panel3.Location = new System.Drawing.Point(3, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 29);
            this.panel3.TabIndex = 10;
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.radioCustom.Location = new System.Drawing.Point(8, 4);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(185, 22);
            this.radioCustom.TabIndex = 0;
            this.radioCustom.TabStop = true;
            this.radioCustom.Text = "Определённый период";
            this.radioCustom.UseVisualStyleBackColor = true;
            this.radioCustom.CheckedChanged += new System.EventHandler(this.radioCustom_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dtUntil);
            this.panel4.Controls.Add(this.dtFrom);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 211);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(322, 36);
            this.panel4.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(149, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // dtUntil
            // 
            this.dtUntil.Enabled = false;
            this.dtUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtUntil.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtUntil.Location = new System.Drawing.Point(168, 6);
            this.dtUntil.Name = "dtUntil";
            this.dtUntil.Size = new System.Drawing.Size(97, 24);
            this.dtUntil.TabIndex = 1;
            this.dtUntil.ValueChanged += new System.EventHandler(this.dtUntil_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Enabled = false;
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(40, 6);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(102, 24);
            this.dtFrom.TabIndex = 0;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSearch.Location = new System.Drawing.Point(0, 26);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(322, 39);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Поиск";
            this.toolTips.SetToolTip(this.buttonSearch, "Для осуществления поиска необходимо ввести в поле ключевые значения:");
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(322, 26);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "Введите запрос";
            this.toolTips.SetToolTip(this.textBoxSearch, resources.GetString("textBoxSearch.ToolTip"));
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportsToolStripMenuItem,
            this.incorrectToolStripMenuItem,
            this.обновитьToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1163, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "reportStrip";
            // 
            // ReportsToolStripMenuItem
            // 
            this.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
            this.ReportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ReportsToolStripMenuItem.Text = "Отчёты";
            this.ReportsToolStripMenuItem.Click += new System.EventHandler(this.ReportsToolStripMenuItem_Click);
            // 
            // incorrectToolStripMenuItem
            // 
            this.incorrectToolStripMenuItem.Name = "incorrectToolStripMenuItem";
            this.incorrectToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.incorrectToolStripMenuItem.Text = "Некорректные нормы";
            this.incorrectToolStripMenuItem.Click += new System.EventHandler(this.incorrectToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadToolStripMenuItem1,
            this.ReloadClearToolStripMenuItem});
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.обновитьToolStripMenuItem.Text = "Обновить ";
            // 
            // ReloadToolStripMenuItem1
            // 
            this.ReloadToolStripMenuItem1.Name = "ReloadToolStripMenuItem1";
            this.ReloadToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.ReloadToolStripMenuItem1.Text = "Обновить";
            this.ReloadToolStripMenuItem1.Click += new System.EventHandler(this.ReloadToolStripMenuItem1_Click);
            // 
            // ReloadClearToolStripMenuItem
            // 
            this.ReloadClearToolStripMenuItem.Name = "ReloadClearToolStripMenuItem";
            this.ReloadClearToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ReloadClearToolStripMenuItem.Text = "Обновить и очистить";
            this.ReloadClearToolStripMenuItem.Click += new System.EventHandler(this.ReloadClearToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.helpToolStripMenuItem.Text = "Открыть справку";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // dgvSilver
            // 
            this.dgvSilver.AllowUserToAddRows = false;
            this.dgvSilver.AllowUserToDeleteRows = false;
            this.dgvSilver.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSilver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSilver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSilver.GridColor = System.Drawing.Color.Silver;
            this.dgvSilver.Location = new System.Drawing.Point(0, 24);
            this.dgvSilver.Name = "dgvSilver";
            this.dgvSilver.ReadOnly = true;
            this.dgvSilver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSilver.Size = new System.Drawing.Size(841, 527);
            this.dgvSilver.TabIndex = 2;
            this.dgvSilver.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvSilver_MouseDoubleClick);
            // 
            // contextMSReload
            // 
            this.contextMSReload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.contextMSReload.Name = "contextMSReload";
            this.contextMSReload.Size = new System.Drawing.Size(192, 48);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.reloadToolStripMenuItem.Text = "Обновить";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.clearToolStripMenuItem.Text = "Очистить и обновить";
            // 
            // toolTips
            // 
            this.toolTips.ToolTipTitle = "Поиск";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 551);
            this.Controls.Add(this.dgvSilver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 489);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSilver)).EndInit();
            this.contextMSReload.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button buttonNorm;
        private System.Windows.Forms.Button buttonDictionary;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvSilver;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ToolStripMenuItem incorrectToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtUntil;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioYear;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radioMonth;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton radioWeek;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton radioToday;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMSReload;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helperMainMenu;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReloadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ReloadClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    }
}

