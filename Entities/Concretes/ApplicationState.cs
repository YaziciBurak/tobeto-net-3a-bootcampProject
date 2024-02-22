using Core.Entities;

namespace Entities.Concretes;

public class ApplicationState : BaseEntity<int>
{

    public string Name { get; set; }

    public ICollection<Application> Applications { get; set; }

    public ApplicationState()
    {
        Applications = new HashSet<Application>();
    }
    public ApplicationState(int userId, string name)
    {
        Id = userId;
        Name = name;
    }
}