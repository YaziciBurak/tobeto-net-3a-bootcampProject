using Core.Entities;

namespace Entities.Concrates;

public class User : BaseEntity<int>
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User()
    {
    }
    public User(int Id,string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password)
    {
        Id = Id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
    }

}
