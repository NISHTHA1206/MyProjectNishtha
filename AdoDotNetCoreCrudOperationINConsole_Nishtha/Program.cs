using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetCoreCrudOperationINConsole_Nishtha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "Server=LAPTOP-NONED55P\\SQLSERVER2022;Database=Employeedb;User Id=sa;Password=user123;Trusted_Connection=True;TrustServerCertificate=True;";
                //Console.WriteLine("connection sucessfull");

                //Calling GetAllEmployees
                GetAllEmployees(connectionString);
               
                //Calling GetEmployeeByID
                int EmployeeId = 1;
                GetEmployeeByID(connectionString, EmployeeId);

                //Calling CreateEmployeeWithAddress
                string firstName = "Ramesh";
                string lastName = "Sharma";
                string email = "Ramesh@Example.com";
                string street = "123 Patia";
                string city = "BBSR";
                string state = "India";
                string postalCode = "755019";

                CreateEmployeeWithAddress(connectionString, firstName, lastName, email, street, city, state, postalCode);

                //Calling UpdateEmployeeWithAddress
                int employeeId = 3;
                firstName = "Rakesh";
                lastName = "Sharma";
                email = "Rakesh@Example.com";
                street = "3456 Patia";
                city = "CTC";
                state = "India";
                postalCode = "755024";
                int addressID = 3;

                UpdateEmployeeWithAddress(connectionString, employeeId, firstName, lastName, email, street, city, state, postalCode, addressID);

                //Calling
                employeeId = 3;
                DeleteEmployee(connectionString, employeeId);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong:{ex.Message}");
            }

            

        }
        static void GetAllEmployees(string connectionString)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    Console.WriteLine("GetAllEmployees Stored Procedure Called");
                    SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"EmployeeID:{reader["EmployeeId"]},FirstName:{reader["FirstName"]},LastName:{reader["LastName"]},Email:{reader["Email"]}");
                        Console.WriteLine($"Addresses:{reader["Street"]},{reader["City"]},{reader["States"]},{reader["PostalCode"]}\n");
                    }
                    reader.Close();
                    connection.Close();
                
            }

        }
        static void GetEmployeeByID(string connectionString, int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("GetEmployeeByID Stored Procedure Called");
                SqlCommand command = new SqlCommand("GetallEmployeeId", connection);
                command.CommandType = CommandType.StoredProcedure;

                //Add parameter for EmployeeID
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(value: $"Employees:{reader["FirstName"]},{reader["LastName"]},Email: {reader["Email"]}");
                    Console.WriteLine($"Addresses:{reader["Street"]},{reader["City"]},{reader["States"]},{reader["PostalCode"]}");

                }
                reader.Close();
                connection.Close();
            }
        }
        static void CreateEmployeeWithAddress(string connectionString, string firstName,string lastName,string email,string street,string city,string states,string postalCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("CreateEmployeeWithAddress Stored Procedure Called");
                SqlCommand command = new SqlCommand("CreateEmployeeWithAddresses", connection);
                command.CommandType = CommandType.StoredProcedure;

                //Add parameters for Employees and Address
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@States", states);
                command.Parameters.AddWithValue("@PostalCode", postalCode);
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Employee and Address created successfully.");
                connection.Close();
            }

        }
        static void UpdateEmployeeWithAddress(string connectionString, int employeeID,string firstName, string lastName, string email, string street, string city, string states, string postalCode,int addressID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("UpdateEmployeeWithAddress Stored Procedure Called");
                SqlCommand command = new SqlCommand("UpdateEmployeeWithAddress", connection);
                command.CommandType = CommandType.StoredProcedure;
                //Add parameters for Employee and Address
                command.Parameters.AddWithValue("@EmployeeID",employeeID);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@States", states);
                command.Parameters.AddWithValue("@PostalCode", postalCode);
                command.Parameters.AddWithValue("@AddressID",addressID);
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Employee and Address updated successfully");
                connection.Close();

            }
        }
        static void DeleteEmployee(string connectionString,int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("DeleteEmployee Stored Procedure Called");
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                //Add parameter for EmployeeID
                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    Console.WriteLine("Employee and their Address deleted successfully");
                }
                else
                {
                    Console.WriteLine("Employee not found");
                }
                connection.Close();
            }
        }
    }
}


