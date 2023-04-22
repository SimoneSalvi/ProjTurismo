using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;

namespace ProjTurismo.Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        //Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        // Insert

        public bool InsertCity(City city)
        {
            bool status = false;
            string strInsert = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro)";


            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strInsert, city);
                status = true;
            }
            return status;

        }

        // Select

        public List<City> FindAll()
        {
            string strSelect = "select Id, Description, DtCadastro from City";

            using (var db = new SqlConnection(strConn))
            {
                var cityLst = db.Query<City>(strSelect);
                return (List<City>)cityLst;
            }
        }

       public bool DeleteById(int id)
        {
            string strDelete = "delete from City where id = @id";
            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strDelete, new { Id = id });
                status = true;
            }
            return status;

        }


        // Update
        
        public bool Update(City city)
        {
            string strUpdate = "update City set Description = @Description where Id = @Id;";
           // City city = new();

            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strUpdate, city);
                status = true;
            }
            return status;
        }
        
    }
}
