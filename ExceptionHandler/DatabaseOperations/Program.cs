using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=COGNINE-L22;Database=MyApplication;Integrated Security=True;";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO UserE VALUES ('123','1234','12345',12344,22)";
                //string insertQuery="INSERT INTO User VALUES('123','1234','12345',12344,22)";
                //string insertQuery="INSERT INTO User VALUES('123','1234','12345',12344,22,23);

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value1", "DataValue1");
                    command.Parameters.AddWithValue("@Value2", "DataValue2");

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows were affected.");
                    }
                }

                connection.Close();
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("A SQL exception occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
