using System.Dynamic;

namespace DBConnection;

public class DatabaseBuilder
{
    private int[] id;
    private string[] name;
    private double[] gpa;
    
    public DatabaseBuilder(int[] id, string[] name, double[] gpa)
    {
        this.id = id;
        this.name = name;
        this.gpa = gpa;
    }

    public int[] GetId()
    {
        return id;
    }

    public string[] GetName()
    {
        return name;
    }

    public double[] GetGpa()
    {
        return gpa;
    }
}