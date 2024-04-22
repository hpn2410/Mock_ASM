using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Sorting
{
    public enum SortField
    {
        StudentName,
        DateOfBirth,
        Phone,
        Email
    }
    public enum SortType
    {
        Ascending = 1,
        Descending = 2,
    }
}
