﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class StudentInfoes
{
    public int StudentInfoId { get; set; }

    public string StudentName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Students Student { get; set; }
    //public enum SortField
    //{
    //    StudentName, DateOfBirth, Phone, Email
    //}
    //public enum SortType
    //{
    //    Ascending = 1,
    //    Descending = 2,
    //}
}
