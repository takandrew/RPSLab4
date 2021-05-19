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
            //Проверка введенных данных
            if (!string.IsNullOrWhiteSpace(AddNameTextBox.Text)
                && !string.IsNullOrWhiteSpace(AddOwnerTextBox.Text)
                && !string.IsNullOrWhiteSpace(AddOrbitTextBox.Text))
            {
                Inserting(AddNameTextBox.Text, AddOwnerTextBox.Text, AddOrbitTextBox.Text, mainForm.dbFileName);
                MessageBox.Show("Запись успешно добавлена.", "Добавление");
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Добавление");
                return;
            }
            this.Close();
        }

        public void Inserting(string obj_Name, string obj_Owner, string obj_Orbit, string dbFileName)
        {
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Создание соединения
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Откройте соединение с БД");
                return;
            }
            try
            {
                m_sqlCmd.CommandText = "INSERT INTO ArtiSpaceObjects" +
                    " ('Obj_Name', 'Obj_Owner', 'Obj_Orbit') values ('" + obj_Name + "'," +
                    " '" + obj_Owner + "', '" + obj_Orbit + "')"; //Запрос добавления
                m_sqlCmd.Connection = m_dbConn;
                m_sqlCmd.ExecuteNonQuery(); //Выполнение запроса
                m_dbConn.Close();
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
