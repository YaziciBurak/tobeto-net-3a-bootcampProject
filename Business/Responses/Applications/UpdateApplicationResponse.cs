namespace Business.Responses.Applications;

public class UpdateApplicationResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string ApplicantFirstName { get; set; }
    public string  ApplicantLastName { get; set; }
    public string BootcampName { get; set; }
    public int ApplicationStateName { get; set; }
}
