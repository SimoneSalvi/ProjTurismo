using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private string Conn { get; set; }

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public TicketRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(Ticket ticket)
        {
            bool status = false;
            string strInsertT = "insert into Ticket (OriginIdAddress, DestinationIdAddress, IdClient, DtTicket, Value)" +
                " values (@OriginIdAddress, @DestinationIdAddress, @IdClient, @DtTicket, @Value)";


            string strInsertC = "insert into client (Name, Fone, IdAddress, DtCadstre) " +
                "values (@Name, @Fone, @IdAddress, @DtCadstre)";

            string strInsertA = "insert into Address(Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity) " +
                 "values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity)";


            string strInsertCi = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro)";

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var cidadeO = db.ExecuteScalar(strInsertCi, ticket.Origin.City);
                var cidadeD = db.ExecuteScalar(strInsertCi, ticket.Destination.City);
                var cidadeC = db.ExecuteScalar(strInsertCi, ticket.Client.Address.City);

                var enderecoO = db.Execute(strInsertA, new
                {
                    IdCity = cidadeO,
                    Stret = ticket.Origin.Stret,
                    Neighborhood = ticket.Origin.Neighborhood,
                    Number = ticket.Origin.Number,
                    ZipCode = ticket.Origin.ZipCode,
                    Complement = ticket.Origin.Complement,
                    DtCadastre = ticket.Origin.DtCadastre
                });

                var enderecoD = db.Execute(strInsertA, new
                {
                    IdCity = cidadeD,
                    Stret = ticket.Destination.Stret,
                    Neighborhood = ticket.Destination.Neighborhood,
                    Number = ticket.Destination.Number,
                    ZipCode = ticket.Destination.ZipCode,
                    Complement = ticket.Destination.Complement,
                    DtCadastre = ticket.Destination.DtCadastre
                });

                var enderecoC = db.Execute(strInsertA, new
                {
                    IdCity = cidadeC,
                    Stret = ticket.Destination.Stret,
                    Neighborhood = ticket.Destination.Neighborhood,
                    Number = ticket.Destination.Number,
                    ZipCode = ticket.Destination.ZipCode,
                    Complement = ticket.Destination.Complement,
                    DtCadastre = ticket.Destination.DtCadastre
                });

                var cliente = db.Execute(strInsertC, new
                {
                    IdAddress = enderecoC,
                    Name = ticket.Client.Name,
                    Fone = ticket.Client.Fone,
                    DtCadstre = ticket.Client.DtCadstre
                });

                db.Execute(strInsertT, new
                {
                    OriginIdAddress = enderecoO,
                    DestinationIdAddress = enderecoD,
                    IdClient = cliente,
                    DtTicket = ticket.DtTicket,
                    Value = ticket.Value
                });
            }
            return status;
        }

        public List<Ticket> GetAll()
        {
            string strSelect = "select t.Id, t.Value, " +
                "t.OriginIdAddress, ci.Description as CidadeOrigem, " +
                "t.DestinationIdAddress,  ci1.Description as CidadeDestino,  " +
                "c.Name " +
                "from Ticket t " +
                "join Client c on t.IdClient = c.Id " +
                "join Address a on t.OriginIdAddress = a.Id " +
                "join Address a1 on t.DestinationIdAddress = a1.Id " +
                "join City ci on a.idCity = ci.Id " +
                "join City ci1 on a1.idCity = ci1.Id";

            using (var db = new SqlConnection(Conn))
            {
                var ticketLst = db.Query<Ticket>(strSelect);
                return (List<Ticket>)ticketLst;
            }
        }

        // DELETE
        public bool Delete(int id)
        {
            string strDelete = "delete from Ticket where id = @id";
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
        //  update Ticket set OriginIdAddress =10, DestinationIdAddress =11, IdClient=11, Value = 30 where Id = 1

        public bool Update(Ticket ticket)
        {

            string strUpdate = "update Ticket set OriginIdAddress = @OriginIdAddress," +
                " DestinationIdAddress = @DestinationIdAddress, IdClient = @IdClient, " +
                "Value = @Value where Id = @Id";

            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strUpdate, new
                {
                    Id = ticket.Id,
                    OriginIdAddress = ticket.Origin.Id,
                    DestinationIdAddress = ticket.Destination.Id,
                    IdClient = ticket.Client.Id,
                    DtTicket = ticket.DtTicket,
                    Value = ticket.Value
                });
                return status;
            }
        }
    }
}
