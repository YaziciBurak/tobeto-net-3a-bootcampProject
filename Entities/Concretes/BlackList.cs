using Core.Entities;

namespace Entities.Concretes;

public class BlackList : BaseEntity<int>
{
    public int ApplicantId { get; set; }
    public string Reason { get; set; }

    public DateTime Date {  get; set; }

    public virtual Applicant? Applicant { get; set; }

    public BlackList()
    {
        
    }
}
