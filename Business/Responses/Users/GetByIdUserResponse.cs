namespace Business.Responses.Users;

public class GetByIdUserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
}
