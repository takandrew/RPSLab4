using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class MainForm : Form
    {
        InfoForm showInfoForm = null;
        InsertForm showInsertForm = null;
        UpdateForm showUpdateForm = null;
        String dbFileName;
        SQLiteConnection m_dbConn;
        SQLiteCommand m_sqlCmd;
        DataTable DBTable = new DataTable();

        public MainForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
            DGridTable.Columns.Add("Obj_ID", "Идентификатор объекта");
            DGridTable.Columns.Add("Obj_Name", "Имя объекта");
            DGridTable.Columns.Add("Obj_Owner", "Владелец объекта");
            DGridTable.Columns.Add("Obj_Orbit", "Орбита объекта");
            DGridTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGridTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            string SQuery;
            dbFileName = @"C:\Users\Takandrew\source\repos\RPSLab4\RPSLab4DB.db";
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
            SQuery = "SELECT * FROM ArtiSpaceObjects";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
            adapter.Fill(DBTable);
            if (DBTable.Rows.Count > 0) 
            {
                for (int i = 0; i < DBTable.Rows.Count; i++)
                    DGridTable.Rows.Add(DBTable.Rows[i].ItemArray);
            }
            else
                MessageBox.Show("Database is empty");
            m_dbConn.Close();
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
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            //Вызов формы и запрет на открытие множества одинаковых окон
            if (showUpdateForm == null || showUpdateForm.IsDisposed)
            {
                showUpdateForm = new UpdateForm();
                showUpdateForm.Show();
            }
            else
            {
                showUpdateForm.Show();
                showUpdateForm.Focus();
            }
        }
    }
}
