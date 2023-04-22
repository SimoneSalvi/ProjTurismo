using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismo.Services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        // Insert
        public bool Insert(Hotel hotel)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Hotel (Address, Name, DtCadastre, Value) " +
                    "values (@Address, @Name, @DtCadastre, @Value)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Address", InsertAddress(hotel.Address)));
                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@DtCadastre", hotel.DtCadastre));
                commandInsert.Parameters.Add(new SqlParameter("@Value", hotel.Value));
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

        private int InsertAddress(Address address)
        {
            string strInsert = "insert into Address (Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity)" +
                " values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Stret", address.Stret));
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@DtCadastre", address.DtCadastre));
            commandInsert.Parameters.Add(new SqlParameter("@IdCity", InsertCity(address.City)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertCity(City city)
        {
            string strInsert = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
            commandInsert.Parameters.Add(new SqlParameter("@DtCadastro", city.DtCadastro));
            return (int)commandInsert.ExecuteScalar();
        }

        //SELECT
        // Select
        public List<Hotel> FindAll()
        {
            List<Hotel> hotelLst = new List<Hotel>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Name, Value from Hotel");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = new Hotel();
                hotel.Id = (int)reader["ID"];
                hotel.Value = Convert.ToDecimal(reader["Value"]);           
                hotel.Name = (string)reader["Name"];

                hotelLst.Add(hotel);
            }
            return hotelLst;
        }


 
        // DELETE
        public int DeleteById(int id)
        {

            string strDelete = "delete from Hotel where id = @id";
            SqlCommand commandDelete = new SqlCommand(strDelete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));
            return (int)commandDelete.ExecuteNonQuery();

        }

        // UPDATE 
        // update Hotel set Address = @Address, Name = @Name, Value = @Value Where Id = @Id

        public bool Update(int id, int address, string name, decimal value)
        {
            Hotel hotel = new();
            bool status = false;

            try
            {
                string strUpdate = "update Hotel set Address = @Address, Name = @Name, Value = @Value Where Id = @Id";
                SqlCommand commandUpdate = new SqlCommand(strUpdate, conn);


                commandUpdate.Parameters.Add(new SqlParameter("@Address", address));
                commandUpdate.Parameters.Add(new SqlParameter("@Name", name));
                commandUpdate.Parameters.Add(new SqlParameter("@Value", value));
                commandUpdate.Parameters.Add(new SqlParameter("@Id", id));

                commandUpdate.ExecuteNonQuery();

                status = true;
            }
            catch
            {
                status = false;
                throw;
            }


            return status;
        }
    }
}
