using BuildSchool.MvcSolution.OnlineStore.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class SalesRepository
    {
        public void Create(Sales model, IDbConnection connection)
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

        public void Update(Sales model, IDbConnection connection)
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

        public void Delete(Sales model, IDbConnection connection)
        {
            connection.Execute("DELETE FROM Sales WHERE SalesID = @SalesID",
                new
                {
                    model.SalesID
                });
        }

        public Sales FindById(int SalesID, IDbConnection connection)
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
        public IEnumerable<Sales> GetAll(IDbConnection connection)
        {
            return connection.Query<Sales>("SELECT * FROM Sales ");
        }
    }
}
