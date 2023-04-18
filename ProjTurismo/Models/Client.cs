using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Models
{
    public class Client
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fone { get; set; }
        public Address Address { get; set; }
        public DateTime DtCadstre { get; set; }
        #endregion

        public override string ToString()
        {
            return $"Nome: {Name}\nTelefone: {Fone}\nEndereço: {Address}\n";
        }
    }
}
