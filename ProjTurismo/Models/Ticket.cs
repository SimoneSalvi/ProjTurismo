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
        public double Value { get; set; }
        #endregion

    }
}
