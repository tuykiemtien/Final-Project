using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class EmployeeBUS
    {
        
        private static EmployeeBUS instance;

        public static EmployeeBUS Instance
        {
            get { if (instance == null) instance = new EmployeeBUS(); return EmployeeBUS.instance; }
            private set => instance = value;
        }

        private EmployeeBUS() { }



        public List<EmployeeDTO> GetAllEmployee()
        {
            List<EmployeeDTO> list = EmployeeDAO.Instance.GetAllEmployee();
           
            return list;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            EmployeeDTO list = EmployeeDAO.Instance.GetEmployeeById(id);
            
            return list;
        }

        public bool InsertNewEmployee(EmployeeDTO employee)
        {
            return EmployeeDAO.Instance.InsertNewEmployee(employee);
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            return EmployeeDAO.Instance.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return EmployeeDAO.Instance.DeleteEmployee(id);
        }
    }
}
