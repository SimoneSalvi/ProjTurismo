using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjTurismo.Models;

namespace ProjTurismo.Services
{
    public class TicketService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        // Insert
        public bool Insert(Ticket ticket)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Ticket (OriginIdAddress, DestinationIdAddress, IdClient, DtTicket, Value)" +
                    " values (@OriginIdAddress, @DestinationIdAddress, @IdClient, @DtTicket, @Value)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@OriginIdAddress", InsertAddress(ticket.Origin)));
                commandInsert.Parameters.Add(new SqlParameter("@DestinationIdAddress", InsertAddress(ticket.Destination)));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(ticket.Client)));
                commandInsert.Parameters.Add(new SqlParameter("@DtTicket", ticket.DtTicket));
                commandInsert.Parameters.Add(new SqlParameter("@Value", ticket.Value));

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
            string strInsert = "insert into City (Description) values (@Description); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertClient(Client client)
        {
            string strInsert = "insert into client (Name, Fone, IdAddress, DtCadstre)" +
                " values (@Name, @Fone, @IdAddress, @DtCadstre); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Fone", client.Fone));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(client.Address)));
            commandInsert.Parameters.Add(new SqlParameter("@DtCadstre", client.DtCadstre));

            return (int)commandInsert.ExecuteScalar();
        }

        // Select
        public List<Ticket> FindAll()
        {
            List<Ticket> ticketLst = new List<Ticket>();

            StringBuilder sb = new StringBuilder();
            sb.Append(" select t.Id, t.OriginIdAddress, t.DestinationIdAddress, t.Value, c.Name from Ticket t, Client c where t.IdClient = c.Id");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new Ticket();
                ticket.Id = (int)reader["ID"];
                //ticket.DtTicket = (DateTime)reader["DtTicket"];
                ticket.Value = Convert.ToDecimal(reader["Value"]);
                ticket.Origin = new Address()
                {
                    Id = (int)reader["OriginIdAddress"],
                    Stret = "",
                    Neighborhood = "",
                    Number = 0,
                    ZipCode = "",
                    Complement = "",
                    //DtCadastre = (DateTime)reader["DtCadastre"],
                    City = new City()
                    {
                        Description = ""
                    }
                };
                ticket.Destination = new Address()
                {
                    Id = (int)reader["DestinationIdAddress"],

                        Stret = "",
                        Neighborhood = "",
                        Number = 0,
                        ZipCode = "",
                        Complement = "",
                        //DtCadastre = (DateTime)reader["DtCadastre"],
                        City = new City()
                        {
                            Description = ""
                        }

                };
                ticket.Client = new Client()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Fone = "",
                    //DtCadstre = (DateTime)reader["DtCadstre"],
                    Address = new Address()
                    {
                        Id = 0,
                        Stret = "",
                        Neighborhood = "",
                        Number = 0,
                        ZipCode = "",
                        Complement = "",
                        //DtCadastre = (DateTime)reader["DtCadastre"],
                        City = new City()
                        {
                            Description = ""
                        }
                    }
                };
                ticketLst.Add(ticket);
            }
            return ticketLst;
        }

        /*       // DELETE
               public int DeleteById(int id)
               {

                   string strDelete = "delete from Client where id = @id";
                   SqlCommand commandDelete = new SqlCommand(strDelete, conn);
                   commandDelete.Parameters.Add(new SqlParameter("@id", id));
                   return (int)commandDelete.ExecuteNonQuery();

               }*/


    }
}
