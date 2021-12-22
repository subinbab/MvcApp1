using ModelLayer;
using MVC_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi1.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employeelist;
        Employee employee;
        
        public IEnumerable<Employee> Get()
        {
            using(EmployeeDbContext EmployeeDb = new EmployeeDbContext())
            {
                 employeelist = EmployeeDb.EmployeeTable.ToList();
            }
            return employeelist;
        }
        public Employee Get(int id)
        {
            using(EmployeeDbContext EmployeeDb = new EmployeeDbContext())
            {
                employee = EmployeeDb.EmployeeTable.FirstOrDefault(x => x.EmpId.Equals(id));
            }
            return employee;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Employee emp)
        {
            try
            {
                using (EmployeeDbContext EmployeeDb = new EmployeeDbContext())
                {
                    EmployeeDb.EmployeeTable.Add(emp);
                    EmployeeDb.SaveChanges();
                }
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch(Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        public HttpResponseMessage Put([FromBody] Employee emp)
        {
            try
            {
                using(EmployeeDbContext EmployeeDb = new EmployeeDbContext())
                {
                    var EmployeeUpdate = EmployeeDb.EmployeeTable.FirstOrDefault(x => x.EmpId.Equals(emp.EmpId));
                    if(EmployeeUpdate != null)
                    {
                        EmployeeUpdate.EmpId = emp.EmpId;

                        EmployeeUpdate.EmpName = emp.EmpName;
                        EmployeeUpdate.EmpPosition = emp.EmpPosition;
                        EmployeeDb.SaveChanges();
                    }
                }
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch(Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDbContext EmployeeDb = new EmployeeDbContext())
                {
                    var EmployeeUpdate = EmployeeDb.EmployeeTable.FirstOrDefault(x => x.EmpId.Equals(id));
                    if (EmployeeUpdate != null)
                    {
                        EmployeeDb.EmployeeTable.Remove(EmployeeUpdate);
                    }
                }
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
    }
}
