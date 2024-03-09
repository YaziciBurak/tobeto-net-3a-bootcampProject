using Core.Utilities.Security.Entities;
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

    public Applicant(int id,string about)
    {
        Id = id;
        About = about;
    }
}