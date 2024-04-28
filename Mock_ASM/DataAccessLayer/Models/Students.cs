using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Students
{
    public int StudentId { get; set; }

    public string StudentCode { get; set; } = null!;

    public int StudentInfoId { get; set; }

    public int ClassId { get; set; }

    public virtual Classes Class { get; set; } = null!;

    public virtual StudentInfoes StudentInfo { get; set; } = null!;
}
