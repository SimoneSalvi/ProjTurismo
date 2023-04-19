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
        public string Name { get; set; }    
        public Address Address { get; set; }
        public DateTime DtCadastre { get; set; }
        public decimal Value { get; set; }
        #endregion

        public override string ToString()
        {
            return $"---- HOTEL  Id: {Id}, Nome: {Name}, Endereço: {Address}, Valor: {Value}";
        }
    }
}
