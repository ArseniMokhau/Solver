using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Solver.Model
{
    public static class DataAccess
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\grazi\source\repos\Generator\Generator\database.db");

        public static List<Question> ReadData(List<string> questionIds)
        {

            List<Question> questions = new List<Question>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    string placeholders = string.Join(",", questionIds);
                    command.CommandText = $"SELECT * FROM Pytanie WHERE Id IN ({placeholders})";

                    for (int i = 0; i < questionIds.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@id{i}", questionIds[i]);
                    }

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string questionText = Decrypt(reader["Question"].ToString(),"xyz");
                            List<string> options = new List<string>
                            {
                                Decrypt(reader["Option1"].ToString(),"xyz"),
                                Decrypt(reader["Option2"].ToString(),"xyz"),
                                Decrypt(reader["Option3"].ToString(),"xyz"),
                                Decrypt(reader["Option4"].ToString(),"xyz")
                            };
                            List<bool> answers = new List<bool>
                            {
                                Convert.ToBoolean(reader["Answer1"]),
                                Convert.ToBoolean(reader["Answer2"]),
                                Convert.ToBoolean(reader["Answer3"]),
                                Convert.ToBoolean(reader["Answer4"])
                            };

                            Question question = new Question(id, questionText, options, answers);
                            questions.Add(question);
                        }
                    }
                }
            }

            return questions;
        }
        public static string Decrypt(string encryptedText, string password)
        {
            byte[] salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (var aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(password, salt);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    byte[] plainBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    return Encoding.UTF8.GetString(plainBytes);
                }
            }
        }
    }
}
