using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Models
{
    public class Package
    {
        #region Properties
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime DtCadastre { get; set; }
        public decimal Value { get; set; }
        public Client Client { get; set; }
        #endregion

        public override string ToString()
        {
            return $"\n>> PacoteId: {Id}, Valor do Pacote: R${Value};" +
                $"Nome do Hotel: {Hotel.Name}, Ticket Id: {Ticket.Id} - Cidade de origem: {Ticket.Origin.City.Description} " +
                $"- Cidade de destino: {Ticket.Destination.City.Description}, " +
                $" Nome do Cliente: {Client.Name}" +
                $"<<\n";
        }
    }
}
