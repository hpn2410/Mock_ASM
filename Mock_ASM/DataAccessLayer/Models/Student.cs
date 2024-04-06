using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentCode { get; set; } = null!;

    public int StudentInfoId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual StudentInfo StudentInfo { get; set; } = null!;
}
