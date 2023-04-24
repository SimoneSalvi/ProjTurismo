using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private string Conn { get; set; }

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public HotelRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(Hotel hotel)
        {
            bool status = false;
            string strInsertH = "insert into Hotel (Address, Name, DtCadastre, Value) " +
                                "values (@Address, @Name, @DtCadastre, @Value)";
            
            string strInsertA = "insert into Address(Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity) " +
                                "values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity); select cast(scope_identity() as int)";

            string strInsertC = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro); select cast(scope_identity() as int)";

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var cidade = db.ExecuteScalar(strInsertC, hotel.Address.City);

                var endereco = db.ExecuteScalar(strInsertA, new
                {
                    IdCity = cidade,
                    Stret = hotel.Address.Stret,
                    Neighborhood = hotel.Address.Neighborhood,
                    Number = hotel.Address.Number,
                    ZipCode = hotel.Address.ZipCode,
                    Complement = hotel.Address.Complement,
                    DtCadastre = hotel.Address.DtCadastre
                });

                db.Execute(strInsertH, new
                {
                    Address = endereco,
                    Name =  hotel.Name,
                    DtCadastre = hotel.DtCadastre,
                    Value = hotel.Value
                });
            }

            return status;
        }

        public List<Hotel> GetAll()
        {
            string strSelect = "select Id, Name, Value from Hotel";

            using (var db = new SqlConnection(Conn))
            {
                var hotelLst = db.Query<Hotel>(strSelect);
                return (List<Hotel>)hotelLst;
            }
        }

        public bool Update(Hotel hotel)
        {
            string strUpdateH = "update Hotel set Address = @Address, " +
                "Name = @Name, Value = @Value Where Id = @Id";

            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();


                db.Execute(strUpdateH, new
                {
                    Address = hotel.Address.Id,
                    Name = hotel.Name,
                    DtCdastre = hotel.DtCadastre,
                    Value = hotel.Value
                });
                return status;
            }

        }

        public bool Delete(int id)
        {
            string strDelete = "delete from Hotel where id = @id";
            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strDelete, new { Id = id });
                status = true;
            }
            return status;
        }
    }
}
