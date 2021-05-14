using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class InsertForm : Form
    {
        MainForm mainForm = new MainForm();
        SQLiteConnection m_dbConn; //Соединение
        SQLiteCommand m_sqlCmd; //Команда
        public InsertForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void AddingButton_Click(object sender, EventArgs e) //Нажатие кнопки "Добавить"
        {
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + mainForm.dbFileName); //Создание соединения
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Откройте соединение с БД");
                return;
            }
            try
            {
                //Проверка введенных данных
                if (!string.IsNullOrWhiteSpace(AddNameTextBox.Text)
                    && !string.IsNullOrWhiteSpace(AddOwnerTextBox.Text)
                    && !string.IsNullOrWhiteSpace(AddOrbitTextBox.Text))
                {
                    m_sqlCmd.CommandText = "INSERT INTO ArtiSpaceObjects" +
                    " ('Obj_Name', 'Obj_Owner', 'Obj_Orbit') values ('" + AddNameTextBox.Text + "'," +
                    " '" + AddOwnerTextBox.Text + "', '" + AddOrbitTextBox.Text + "')"; //Запрос добавления
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.ExecuteNonQuery(); //Выполнение запроса
                    MessageBox.Show("Запись успешно добавлена.", "Добавление");
                    m_dbConn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Добавление");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                m_dbConn.Close();
                return;
            }
        }

        private void InsertForm_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы
        {
            mainForm.Activate();
        }
    }
}
