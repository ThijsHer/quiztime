using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using quiztime.classes;
using System.Windows;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace quiztime
{
    internal class Class1
    {
        private List<ObservableCollection<myQuiz >> quiz = new List<ObservableCollection<myQuiz>>();
        private MySqlConnection conn;
        private MySqlConnection conn2;
        public Class1()
        {
            string myConnectionString = "server=localhost;uid=root;" +
                "pwd=;database=quiztime";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                conn2 = new MySql.Data.MySqlClient.MySqlConnection();
                conn2.ConnectionString = myConnectionString;
                conn2.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<ObservableCollection<myQuiz>> test()
        {
            var quizdata = new List<myQuiz>();
            string sql = @"select * from quiz";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.Add("@name",MySqlDbType.VarChar).Value = name;
            //cmd.Parameters.Add("@picture", MySqlType.VarChar).Value = surname;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                quizdata.Add(new myQuiz());
                quizdata[quizdata.Count - 1].Id = Convert.ToString(reader["idQuiz"]);
                quizdata[quizdata.Count - 1].Name = Convert.ToString(reader["Quizname"]);

                ObservableCollection<myQuiz> tempOC = new ObservableCollection<myQuiz>();
                tempOC.Add(new myQuiz() { Id = Convert.ToString(reader["idQuiz"]), Name = Convert.ToString(reader["Quizname"])});
                quiz.Add(tempOC);
            } 
            reader.Close();
            return quiz;
        }
        public List<string[]> vragenData(int Quizid)
        {
            List<string[]> list = new List<string[]>();
            string sql = @"select * from Question WHERE Quiz_idQuiz = @Quizid";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@Quizid", MySqlDbType.VarChar).Value = Quizid;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] question = new string[11];
                question[0] = Convert.ToString(reader["idQuestion"]);
                question[1] = Convert.ToString(reader["Question"]);
                question[2] = Convert.ToString(reader["image"]);
                int counter = 3;
                string sql2 = @"select * from answer WHERE Question_idQuestion = @Quizid";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                cmd2.Parameters.Add("@Quizid", MySqlDbType.VarChar).Value = question[0];
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    question[counter] = Convert.ToString(reader2["Answer"]);
                    counter++;
                    question[counter] = Convert.ToString(reader2["Correct"]);
                    counter++;

                }
                reader2.Close();

                list.Add(question);


            }
            reader.Close();
            return list;
        }

        public void quizopslaan()
        {
            
        }

















    }



}
