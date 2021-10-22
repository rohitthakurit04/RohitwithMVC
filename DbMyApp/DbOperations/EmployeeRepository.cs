using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAppModels;
using System.Data.SqlClient;


namespace DbMyApp.DbOperations
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDbEntities())
            {
                Employee emp = new Employee()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Code = model.Code,
                    AddressId = model.AddressId,
                    Address = new Address()
                    {
                        Details = model.Address.Details,
                        Country = model.Address.Country,
                        State = model.Address.State,
                        Id = model.AddressId



                    }
                };

                context.Employee.Add(emp);
                context.SaveChanges();

                return emp.Id;
            }

        }

        public List<EmployeeModel> GetAllEmpolyees()
        {
            using (var context = new EmployeeDbEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                        AddressId = x.AddressId,
                        Code = x.Code,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = new AddressModel()
                        {
                            Id = x.Address.Id,
                            Details = x.Address.Details,
                            Country = x.Address.Country,
                            State = x.Address.State
                        }

                    }).ToList();

                return result;

            }
        }

        public EmployeeModel GetEmpolyee(int id)
        {
            using (var context = new EmployeeDbEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                        AddressId = x.AddressId,
                        Code = x.Code,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = new AddressModel()
                        {
                            Id = x.Address.Id,
                            Details = x.Address.Details,
                            Country = x.Address.Country,
                            State = x.Address.State
                        }

                    }).FirstOrDefault();

                return result;

            }
        }

        public bool UpdateEmpolyee(int id, EmployeeModel model)
        {
            using (var context = new EmployeeDbEntities())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee != null)
                {
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Code = model.Code;
                }
                context.SaveChanges();
                return true;
            }

        }


        public bool DeleteEmployee(int id)
        {
            using (var context = new EmployeeDbEntities())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    context.Employee.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
