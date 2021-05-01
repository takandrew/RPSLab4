using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dbFileName = "RPSLab4.db";
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName);
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                m_sqlCmd.CommandText = "INSERT INTO ArtiSpaceObject" +
                    " ('Obj_ID', 'Obj_Name', 'Obj_From', 'Obj_To') values ('" + RPSLab4.MainForm.DBTable.Rows.Count+1
                    + "', '" + AddNameTextBox.Text + "'," +
                    " '"+ AddFromTextBox.Text +"', '"+ AddToTextBox.Text +"')";
                //m_sqlCmd.Connection.Open(); 
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            m_dbConn.Close();
            this.Close();
        }

    }
}
