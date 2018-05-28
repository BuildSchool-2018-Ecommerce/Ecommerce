using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Dapper;
using System.Configuration;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class EmployeesRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public EmployeesRepository()
        {
            sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

            if (string.IsNullOrEmpty(sql))
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(Employees model)
        {
            connection.Execute("INSERT INTO Employees(Name, Phone, HireDate, Email, Image) VALUES ( @Name, @Phone, @HireDate, @Email, @Image)",
                new
                {
                    model.Name,
                    model.Phone,
                    model.HireDate,
                    model.Email,
                    model.Image
                });
        }

        public void Update(Employees model)
        {
            connection.Execute("UPDATE Employees SET Name=@Name, Phone=@Phone, Email=@Email, Image=@Image WHERE EmployeeID = @EmployeeID",
                new
                {
                    model.Name,
                    model.Phone,
                    model.Email,
                    model.Image,
                    model.EmployeeID
                });
        }
        public void UpdateGUID(Employees model)
        {
            connection.Execute("UPDATE Employees SET EmployeeGUID=@EmployeeGUID WHERE EmployeeID = @EmployeeID",
                new
                {
                    model.EmployeeGUID,
                    model.EmployeeID
                });
        }

        public void Delete(Employees model)
        {
            connection.Execute("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", 
                new
                {
                    model.EmployeeID
                });
        }

        public Employees FindById(int EmployeeID)
        {
            var result = connection.Query<Employees>("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", 
                new
                {
                    EmployeeID
                });
            Employees employee = null;
            foreach (var item in result)
            {
                employee = item;
            }
            return employee;
        }

        public IEnumerable<Employees> GetAll()
        {
            return connection.Query<Employees>("SELECT * FROM employees");
        }

        public IEnumerable<Employees> FindByHireYear(int startYear, int endYear)
        {
            return connection.Query<Employees>("SELECT * FROM Employees WHERE YEAR(HireDate) BETWEEN @startYear AND @endYear ORDER BY HireDate DESC", 
                new
                {
                    startYear, endYear
                });
        }
        public IEnumerable<GetHowLongHireDate> GetHowLongHireDate()
        {
            return connection.Query<GetHowLongHireDate>("GetHowLongHireDate", 
                new
                {

                }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Employees> FindByName(string Name)
        {
            return connection.Query<Employees>("SELECT * FROM Employees WHERE Name = @Name", 
                new
                {
                    Name
                });
        }
    }
}
