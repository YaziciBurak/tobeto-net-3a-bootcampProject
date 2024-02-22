using Entities.Concrates;

namespace Entities.Concretes;

public class Instructor : User 
{
    public string CompanyName { get; set; }

    public ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public Instructor(int userId, string companyName)
    {
        Id = userId;
        CompanyName = companyName;
    }
}