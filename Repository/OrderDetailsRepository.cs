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
    public class OrderDetailsRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public OrderDetailsRepository()
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
        public void Create(OrderDetails model, IDbConnection connection)
        {
            connection.Execute("INSERT INTO OrderDetails VALUES (@OrderID, @ProductFormatID, @Quantity, @UnitPrice) ",
                new
                {
                    model.OrderID,
                    model.ProductFormatID,
                    model.Quantity,
                    model.UnitPrice
                });

            var request = new ProductFormatRepository();
            var product = request.FindById(model.ProductFormatID);
            if ((product.StockQuantity - model.Quantity) >= 0)
            {
                connection.Execute("UPDATE ProductFormat SET StockQuantity = StockQuantity - @Quantity WHERE ProductFormatID = @ProductFormatID ",
                new
                {
                    model.Quantity,
                    model.ProductFormatID
                });
            }
            else
            {
                throw (new Exception("No Quantity"));
            }
        }
        public void Update(OrderDetails model)
        {
            connection.Execute("UPDATE OrderDetails SET ProductFormatID = @ProductFormatID, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE OrderID = @OrderID",
                new
                {
                    model.ProductFormatID,
                    model.Quantity,
                    model.UnitPrice,
                    model.OrderID
                });
        }

        public void Delete(OrderDetails model)
        {
            connection.Execute("DELETE FROM OrderDetails WHERE OrderID = @OrderID",
                new
                {
                    model.OrderID
                });
        }

        public OrderDetails FindById(int OrderID)
        {
            var result = connection.Query<OrderDetails>("SELECT * FROM OrderDetails WHERE OrderID = @OrderID", 
                new
                {
                    OrderID
                });
            OrderDetails orderDetail = null;
            foreach (var item in result)
            {
                orderDetail = item;
            }
            return orderDetail;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return connection.Query<OrderDetails>("SELECT * FROM OrderDetails ");
        }
    }
}
