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
    public class ImageRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public ImageRepository()
        {
            sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

            if (string.IsNullOrEmpty(sql))
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(Images model)
        {
            connection.Execute("INSERT INTO Image VALUES ( @Image )",
                new
                {
                    model.Image
                });
        }


        public void Update(Images model)
        {
            connection.Execute("UPDATE Image SET Image=@Image WHERE ImageID = @ImageID",
                new
                {
                    model.Image,
                    model.ImageID
                });
        }

        public void Delete(Images model)
        {
            connection.Execute("DELETE FROM Image WHERE ImageID = @ImageID",
                new
                {
                    model.ImageID
                });
        }

        public Images FindById(int ImageID)
        {
            var result = connection.Query<Images>("SELECT * FROM Image WHERE ImageID = @ImageID",
                new
                {
                    ImageID
                });
            Images images = null;
            foreach (var item in result)
            {
                images = item;
            }
            return images;
        }
        public IEnumerable<Images> GetAll()
        {
            return connection.Query<Images>("SELECT * FROM Image");
        }
    }
}
