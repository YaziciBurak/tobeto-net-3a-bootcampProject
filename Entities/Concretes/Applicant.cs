using Entities.Concrates;

namespace Entities.Concretes;

public class Applicant : User
{

    public string About { get; set; }

    public virtual BlackList? BlackList { get; set; }

    public ICollection<Application> Applications { get; set; }
    public Applicant()
    {
        Applications = new HashSet<Application>();
    }

    public Applicant(int Id,string about)
    {
        Id = Id;
        About = about;
    }
}