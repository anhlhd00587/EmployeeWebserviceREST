using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeWebserviceREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeNew.svc or EmployeeNew.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeNew : IEmployeeNew
    {
        EmployeeDataDataContext db = new EmployeeDataDataContext();
        public bool AddEmployee(Employee eml)
        {
            try
            {
                db.Employees.InsertOnSubmit(eml);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteEmployee(int idE)
        {
            try
            {
                Employee employeeToDelete =
                    (from employee in db.Employees where employee.empID == idE select employee).Single();
                db.Employees.DeleteOnSubmit(employeeToDelete);
                db.SubmitChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetProductList()
        {
            try
            {
                return (from employee in db.Employees select employee).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateEmployee(Employee eml)
        {
            Employee employeeToModify =
                (from employee in db.Employees where employee.empID == eml.empID select employee).Single();
            employeeToModify.Age = eml.Age;
            employeeToModify.Address = eml.Address;
            employeeToModify.LastName = eml.LastName;
            employeeToModify.FirsName = eml.FirsName;
            db.SubmitChanges();
            return true;
        }
    }
}
