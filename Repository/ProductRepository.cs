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
using Utils;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class ProductRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public ProductRepository()
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
        public void Create(Product model)
        {
            connection.Execute("INSERT INTO Products VALUES ( @ProductName, @UnitPrice, @Description, @CategoryID, @ShelfDate)",
                new
                {
                    model.ProductName,
                    model.UnitPrice,
                    model.Description,
                    model.CategoryID,
                    model.ShelfDate
                });
        }

        public void Update(Product model)
        {
            connection.Execute("UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, Description = @Description, CategoryID = @CategoryID WHERE ProductID = @ProductID",
                new
                {
                    model.ProductName,
                    model.UnitPrice,
                    model.Description,
                    model.CategoryID,
                    model.ProductID
                });
        }

        public void Delete(Product model)
        {
            connection.Execute("DELETE FROM Products WHERE ProductID = @ProductID",
                new
                {
                    model.ProductID
                });
        }

        public Product FindById(int ProductID)
        {
            var result = connection.Query<Product>("SELECT * FROM Products WHERE ProductID = @ProductID", 
                new
                {
                    ProductID
                });
            Product product = null;
            foreach (var item in result)
            {
                product = item;
            }
            return product;
        }
        public IEnumerable<GetProductOrder> GetHotProduct()
        {
            var affectedRows = connection.Query<GetProductOrder>("GetProductOrder", 
                new
                {

                },commandType: CommandType.StoredProcedure);
            return affectedRows;
        }
        public IEnumerable<Product> FindProductByUnitPrice(decimal lower, decimal upper)
        {
            return connection.Query<Product>("FindProductByUnitPrice", 
                new
                {
                    lower,
                    upper
                }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<FindProductFormatByProductID> FindProductFormatByProductID(int productid)
        {
            return connection.Query<FindProductFormatByProductID>("FindProductFormatByProductID",
                new
                {
                    productid
                }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Product> FindByProductName(string ProductName)
        {
            return connection.Query<Product>("SELECT * FROM Products WHERE ProductName LIKE @ProductName",
                new
                {
                    ProductName
                });
        }
        public IEnumerable<Product> GetAll()
        {
            return connection.Query<Product>("SELECT * FROM Products");
        }
    }
}
