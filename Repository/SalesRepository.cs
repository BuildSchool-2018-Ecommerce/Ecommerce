using BuildSchool.MvcSolution.OnlineStore.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class SalesRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public SalesRepository()
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb")))
            {
                sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");
            }
            else
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(Sales model)
        {
            connection.Execute("INSERT INTO Sales VALUES ( @ProductID, @Sale, @StartDate, @EndDate )",
                new
                {
                    model.ProductID,
                    model.Sale,
                    model.StartDate,
                    model.EndDate
                });
        }

        public void Update(Sales model)
        {
            connection.Execute("UPDATE Sales SET ProductID = @ProductID, Sale = @Sale, StartDate = @StartDate, EndDate = @EndDate WHERE SalesID = @SalesID",
                new
                {
                    model.ProductID,
                    model.Sale,
                    model.StartDate,
                    model.EndDate,
                    model.SalesID
                });
        }

        public void Delete(Sales model)
        {
            connection.Execute("DELETE FROM Sales WHERE SalesID = @SalesID",
                new
                {
                    model.SalesID
                });
        }

        public Sales FindById(int SalesID)
        {
            var result = connection.Query<Sales>("SELECT * FROM Sales WHERE SalesID = @SalesID",
                new
                {
                    SalesID
                });
            Sales sales = null;
            foreach (var item in result)
            {
                sales = item;
            }
            return sales;
        }
        public IEnumerable<Sales> GetAll()
        {
            return connection.Query<Sales>("SELECT * FROM Sales ");
        }
    }
}
