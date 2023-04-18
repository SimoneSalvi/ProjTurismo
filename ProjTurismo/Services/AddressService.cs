using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismo.Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        // Insert
        public bool Insert(Address address)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Address (Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity) " +
                    "values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Stret", address.Stret));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@DtCadastre", address.DtCadastre));
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", InsertCity(address)));

                commandInsert.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            {
                conn.Close();
            }
            return status;
        }

        private int InsertCity(Address address)
        {
            string strInsert = "insert into City (Description) values (@Description); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", address.City.Description));
            //commandInsert.Parameters.Add(new SqlParameter("@DtCadastro", address.City.DtCadastro));
            return (int)commandInsert.ExecuteScalar(); 
        }

        // Select
        public List<Address> FindAll()
        {
            List<Address> addressLst = new List<Address>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select a.Id, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, c.Description from Address a, City c Where c.Id = a.idCity");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Address address = new Address();

                address.Id = (int)reader["Id"];
                address.Stret = (string)reader["Stret"];
                address.Neighborhood = (string)reader["Neighborhood"];
                address.Number = (int)reader["Number"];
                address.ZipCode = (string)reader["ZipCode"];
                address.Complement = (string)reader["Complement"];
                address.DtCadastre = (DateTime)reader["DtCadastre"];
                address.City = new City() { Description = (string)reader["Description"]};

                addressLst.Add(address);
            }
            return addressLst;
        }

        // DELETE
        public int DeleteById(int id)
        {

            string strDelete = "delete from Address where id = @id";
            SqlCommand commandDelete = new SqlCommand(strDelete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));
            return (int)commandDelete.ExecuteNonQuery();

        }
    }
}
