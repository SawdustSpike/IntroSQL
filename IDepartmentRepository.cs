using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSQL

{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();

        public void InsertDepartment();
      
        public void DeleteDepartment(int DepartmentID);


     
    }
}
