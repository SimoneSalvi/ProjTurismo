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
        public double Value { get; set; }
        public Client Client { get; set; }
        #endregion

    }
}
