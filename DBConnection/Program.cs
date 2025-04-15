using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace DBConnection;

using MySqlConnector;

public static class Program
{
    static void Main(string[] args)
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "demo1",
            UserID = "root",
            Password = "password"
        };

        MySqlConnection connection = new MySqlConnection(builder.ToString());
        connection.Open();

        string query = "SELECT * FROM student";
        
        PrintDatabase(connection);

        Console.WriteLine("Enter student id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter student name: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Enter student's gpa: ");
        double gpa = double.TryParse(Console.ReadLine(), out gpa) ? gpa : 0.0;

        query = 
            $"INSERT INTO student VALUES({id}, '{name}', {gpa})"
        ;
        
        MySqlCommand command = new MySqlCommand(query, connection);

        command.ExecuteNonQuery();
        
        PrintDatabase(connection);

        List<Student> students = ReadDatabase(connection);

        Console.WriteLine("\n\nStudents (From object): ");
        
        foreach (Student student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    public static void PrintDatabase(MySqlConnection connection)
    {
        string query = "SELECT * FROM student";
        
        MySqlCommand command = new MySqlCommand(query, connection);
        
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read()) // read all available columns, returns true until there aren't any rows left
            {
                int? idRead = reader.GetInt32("id");
                string nameRead = reader.GetString("name");
                double gpaRead = reader.GetDouble("gpa");
                
                Console.WriteLine($"ID: {idRead}, Name: {nameRead}, GPA: {gpaRead}");
            }
        }
    }
    
    public static List<Student> ReadDatabase(MySqlConnection connection, string query = "SELECT * FROM student")
    {
        List<Student> students = new List<Student>();
        
        MySqlCommand command = new MySqlCommand(query, connection);
        
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read()) // read all available columns, returns true until there aren't any rows left
            {
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");
                double gpa = reader.GetDouble("gpa");
                List<Course> courses = new List<Course>();
                
                students.Add(new Student(id, name, gpa, course));
            }
        }

        return students;
    }
}