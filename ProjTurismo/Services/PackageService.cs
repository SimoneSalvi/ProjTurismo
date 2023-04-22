using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismo.Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        // Insert
        public bool Insert(Package package)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Package (Hotel, Ticket, DtCadastre, Value, Client) values " +
                    "(@Hotel, @Ticket, @DtCadastre, @Value, @Client)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Hotel", InsertHotel(package.Hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@Ticket", InsertTicket(package.Ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@DtCadastre", package.DtCadastre));
                commandInsert.Parameters.Add(new SqlParameter("@Client", InsertClient(package.Client)));
                commandInsert.Parameters.Add(new SqlParameter("@Value", package.Value));

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

        private int InsertHotel(Hotel hotel)
        {
            string strInsert = "insert into Hotel (Address, Name, DtCadastre, Value) " +
    "values (@Address, @Name, @DtCadastre, @Value); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Address", InsertAddress(hotel.Address)));
            commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
            commandInsert.Parameters.Add(new SqlParameter("@DtCadastre", hotel.DtCadastre));
            commandInsert.Parameters.Add(new SqlParameter("@Value", hotel.Value));
            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertTicket(Ticket ticket)
        {
            string strInsert = "insert into Ticket (OriginIdAddress, DestinationIdAddress, IdClient, DtTicket, Value)" +
     " values (@OriginIdAddress, @DestinationIdAddress, @IdClient, @DtTicket, @Value); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@OriginIdAddress", InsertAddress(ticket.Origin)));
            commandInsert.Parameters.Add(new SqlParameter("@DestinationIdAddress", InsertAddress(ticket.Destination)));
            commandInsert.Parameters.Add(new SqlParameter("@IdClient", InsertClient(ticket.Client)));
            commandInsert.Parameters.Add(new SqlParameter("@DtTicket", ticket.DtTicket));
            commandInsert.Parameters.Add(new SqlParameter("@Value", ticket.Value));
            return (int)commandInsert.ExecuteScalar();
        }

        // SELECT

        public List<Package> FindAll()
        {
            List<Package> packagetLst = new List<Package>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.id as IdPacote, p.Value as ValorPacote, " +
                "h.Name as NomeHotel,  " +
                "t.OriginIdAddress as IdOrigem, ci.Description as CidadeOrigem, " +
                "t.DestinationIdAddress as IdDestino, ci1.Description as CidadeDestino, " +
                "c.Name " +
                "from Package p  " +
                "join Ticket t on p.Ticket = t.Id " +
                "join Hotel h on p.Hotel = h.id " +
                "join Client c on p.Client = c.Id " +
                "join Address a on t.OriginIdAddress = a.Id " +
                "join Address a1 on t.DestinationIdAddress = a1.Id " +
                "join City ci on a.idCity = ci.Id " +
                "join City ci1 on a1.idCity = ci1.Id");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Package package = new();
                package.Id = (int)reader["IdPacote"];
                package.Hotel = new Hotel()
                {
                    Name = (string)reader["NomeHotel"],
                    Address = new Address()
                    {
                        Stret = " ",
                        Neighborhood = " ",
                        Number = 0,
                        ZipCode = " ",
                        Complement = "",
                        //DtCadastre = DateTime.Now,
                        City = new City() { Description = " " }
                    },
                    //DtCadastre = DateTime.Now,
                    Value = 0
                };
                package.Ticket = new Ticket()
                {
                    Origin = new Address()
                    {
                        Stret = " ",
                        Neighborhood = " ",
                        Number = 0,
                        ZipCode = " ",
                        Complement = "",
                        //DtCadastre = DateTime.Now,
                        City = new City() { Description = (string)reader["CidadeOrigem"] }
                    },
                    Destination = new Address()
                    {
                        Stret = " ",
                        Neighborhood = " ",
                        Number = 0,
                        ZipCode = " ",
                        Complement = "",
                        //DtCadastre = DateTime.Now,
                        City = new City() { Description = (string)reader["CidadeDestino"] }
                    },
                    Client = new Client()
                    {
                        Name = (string)reader["Name"],
                        Fone = " ",
                        Address = new Address()
                        {
                            Stret = " ",
                            Neighborhood = " ",
                            Number = 0,
                            ZipCode = " ",
                            Complement = "",
                            //DtCadastre = DateTime.Now,
                            City = new City() { Description = " " }
                        },
                        //DtCadstre = DateTime.Now,
                    },
                    //DtTicket = DateTime.Now,
                    Value = 0

                };
                //DtCadastre = DateTime.Now,
                package.Value = (decimal)reader["ValorPacote"]; 
                package.Client = new Client()
                {
                    Name = (string)reader["Name"],
                    Fone = " ",
                    Address = new Address()
                    {
                        Stret = " ",
                        Neighborhood = " ",
                        Number = 0,
                        ZipCode = " ",
                        Complement = "",
                        //DtCadastre = DateTime.Now,
                        City = new City() { Description = " " }
                    },
                    //DtCadstre = DateTime.Now,
                };
                packagetLst.Add(package);
            }
            return packagetLst;
        }
    }
}
