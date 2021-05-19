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
        public string dbFileName = @".\RPSLab4DB.db"; //Адрес БД
        SQLiteConnection m_dbConn; //Соединение
        SQLiteCommand m_sqlCmd; //Команда
        DataTable dBTable = new DataTable(); //Хранение данных для таблицы
        ArtiSpaceObject spaceObject = new ArtiSpaceObject();
        SQLiteConnection m_dbConn1; //Соединение
        SQLiteCommand m_sqlCmd1; //Команда
        DataTable dBTable1 = new DataTable(); //Хранение данных для таблицы

        public MainForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
            //Добавление столбцов таблицы
            DGridTable.Columns.Add("Obj_ID", "Идентификатор объекта");
            DGridTable.Columns.Add("Obj_Name", "Название объекта");
            DGridTable.Columns.Add("Obj_Owner", "Владелец объекта");
            DGridTable.Columns.Add("Obj_Orbit", "Орбита объекта"); 
            DGridTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGridTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            if (AutoShowInfo.Default.autoShowInfo == true) //Проверка необходимости вывода справки при запуске
            {
                AutoShowInfoToolStripMenuItem.Checked = true;
                showInfoForm = new InfoForm();
                showInfoForm.Show();
            }
            else
                AutoShowInfoToolStripMenuItem.Checked = false;
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

        public void UpdateTable() //Вывод БД в таблицу
        {
            dBTable.Clear();
            DGridTable.Rows.Clear();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            string SQuery;
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Создание соединения
                m_dbConn.Open(); 
                m_sqlCmd.Connection = m_dbConn; //Указание соединения для команды
                SQuery = "SELECT * FROM ArtiSpaceObjects"; //Запрос всех данных БД
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
                //Заполнение таблицы данными БД
                adapter.Fill(dBTable);
                if (dBTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dBTable.Rows.Count; i++)
                        DGridTable.Rows.Add(dBTable.Rows[i].ItemArray);
                }
                else
                {
                    DGridTable.Rows.Add();
                }
                m_dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка подключения к БД \n" + ex.Message, "Ошибка");
                this.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e) //При первом запуске основной формы
        {
            UpdateTable(); 
        }

        private void AddButton_Click(object sender, EventArgs e) //Нажатие кнопки "Добавить"
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

        private void MainForm_Activated(object sender, EventArgs e) //Активация формы
        {
            //Используется для обновления таблицы из других форм
            UpdateTable();
        }

        private void ChangeButton_Click(object sender, EventArgs e) //Нажатие кнопки "Изменить"
        {
            try
            {
                int rowNum = DGridTable.CurrentCell.RowIndex;
                spaceObject.objID = Convert.ToInt32(DGridTable.Rows[rowNum].Cells[0].Value);
                spaceObject.objName = DGridTable.Rows[rowNum].Cells[1].Value.ToString();
                spaceObject.objOwner = DGridTable.Rows[rowNum].Cells[2].Value.ToString();
                spaceObject.objOrbit = DGridTable.Rows[rowNum].Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
            //Вызов формы и запрет на открытие множества одинаковых окон
            if (showUpdateForm == null || showUpdateForm.IsDisposed)
            {
                showUpdateForm = new UpdateForm(spaceObject);
                showUpdateForm.Show();
            }
            else
            {
                showUpdateForm.Show();
                showUpdateForm.Focus();
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e) //Нажатие кнопки "Удалить"
        {
            int rowNum = DGridTable.CurrentCell.RowIndex;
            spaceObject.objID = Convert.ToInt32(DGridTable.Rows[rowNum].Cells[0].Value);
            if (MessageBox.Show("Вы уверены, что хотите удалить запись с идентификатором: '" + spaceObject.objID + "'?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Deleting(spaceObject.objID, dbFileName);
                MessageBox.Show("Запись успешно удалена.", "Удаление");
            }
            UpdateTable();
        }

        public void Deleting(int obj_ID, string dbFileNameD)
        {
            try
            {
                dBTable1.Clear();
                m_dbConn1 = new SQLiteConnection("Data Source=" + dbFileNameD);
                m_sqlCmd1 = new SQLiteCommand();
                m_dbConn1.Open();
                m_sqlCmd1.Connection = m_dbConn1;
                m_sqlCmd1.CommandText = "DELETE FROM ArtiSpaceObjects WHERE Obj_ID ='" + obj_ID + "'"; //Запрос удаления
                m_sqlCmd1.ExecuteNonQuery(); //Выполнение запроса
                m_dbConn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                m_dbConn1.Close();
                return;
            }
        }

        private void SaveDataToolStripMenuItem_Click(object sender, EventArgs e) //Сохранение таблицы в файл
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return; //Случай с отменой выбора файла
            string saveFilename = saveFileDialog1.FileName;
            try
            {
                string resultString = "\t\t\t Таблица значений: \n";
                for (int k = 0; k < DGridTable.Columns.Count; k++)
                    resultString += DGridTable.Columns[k].HeaderCell.Value + "\t";
                resultString += "\n";
                for (int i = 0; i < DGridTable.Rows.Count; i++)
                {
                    for (int j = 0; j < DGridTable.Columns.Count; j++)
                    {
                        resultString += DGridTable.Rows[i].Cells[j].Value + "\t\t\t";
                    }
                    resultString += "\n";
                }
                System.IO.File.WriteAllText(saveFilename, resultString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
            MessageBox.Show("Файл сохранен", "Файл");
        }

        private void AutoShowInfoToolStripMenuItem_Click(object sender, EventArgs e) //Нажатие настроек вывода справки на экран
        {
            //Установка настройки необходимости вывода справки при запуске программы
            if (AutoShowInfoToolStripMenuItem.Checked) //Если до нажатия был включен вывод
            {
                AutoShowInfoToolStripMenuItem.Checked = false;
                AutoShowInfo.Default.autoShowInfo = false;
                AutoShowInfo.Default.Save();
            }
            else //Если до нажатия был выключен вывод
            {
                AutoShowInfoToolStripMenuItem.Checked = true;
                AutoShowInfo.Default.autoShowInfo = true;
                AutoShowInfo.Default.Save();
            }
        }
    }
}
