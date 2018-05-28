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
    public class CategoryRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public CategoryRepository()
        {
            sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

            if (string.IsNullOrEmpty(sql))
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(Category model)
        {
            connection.Execute("INSERT INTO Category VALUES ( @CategoryName )", 
                new
                {
                    model.CategoryName
                });
        }


        public void Update(Category model)
        {
            connection.Execute("UPDATE Category SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID",
                new
                {
                    model.CategoryName, model.CategoryID
                });
        }

        public void Delete(Category model)
        {
            connection.Execute("DELETE FROM Category WHERE CategoryID = @CategoryID",
                new
                {
                    model.CategoryID
                });
        }

        public Category FindById(int CategoryID)
        {
            var result = connection.Query<Category>("SELECT * FROM Category WHERE CategoryID = @CategoryID", 
                new
                {
                    CategoryID
                });
            Category category = null;
            foreach (var item in result)
            {
                category = item;
            }
            return category;
        }
        public IEnumerable<Category> GetAll()
        {
            return connection.Query<Category>("SELECT * FROM Category");
        }
        public IEnumerable<FindProductsByCategory> FindProductsByCategory()
        {
            return connection.Query<FindProductsByCategory>("FindProductsByCategory", 
                new
                {

                }, commandType: CommandType.StoredProcedure);
        }
    }
}
