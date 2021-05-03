using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class InsertForm : Form
    {
        String dbFileName;
        SQLiteConnection m_dbConn;
        SQLiteCommand m_sqlCmd;
        public InsertForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void AddingButton_Click(object sender, EventArgs e)
        {
            m_sqlCmd = new SQLiteCommand();
            dbFileName = @"C:\Users\Takandrew\source\repos\RPSLab4\RPSLab4DB.db";
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName);
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                if ((AddNameTextBox.Text.ToUpper() != AddNameTextBox.Text.ToLower())
                    && (AddOwnerTextBox.Text.ToUpper() != AddOwnerTextBox.Text.ToLower())
                    && (AddOrbitTextBox.Text.ToUpper() != AddOrbitTextBox.Text.ToLower()))
                {
                    m_sqlCmd.CommandText = "INSERT INTO ArtiSpaceObjects" +
                    " ('Obj_Name', 'Obj_Owner', 'Obj_Orbit') values ('" + AddNameTextBox.Text + "'," +
                    " '" + AddOwnerTextBox.Text + "', '" + AddOrbitTextBox.Text + "')";
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.ExecuteNonQuery();
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

        private void InsertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm man = new MainForm();
            man.Activate();
        }
    }
}
