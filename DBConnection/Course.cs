namespace DBConnection;

public class Course
{
    private int id { get; set; }
    private string name { get; set; }

    public Course(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public string ToString()
    {
        return $"ID: {id}, Name: {name}";
    }
}