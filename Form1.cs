#region Namespace directives
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Victor.Timetable;


#endregion
namespace Registry
{


    public partial class Form1 : Form
    {


        #region Constructors

        public Form1()
        {
            InitializeComponent();
            db.DataSource = new List<Doctor>();
            _uaDayOfWeeks = new List<string>
            {
           "Понеділок",
            "Вівторок",
            "Середа",
            "Четвер",
            "П'ятниця",
            "Субота",
            "Неділя"
            };
        }

        #endregion

        #region Private methods
        
        /// <summary>
        /// Встановлює робочого графіку працівника (дні приймання)
        /// </summary>
        /// <param name="doctor"></param>
        /// <param name="rowIndex"></param>
        private void SetDateOfReception(Doctor doctor, int rowIndex)
        {
            var cell = new DataGridViewComboBoxCell();
            var data = new DataTable();
            data.Columns.Add(new DataColumn("Description", typeof(string)));
            data.Columns.Add(new DataColumn("Value", typeof(DateTime)));
            int workDay = -1;
            for (int i = 0; i < 7; i++)
            {
                if (!doctor.Timetable[i].IsSet)
                    continue;
                data.Rows.Add(_uaDayOfWeeks[i], doctor.Timetable[i].Date);
                if (workDay == -1)
                    workDay = i;
            }
            cell.DataSource = data;
            cell.DisplayMember = "Description";
            cell.ValueMember = "Value";
            doctorsTable[3, rowIndex] = cell;
            doctorsTable[3, rowIndex].Value = doctor.Timetable[workDay].Date;
        }


        /// <summary>
        /// Зберігає дані у файл за вказаним шляхом
        /// </summary>
        /// <param name="path"></param>
        private void SaveData(string path)
        {
            if (path == string.Empty || doctorsTable.RowCount == 0)
                return;
            using (FileStream fs = File.OpenWrite(path))
                bf.Serialize(fs, db.DataSource);
        }

        /// <summary>
        /// синхронізації даних таблиці з об'єктами Doctor 
        /// </summary>
        private void SyncTable()
        {
            int i = 0;
            foreach (Doctor doctor in db)
            {
                doctor.Timetable.RemoveExpired();
                SetDateOfReception(doctor, i);
                i++;
            }
            doctorsTable.Refresh();
        }

        /// <summary>
        /// приймає делегат Comparison<Doctor> для порівняння об'єктів Doctor
        /// </summary>
        /// <param name="comparison"></param>
        private void Sort(Comparison<Doctor> comparison)
        {
            // Сортування списку Doctors за заданим порівнянням
            Doctors.Sort(comparison);
            // Синхронізація таблиці після сортування
            SyncTable();
        }
       
        /// <summary>
        /// сортування за ПІБ
        /// </summary>
        private void SortByName()
        {
            Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// сортування за спеціалізацією
        /// </summary>
        private void SortBySpeciaization()
        {
            Sort((x, y) => String.Compare(x.Specialization, y.Specialization, StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// сортування за номером кабінету
        /// </summary>
        private void SortByCabinetNumber()
        {
            Sort((x, y) => String.Compare(x.CabinetNumber, y.CabinetNumber, StringComparison.OrdinalIgnoreCase));

        }
        /// <summary>
        /// сортування за ідентифікатором
        /// </summary>
        private void SortByIdentifier()
        {
            Sort((x, y) => x.Identifier - y.Identifier);
        }
        /// <summary>
        /// сортування за досвідом
        /// </summary>
        private void SortByExperience()
        {
            Sort((x, y) => x.Experience - y.Experience);
        }
        /// <summary>
        /// сортування за назвою заклада
        /// </summary>
        private void SortByOrgPrefLabel()
        {
            Sort((x, y) => String.Compare(x.OrgPrefLabel, y.OrgPrefLabel, StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region Fields

        private readonly BinaryFormatter bf = new BinaryFormatter();
        private readonly DoctorForm _doctorForm = new DoctorForm();
        private readonly SearchDialog _search = new SearchDialog();
        private readonly List<TimeSpan> _journal = new List<TimeSpan>();
        private readonly List<string> _uaDayOfWeeks;
        private int _dayIndex;
        private Doctor _selectedDoctor;

        /// <summary>
        /// Отримує список працівників
        /// </summary>
        private List<Doctor> Doctors
        {
            get { return ((List<Doctor>)db.List); }
        }

        #endregion

        #region Events

        /// <summary>
        /// Обробник події "sortByName_Click"
        /// сортування за ПІБ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByName_Click(object sender, EventArgs e)
        {
            SortByName();
        }

        /// <summary>
        /// Обробник події "FormClosing"
        /// Відображає діалогове вікно для підтвердження збереження даних перед виходом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(Resources.IsSaveNeeded, Resources.Exit, MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
                e.Cancel = true;
            else if (dr == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    SaveData(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Викликається при завантаженні форми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
        }

        /// <summary>
        /// Обробник події "Click" на кнопці "edit1"
        /// Редагує дані за допомогою форми "_doctorForm"
        /// Якщо не потрібно зберігати зміни, відновлює попередню інформацію
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edit1_Click(object sender, EventArgs e)
        {
            if (doctorsTable.Rows.Count <= 0)
            {
                MessageBox.Show(Resources.ChooseDoctor, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            object tmpDoctor = ((Doctor)db.Current).Clone();
            var doctor = (Doctor)db.Current;
            int idx = doctorsTable.CurrentRow.Index;
            _doctorForm.EditDoctor(doctor);
            if (!_doctorForm.IsSaveNeeded)
            {
                db[idx] = tmpDoctor;
                return;
            }
            SortByName();
            doctorsTable.Refresh();
        }

        /// <summary>
        /// Обробник події "Click" на кнопці "add1"
        /// Викликає форму "_doctorForm" для додавання працівника
        /// Якщо не потрібно зберігати зміни, видаляє доданого працівника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add1_Click(object sender, EventArgs e)
        {
            var doctor = (Doctor)db.AddNew();
            _doctorForm.AddDoctor(doctor);
            if (!_doctorForm.IsSaveNeeded)
                db.RemoveCurrent();
            else if (doctorsTable.RowCount > 0)
            {
                if (!tabControl1.Contains(tabPage2))
                    tabControl1.TabPages.Add(tabPage2);
                SortByName();
            }
            doctorsTable.Refresh();
        }

        /// <summary>
        /// Обробник події "DropDownOpening" на елементі "file1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void file1_DropDownOpening(object sender, EventArgs e)
        {
            save1.Enabled = doctorsTable.RowCount > 0;
        }

        /// <summary>
        /// Обробник події "Click" на елементі "new1" 
        /// Створення нової БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void new1_Click(object sender, EventArgs e)
        {
            SaveData(saveFileDialog1.FileName);
            db.DataSource = new List<Doctor>();
            saveFileDialog1.FileName = string.Empty;
            tabControl1.TabPages.Remove(tabPage2);
            doctorsTable.Refresh();
        }
        /// <summary>
        /// Обробник події "Click" на елементі "open"
        /// відкриття існуючої БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            tabControl1.TabPages.Remove(tabPage2);
            SaveData(saveFileDialog1.FileName);
            string path = openFileDialog1.FileName;
            using (FileStream fs = File.OpenRead(path))
                db.DataSource = bf.Deserialize(fs);
            saveFileDialog1.FileName = path;
            if (doctorsTable.RowCount > 0)
            {
                SyncTable();
                tabControl1.TabPages.Add(tabPage2);
            }
            doctorsTable.Refresh();
        }

        /// <summary>
        /// Обробник події "Click" на елементі "open" 
        /// Збереження БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Doctors");
                    for (int columnIndex = 0; columnIndex < doctorsTable.Columns.Count; columnIndex++)
                    {
                        worksheet.Cells[1, columnIndex + 1].Value = doctorsTable.Columns[columnIndex].HeaderText;
                    }
                    for (int rowIndex = 0; rowIndex < doctorsTable.Rows.Count; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < doctorsTable.Columns.Count; columnIndex++)
                        {
                            worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = doctorsTable.Rows[rowIndex].Cells[columnIndex].Value;
                        }
                    }
                    package.SaveAs(new FileInfo(filePath));
                }
            }
        }

        /// <summary>
        /// Обробник події "Click" на елементі "delete"
        /// Видалення працівника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Resources.AreYouSure, Resources.Remove, MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                db.RemoveCurrent();
            if (dr == DialogResult.Yes)
                db.RemoveCurrent();
            if (doctorsTable.RowCount < 1)
                tabControl1.TabPages.Remove(tabPage2);
            doctorsTable.Refresh();
        }

        /// <summary>
        /// Обробник події "DropDownOpening" на елементі "actions1" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actions1_DropDownOpening(object sender, EventArgs e)
        {
            edit.Enabled = delete1.Enabled = doctorsTable.RowCount > 0;
        }

        /// <summary>
        /// Очищає таблицю журналу та встановлює вміст залежно від вибраного працівника та дня
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void journal_Enter(object sender, EventArgs e)
        {
            journal.Rows.Clear();
            _journal.Clear();
            DataGridViewRow currentRow = doctorsTable.CurrentRow;
            string day = currentRow.Cells[3].FormattedValue.ToString();
            _dayIndex = _uaDayOfWeeks.IndexOf(day);
            _selectedDoctor = (Doctor)db.Current;
            DayShedule dayShedule = _selectedDoctor.Timetable[_dayIndex];
            journalHeader.Text = string.Format("{0}, {1}, {2}",
                _selectedDoctor.Name,
                _uaDayOfWeeks[_dayIndex],
                dayShedule.Date.ToString("d.MM.yyyy"));
            foreach (var entry in dayShedule)
            {
                journal.Rows.Add(entry.Key.ToString(@"hh\:mm"), entry.Value);
                _journal.Add(entry.Key);
            }
        }

        /// <summary>
        /// Закриває форму або вікно програми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Виконує перевірку правильності введеного ПІБ пацієнта та зберігає дані у розкладі лікаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void journal_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;
            string patientName = e.FormattedValue.ToString();
            DayShedule dayShedule = _selectedDoctor.Timetable[_dayIndex];
            TimeSpan time = _journal[e.RowIndex];
            string error = string.Empty;
            if (patientName != string.Empty && !Regex.IsMatch(patientName, @"^[А-яієїІЇЄҐ]+\s+([А-яієїІЇЄҐ]\.\s*){2}$"))
                error = "ПІБ введено не вірно";
            journal.CurrentRow.ErrorText = error;
            if (error != string.Empty)
                e.Cancel = true;
            else
                dayShedule[time] = patientName;
        }

        /// <summary>
        /// Сортування за спеціальністю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortBySpeciaization_Click(object sender, EventArgs e)
        {
            SortBySpeciaization();
        }
        
        /// <summary>
        /// Сортування за номером кабінета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByCabinetNumberMenu_Click(object sender, EventArgs e)
        {
            SortByCabinetNumber();
        }

        /// <summary>
        /// Сортування за індентифікатором
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByIdentifierMenu_Click(object sender, EventArgs e)
        {
            SortByIdentifier();
        }

        /// <summary>
        /// сортування за мед. стажем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByExperienceMenu_Click(object sender, EventArgs e)
        {
            SortByExperience();
        }

        /// <summary>
        /// сортування за назвою закладу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortByOrgPrefLabelMenu_Click(object sender, EventArgs e)
        {
            SortByOrgPrefLabel();
        }

        /// <summary>
        /// ортує дані таблиці за вибраним стовпцем при кліку на його заголовок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctorsTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)

        {
            switch (e.ColumnIndex)
            {
                case 0:
                    SortByName();
                    break;
                case 1:
                    SortBySpeciaization();
                    break;
                case 2:
                    SortByCabinetNumber();
                    break;
                case 3:
                    SortByIdentifier();
                    break;
                case 4:
                    SortByExperience();
                    break;
                case 5:
                    SortByOrgPrefLabel();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Пошук за працівником ПІБ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findDoctor_Click(object sender, EventArgs e)
        {
            string query = _search.OpenDialog();
            if (query != string.Empty)
            {
                int index = Doctors.FindIndex(d => d.Name.Contains(query));
                if (index > 0)
                    db.Position = index;
            }
        }
        /// <summary>
        /// Пошук за пацієнтом ПІБ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findPatient_Click(object sender, EventArgs e)
        {
            string query = _search.OpenDialog().ToLower();
            if (query != string.Empty)
            {
                int index =
               Doctors.FindIndex(doctor => doctor.Timetable.FirstOrDefault(shedule => shedule.Values.Where(s => !string.IsNullOrWhiteSpace(s)).FirstOrDefault(s => s.ToLower().Contains(query)) != null) != null);

                if (index > 0)
                {
                    db.Position = index;
                    tabControl1.SelectedTab = tabPage2;
                }
            }
        }
        /// <summary>
        /// Пошук за індентифікатором
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findOIdentifier_Click(object sender, EventArgs e)
        {
            string query = _search.OpenDialog();
            if (!string.IsNullOrEmpty(query))
            {
                if (int.TryParse(query, out int queryInt))
                {
                    var doctor = Doctors.FirstOrDefault(d => d.Identifier == queryInt);
                    if (doctor != null)
                    {
                        int index = Doctors.IndexOf(doctor);
                        if (index >= 0)
                        {
                            db.Position = index;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Пошук за посадою
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findpost_Click(object sender, EventArgs e)
        {

            string query = _search.OpenDialog();
            if (query != string.Empty)
            {
                int index = Doctors.FindIndex(d => d.PostPrefLabel.Contains(query));
                if (index > 0)
                    db.Position = index;
            }
        }
        /// <summary>
        /// Пошук за спеціальністю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findSpecialization_Click(object sender, EventArgs e)
        {

            string query = _search.OpenDialog();
            if (query != string.Empty)
            {
                int index = Doctors.FindIndex(d => d.Specialization.Contains(query));
                if (index > 0)
                    db.Position = index;
            }
        }
        /// <summary>
        /// Пошук за назвою заклада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findorgPrefLabel_Click(object sender, EventArgs e)
        {

            string query = _search.OpenDialog();
            if (query != string.Empty)
            {
                int index = Doctors.FindIndex(d => d.OrgPrefLabel.Contains(query));
                if (index > 0)
                    db.Position = index;
            }
        }
    }
}