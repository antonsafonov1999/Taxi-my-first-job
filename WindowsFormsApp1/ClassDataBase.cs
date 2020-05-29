using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Devart.Data.SQLite;

namespace WindowsFormsApp1
{
    public class ClassDataBase
    {

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string setupProgram, string sSql)
        {
            int n = 0;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};", setupProgram)))
                {

                    con.Open();
                    using (SQLiteCommand sqlCommand = con.CreateCommand())
                    {
                        sqlCommand.CommandText = sSql;
                        n = sqlCommand.ExecuteNonQuery();

                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                n = 0;

            }
            return n;
        }
        #endregion

        #region Execute

        protected T GetObject<T>(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        public void Execute<T>(string setupProgram, string sSql, ref List<T> listResult)
        {
            string result = "";
            try
            {
                string databaseName = setupProgram;
                SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                con.Open();
                SQLiteCommand command = new SQLiteCommand(sSql, con);
                SQLiteDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result = "";
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            try
                            {
                                result += dataReader.GetString(i) + "|";
                            }
                            catch { result += "|"; }
                        }
                        if (result.Count() > 2) result = result.Remove(result.Count() - 1);
                        if (result != "") listResult.Add(GetObject<T>(result));
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public int ExecuteItog(string setupProgram, string sSql)
        {
            int result = 0;
            try
            {
                string databaseName = setupProgram;
                SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                con.Open();
                SQLiteCommand command = new SQLiteCommand(sSql, con);
                SQLiteDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader.GetString(0));

                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }



        #endregion

    }
}
