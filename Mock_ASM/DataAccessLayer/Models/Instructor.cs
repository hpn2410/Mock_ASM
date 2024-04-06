using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string InstructorName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
