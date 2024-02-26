namespace Business.Responses.BlackList;

public class DeleteBlackListResponse
{
    public int Id { get; set; }
    public DateTime DeletedDate { get; set; } = DateTime.Now;
}
