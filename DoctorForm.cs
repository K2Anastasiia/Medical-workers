using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Registry
{
    public partial class DoctorForm : Form
    {
        #region 

        private readonly bool[] _settedRows = new bool[7];
        private Doctor _doctor;
        private TimeSpan _interval;

        /// <summary>
        /// Вказує, чи є потреба у збереженні
        /// </summary>
        public bool IsSaveNeeded { get; private set; }

        #endregion

        #region Public Methods

        public DoctorForm()
        {
            InitializeComponent();

            #region 

            info.Rows.Add(13);

            info[0, 0].Value = "ПІБ";
            info[0, 1].Value = "Спеціалізація";
            info[0, 2].Value = "Кабінет";
            info[0, 3].Value = "Iдентифікатор";
            info[0, 4].Value = "Досвід";
            info[0, 5].Value = "Iдентифікатор  закладу";
            info[0, 6].Value = "Назва закладу";
            info[0, 7].Value = "Веб-сторінка";
            info[0, 8].Value = "Службова електронна пошта";
            info[0, 9].Value = "Службовий телефон";
            info[0, 10].Value = "Кваліфікаційна категорія";
            info[0, 11].Value = "Гендер";
            info[0, 12].Value = "Посада";

            #endregion

            #region 

            timetable.Rows.Add(8);
            timetable[0, 0].Value = "Понеділок";
            timetable[0, 1].Value = "Вівторок";
            timetable[0, 2].Value = "Середа";
            timetable[0, 3].Value = "Четверг";
            timetable[0, 4].Value = "П'ятниця";
            timetable[0, 5].Value = "Субота";
            timetable[0, 6].Value = "Неділя";
            timetable[0, 7].Value = "Час на пацієнта";
            timetable[2, 7].ReadOnly = true;

            #endregion

            Clear("Необхідно ввести дані");
        }

        /// <summary>
        /// Додає нового працівника до системи
        /// </summary>
        /// <param name="doctor"></param>
        public void AddDoctor(Doctor doctor)
        {
            _doctor = doctor;
            ShowDialog();
        }

        /// <summary>
        /// Редагує інформацію про працівника
        /// </summary>
        /// <param name="doctor"></param>
        public void EditDoctor(Doctor doctor)
        {
            _doctor = doctor;
            Clear(string.Empty);
            info[1, 0].Value = _doctor.Name;

            info[1, 1].Value = _doctor.Specialization;
            info[1, 2].Value = _doctor.CabinetNumber;
            info[1, 3].Value = _doctor.Identifier;
            info[1, 4].Value = _doctor.Experience;
            info[1, 5].Value = _doctor.OrgIdentifier;
            info[1, 6].Value = _doctor.OrgPrefLabel;
            info[1, 7].Value = _doctor.Homepage;
            info[1, 8].Value = _doctor.Mbox;
            info[1, 9].Value = _doctor.Phone;
            info[1, 10].Value = _doctor.Gender;
            info[1, 11].Value = _doctor.QualificationCategory;
            info[1, 12].Value = _doctor.PostPrefLabel;

            int i = 0;
            for (; i < 7; i++)
            {
                if (!_doctor.Timetable[i].IsSet)
                    continue;
                timetable[1, i].Value = _doctor.Timetable[i].StartTime.ToString(@"hh\:mm");
                timetable[2, i].Value = _doctor.Timetable[i].EndTime.ToString(@"hh\:mm");
            }

            i = 0;
            while (!_doctor.Timetable[i].IsSet)
                ++i;
            _interval = _doctor.Timetable[i].Interval;
            timetable[1, 7].Value = _interval.ToString(@"mm");

            ShowDialog();
        }

        #endregion

        #region 

        /// <summary>
        /// Очищення полів інформації та графіка
        /// </summary>
        /// <param name="errorText"></param>
        private void Clear(string errorText)
        {
            // Очистка інформації
            for (int i = 0; i < info.RowCount; i++)
            {
                info[1, i].Value = info[1, i].DefaultNewRowValue;
                info.Rows[i].ErrorText = errorText;
            }

            // Очистка графіка
            int count = timetable.RowCount - 1;
            for (int i = 0; i < count; i++)
            {
                _settedRows[i] = false;
                timetable[1, i].Value = timetable[1, i].DefaultNewRowValue;
                timetable[2, i].Value = timetable[2, i].DefaultNewRowValue;
                timetable.Rows[i].ErrorText = string.Empty;
            }

            timetable[1, 7].Value = timetable[1, 7].DefaultNewRowValue;
            timetable.Rows[7].ErrorText = errorText;

            info.CurrentCell = info[1, 0];
            timetable.CurrentCell = timetable[1, 0];
        }

        /// <summary>
        ///  Перевіряє, чи всі рядки в полі інформації та графіку є дійсними
        /// </summary>
        /// <returns></returns>
        private bool IsRowsValid()
        {
            if (info.Rows.Cast<DataGridViewRow>().Any(row => row.ErrorText != string.Empty))
                return false;

            return timetable.Rows.Cast<DataGridViewRow>().All(row => row.ErrorText == string.Empty);
        }

        /// <summary>
        /// Підготовка до встановлення графіку
        /// </summary>
        /// <returns>Повертає true, якщо підготовка успішна; в іншому випадку - false</returns>
        private bool PrepareForSetTimetable()
        {
            for (int i = 0; i < 7; i++)
            {
                if (timetable.Rows[i].ErrorText != string.Empty)
                    return false;

                if (timetable[1, i].FormattedValue.ToString() != string.Empty &&
                    timetable[2, i].FormattedValue.ToString() != string.Empty)
                    _settedRows[i] = true;
            }

            return timetable.Rows[7].ErrorText == string.Empty;
        }

        /// <summary>
        /// Встановлення графіку
        /// </summary>
        private void SetTimetable()
        {
            if (!PrepareForSetTimetable())
                return;

            bool hasSettedRows = false, hasErrors = false;
            for (int i = 0; i < 7; i++)
            {
                if (!_settedRows[i])
                {
                    if (_doctor.Timetable[i].IsSet)
                        _doctor.Timetable[i].Unset();
                    continue;
                }

                try
                {
                    _doctor.Timetable[i].Set(TimeSpan.Parse(timetable[1, i].FormattedValue.ToString()), TimeSpan.Parse(timetable[2, i].FormattedValue.ToString()), _interval);
                    hasSettedRows = true;
                    timetable.Rows[i].ErrorText = string.Empty;
                }
                catch (Exception exception)
                {
                    hasErrors = true;
                    timetable.Rows[i].ErrorText = exception.Message;
                }
            }

            if (hasErrors)
                return;

            if (!hasSettedRows)
                timetable.Rows[0].ErrorText = "Необхідно встановити хоча б один день";
        }

        #endregion

        #region 

        /// <summary>
        /// Перевірка валідності значень комірок в таблиці інформації
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void info_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string s = e.FormattedValue.ToString();
            switch (e.RowIndex)
            {
                case 0:
                    try
                    {
                        _doctor.Name = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;

                case 1:
                    try
                    {
                        _doctor.Specialization = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 2:
                    try
                    {
                        _doctor.CabinetNumber = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (Exception exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 3:
                    try
                    {
                        _doctor.Identifier = Convert.ToInt32(s);
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (Exception exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 4:
                    try
                    {
                        _doctor.Experience = Convert.ToInt32(s);
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (Exception exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 5:
                    try
                    {
                        _doctor.OrgIdentifier = Convert.ToInt32(s);
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (Exception exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 6:
                    try
                    {
                        _doctor.OrgPrefLabel = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 7:
                    try
                    {
                        _doctor.Homepage = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 8:
                    try
                    {
                        _doctor.Mbox = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 9:
                    try
                    {
                        _doctor.Phone = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 10:
                    try
                    {
                        _doctor.QualificationCategory = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 11:
                    try
                    {
                        _doctor.Gender = Convert.ToInt32(s);
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (Exception exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;
                case 12:
                    try
                    {
                        _doctor.PostPrefLabel = s;
                        info.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    catch (ArgumentException exception)
                    {
                        info.Rows[e.RowIndex].ErrorText = exception.Message;
                    }
                    break;

                default:
                    throw new NotImplementedException("Something wrong");
            }
        }

        /// <summary>
        /// Перевірка валідності значень комірок в таблиці графіка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timetable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;

            if (e.RowIndex == 7)
            {
                if (e.ColumnIndex == 2)
                    return;

                int parsed;
                if (!int.TryParse(e.FormattedValue.ToString(), out parsed))
                {
                    timetable.CurrentRow.ErrorText = "Значення введено невірно";
                    return;
                }

                if (parsed < 15)
                {
                    timetable.CurrentRow.ErrorText = "Значення має бути не менше 15 хвилин";
                    return;
                }

                if (parsed > 60)
                {
                    timetable.CurrentRow.ErrorText = "Значення має бути не більше 60 хвилин";
                    return;
                }

                _interval = new TimeSpan(0, 0, parsed, 0);
                timetable.Rows[e.RowIndex].ErrorText = string.Empty;
                return;
            }

            string s = e.FormattedValue.ToString();
            TimeSpan tmp;
            if (s != string.Empty && (!TimeSpan.TryParse(s, out tmp) || tmp.Days > 0))
            {
                timetable.CurrentRow.ErrorText = "Значення введено неправильно";
                return;
            }

            timetable.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        /// <summary>
        /// Обробка події закриття форми DoctorForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoctorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (info.CurrentCell.IsInEditMode)
            {
                e.Cancel = true;
                info.CurrentRow.ErrorText = "Необхідно завершити редагування";
                return;
            }

            if (timetable.CurrentCell.IsInEditMode)
            {
                e.Cancel = true;
                timetable.CurrentRow.ErrorText = "Необхідно завершити редагування";
                return;
            }

            DialogResult dr = MessageBox.Show("Зберегти результати роботи?", "Вийти", MessageBoxButtons.YesNoCancel);
            SetTimetable();

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            IsSaveNeeded = dr == DialogResult.Yes;

            if (IsSaveNeeded)
            {
                if (!IsRowsValid())
                {
                    e.Cancel = true;
                    return;
                }
            }

            Clear("Необхідно ввести дані");
        }
        #endregion

        private void info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Метод, який викликається під час завантаження форми DoctorForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoctorForm_Load(object sender, EventArgs e)
        {
            timetable[1, 0].Value = new TimeSpan(9, 0, 0).ToString(@"hh\:mm");  // Set the value of timetable[1, 1] to "09:00"
            timetable[2, 0].Value = new TimeSpan(17, 0, 0).ToString(@"hh\:mm"); // Set the value of timetable[2, 1] to "17:00"
            timetable[1, 7].Value = 50;
        }

    }
}

