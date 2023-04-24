using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public class PackageRepository : IPackageRepository
    {
        private string Conn { get; set; }

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public PackageRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(Package package)
        {
            bool status = false;

            string strInsertP = "insert into Package (Hotel, Ticket, DtCadastre, Value, Client) values " +
                    "(@Hotel, @Ticket, @DtCadastre, @Value, @Client)";

            string strInsertT = "insert into Ticket (OriginIdAddress, DestinationIdAddress, IdClient, DtTicket, Value)" +
                    " values (@OriginIdAddress, @DestinationIdAddress, @IdClient, @DtTicket, @Value); select cast(scope_identity() as int)";

            string strInsertH = "insert into Hotel (Address, Name, DtCadastre, Value) " +
                    "values (@Address, @Name, @DtCadastre, @Value); select cast(scope_identity() as int)";

            string strInsertC = "insert into client (Name, Fone, IdAddress, DtCadstre) " +
                    "values (@Name, @Fone, @IdAddress, @DtCadstre); select cast(scope_identity() as int)";

            string strInsertA = "insert into Address(Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity) " +
                    "values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity); select cast(scope_identity() as int)";

            string strInsertCi = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro); select cast(scope_identity() as int)";

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var cidadeO = db.ExecuteScalar(strInsertCi, package.Ticket.Origin.City);
                var cidadeD = db.ExecuteScalar(strInsertCi, package.Ticket.Destination.City);
                var cidadeC = db.ExecuteScalar(strInsertCi, package.Ticket.Client.Address.City);
                var cidadeH = db.ExecuteScalar(strInsertCi, package.Hotel.Address.City);

                var enderecoO = db.ExecuteScalar(strInsertA, new
                {
                    IdCity = cidadeO,
                    Stret = package.Ticket.Origin.Stret,
                    Neighborhood = package.Ticket.Origin.Neighborhood,
                    Number = package.Ticket.Origin.Number,
                    ZipCode = package.Ticket.Origin.ZipCode,
                    Complement = package.Ticket.Origin.Complement,
                    DtCadastre = package.Ticket.Origin.DtCadastre
                });

                var enderecoD = db.ExecuteScalar(strInsertA, new
                {
                    IdCity = cidadeD,
                    Stret = package.Ticket.Destination.Stret,
                    Neighborhood = package.Ticket.Destination.Neighborhood,
                    Number = package.Ticket.Destination.Number,
                    ZipCode = package.Ticket.Destination.ZipCode,
                    Complement = package.Ticket.Destination.Complement,
                    DtCadastre = package.Ticket.Destination.DtCadastre
                });

                var enderecoC = db.ExecuteScalar(strInsertA, new
                {
                    IdCity = cidadeC,
                    Stret = package.Ticket.Destination.Stret,
                    Neighborhood = package.Ticket.Destination.Neighborhood,
                    Number = package.Ticket.Destination.Number,
                    ZipCode = package.Ticket.Destination.ZipCode,
                    Complement = package.Ticket.Destination.Complement,
                    DtCadastre = package.Ticket.Destination.DtCadastre
                });

                var enderecoH = db.ExecuteScalar(strInsertA, new
                {
                    IdCity = cidadeH,
                    Stret = package.Hotel.Address.Stret,
                    Neighborhood = package.Hotel.Address.Neighborhood,
                    Number = package.Hotel.Address.Number,
                    ZipCode = package.Hotel.Address.ZipCode,
                    Complement = package.Hotel.Address.Complement,
                    DtCadastre = package.Hotel.Address.DtCadastre
                });

                var cliente = db.ExecuteScalar(strInsertC, new
                {
                    IdAddress = enderecoC,
                    Name = package.Ticket.Client.Name,
                    Fone = package.Ticket.Client.Fone,
                    DtCadstre = package.Ticket.Client.DtCadstre
                });

                var ticket = db.Execute(strInsertT, new
                {
                    OriginIdAddress = enderecoO,
                    DestinationIdAddress = enderecoD,
                    IdClient = cliente,
                    DtTicket = package.Ticket.DtTicket,
                    Value = package.Ticket.Value
                });

                var hotel = db.Execute(strInsertH, new
                {
                    Address = enderecoH,
                    Name = package.Hotel.Name,
                    DtCadastre = package.Hotel.DtCadastre,
                    Value = package.Hotel.Value
                });

                db.Execute(strInsertP, new
                {
                    Hotel = hotel,
                    Ticket = ticket,
                    DtCadastre = package.DtCadastre,
                    Value = package.Value,
                    Client = cliente
                });
                return status;
            }
        }
        public List<Package> GetAll()
        {
            string strSelect = "select p.id as IdPacote, p.Value as ValorPacote, " +
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
                "join City ci1 on a1.idCity = ci1.Id";

            using (var db = new SqlConnection(Conn))
            {
                var packagetLst = db.Query<Package>(strSelect);
                return (List<Package>)packagetLst;
            }
        }

        public bool Update(Package package)
        {
            string strUpdate = "update Package set Hotel = @Hotel, Ticket = @Ticket, "+
					"dtCadastre = @DtCadastre, " +
				"Value = Value, Client = Client " +
				"where id = @Id";

            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strUpdate, new
                {
                    Id = package.Id,
                    Hotel = package.Hotel.Id,
                    Ticket = package.Ticket,
                    DtCadastre = package.DtCadastre,
                    Value = package.Value,
                    Client = package.Client
                });
                return status;
            }

        }

        public bool Delete(int id)
        {
            string strDelete = "delete from Package where id = @id";
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
