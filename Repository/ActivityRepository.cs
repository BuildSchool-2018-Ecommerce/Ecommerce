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
    public class ActivityRepository
    {
        public void Create(Activity model, IDbConnection connection)
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

        public void Update(Activity model, IDbConnection connection)
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

        public void Delete(Activity model, IDbConnection connection)
        {
            connection.Execute("DELETE FROM Activity WHERE ActivityID = @ActivityID",
                new
                {
                    model.ActivityID
                });
        }

        public Activity FindById(int ActivityID, IDbConnection connection)
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
        public IEnumerable<Activity> GetAll(IDbConnection connection)
        {
            return connection.Query<Activity>("SELECT * FROM Activity ");
        }
    }
}
