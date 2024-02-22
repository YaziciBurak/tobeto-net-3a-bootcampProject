using Entities.Concrates;

namespace Entities.Concretes;

public class Applicant : User
{

    public string About { get; set; }

    public ICollection<Application> Applications { get; set; }
    public Applicant()
    {
        Applications = new HashSet<Application>();
    }

    public Applicant(int userId,string about)
    {
        Id = userId;
        About = about;
    }
}