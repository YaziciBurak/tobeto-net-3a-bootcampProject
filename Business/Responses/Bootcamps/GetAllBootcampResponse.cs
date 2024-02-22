﻿namespace Business.Responses.Bootcamps;

public class GetAllBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string InstructorFirstName { get; set; }

    public string InstructorLastName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
