﻿using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_WEBAPI.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> EmployeeTable { get; set; }
        public EmployeeDbContext() : base("EmployeeCon")
        {

        }
    }
}