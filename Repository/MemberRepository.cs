using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Dapper;
using System.Configuration;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class MemberRepository
    {
        private static string sql;
        private static IDbConnection connection;
        public MemberRepository()
        {
            sql = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ProductionDb");

            if (string.IsNullOrEmpty(sql))
            {
                sql = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            }
            connection = new SqlConnection(sql);
        }
        public void Create(Members model)
        {
            connection.Execute("INSERT INTO Members " +
                "VALUES (@MemberID, @Password, @Name, @Phone, @Address, @Email, @MemberGUID)",
                new
                {
                    model.MemberID,
                    model.Password,
                    model.Name,
                    model.Phone,
                    model.Address,
                    model.Email,
                    model.MemberGUID
                });
        }

        public void Update(Members model)
        {
            connection.Execute("UPDATE Members SET Name=@Name, Phone=@Phone, Address=@Address, Email=@Email WHERE MemberID = @MemberID",
                new
                {
                    model.Name,
                    model.Phone,
                    model.Address,
                    model.Email,
                    model.MemberID
                });
        }
        public void UpdateGUID(Members model)
        {
            connection.Execute("UPDATE Members SET MemberGUID=@MemberGUID WHERE MemberID = @MemberID",
                new
                {
                    model.MemberGUID,
                    model.MemberID
                });
        }

        public void Delete(Members model)
        {
            connection.Execute("DELETE FROM Members WHERE MemberID = @MemberID",
                new
                {
                    model.MemberID
                });
        }

        public Members FindById(string MemberID)
        {
            var result = connection.Query<Members>("SELECT * FROM Members WHERE MemberID = @MemberID", 
                new
                {
                    MemberID
                });
            Members member = null;
            foreach(var item in result)
            {
                member = item;
            }
            return member;
        }
        public IEnumerable<GetBuyerOrder> GetBuyerOrder(string memberid)
        {
            return connection.Query<GetBuyerOrder>("GetBuyerOrder", 
                new
                {
                    memberid
                }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<GetBuyerOrder> GetBuyerOrder(string memberid, IDbConnection connection, IDbTransaction transaction)
        {
            return connection.Query<GetBuyerOrder>("GetBuyerOrder", 
                new
                {
                    memberid
                }, transaction, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Members> GetAll()
        {
            return connection.Query<Members>("SELECT * FROM Members");
        }
    }
}
