using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public string StudentCode { get; set; } = null!;

        public int StudentInfoId { get; set; }

        public int ClassId { get; set; }
    }
}


