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
    public partial class MainForm : Form
    {
        InfoForm showInfoForm = null;
        InsertForm showInsertForm = null;
        String dbFileName;
        SQLiteConnection m_dbConn;
        SQLiteCommand m_sqlCmd;
        DataTable DBTable = new DataTable();

        public MainForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e) //Вывод справочного окна
        {
            //Вызов формы и запрет на открытие множества одинаковых окон
            if (showInfoForm == null || showInfoForm.IsDisposed)
            {
                showInfoForm = new InfoForm();
                showInfoForm.Show();
            }
            else
            {
                showInfoForm.Show();
                showInfoForm.Focus();
            }
        }

        public void UpdateTable()
        {
            DBTable.Clear();
            DGridTable.Rows.Clear();
            DGridTable.Columns.Clear();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            string SQuery;
            dbFileName = "RPSLab4.db";
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName);
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                lbStatusText.Text = "Connected";
            }
            catch (SQLiteException ex)
            {
                lbStatusText.Text = "Disconnected";
                MessageBox.Show("Error: " + ex.Message);
            }
            SQuery = "SELECT * FROM ArtiSpaceObject";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
            adapter.Fill(DBTable);
            DGridTable.Columns.Add("Obj_ID", "Идентификатор объекта"); DGridTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGridTable.Columns.Add("Obj_Name", "Имя объекта");
            DGridTable.Columns.Add("Obj_From", "Откуда");
            DGridTable.Columns.Add("Obj_To", "Куда");
            if (DBTable.Rows.Count > 0)
            {
                for (int i = 0; i < DBTable.Rows.Count; i++)
                    DGridTable.Rows.Add(DBTable.Rows[i].ItemArray);
            }
            else
                MessageBox.Show("Database is empty");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Вызов формы и запрет на открытие множества одинаковых окон
            if (showInsertForm == null || showInsertForm.IsDisposed)
            {
                showInsertForm = new InsertForm();
                showInsertForm.Show();
            }
            else
            {
                showInsertForm.Show();
                showInsertForm.Focus();
            }
            m_dbConn.Close();
            UpdateTable();
        }
    }
}
