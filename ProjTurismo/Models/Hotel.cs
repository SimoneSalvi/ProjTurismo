using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Models
{
    public class Hotel
    {
        #region Properties
        public int Id { get; set; }
        public DateTime DtTicket { get; set; }
        public Address Address { get; set; }
        public DateTime DtCadastre { get; set; }
        public double Value { get; set; }
        #endregion


    }
}
