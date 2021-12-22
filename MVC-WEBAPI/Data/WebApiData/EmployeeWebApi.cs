using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MVC_WEBAPI.Data.WebApiData
{
    public static class EmployeeWebApi
    {
        public static IEnumerable<Employee> GetEmployee()
        {
            IEnumerable<Employee> employee = null;
            using (HttpClient httpclient = new HttpClient())
            {
                string url = "http://localhost:50000/api/employee/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    employee = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Employee>>(response.Result);
                }
                return employee;
            }
        }
        public static Employee GetEmployee(int id)
        {
            Employee employee = null;
            using (HttpClient httpclient = new HttpClient())
            {
                string url = "http://localhost:50000/api/employee/" + id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    employee = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(response.Result);
                }
                return employee;
            }
        }
        public static bool EditEmployee(Employee emp)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "http://localhost:50000/api/employee/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public static bool CreateEmployee(Employee emp)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "http://localhost:50000/api/employee/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
       public static bool DeleteEmployee(int id)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(id);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "http://localhost:50000/api/employee/"+id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.DeleteAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}