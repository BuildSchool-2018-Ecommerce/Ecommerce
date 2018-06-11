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
    public class ShoppingCartRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public ShoppingCartRepository()
        {
            sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

            if (string.IsNullOrEmpty(sql))
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(ShoppingCart model)
        {
            connection.Execute("INSERT INTO ShoppingCart VALUES ( @MemberID, @ProductFormatID, @Quantity, @UnitPrice )",
                new
                {
                    model.MemberID,
                    model.ProductFormatID,
                    model.Quantity,
                });
        }


        public void Update(ShoppingCart model)
        {
            connection.Execute("UPDATE ShoppingCart SET MemberID = @MemberID, ProductFormatID = @ProductFormatID, Quantity = @Quantity WHERE ShoppingCartID = @ShoppingCartID",
                new
                {
                    model.MemberID,
                    model.ProductFormatID,
                    model.Quantity,
                    model.ShoppingCartID,
                });
        }
        public void Delete(ShoppingCart model)
        {
            connection.Execute("DELETE FROM ShoppingCart WHERE ShoppingCartID = @ShoppingCartID",
                new
                {
                    model.ShoppingCartID
                });
        }

        public ShoppingCart FindById(int ShoppingCartID)
        {
            var result = connection.Query<ShoppingCart>("SELECT * FROM ShoppingCart WHERE ShoppingCartID = @ShoppingCartID",
                new
                {
                    ShoppingCartID
                });
            ShoppingCart shoppingCart = null;
            foreach (var item in result)
            {
                shoppingCart = item;
            }
            return shoppingCart;
        }
        public IEnumerable<ShoppingCart> GetAll()
        {
            return connection.Query<ShoppingCart>("SELECT * FROM ShoppingCart");
        }

        public IEnumerable<ShoppingCart> FindShoppingCartsByMemberId(string memberid)
        {
            return connection.Query<ShoppingCart>("SELECT * FROM ShoppingCart WHERE MemberID = @MemberID",
                new
                {
                    memberid
                });
        }

        public IEnumerable<ShoppingIconView> ShoppingCarts(string memberid)
        {
            return connection.Query<ShoppingIconView>("ShoppingCartByMemberID",
                new
                {
                    memberid
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
