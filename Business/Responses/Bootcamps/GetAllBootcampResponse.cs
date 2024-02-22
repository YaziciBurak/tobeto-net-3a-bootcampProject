namespace Business.Responses.Bootcamps;

public class GetAllBootcampResponse
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
