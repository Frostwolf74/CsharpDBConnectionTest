namespace DBConnection;

public class Student
{
    private int id { get; set; }
    private string name { get; set; }
    private double gpa { get; set; }
    private List<Course> courses { get; set; }

    public Student(int id, string name, double gpa, List<Course> courses)
    {
        this.id = id;
        this.name = name;
        this.gpa = gpa;
        this.courses = courses;
    }

    public Student()
    {
        Console.WriteLine("id: ");
        this.id = int.Parse(Console.ReadLine());

        Console.WriteLine("name: ");
        this.name = Console.ReadLine();
        
        Console.WriteLine("gpa: ");
        this.gpa = double.Parse(Console.ReadLine());
    }

    public string ToString()
    {
        return $"ID: {id}, Name: {name}, GPA: {gpa}";
    }
}