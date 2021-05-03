using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class UpdateForm : Form
    {
        String dbFileName;
        SQLiteConnection m_dbConn;
        SQLiteCommand m_sqlCmd;
        DataTable DBTable = new DataTable();
        public UpdateForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void UpdatingButton_Click(object sender, EventArgs e)
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
                SQuery = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID='"+ UpdateIDUpDown.Value +"'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
                adapter.Fill(DBTable);
                if (DBTable.Rows.Count != 0)
                {
                    if ((UpdateNameTextBox.Text.ToUpper() != UpdateNameTextBox.Text.ToLower())
                    && (UpdateOwnerTextBox.Text.ToUpper() != UpdateOwnerTextBox.Text.ToLower())
                    && (UpdateOrbitTextBox.Text.ToUpper() != UpdateOrbitTextBox.Text.ToLower()))
                    {
                        m_sqlCmd.CommandText = "UPDATE ArtiSpaceObjects SET Obj_name ='" + UpdateNameTextBox.Text + "'" +
                            ", Obj_Owner ='" + UpdateOwnerTextBox.Text + "'," +
                            " Obj_Orbit ='" + UpdateOrbitTextBox.Text + "'" +
                            " WHERE Obj_ID ='" + UpdateIDUpDown.Value + "'";
                        m_sqlCmd.Connection = m_dbConn;
                        m_sqlCmd.ExecuteNonQuery();
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

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm man = new MainForm();
            man.Activate();
        }
    }
}
