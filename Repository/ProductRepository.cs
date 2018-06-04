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
            sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

            if (string.IsNullOrEmpty(sql))
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
        public IEnumerable<NewProduct> NewProduct()
        {
            return connection.Query<NewProduct>("SELECT * FROM NewProduct");
        }
        public IEnumerable<SalesProduct> SalesProduct()
        {
            return connection.Query<SalesProduct>("SELECT * FROM SalesProduct");
        }
        public IEnumerable<Top8Product> Top8Product()
        {
            return connection.Query<Top8Product>("SELECT * FROM Top8Product");
        }
        public IEnumerable<AllProduct> AllProduct()
        {
            return connection.Query<AllProduct>("SELECT * FROM AllProduct");
        }
        public IEnumerable<CategoryProduct> CategoryProduct(int categoryid)
        {
            return connection.Query<CategoryProduct>("CategoryProduct",
                new
                {
                    categoryid
                }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<FindProductByProductID> FindProductByProductID(int productid)
        {
            return connection.Query<FindProductByProductID>("FindProductByProductID",
                new
                {
                    productid
                }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<ProductSizeAndQuantity> ProductSize(int productid, string color)
        {
            return connection.Query<ProductSizeAndQuantity>("ProductSize",
                new
                {
                    productid,
                    color
                }, commandType: CommandType.StoredProcedure);
        }
        public ProductSizeAndQuantity ProductQuantity(int productid, string color, string size)
        {
            var result = connection.Query<ProductSizeAndQuantity>("ProductQuantity",
                new
                {
                    productid,
                    color,
                    size
                }, commandType: CommandType.StoredProcedure);
            ProductSizeAndQuantity quntity = null;
            foreach(var item in result)
            {
                quntity = item;
            }
            return quntity;
        }
        public int MaxUnitPrice()
        {
            var result = connection.Query<int>("SELECT MAX(UnitPrice) as UnitPrice FROM Products");
            int price = 0;
            foreach(var item in result)
            {
                price = item;
            }
            return price;
        }
        public IEnumerable<CategoryProduct> CategoryProductNotEqualProductID(int categoryid, int productid)
        {
            return connection.Query<CategoryProduct>("CategoryProductNotEqualProductID",
                new
                {
                    categoryid,
                    productid
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
