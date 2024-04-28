using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Classes
{
    public int ClassId { get; set; }

    public string ClassCode { get; set; } = null!;

    public virtual ICollection<Students> Students { get; set; } = new List<Students>();

    public virtual ICollection<Instructors> Instructors { get; set; } = new List<Instructors>();
}
