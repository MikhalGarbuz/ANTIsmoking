using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANTIsmoking.Models;
using MySql.Data.MySqlClient;

namespace ANTIsmoking.Data
{
    public class ChDbContext
    {
        public string connectionString = "server=localhost;port=3306;database=antismoking;uid=root;password=Mikhal-1104;";
        public string SelectComm(int cumpNum)
        {
            string outputString = "";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = $"SELECT name, cum{cumpNum} FROM chasertab";

                    using (MySqlCommand command1 = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    outputString += reader[i].ToString() + " | ";
                                }
                                outputString += Environment.NewLine;

                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return outputString;
        }
        public string AdminCheck(int cumpNum)
        {
            string outputString = "";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = $"SELECT id, name, cum{cumpNum} FROM chasertab";

                    using (MySqlCommand command1 = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    outputString += reader[i].ToString() + " | ";
                                }
                                outputString += Environment.NewLine;

                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return outputString;
        }
        public void OutputComm()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM chasertab";

                    using (MySqlCommand command1 = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write(reader[i] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void DecrementComm(int id, int cumpNum, int decrementValue)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string decrementQuery = $"UPDATE chasertab SET cum{cumpNum} = cum{cumpNum} - @DecrementValue WHERE id={id}";

                    using (MySqlCommand command = new MySqlCommand(decrementQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DecrementValue", decrementValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"{rowsAffected} row(s) decremented.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void IncrementComm(int id, int cumpNum, int incrementValue)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string incrementQuery = $"UPDATE chasertab SET cum{cumpNum} = cum{cumpNum} + @IncrementValue WHERE id={id}";

                    using (MySqlCommand command = new MySqlCommand(incrementQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IncrementValue", incrementValue);

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"{rowsAffected} row(s) decremented.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void InsertComm(List<Chaser> chaserList)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO chasertab (id, name, cum3, cum8, cum11, cum12, cum14) VALUES (@id, @name, @cum3, @cum8, @cum11, @cum12, @cum14)";

                    foreach (var myObject in chaserList)
                    {
                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@id", myObject.id);
                            command.Parameters.AddWithValue("@name", myObject.name);
                            command.Parameters.AddWithValue("@cum1", myObject.cum3);
                            command.Parameters.AddWithValue("@cum1", myObject.cum8);
                            command.Parameters.AddWithValue("@cum2", myObject.cum11);
                            command.Parameters.AddWithValue("@cum1", myObject.cum12);
                            command.Parameters.AddWithValue("@cum3", myObject.cum14);
                            int rowsAffected = command.ExecuteNonQuery();

                            Console.WriteLine($"{rowsAffected} row(s) inserted.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void DeleteComm()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM chasertab";
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) deleted.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
