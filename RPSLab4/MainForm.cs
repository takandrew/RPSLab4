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
        DeleteForm showDeleteForm = null;
        public string dbFileName = @".\RPSLab4DB.db"; //Адрес БД
        SQLiteConnection m_dbConn; //Соединение
        SQLiteCommand m_sqlCmd; //Команда
        DataTable dBTable = new DataTable(); //Хранение данных для таблицы

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
                    MessageBox.Show("БД пуста");
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

        private void DeleteButton_Click(object sender, EventArgs e) //Нажатие кнопки "Удалить"
        {
            //Вызов формы и запрет на открытие множества одинаковых окон
            if (showDeleteForm == null || showDeleteForm.IsDisposed)
            {
                showDeleteForm = new DeleteForm();
                showDeleteForm.Show();
            }
            else
            {
                showDeleteForm.Show();
                showDeleteForm.Focus();
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
