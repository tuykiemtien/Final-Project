using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using BusinessLogicLayer;
namespace GUI.Models
{
    public class EmployeeModel
    {
        private static EmployeeModel instance;

        public static EmployeeModel Instance
        {
            get { if (instance == null) instance = new EmployeeModel(); return EmployeeModel.instance; }
            private set => instance = value;
        }

        private EmployeeModel() { }

        public List<EmployeeDTO> GetAllEmployee()
        {
            return EmployeeBUS.Instance.GetAllEmployee();
        }
        public EmployeeDTO GetEmployeeById(int id)
        {
            return EmployeeBUS.Instance.GetEmployeeById(id);
        }

        public bool InsertNewEmployee(EmployeeDTO employee)
        {
            return EmployeeBUS.Instance.InsertNewEmployee(employee);
        }
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            return EmployeeBUS.Instance.UpdateEmployee(employee);
        }
        public bool DeleteEmployee(int id)
        {
            return EmployeeBUS.Instance.DeleteEmployee(id);
        }
    }
}