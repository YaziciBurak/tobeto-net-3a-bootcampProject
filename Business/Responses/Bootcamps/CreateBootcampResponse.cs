namespace Business.Responses.Bootcamps;

public class CreateBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string BootcampStateName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
