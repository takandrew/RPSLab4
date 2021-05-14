﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RPSLab4
{
    public partial class DeleteForm : Form
    {
        MainForm mainForm = new MainForm();
        SQLiteConnection m_dbConn; //Соединение
        SQLiteCommand m_sqlCmd; //Команда
        DataTable dBTable = new DataTable(); //Хранение данных для таблицы
        public DeleteForm()
        {
            InitializeComponent();
            MaximizeBox = false; //Отключение возможности растягивания окна
        }

        private void DeletingButton_Click(object sender, EventArgs e) //Нажатие кнопки "Удалить
        {
            m_sqlCmd = new SQLiteCommand();
            m_dbConn = new SQLiteConnection("Data Source=" + mainForm.dbFileName); //Создание соединения
            m_dbConn.Open();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Откройте соединение с БД");
                return;
            }
            try
            {
                dBTable.Clear();
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
                    MessageBox.Show(ex.Message, "Ошибка");
                }
                SQuery = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID='" + DeleteIDUpDown.Value + "'"; //Запрос выборки
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
                adapter.Fill(dBTable);
                if (dBTable.Rows.Count != 0)
                {
                    m_sqlCmd.CommandText = "DELETE FROM ArtiSpaceObjects WHERE Obj_ID ='" + DeleteIDUpDown.Value + "'"; //Запрос удаления
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.ExecuteNonQuery(); //Выполнение запроса
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

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы
        {
            mainForm.Activate();
        }
    }
}
