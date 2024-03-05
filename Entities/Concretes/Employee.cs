namespace Entities.Concrates;

public class Employee: User
{
    public string Position { get; set; }

    public Employee()
    {

    }

    public Employee(int id,string position)
    {
        Id = id;
        Position = position;
    }
}
