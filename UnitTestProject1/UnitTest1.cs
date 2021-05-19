using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.Data;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string dbFileName = @".\RPSLab4TestDB.db";
        RPSLab4.ArtiSpaceObject spaceObject = new RPSLab4.ArtiSpaceObject();

        [TestMethod]
        public void Test1Insert()
        {
            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Соединение
            SQLiteConnection m_dbConn1 = new SQLiteConnection("Data Source=" + dbFileName);
            SQLiteCommand m_sqlCmd = new SQLiteCommand(); //Команда
            SQLiteCommand m_sqlCmd1 = new SQLiteCommand(); //Команда
            DataTable dBTable = new DataTable(); //Хранение данных для таблицы
            DataTable dBTable1 = new DataTable(); //Хранение данных для таблицы
            

            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            string SQuery = "SELECT * FROM ArtiSpaceObjects"; //Запрос с условием
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
            adapter.Fill(dBTable);
            m_dbConn.Close();
            int numOfRows = dBTable.Rows.Count;
            int expectedRowsAfterInserting = numOfRows + 1;
            RPSLab4.InsertForm insertForm = new RPSLab4.InsertForm();
            insertForm.Inserting("Тест", "Тест", "Тест", dbFileName);
            m_dbConn1.Open();
            m_sqlCmd1.Connection = m_dbConn1;
            adapter = new SQLiteDataAdapter(SQuery, m_dbConn1);
            adapter.Fill(dBTable1);
            m_dbConn1.Close();
            
            int numOfRows1 = dBTable1.Rows.Count;
            Assert.AreEqual(expectedRowsAfterInserting, numOfRows1);
        }

        [TestMethod]
        public void Test2Select()
        {
            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Соединение
            SQLiteConnection m_dbConn1 = new SQLiteConnection("Data Source=" + dbFileName);
            SQLiteCommand m_sqlCmd = new SQLiteCommand(); //Команда
            SQLiteCommand m_sqlCmd1 = new SQLiteCommand(); //Команда
            DataTable dBTable = new DataTable(); //Хранение данных для таблицы
            DataTable dBTable1 = new DataTable(); //Хранение данных для таблицы

            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            string SQuery = "SELECT * FROM ArtiSpaceObjects"; //Запрос с условием
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
            adapter.Fill(dBTable);
            m_dbConn.Close();
            int numOfRows = dBTable.Rows.Count-1;
            object[] neededIDObj = dBTable.Rows[numOfRows].ItemArray;
            int neededID = Convert.ToInt32(neededIDObj[0]);

            m_dbConn1.Open();
            m_sqlCmd1.Connection = m_dbConn1;
            string SQuery1 = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID = '"+ neededID +"'"; //Запрос с условием
            adapter = new SQLiteDataAdapter(SQuery1, m_dbConn1);
            adapter.Fill(dBTable1);
            m_dbConn.Close();
            object[] neededObj = dBTable.Rows[0].ItemArray;

            object[] expectedObj = { neededID, "Тест", "Тест", "Тест" };

            int one = 1; int two = 2;
            bool equalResult = false;

            for (int i = 0; i < neededObj.Length; i++)
            {
                if (neededObj.GetValue(i).ToString() == expectedObj.GetValue(i).ToString())
                {
                    equalResult = true;
                    break;
                }
            }

            if (equalResult)
            {
                Assert.AreEqual(one, one);
            }
            else
                Assert.AreEqual(one, two);
        }

        [TestMethod]
        public void Test3Change()
        {
            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Соединение
            SQLiteConnection m_dbConn1 = new SQLiteConnection("Data Source=" + dbFileName);
            SQLiteConnection m_dbConn2 = new SQLiteConnection("Data Source=" + dbFileName);
            SQLiteCommand m_sqlCmd = new SQLiteCommand(); //Команда
            SQLiteCommand m_sqlCmd1 = new SQLiteCommand(); //Команда
            SQLiteCommand m_sqlCmd2 = new SQLiteCommand(); //Команда
            DataTable dBTable = new DataTable(); //Хранение данных для таблицы
            DataTable dBTable1 = new DataTable(); //Хранение данных для таблицы
            DataTable dBTable2 = new DataTable(); //Хранение данных для таблицы

            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            string SQuery = "SELECT * FROM ArtiSpaceObjects"; //Запрос с условием
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
            adapter.Fill(dBTable);
            m_dbConn.Close();
            int numOfRows = dBTable.Rows.Count - 1;
            object[] neededIDObj = dBTable.Rows[numOfRows].ItemArray;
            int neededID = Convert.ToInt32(neededIDObj[0]);

            m_dbConn1.Open();
            m_sqlCmd1.Connection = m_dbConn1;
            string SQuery1 = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID = '" + neededID + "'";
            adapter = new SQLiteDataAdapter(SQuery1, m_dbConn1);
            adapter.Fill(dBTable1);
            m_dbConn1.Close();

            spaceObject.objID = neededID; spaceObject.objName = "Изменено";
            spaceObject.objOwner = "Изменено"; spaceObject.objOrbit = "Изменено";
            RPSLab4.UpdateForm updateForm = new RPSLab4.UpdateForm(spaceObject);
            updateForm.Updating(spaceObject.objID, spaceObject.objName,
                spaceObject.objOwner, spaceObject.objOrbit, dbFileName);

            m_dbConn2.Open();
            m_sqlCmd2.Connection = m_dbConn2;
            string SQuery2 = "SELECT * FROM ArtiSpaceObjects WHERE Obj_ID = '" + neededID + "'";
            adapter = new SQLiteDataAdapter(SQuery2, m_dbConn2);
            adapter.Fill(dBTable2);
            m_dbConn1.Close();

            object[] notChanged = dBTable1.Rows[0].ItemArray;
            object[] changed = dBTable2.Rows[0].ItemArray;

            int one = 1; int two = 2;
            bool equalResult = false;

            for (int i = 1; i < notChanged.Length; i++)
            {
                if (notChanged.GetValue(i).ToString() == changed.GetValue(i).ToString())
                {
                    equalResult = true;
                    break;
                }
            }

            if (equalResult)
            {
                Assert.AreEqual(one, two);
            }
            else
                Assert.AreEqual(one, one);
        }

        [TestMethod]
        public void Test4Delete()
        {
            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName); //Соединение
            SQLiteConnection m_dbConn1 = new SQLiteConnection("Data Source=" + dbFileName);
            SQLiteCommand m_sqlCmd = new SQLiteCommand(); //Команда
            SQLiteCommand m_sqlCmd1 = new SQLiteCommand(); //Команда
            DataTable dBTable = new DataTable(); //Хранение данных для таблицы
            DataTable dBTable1 = new DataTable(); //Хранение данных для таблицы


            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            string SQuery = "SELECT * FROM ArtiSpaceObjects"; //Запрос с условием
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQuery, m_dbConn);
            adapter.Fill(dBTable);
            m_dbConn.Close();
            int numOfRows = dBTable.Rows.Count;
            int expectedRowsAfterDeleting = numOfRows - 1;
            object[] neededIDObj = dBTable.Rows[numOfRows-1].ItemArray;
            int neededID = Convert.ToInt32(neededIDObj[0]);
            RPSLab4.MainForm mainForm = new RPSLab4.MainForm();
            mainForm.Deleting(neededID, dbFileName);

            m_dbConn1.Open();
            m_sqlCmd1.Connection = m_dbConn1;
            adapter = new SQLiteDataAdapter(SQuery, m_dbConn1);
            adapter.Fill(dBTable1);
            m_dbConn1.Close();
            int numOfRows1 = dBTable1.Rows.Count;

            Assert.AreEqual(expectedRowsAfterDeleting, numOfRows1);
        }
    }
}
