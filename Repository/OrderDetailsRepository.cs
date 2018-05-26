using BuildSchool.MvcSolution.OnlineStore.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class OrderDetailsRepository
    {
        public void Create(OrderDetails model, SqlConnection connection, IDbTransaction transaction)
        {
            //SqlConnection connection = new SqlConnection(
            //    "data source=.; database=Commerce; integrated security=true");
            var a = connection.Query<Orders>("INSERT INTO OrderDetails VALUES (@OrderID, @ProductFormatID, @Quantity, @UnitPrice) ",
                new { model.OrderID, model.ProductFormatID, model.Quantity, model.UnitPrice }, transaction);

            var request = new ProductFormatRepository();
            var product = request.FindById(model.ProductFormatID);
            if ((product.StockQuantity - model.Quantity) >= 0)
            {
                var b = connection.Query<Orders>("UPDATE ProductFormat SET StockQuantity = StockQuantity - @Quantity WHERE ProductFormatID = @ProductFormatID ",
                new { model.Quantity, model.ProductFormatID }, transaction);
            }
            else
            {
                throw (new Exception("No Quantity"));
            }
        }
        public void Update(OrderDetails model)
        {
            IDbConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");
            connection.Execute("UPDATE OrderDetails SET ProductFormatID = @ProductFormatID, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE OrderID = @OrderID",
                new { model.ProductFormatID, model.Quantity, model.UnitPrice, model.OrderID });

            //var sql = "UPDATE OrderDetails SET ProductFormatID = @ProductFormatID, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE OrderID = @OrderID";

            //SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@OrderID", model.OrderID);
            //command.Parameters.AddWithValue("@ProductFormatID", model.ProductFormatID);
            //command.Parameters.AddWithValue("@Quantity", model.Quantity);
            //command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public void Delete(OrderDetails model)
        {
            IDbConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");
            connection.Execute("DELETE FROM OrderDetails WHERE OrderID = @OrderID",
                new { model.OrderID });

            //var sql = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";

            //SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@OrderID", model.OrderID);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public OrderDetails FindById(int OrderID)
        {
            IDbConnection connection = new SqlConnection("data source=.; database=Commerce; integrated security=true");
            var result = connection.Query<OrderDetails>("SELECT * FROM OrderDetails WHERE OrderID = @OrderID", new { OrderID });
            OrderDetails orderDetail = null;
            foreach (var item in result)
            {
                orderDetail = item;
            }
            return orderDetail;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            IDbConnection connection = new SqlConnection("data source=.; database=Commerce; integrated security=true");
            return connection.Query<OrderDetails>("SELECT * FROM OrderDetails ");
        }
    }
}
