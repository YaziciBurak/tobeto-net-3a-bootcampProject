namespace Entities.Concrates;

public class Employee: User
{
    public string Position { get; set; }

    public Employee()
    {
        
    }
    public Employee(int userId, string position)
    {
        Id = userId;
        Position = position;
    }
}
