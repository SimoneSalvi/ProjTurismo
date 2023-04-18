using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Models
{
    public class City
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DtCadastro { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Description}";
        }
        #endregion
    }
}
