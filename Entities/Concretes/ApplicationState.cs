using Core.Entities;
using Entities.Concretes;


namespace Entities.Entity;

public class ApplicationState : BaseEntity<int>
{

    public string Name { get; set; }

    public ICollection<Application> Applications { get; set; }

    public ApplicationState()
    {
        Applications = new HashSet<Application>();
    }
   
    
}