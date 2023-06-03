using static System.Windows.Forms.LinkLabel;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Registry
{
    partial class Form1
    {
        ///<summary>
        /// Требуется переменная конструктора.
        ///</summary>
        private System.ComponentModel.IContainer components = null;
        ///<summary>
        /// Освободить все используемые ресурсы.
        ///</summary>
        ///<param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</ param >
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Код, автоматически созданный конструктором форм Windows
        ///<summary>
        /// Обязательный метод для поддержки конструктора – не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        ///</summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.doctorsTable = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cabinetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workDays = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgPrefLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homepage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postPrefLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.db = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file1 = new System.Windows.Forms.ToolStripMenuItem();
            this.new1 = new System.Windows.Forms.ToolStripMenuItem();
            this.open1 = new System.Windows.Forms.ToolStripMenuItem();
            this.save1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exit1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actions1 = new System.Windows.Forms.ToolStripMenuItem();
            this.add1 = new System.Windows.Forms.ToolStripMenuItem();
            this.edit = new System.Windows.Forms.ToolStripMenuItem();
            this.delete1 = new System.Windows.Forms.ToolStripMenuItem();
            this.інструментиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByNameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SortBySpeciaizationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByCabinetNumberMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByIdentifierMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByExperienceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByOrgPrefLabelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.докторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пацієнтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ІдентифікаторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ПосадаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СпеціальністьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ЗакладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.journal = new System.Windows.Forms.DataGridView();
            this.time1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journal)).BeginInit();
            this.SuspendLayout();
            // 
            // doctorsTable
            // 
            this.doctorsTable.AllowUserToAddRows = false;
            this.doctorsTable.AllowUserToDeleteRows = false;
            this.doctorsTable.AllowUserToResizeColumns = false;
            this.doctorsTable.AllowUserToResizeRows = false;
            this.doctorsTable.AutoGenerateColumns = false;
            this.doctorsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.doctorsTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.doctorsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.specialization,
            this.cabinetNumber,
            this.workDays,
            this.identifier,
            this.experience,
            this.orgIdentifier,
            this.orgPrefLabel,
            this.homepage,
            this.mbox,
            this.phone,
            this.qualificationCategory,
            this.gender,
            this.postPrefLabel});
            this.doctorsTable.DataSource = this.db;
            this.doctorsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doctorsTable.Location = new System.Drawing.Point(5, 5);
            this.doctorsTable.Margin = new System.Windows.Forms.Padding(4);
            this.doctorsTable.MultiSelect = false;
            this.doctorsTable.Name = "doctorsTable";
            this.doctorsTable.RowHeadersWidth = 51;
            this.doctorsTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.doctorsTable.RowTemplate.Height = 23;
            this.doctorsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.doctorsTable.Size = new System.Drawing.Size(1606, 269);
            this.doctorsTable.TabIndex = 0;
            this.doctorsTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.doctorsTable_ColumnHeaderMouseClick);
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.FillWeight = 96.75909F;
            this.name.HeaderText = "Лікар";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // specialization
            // 
            this.specialization.DataPropertyName = "Specialization";
            this.specialization.FillWeight = 96.75909F;
            this.specialization.HeaderText = "Спеціальність";
            this.specialization.MinimumWidth = 6;
            this.specialization.Name = "specialization";
            this.specialization.ReadOnly = true;
            // 
            // cabinetNumber
            // 
            this.cabinetNumber.DataPropertyName = "CabinetNumber";
            this.cabinetNumber.FillWeight = 96.75909F;
            this.cabinetNumber.HeaderText = "Номер кабинета";
            this.cabinetNumber.MinimumWidth = 6;
            this.cabinetNumber.Name = "cabinetNumber";
            this.cabinetNumber.ReadOnly = true;
            // 
            // workDays
            // 
            this.workDays.FillWeight = 96.75909F;
            this.workDays.HeaderText = "Робочий час";
            this.workDays.MinimumWidth = 6;
            this.workDays.Name = "workDays";
            // 
            // identifier
            // 
            this.identifier.DataPropertyName = "Identifier";
            this.identifier.FillWeight = 96.75909F;
            this.identifier.HeaderText = "Ідентифікатор";
            this.identifier.MinimumWidth = 6;
            this.identifier.Name = "identifier";
            this.identifier.ReadOnly = true;
            // 
            // experience
            // 
            this.experience.DataPropertyName = "Experience";
            this.experience.FillWeight = 96.75909F;
            this.experience.HeaderText = "Медичний стаж";
            this.experience.MinimumWidth = 6;
            this.experience.Name = "experience";
            this.experience.ReadOnly = true;
            // 
            // orgIdentifier
            // 
            this.orgIdentifier.DataPropertyName = "OrgIdentifier";
            this.orgIdentifier.FillWeight = 96.75909F;
            this.orgIdentifier.HeaderText = "ідентифікатор закладу";
            this.orgIdentifier.MinimumWidth = 6;
            this.orgIdentifier.Name = "orgIdentifier";
            this.orgIdentifier.ReadOnly = true;
            // 
            // orgPrefLabel
            // 
            this.orgPrefLabel.DataPropertyName = "OrgPrefLabel";
            this.orgPrefLabel.FillWeight = 96.75909F;
            this.orgPrefLabel.HeaderText = "Назва закладу";
            this.orgPrefLabel.MinimumWidth = 6;
            this.orgPrefLabel.Name = "orgPrefLabel";
            this.orgPrefLabel.ReadOnly = true;
            // 
            // homepage
            // 
            this.homepage.DataPropertyName = "Homepage";
            this.homepage.FillWeight = 96.75909F;
            this.homepage.HeaderText = "Веб-сторінка";
            this.homepage.MinimumWidth = 6;
            this.homepage.Name = "homepage";
            this.homepage.ReadOnly = true;
            // 
            // mbox
            // 
            this.mbox.DataPropertyName = "Mbox";
            this.mbox.FillWeight = 96.75909F;
            this.mbox.HeaderText = "Службова електронна пошта";
            this.mbox.MinimumWidth = 6;
            this.mbox.Name = "mbox";
            this.mbox.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "Phone";
            this.phone.FillWeight = 96.75909F;
            this.phone.HeaderText = "Службовий телефон";
            this.phone.MinimumWidth = 6;
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // qualificationCategory
            // 
            this.qualificationCategory.DataPropertyName = "QualificationCategory";
            this.qualificationCategory.FillWeight = 142.132F;
            this.qualificationCategory.HeaderText = "Кваліфікаційна категорія";
            this.qualificationCategory.MinimumWidth = 6;
            this.qualificationCategory.Name = "qualificationCategory";
            this.qualificationCategory.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "Gender";
            this.gender.FillWeight = 96.75909F;
            this.gender.HeaderText = "Гендер";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // postPrefLabel
            // 
            this.postPrefLabel.DataPropertyName = "PostPrefLabel";
            this.postPrefLabel.FillWeight = 96.75909F;
            this.postPrefLabel.HeaderText = "Посада";
            this.postPrefLabel.MinimumWidth = 6;
            this.postPrefLabel.Name = "postPrefLabel";
            this.postPrefLabel.ReadOnly = true;
            // 
            // db
            // 
            this.db.DataSource = typeof(Registry.Doctor);
            this.db.Filter = "";
            this.db.Sort = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file1,
            this.actions1,
            this.інструментиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1624, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file1
            // 
            this.file1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new1,
            this.open1,
            this.save1,
            this.exit1});
            this.file1.Name = "file1";
            this.file1.Size = new System.Drawing.Size(59, 24);
            this.file1.Text = "&Файл";
            this.file1.DropDownOpening += new System.EventHandler(this.file1_DropDownOpening);
            // 
            // new1
            // 
            this.new1.Name = "new1";
            this.new1.Size = new System.Drawing.Size(155, 26);
            this.new1.Text = "&Новий";
            this.new1.Click += new System.EventHandler(this.new1_Click);
            // 
            // open1
            // 
            this.open1.Name = "open1";
            this.open1.Size = new System.Drawing.Size(155, 26);
            this.open1.Text = "&Відкрити";
            this.open1.Click += new System.EventHandler(this.open_Click);
            // 
            // save1
            // 
            this.save1.Name = "save1";
            this.save1.Size = new System.Drawing.Size(155, 26);
            this.save1.Text = "&Зберегти";
            this.save1.Click += new System.EventHandler(this.save_Click);
            // 
            // exit1
            // 
            this.exit1.Name = "exit1";
            this.exit1.Size = new System.Drawing.Size(155, 26);
            this.exit1.Text = "&Вихід";
            this.exit1.Click += new System.EventHandler(this.exit_Click);
            // 
            // actions1
            // 
            this.actions1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add1,
            this.edit,
            this.delete1});
            this.actions1.Name = "actions1";
            this.actions1.Size = new System.Drawing.Size(106, 24);
            this.actions1.Text = "&Працівники";
            this.actions1.DropDownOpening += new System.EventHandler(this.actions1_DropDownOpening);
            // 
            // add1
            // 
            this.add1.Name = "add1";
            this.add1.Size = new System.Drawing.Size(224, 26);
            this.add1.Text = "&Додати";
            this.add1.Click += new System.EventHandler(this.add1_Click);
            // 
            // edit
            // 
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(224, 26);
            this.edit.Text = "&Редагувати";
            this.edit.Click += new System.EventHandler(this.edit1_Click);
            // 
            // delete1
            // 
            this.delete1.Name = "delete1";
            this.delete1.Size = new System.Drawing.Size(224, 26);
            this.delete1.Text = "&Видалити";
            this.delete1.Click += new System.EventHandler(this.delete_Click);
            // 
            // інструментиToolStripMenuItem
            // 
            this.інструментиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortStrip,
            this.пошукToolStripMenuItem});
            this.інструментиToolStripMenuItem.Name = "інструментиToolStripMenuItem";
            this.інструментиToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.інструментиToolStripMenuItem.Text = "&Інструменти";
            // 
            // SortStrip
            // 
            this.SortStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByNameMenu,
            this.SortBySpeciaizationMenu,
            this.SortByCabinetNumberMenu,
            this.SortByIdentifierMenu,
            this.SortByExperienceMenu,
            this.SortByOrgPrefLabelMenu});
            this.SortStrip.Name = "SortStrip";
            this.SortStrip.Size = new System.Drawing.Size(182, 26);
            this.SortStrip.Text = "&Сортувати за";
            // 
            // sortByNameMenu
            // 
            this.sortByNameMenu.Name = "sortByNameMenu";
            this.sortByNameMenu.Size = new System.Drawing.Size(214, 26);
            this.sortByNameMenu.Text = "&Ім\'ям";
            this.sortByNameMenu.Click += new System.EventHandler(this.sortByName_Click);
            // 
            // SortBySpeciaizationMenu
            // 
            this.SortBySpeciaizationMenu.Name = "SortBySpeciaizationMenu";
            this.SortBySpeciaizationMenu.Size = new System.Drawing.Size(214, 26);
            this.SortBySpeciaizationMenu.Text = "&Спеціалізацією";
            this.SortBySpeciaizationMenu.Click += new System.EventHandler(this.SortBySpeciaization_Click);
            // 
            // SortByCabinetNumberMenu
            // 
            this.SortByCabinetNumberMenu.Name = "SortByCabinetNumberMenu";
            this.SortByCabinetNumberMenu.Size = new System.Drawing.Size(214, 26);
            this.SortByCabinetNumberMenu.Text = "&Номером кбінету";
            this.SortByCabinetNumberMenu.Click += new System.EventHandler(this.SortByCabinetNumberMenu_Click);
            // 
            // SortByIdentifierMenu
            // 
            this.SortByIdentifierMenu.Name = "SortByIdentifierMenu";
            this.SortByIdentifierMenu.Size = new System.Drawing.Size(214, 26);
            this.SortByIdentifierMenu.Text = "&Ідентифікатором";
            this.SortByIdentifierMenu.Click += new System.EventHandler(this.SortByIdentifierMenu_Click);
            // 
            // SortByExperienceMenu
            // 
            this.SortByExperienceMenu.Name = "SortByExperienceMenu";
            this.SortByExperienceMenu.Size = new System.Drawing.Size(214, 26);
            this.SortByExperienceMenu.Text = "Стажем";
            this.SortByExperienceMenu.Click += new System.EventHandler(this.SortByExperienceMenu_Click);
            // 
            // SortByOrgPrefLabelMenu
            // 
            this.SortByOrgPrefLabelMenu.Name = "SortByOrgPrefLabelMenu";
            this.SortByOrgPrefLabelMenu.Size = new System.Drawing.Size(214, 26);
            this.SortByOrgPrefLabelMenu.Text = "Назвою заклада";
            this.SortByOrgPrefLabelMenu.Click += new System.EventHandler(this.SortByOrgPrefLabelMenu_Click);
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.докторToolStripMenuItem,
            this.пацієнтToolStripMenuItem,
            this.ІдентифікаторToolStripMenuItem,
            this.ПосадаToolStripMenuItem,
            this.СпеціальністьToolStripMenuItem,
            this.ЗакладToolStripMenuItem});
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.пошукToolStripMenuItem.Text = "&Пошук";
            // 
            // докторToolStripMenuItem
            // 
            this.докторToolStripMenuItem.Name = "докторToolStripMenuItem";
            this.докторToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.докторToolStripMenuItem.Text = "&Лікар";
            this.докторToolStripMenuItem.Click += new System.EventHandler(this.findDoctor_Click);
            // 
            // пацієнтToolStripMenuItem
            // 
            this.пацієнтToolStripMenuItem.Name = "пацієнтToolStripMenuItem";
            this.пацієнтToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.пацієнтToolStripMenuItem.Text = "&Пацієнт";
            this.пацієнтToolStripMenuItem.Click += new System.EventHandler(this.findPatient_Click);
            // 
            // ІдентифікаторToolStripMenuItem
            // 
            this.ІдентифікаторToolStripMenuItem.Name = "ІдентифікаторToolStripMenuItem";
            this.ІдентифікаторToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.ІдентифікаторToolStripMenuItem.Text = "&Ідентифікатор";
            this.ІдентифікаторToolStripMenuItem.Click += new System.EventHandler(this.findOIdentifier_Click);
            // 
            // ПосадаToolStripMenuItem
            // 
            this.ПосадаToolStripMenuItem.Name = "ПосадаToolStripMenuItem";
            this.ПосадаToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.ПосадаToolStripMenuItem.Text = "&Посада";
            this.ПосадаToolStripMenuItem.Click += new System.EventHandler(this.findpost_Click);
            // 
            // СпеціальністьToolStripMenuItem
            // 
            this.СпеціальністьToolStripMenuItem.Name = "СпеціальністьToolStripMenuItem";
            this.СпеціальністьToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.СпеціальністьToolStripMenuItem.Text = "&Спеціальність";
            this.СпеціальністьToolStripMenuItem.Click += new System.EventHandler(this.findSpecialization_Click);
            // 
            // ЗакладToolStripMenuItem
            // 
            this.ЗакладToolStripMenuItem.Name = "ЗакладToolStripMenuItem";
            this.ЗакладToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.ЗакладToolStripMenuItem.Text = "&Назва закладу";
            this.ЗакладToolStripMenuItem.Click += new System.EventHandler(this.findorgPrefLabel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files |*.xlsx";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Excel Files |*.xlsx";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1624, 308);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.doctorsTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(1616, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Працівники";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.journal);
            this.tabPage2.Controls.Add(this.journalHeader);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(1616, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Журнал";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.journal_Enter);
            // 
            // journal
            // 
            this.journal.AllowUserToAddRows = false;
            this.journal.AllowUserToDeleteRows = false;
            this.journal.AllowUserToResizeColumns = false;
            this.journal.AllowUserToResizeRows = false;
            this.journal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.journal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.journal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time1,
            this.patient1});
            this.journal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.journal.Location = new System.Drawing.Point(5, 31);
            this.journal.Margin = new System.Windows.Forms.Padding(5);
            this.journal.MultiSelect = false;
            this.journal.Name = "journal";
            this.journal.RowHeadersWidth = 51;
            this.journal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.journal.RowTemplate.Height = 23;
            this.journal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.journal.Size = new System.Drawing.Size(1606, 243);
            this.journal.TabIndex = 0;
            this.journal.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.journal_CellValidating);
            // 
            // time1
            // 
            this.time1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.time1.DataPropertyName = "Keys";
            dataGridViewCellStyle1.NullValue = null;
            this.time1.DefaultCellStyle = dataGridViewCellStyle1;
            this.time1.FillWeight = 45F;
            this.time1.HeaderText = "Час";
            this.time1.MinimumWidth = 6;
            this.time1.Name = "time1";
            this.time1.ReadOnly = true;
            this.time1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.time1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.time1.Width = 45;
            // 
            // patient1
            // 
            this.patient1.DataPropertyName = "Values";
            this.patient1.FillWeight = 149.2386F;
            this.patient1.HeaderText = "Пацієнт";
            this.patient1.MinimumWidth = 6;
            this.patient1.Name = "patient1";
            // 
            // journalHeader
            // 
            this.journalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.journalHeader.Location = new System.Drawing.Point(5, 5);
            this.journalHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.journalHeader.Name = "journalHeader";
            this.journalHeader.Size = new System.Drawing.Size(1606, 26);
            this.journalHeader.TabIndex = 1;
            this.journalHeader.Text = "journalHeader";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 336);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(706, 371);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дані про мед. працівників";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doctorsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.journal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.DataGridView doctorsTable;
        private System.Windows.Forms.BindingSource db;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file1;
        private System.Windows.Forms.ToolStripMenuItem actions1;
        private System.Windows.Forms.ToolStripMenuItem add1;
        private System.Windows.Forms.ToolStripMenuItem edit;
        private System.Windows.Forms.ToolStripMenuItem save1;
        private System.Windows.Forms.ToolStripMenuItem open1;
        private System.Windows.Forms.ToolStripMenuItem exit1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem new1;
        private System.Windows.Forms.ToolStripMenuItem delete1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView journal;
        private System.Windows.Forms.Label journalHeader;







        private System.Windows.Forms.ToolStripMenuItem інструментиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortStrip;
        private System.Windows.Forms.ToolStripMenuItem sortByNameMenu;
        private System.Windows.Forms.ToolStripMenuItem SortBySpeciaizationMenu;
        private System.Windows.Forms.ToolStripMenuItem SortByCabinetNumberMenu;
        private System.Windows.Forms.ToolStripMenuItem SortByIdentifierMenu;
        private System.Windows.Forms.ToolStripMenuItem SortByExperienceMenu;
        private System.Windows.Forms.ToolStripMenuItem SortByOrgPrefLabelMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn time1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient1;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem докторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пацієнтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ІдентифікаторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ПосадаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СпеціальністьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ЗакладToolStripMenuItem;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn specialization;
        private DataGridViewTextBoxColumn cabinetNumber;
        private DataGridViewComboBoxColumn workDays;
        private DataGridViewTextBoxColumn identifier;
        private DataGridViewTextBoxColumn experience;
        private DataGridViewTextBoxColumn orgIdentifier;
        private DataGridViewTextBoxColumn orgPrefLabel;
        private DataGridViewTextBoxColumn homepage;
        private DataGridViewTextBoxColumn mbox;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn qualificationCategory;
        private DataGridViewTextBoxColumn gender;
        private DataGridViewTextBoxColumn postPrefLabel;
    }
}