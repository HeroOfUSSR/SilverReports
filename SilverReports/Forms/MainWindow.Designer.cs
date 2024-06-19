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
            this.buttonIncorrect = new System.Windows.Forms.Button();
            this.buttonNorm = new System.Windows.Forms.Button();
            this.buttonDictionary = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поЗаказамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обсчётСеребраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обсчётПлощадиСеребренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поЦехуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvSilver = new System.Windows.Forms.DataGridView();
            this.contextMenuReload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.перезагрузитьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSilver)).BeginInit();
            this.contextMenuReload.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonIncorrect);
            this.panel1.Controls.Add(this.buttonNorm);
            this.panel1.Controls.Add(this.buttonDictionary);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(731, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 426);
            this.panel1.TabIndex = 0;
            // 
            // buttonIncorrect
            // 
            this.buttonIncorrect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonIncorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonIncorrect.Location = new System.Drawing.Point(0, 384);
            this.buttonIncorrect.Name = "buttonIncorrect";
            this.buttonIncorrect.Size = new System.Drawing.Size(216, 42);
            this.buttonIncorrect.TabIndex = 8;
            this.buttonIncorrect.Text = "Некорректные нормы";
            this.buttonIncorrect.UseVisualStyleBackColor = true;
            this.buttonIncorrect.Click += new System.EventHandler(this.buttonIncorrect_Click);
            // 
            // buttonNorm
            // 
            this.buttonNorm.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonNorm.Location = new System.Drawing.Point(0, 233);
            this.buttonNorm.Name = "buttonNorm";
            this.buttonNorm.Size = new System.Drawing.Size(216, 42);
            this.buttonNorm.TabIndex = 5;
            this.buttonNorm.Text = "Таблица норм";
            this.buttonNorm.UseVisualStyleBackColor = true;
            this.buttonNorm.Click += new System.EventHandler(this.buttonNorm_Click);
            // 
            // buttonDictionary
            // 
            this.buttonDictionary.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonDictionary.Location = new System.Drawing.Point(0, 191);
            this.buttonDictionary.Name = "buttonDictionary";
            this.buttonDictionary.Size = new System.Drawing.Size(216, 42);
            this.buttonDictionary.TabIndex = 4;
            this.buttonDictionary.Text = "Справочник дец номеров";
            this.buttonDictionary.UseVisualStyleBackColor = true;
            this.buttonDictionary.Click += new System.EventHandler(this.buttonDictionary_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonDelete.Location = new System.Drawing.Point(0, 149);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(216, 42);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить чек";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonEdit.Location = new System.Drawing.Point(0, 107);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(216, 42);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Изменить чек";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonAdd.Location = new System.Drawing.Point(0, 65);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(216, 42);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить чек";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Controls.Add(this.textBoxSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 65);
            this.panel2.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSearch.Location = new System.Drawing.Point(0, 26);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(216, 39);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(216, 26);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "Поиск";
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поЗаказамToolStripMenuItem,
            this.поЦехуToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // поЗаказамToolStripMenuItem
            // 
            this.поЗаказамToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обсчётСеребраToolStripMenuItem,
            this.обсчётПлощадиСеребренияToolStripMenuItem});
            this.поЗаказамToolStripMenuItem.Name = "поЗаказамToolStripMenuItem";
            this.поЗаказамToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.поЗаказамToolStripMenuItem.Text = "По заказам";
            // 
            // обсчётСеребраToolStripMenuItem
            // 
            this.обсчётСеребраToolStripMenuItem.Name = "обсчётСеребраToolStripMenuItem";
            this.обсчётСеребраToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.обсчётСеребраToolStripMenuItem.Text = "Обсчёт серебра";
            this.обсчётСеребраToolStripMenuItem.Click += new System.EventHandler(this.обсчётСеребраToolStripMenuItem_Click);
            // 
            // обсчётПлощадиСеребренияToolStripMenuItem
            // 
            this.обсчётПлощадиСеребренияToolStripMenuItem.Name = "обсчётПлощадиСеребренияToolStripMenuItem";
            this.обсчётПлощадиСеребренияToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.обсчётПлощадиСеребренияToolStripMenuItem.Text = "Обсчёт площади серебрения";
            this.обсчётПлощадиСеребренияToolStripMenuItem.Click += new System.EventHandler(this.обсчётПлощадиСеребренияToolStripMenuItem_Click);
            // 
            // поЦехуToolStripMenuItem
            // 
            this.поЦехуToolStripMenuItem.Name = "поЦехуToolStripMenuItem";
            this.поЦехуToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.поЦехуToolStripMenuItem.Text = "По цеху";
            this.поЦехуToolStripMenuItem.Click += new System.EventHandler(this.поЦехуToolStripMenuItem_Click);
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
            this.dgvSilver.Size = new System.Drawing.Size(731, 426);
            this.dgvSilver.TabIndex = 2;
            this.dgvSilver.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSilver_ColumnHeaderMouseClick);
            // 
            // contextMenuReload
            // 
            this.contextMenuReload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перезагрузитьТаблицуToolStripMenuItem});
            this.contextMenuReload.Name = "contextMenuReload";
            this.contextMenuReload.Size = new System.Drawing.Size(203, 26);
            // 
            // перезагрузитьТаблицуToolStripMenuItem
            // 
            this.перезагрузитьТаблицуToolStripMenuItem.Name = "перезагрузитьТаблицуToolStripMenuItem";
            this.перезагрузитьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.перезагрузитьТаблицуToolStripMenuItem.Text = "Перезагрузить таблицу";
            this.перезагрузитьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.перезагрузитьТаблицуToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 450);
            this.Controls.Add(this.dgvSilver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Главное меню";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSilver)).EndInit();
            this.contextMenuReload.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonIncorrect;
        private System.Windows.Forms.Button buttonNorm;
        private System.Windows.Forms.Button buttonDictionary;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvSilver;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ToolStripMenuItem поЗаказамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обсчётСеребраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обсчётПлощадиСеребренияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поЦехуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuReload;
        private System.Windows.Forms.ToolStripMenuItem перезагрузитьТаблицуToolStripMenuItem;
    }
}

