﻿using Core.Entities;
using Entities.Entity;

namespace Entities.Concretes;

public class Application : BaseEntity<int>
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }

    public Bootcamp Bootcamp { get; set; }
    public virtual Applicant? Applicant { get; set; }

    public virtual ApplicationState? ApplicationState { get; set; }

    public Application()
    {

    }


}