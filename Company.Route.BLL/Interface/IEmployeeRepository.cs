using Company.Route.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        
        List<Employee> GetByName(string name);
    }
}
