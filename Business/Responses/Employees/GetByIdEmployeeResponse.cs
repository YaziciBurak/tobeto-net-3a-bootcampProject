namespace Business.Responses.Employees;

public class GetByIdEmployeeResponse
{
    public int Id { get; set; }
    public string EmployeeFirstName { get; set; }

    public string EmployeeLastName { get; set; }
    public string Position { get; set; }
}
