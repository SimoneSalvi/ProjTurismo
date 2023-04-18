using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // Insert
        public bool InsertCity(City city)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
                commandInsert.Parameters.Add(new SqlParameter("@DtCadastro", city.DtCadastro));

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

        // Select
        public List<City> FindAll()
        {
            List<City> cityLst = new List<City>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, Description, DtCadastro from City");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                City city = new City();

                city.Id = (int)reader["Id"];
                city.Description = (string)reader["Description"];
                city.DtCadastro = (DateTime)reader["DtCadastro"];

                cityLst.Add(city);
            }
            return cityLst;
        }

        public int DeleteById(int id)
        {

            string strDelete = "delete from City where id = @id";
            SqlCommand commandDelete = new SqlCommand(strDelete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));
            return (int)commandDelete.ExecuteNonQuery();

        }

        // Update
        
        public bool Update(int id, string c)
        {
            City city = new();
            bool status = false;

            try
            {
                string strUpdate = "update City set Description = @Description where Id = @Id;";
                SqlCommand commandUpdate = new SqlCommand(strUpdate, conn);

                
                commandUpdate.Parameters.Add(new SqlParameter("@Description", c));
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
