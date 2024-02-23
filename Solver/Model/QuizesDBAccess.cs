using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Model
{
    internal class QuizesDBAccess
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\grazi\source\repos\Generator\Generator\database.db");

        public static List<Quiz> ReadData()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            List<Quiz> quizes = new List<Quiz>();
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Quiz";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id_quiz"]);
                string nazwa = reader["Nazwa"].ToString();
                string idPyt = reader["Id_pytania"].ToString();

                Quiz quiz = new Quiz(id, Decrypt(nazwa,"xyz"), Decrypt(idPyt,"xyz"));
                quizes.Add(quiz);
            }
            conn.Close();
            return quizes;
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
