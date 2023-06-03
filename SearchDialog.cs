#region Namespace directives
using System.Windows.Forms;
using System;
#endregion

namespace Registry
{
    public partial class SearchDialog : Form
    {
        private string _query;
        private int _queryInt;

        public SearchDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Відкриває діалогове вікно для пошуку
        /// </summary>
        /// <returns>Рядок, що містить результат пошуку.</returns>
        internal string OpenDialog()
        {
            textBox1.Text = string.Empty;
            ShowDialog();
            textBox1.Capture = true;
            return _query;
        }
        /// <summary>
        /// Відкриває діалогове вікно для отримання цілочисельного значення
        /// </summary>
        /// <returns>Цілочисельне значення, отримане з діалогового вікна</returns>
        internal int OpenIntDialog()
        {
            textBox1.Text = string.Empty;
            ShowDialog();
            textBox1.Capture = true;
            return _queryInt;
        }
        /// <summary>
        /// Обробник події натискання кнопки Пошук
        /// Викликає метод SetQuery()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SetQuery();
        }
        /// <summary>
        /// Встановлює значення запиту
        /// </summary>
        private void SetQuery()
        {
            if (int.TryParse(textBox1.Text, out int intValue))
            {
                _queryInt = intValue;
            }
            else
            {
                _queryInt = 0;
            }

            _query = textBox1.Text;
            textBox1.Capture = false;
            Close();
        }
        /// <summary>
        /// Якщо натиснута клавіша - Enter, викликається метод SetQuery()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetQuery();
        }
    }
}

