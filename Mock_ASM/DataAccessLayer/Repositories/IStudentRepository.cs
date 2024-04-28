using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Students>> GetAll();
        Task<Students> GetById(int id);
        Task<Students> Post(Students student);
        Task<Students> Put(Students student);
        Task<bool> Delete(int id);
    }
}
