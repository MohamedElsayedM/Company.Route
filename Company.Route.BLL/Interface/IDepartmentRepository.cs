using Company.Route.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL.Interface
{
    public interface IDepartmentRepository
    {
       IEnumerable<Department> GetAll();
        Department? Get(int id);

        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);


    }
}
