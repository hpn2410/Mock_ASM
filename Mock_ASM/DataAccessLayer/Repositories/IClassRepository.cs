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
        Task<List<Class>> GetAll();
        Task<Class> GetById(int id);
        Task<Class> Post(Class studentClass);
        Task<Class> Put(Class studentClass);
        Task<bool> Delete(int id);
    }
}
