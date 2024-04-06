using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassCode { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
