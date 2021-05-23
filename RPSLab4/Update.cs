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
        DataTable dBTable = new DataTable(); //Хранение данных для таблицы
        int objectID;
        ArtiSpaceObject spaceobj = new ArtiSpaceObject();
        public UpdateForm(ArtiSpaceObject t)
        {
            spaceobj = t;
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void UpdatingButton_Click(object sender, EventArgs e) //Нажатие кнопки "Изменить"
        {
            //Проверка введенных данных
            if (!string.IsNullOrWhiteSpace(UpdateNameTextBox.Text)
            && !string.IsNullOrWhiteSpace(UpdateOwnerTextBox.Text)
            && !string.IsNullOrWhiteSpace(UpdateOrbitTextBox.Text))
            {
                if (Updating(objectID, UpdateNameTextBox.Text, UpdateOwnerTextBox.Text, UpdateOrbitTextBox.Text, mainForm.dbFileName))
                    MessageBox.Show("Запись успешно изменена.", "Изменение");
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Изменение");
            }
            this.Close();
        }

        public bool Updating(int obj_ID, string obj_Name, string obj_Owner, string obj_Orbit, string dbFileName) //Изменение записи в БД
        {
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName);
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Откройте соединение с БД");
                return false;
            }
            try
            {
                dBTable.Clear();
                m_dbConn = new SQLiteConnection();
                m_sqlCmd = new SQLiteCommand();
                string SQuery;
                try
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName);
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
                SQuery = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID='" + obj_ID + "'"; //Запрос с условием
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
                adapter.Fill(dBTable);
                m_sqlCmd.CommandText = "UPDATE ArtiSpaceObjects SET Obj_name = @Obj_Name, Obj_Owner =" +
                    "@Obj_Owner, Obj_Orbit = @Obj_Orbit WHERE Obj_ID = @Obj_ID"; //Запрос изменения
                m_sqlCmd.Parameters.Add("@Obj_ID", DbType.Int32).Value = obj_ID;
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

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы
        {
            mainForm.Activate();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            objectID = spaceobj.objID;
            UpdateNameTextBox.Text = spaceobj.objName;
            UpdateOwnerTextBox.Text = spaceobj.objOwner;
            UpdateOrbitTextBox.Text = spaceobj.objOrbit;
        }
    }
}
