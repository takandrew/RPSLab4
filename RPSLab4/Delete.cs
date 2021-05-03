using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class DeleteForm : Form
    {
        String dbFileName;
        SQLiteConnection m_dbConn;
        SQLiteCommand m_sqlCmd;
        DataTable DBTable = new DataTable();
        public DeleteForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void DeletingButton_Click(object sender, EventArgs e)
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
                DBTable.Clear();
                m_dbConn = new SQLiteConnection();
                m_sqlCmd = new SQLiteCommand();
                string SQuery;
                dbFileName = @"C:\Users\Takandrew\source\repos\RPSLab4\RPSLab4DB.db";
                try
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName);
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                SQuery = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID='" + DeleteIDUpDown.Value + "'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
                adapter.Fill(DBTable);
                if (DBTable.Rows.Count != 0)
                {
                    m_sqlCmd.CommandText = "DELETE FROM ArtiSpaceObjects WHERE Obj_ID ='" + DeleteIDUpDown.Value + "'";
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно удалена.", "Удаление");
                    m_dbConn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("БД не содержит записи с данным идентификатором", "Удаление");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                m_dbConn.Close();
                return;
            }
        }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm man = new MainForm();
            man.Activate();
        }
    }
}
