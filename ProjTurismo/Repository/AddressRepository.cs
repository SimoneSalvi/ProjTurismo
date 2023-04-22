using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    internal class AddressRepository : IAddressRepository
    {
        private string Conn { get; set; }

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public AddressRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        // Insert
        public bool Insert(Address address)
        {
            bool status = false;
            string strInsertA = "insert into Address(Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity) " +
                    "values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity)";

            string strInsertC = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro)";

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var cidade = db.ExecuteScalar(strInsertC, address.City);

                db.Execute(strInsertA, new
                {
                    IdCity = cidade,
                    Stret = address.Stret,
                    Neighborhood = address.Neighborhood,
                    Number = address.Number,
                    ZipCode = address.ZipCode,
                    Complement = address.Complement,
                    DtCadastre = address.DtCadastre
                });

            }

            return status;
        }

        // Select
        public List<Address> GetAll()
        {
            string strSelect = "select a.Id, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, c.Description from Address a, City c Where c.Id = a.idCity";

            using (var db = new SqlConnection(Conn))
            {
                var addressLst = db.Query<Address>(strSelect);
                return (List<Address>)addressLst;
            }
        }

        // DELETE
        public bool Delete(int id)
        {
            string strDelete = "delete from Address where id = @id";
            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strDelete, new { Id = id });
                status = true;
            }
            return status;

        }

        //UPDATE 
        public bool Update(Address address)
        {
            string strUpdate = "update Address set Stret = @stret, Neighborhood = @Neighborhood," +
                    " Number = @Number, ZipCode = @ZipCode, Complement = @Complement, DtCadastre = @DtCadastre, " +
                    " idCity = @idCity where Id = @Id";

            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strUpdate, new
                {
                    Id = address.Id,
                    IdCity = address.City.Id,
                    Stret = address.Stret,
                    Neighborhood = address.Neighborhood,
                    Number = address.Number,
                    ZipCode = address.ZipCode,
                    Complement = address.Complement,
                    DtCadastre = address.DtCadastre
                });
                return status;
            }
        }
    }
}
