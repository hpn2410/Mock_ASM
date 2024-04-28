using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IClassRepository
    {
        Task<List<Classes>> GetAll();
        Task<Classes> GetById(int id);
        Task<Classes> Post(Classes studentClass);
        Task<Classes> Put(Classes studentClass);
        Task<bool> Delete(int id);
    }
}
