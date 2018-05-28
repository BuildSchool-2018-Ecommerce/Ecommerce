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
    public class ActivityRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public ActivityRepository()
        {
            if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb")))
            {
                sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");
            }
            else
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(Activity model)
        {
            connection.Execute("INSERT INTO Activity VALUES ( @StartDate, @EndDate, @Discount, @Image, @Introduce )",
                new
                {
                    model.StartDate,
                    model.EndDate,
                    model.Discount,
                    model.Image,
                    model.Introduce
                });
        }

        public void Update(Activity model)
        {
            connection.Execute("UPDATE Activity SET StartDate = @StartDate, EndDate = @EndDate, Discount = @Discount, Image = @Image, Introduce = @Introduce WHERE ActivityID = @ActivityID",
                new
                {
                    model.StartDate,
                    model.EndDate,
                    model.Discount,
                    model.Image,
                    model.Introduce,
                    model.ActivityID
                });
        }

        public void Delete(Activity model)
        {
            connection.Execute("DELETE FROM Activity WHERE ActivityID = @ActivityID",
                new
                {
                    model.ActivityID
                });
        }

        public Activity FindById(int ActivityID)
        {
            var result = connection.Query<Activity>("SELECT * FROM Activity WHERE ActivityID = @ActivityID",
                new
                {
                    ActivityID
                });
            Activity activity = null;
            foreach (var item in result)
            {
                activity = item;
            }
            return activity;
        }
        public IEnumerable<Activity> GetAll()
        {
            return connection.Query<Activity>("SELECT * FROM Activity ");
        }
    }
}
