using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjTurismo.Models;

namespace ProjTurismo.Services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        // Insert
        public bool Insert(Client client)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into client (Name, Fone, IdAddress, DtCadstre) " +
                    "values (@Name, @Fone, @IdAddress, @DtCadstre)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Fone", client.Fone));
                commandInsert.Parameters.Add(new SqlParameter("@DtCadstre", client.DtCadstre));

                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(client)));

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

        private int InsertAddress(Client client)
        {
            string strInsert = "insert into Address (Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity)" +
                " values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Stret", client.Address.Stret));
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", client.Address.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@Number", client.Address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@ZipCode", client.Address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complement", client.Address.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@DtCadastre", client.Address.DtCadastre));
            commandInsert.Parameters.Add(new SqlParameter("@IdCity", InsertCity(client)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertCity(Client client)
        {
            string strInsert = "insert into City (Description) values (@Description); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", client.Address.City.Description));
            //commandInsert.Parameters.Add(new SqlParameter("@DtCadastro", address.City.DtCadastro));
            return (int)commandInsert.ExecuteScalar();
        }

        // Select
        public List<Client> FindAll()
        {
            List<Client> clientLst = new List<Client>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, c.Name, c.Fone, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, ci.Description, c.DtCadstre from Client c, Address a, City ci where a.Id = c.IdAddress and ci.Id = a.idCity");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Client client = new Client();
                client.Id = (int)reader["Id"];
                client.Name = (string)reader["Name"];
                client.Fone = (string)reader["Fone"];
                client.DtCadstre = (DateTime)reader["DtCadstre"];
                client.Address = new Address()
                {
                    Stret = (string)reader["Stret"],
                    Neighborhood = (string)reader["Neighborhood"],
                    Number = (int)reader["Number"],
                    ZipCode = (string)reader["ZipCode"],
                    Complement = (string)reader["Complement"],
                    DtCadastre = (DateTime)reader["DtCadastre"],
                    City = new City()
                    {
                        Description = (string)reader["Description"]
                    }
                };
                clientLst.Add(client);
            }
            return clientLst;
        }

                // DELETE
                public int DeleteById(int id)
                {

                    string strDelete = "delete from Client where id = @id";
                    SqlCommand commandDelete = new SqlCommand(strDelete, conn);
                    commandDelete.Parameters.Add(new SqlParameter("@id", id));
                    return (int)commandDelete.ExecuteNonQuery();

                }
          
    }
}
