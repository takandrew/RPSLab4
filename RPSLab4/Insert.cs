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
                if (Inserting(AddNameTextBox.Text, AddOwnerTextBox.Text, AddOrbitTextBox.Text, mainForm.dbFileName))
                    MessageBox.Show("Запись успешно добавлена.", "Добавление");
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Добавление");
                return;
            }
            this.Close();
        }

        public bool Inserting(string obj_Name, string obj_Owner, string obj_Orbit, string dbFileName) //Добавление записи в БД
        {
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Создание соединения
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Откройте соединение с БД");
                return false;
            }
            try
            {
                m_sqlCmd.CommandText = "INSERT INTO ArtiSpaceObjects" +
                    " ('Obj_Name', 'Obj_Owner', 'Obj_Orbit') values (@Obj_Name, " +
                    "@Obj_Owner, @Obj_Orbit)"; //Запрос добавления
                m_sqlCmd.Parameters.Add("@Obj_Name", DbType.String).Value = obj_Name;
                m_sqlCmd.Parameters.Add("@Obj_Owner", DbType.String).Value = obj_Owner;
                m_sqlCmd.Parameters.Add("@Obj_Orbit", DbType.String).Value = obj_Orbit;
                m_sqlCmd.Connection = m_dbConn;
                m_sqlCmd.ExecuteNonQuery(); //Выполнение запроса
                m_dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                m_dbConn.Close();
                return false;
            }
            return true;
        }

        private void InsertForm_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы
        {
            mainForm.Activate();
        }
    }
}
