using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTO
{
    public class StudentInfoDTO
    {
        public int StudentInfoId { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        public string StudentName { get; set; } = null!;

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        //public EmailAddressAttribute Email { get; set; } = null!;
        public string Email { get; set; } = null!;

        public enum SortField
        {
            StudentName, DateOfBirth, Phone, Email
        }
        public enum SortType
        {
            Ascending = 1,
            Descending = 2,
        }

    }   
}


