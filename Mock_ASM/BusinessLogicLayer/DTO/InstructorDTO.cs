using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO
{
    public class InstructorDTO
    {
        public int InstructorId { get; set; }

        public string InstructorName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
