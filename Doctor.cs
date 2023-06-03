#region Namespace directives
using System.Text.RegularExpressions;
using System;
using Victor.Timetable;
#endregion

namespace Registry
{
    [Serializable]
    public class Doctor : ICloneable
    {
        #region Fields

        private string _cabinetNumber; // Номер кабінету
        private string _name; // ПІБ лікаря
        private string _specialization; // Спеціальність
        private int _identifier; // Ідентифікатор
        private int _experience; // Досвід роботи
        private int _orgIdentifier; // Ідентифікатор закладу
        private string _orgPrefLabel; // Назва закладу
        private string _homepage; // Веб-сайт
        private string _mbox; // Адреса електронної пошти
        private string _phone; // Номер телефону
        private string _qualificationCategory; // Категорія кваліфікації
        private int _gender; // Гендер
        private string _postPrefLabel; // Посада

        #endregion

        #region Constructors
        public Doctor()
        {
            Timetable = new Timetable();
        }

        public Doctor(string name, string speciality, string cabinetNumber, int identifier, int experience, int orgIdentifier, string orgPrefLabel, string homepage, string mbox, string phone, string qualificationCategory, int gender, string postPrefLabel, Timetable timetable)
            : this()
        {
            Name = name;
            Specialization = speciality;
            CabinetNumber = cabinetNumber;
            Identifier = identifier;
            Experience = experience;
            Timetable = timetable;
            OrgIdentifier = orgIdentifier;
            OrgPrefLabel = orgPrefLabel;
            Homepage = homepage;
            Mbox = mbox;
            Phone = phone;
            QualificationCategory = qualificationCategory;
            Gender = gender;
            PostPrefLabel = postPrefLabel;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Розклад працівника
        /// </summary>
        public Timetable Timetable { get; private set; }
        /// <summary>
        /// Отримує або задає ПІБ 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[\p{IsCyrillic} -]+$"))
                    throw new ArgumentException("ПІБ лікаря задано невірно");
                _name = value;
            }
        }


        /// <summary>
        /// Отримує або задає спеціальність 
        /// </summary>
        public string Specialization
        {
            get { return _specialization; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[\p{IsCyrillic} -]+$"))
                    throw new ArgumentException("Неправильно вказана спеціальність");
                _specialization = value;
            }
        }

        /// <summary>
        /// Отримує або задає номер кабінету 
        /// </summary>
        public string CabinetNumber
        {
            get { return _cabinetNumber; }
            set
            {
                if (value != "NA" && !int.TryParse(value, out _))
                    throw new ArgumentException("Номер кабінету має бути числом або 'NA'");
                _cabinetNumber = value;
            }
        }

        /// <summary>
        /// Отримує або задає ідентифікатор
        /// </summary>
        public int Identifier
        {
            get { return _identifier; }
            set
            {
                string valueString = value.ToString();
                if (valueString.Length < 1 || valueString.Length > 4)
                    throw new ArgumentException("Ідентифікатор має містити від 1 до 4 цифр");
                _identifier = value;
            }
        }

        /// <summary>
        /// Отримує або задає досвід
        /// </summary>
        public int Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
            }
        }

        /// <summary>
        /// Отримує або задає ідентифікатор організації
        /// </summary>
        public int OrgIdentifier
        {
            get { return _orgIdentifier; }
            set
            {
                if (value.ToString().Length != 8)
                    throw new ArgumentException("Ідентифікатор має містити рівно 8 цифри");
                _orgIdentifier = value;
            }
        }

        /// <summary>
        /// Отримує або задає назву назву організації
        /// </summary>
        public string OrgPrefLabel
        {
            get { return _orgPrefLabel; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[\p{L}\s«»]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline))
                    throw new ArgumentException("Назва закладу задана невірно");
                _orgPrefLabel = value;
            }
        }

        /// <summary>
        /// Отримує або задає домашню сторінку
        /// </summary>
        public string Homepage
        {
            get { return _homepage; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[A-Za-z]+(\.[A-Za-z]+)*\.org\.ua$"))
                    throw new ArgumentException("Неправильно вказано веб-сайт(.org.ua)");
                _homepage = value;
            }
        }

        /// <summary>
        /// Отримує або задає адресу електронної
        /// </summary>
        public string Mbox
        {
            get { return _mbox; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[A-Za-z]+@ukr\.net$"))
                    throw new ArgumentException("Неправильно вказано адресу електронної пошти (mlcentr@ukr.net)");
                _mbox = value;
            }
        }

        /// <summary>
        /// Отримує або задає номер телефону
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^380\d{9}$"))
                    throw new ArgumentException("Номер телефону вказано невірно (380000000000)");
                _phone = value;
            }
        }
        /// <summary>
        /// Отримує або задає категорію кваліфікації
        /// </summary>
        public string QualificationCategory
        {
            get { return _qualificationCategory; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[А-ЯІЇЄҐа-яіїєґ-]+$"))
                    throw new ArgumentException("Невірно задана категорія кваліфікації");
                _qualificationCategory = value;
            }
        }

        /// <summary>
        /// Отримує або задає гендер
        /// </summary>
        public int Gender
        {
            get { return _gender; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Гендер вказан не вірно");
                _gender = value;
            }
        }

        /// <summary>
        /// Отримує або задає посаду
        /// </summary>
        public string PostPrefLabel
        {
            get { return _postPrefLabel; }
            set
            {
                value = value.Trim();
                if (!Regex.IsMatch(value, @"^[\p{IsCyrillic} \-.]+$"))
                    throw new ArgumentException("Специальність задана некоректно");
                _postPrefLabel = value;
            }
        }

        #endregion

        #region Implementation of ICloneable
        /// <summary>
        /// Створює копію об'єкта типу Doctor
        /// </summary>
        /// <returns>Новий об'єкт типу Doctor, що є копією поточного об'єкта</returns>
        public object Clone()
        {
            return new Doctor(_name, _specialization, _cabinetNumber, _identifier, _experience, _orgIdentifier, _orgPrefLabel, _homepage, _mbox, _phone, _qualificationCategory, _gender, _postPrefLabel, Timetable);
        }
        #endregion
    }
}
