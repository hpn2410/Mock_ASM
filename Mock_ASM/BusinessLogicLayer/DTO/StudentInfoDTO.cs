using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO
{
    public class StudentInfoDTO
    {
        public int StudentInfoId { get; set; }

        public string StudentName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}


