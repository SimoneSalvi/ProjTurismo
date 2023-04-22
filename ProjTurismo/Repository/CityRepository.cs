using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.IdentityModel.Protocols;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public class CityRepository : ICityRepository
    {
        private string Conn { get; set; }

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public CityRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        //Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        // Insert

        public bool Insert(City city)
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

        public List<City> GetAll()
        {
            string strSelect = "select Id, Description, DtCadastro from City";

            using (var db = new SqlConnection(Conn))
            {
                var cityLst = db.Query<City>(strSelect);
                return (List<City>)cityLst;
            }
        }

        public bool Delete(int id)
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
