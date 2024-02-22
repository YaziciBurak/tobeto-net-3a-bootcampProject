using Core.Entities;
using Entities.Concrates;

namespace Entities.Concretes;

public class Bootcamp : BaseEntity<int>
{
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Instructor? Instructor { get; set; }
    public virtual BootcampState? BootcampState { get; set; }
    public ICollection<Application> Applications { get; set; }
    public Bootcamp()
    {
        Applications = new HashSet<Application>();
    }

    public Bootcamp(int userId, string name, int instructorId, int bootcampState, DateTime startDate, DateTime endDate):this()
    {
        Id = userId;
        Name = name;
        InstructorId = instructorId;
        BootcampStateId = bootcampState;
        StartDate = startDate;
        EndDate = endDate;
    }

    
}