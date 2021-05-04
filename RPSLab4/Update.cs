using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class UpdateForm : Form
    {
        MainForm mainForm = new MainForm();
        SQLiteConnection m_dbConn; //Соединение
        SQLiteCommand m_sqlCmd; //Команда
        DataTable DBTable = new DataTable(); //Хранение данных для таблицы
        public UpdateForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void UpdatingButton_Click(object sender, EventArgs e) //Нажатие кнопки "Изменить"
        {
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + mainForm.dbFileName);
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Откройте соединение с БД");
                return;
            }
            try
            {
                DBTable.Clear();
                m_dbConn = new SQLiteConnection();
                m_sqlCmd = new SQLiteCommand();
                string SQuery;
                try
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + mainForm.dbFileName);
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                SQuery = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID='"+ UpdateIDUpDown.Value +"'"; //Запрос с условием
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
                adapter.Fill(DBTable);
                if (DBTable.Rows.Count != 0)
                {
                    //Проверка введенных данных
                    if ((UpdateNameTextBox.Text.ToUpper() != UpdateNameTextBox.Text.ToLower())
                    && (UpdateOwnerTextBox.Text.ToUpper() != UpdateOwnerTextBox.Text.ToLower())
                    && (UpdateOrbitTextBox.Text.ToUpper() != UpdateOrbitTextBox.Text.ToLower())) 
                    {
                        m_sqlCmd.CommandText = "UPDATE ArtiSpaceObjects SET Obj_name ='" + UpdateNameTextBox.Text + "'" +
                            ", Obj_Owner ='" + UpdateOwnerTextBox.Text + "'," +
                            " Obj_Orbit ='" + UpdateOrbitTextBox.Text + "'" +
                            " WHERE Obj_ID ='" + UpdateIDUpDown.Value + "'"; //Запрос изменения
                        m_sqlCmd.Connection = m_dbConn;
                        m_sqlCmd.ExecuteNonQuery(); //Выполнение запроса
                        MessageBox.Show("Запись успешно изменена.", "Изменение");
                        m_dbConn.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля", "Изменение");
                    }
                }
                else
                {
                    MessageBox.Show("БД не содержит записи с данным идентификатором", "Изменение");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                m_dbConn.Close();
                return;
            }
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы
        {
            mainForm.Activate();
        }
    }
}
