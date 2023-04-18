using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTurismo.Models
{
    public class Address
    {
        #region Properties
        public int Id { get; set; }
        public string Stret { get; set; } //Logradouro
        public string Neighborhood { get; set; } //Bairro
        public int Number { get; set; } //Numero
        public string ZipCode { get; set; } //CEP
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime DtCadastre { get; set; } //Data_Cadastro
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Logradouro: {Stret} nº{Number}, Bairro: {Neighborhood}, CEP: {ZipCode}, Complemento: {Complement}, Cidade: {City.Description}";
        }
        #endregion
    }
}
