﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSQL
{
    public class DapperDepartmentRepository : IDepartmentRepository

    {
        private readonly IDbConnection _connection;
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void DeleteDepartment(int DepartmentID)
        {
            _connection.Execute($"DELETE FROM departments WHERE DepartmentID = {DepartmentID}");
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
             new { departmentName = newDepartmentName });
        }

        public void InsertDepartment()
        {
            throw new NotImplementedException();
        }
    }
}
