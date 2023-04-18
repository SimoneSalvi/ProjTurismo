using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Models
{
    public class Ticket
    {
        #region Properties
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Client Client { get; set; }
        public DateTime DtTicket { get; set; }
        public decimal Value { get; set; }
        #endregion

        public override string ToString()
        {
            return $"°° TICKET Origem: {Origin.Id} e Destino: {Destination.Id}, Valor: R${Value}, Cliente: {Client.Id} °°";
        }
    }
}
