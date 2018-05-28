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
    public class ProductFormatRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public ProductFormatRepository()
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
        public void Create(ProductFormat model)
        {
            connection.Execute("INSERT INTO ProductFormat VALUES ( @ProductID, @Size, @Color, @StockQuantity, @Image)",
                new
                {
                    model.ProductID,
                    model.Size,
                    model.Color,
                    model.StockQuantity,
                    model.Image
                });
        }

        public void Update(ProductFormat model)
        {
            connection.Execute("UPDATE ProductFormat SET Size = @Size, Color = @Color, StockQuantity = @StockQuantity, Image=@Image WHERE ProductFormatID = @ProductFormatID",
                new
                {
                    model.Size,
                    model.Color,
                    model.StockQuantity,
                    model.Image,
                    model.ProductFormatID
                });
        }

        public void Delete(ProductFormat model)
        {
            connection.Execute("DELETE FROM ProductFormat WHERE ProductFormatID = @ProductFormatID",
                new
                {
                    model.ProductFormatID
                });
        }

        public ProductFormat FindById(int ProductFormatID)
        {
            var result = connection.Query<ProductFormat>("SELECT * FROM ProductFormat WHERE ProductFormatID = @ProductFormatID", 
                new
                {
                    ProductFormatID
                });
            ProductFormat productFormat = null;
            foreach (var item in result)
            {
                productFormat = item;
            }
            return productFormat;
        }

        public IEnumerable<ProductFormat> GetAll()
        {
            return connection.Query<ProductFormat>("SELECT * FROM ProductFormat ");
        }
    }
}
