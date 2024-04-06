using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ClassInstructor
    {
        public int ClassId { get; set; }
        public int InstructorId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
