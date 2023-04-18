using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;
using ProjTurismo.Controllers;
using ProjTurismo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proj Hotelaria MVC - ADO.NET!");

        #region City
        City city = new City()
        {
            Description = "Araras - SP",
            DtCadastro = DateTime.Now
        };


        // Insert
        /*
        if (new CityController().Insert(city))
        {
            Console.WriteLine("Sucesso! Registro Inserido!");
        }
        else
        {
            Console.WriteLine("Erro ao inserir registro");
        }
        */

        // Select
        //new CityController().FindAll().ForEach(Console.WriteLine);

        // UPDATE
        //new CityController().Update(3, "Araras");

        // DELETE
        // new CityController().Delete(1);
        #endregion

        #region Address
        Address address = new()
        {
            Stret = "Av Feijo",
            Neighborhood = "Centro",
            Number = 160,
            ZipCode = "14555000",
            Complement = "",
            DtCadastre = DateTime.Now,
            City = new City() { Description = "Brotas - SP" }
        };

        // Insert
        /*
       if (new AddressController().Insert(address))
       {
           Console.WriteLine("Sucesso! Registro Inserido!");
       }
       else
       {
           Console.WriteLine("Erro ao inserir registro");
       }
        */

        // Select
        //new AddressController().FindAll().ForEach(Console.WriteLine);

        // UPDATE
        //new CityController().Update(3, "Araras");

        // DELETE
        // new AddressController().Delete(1);
        #endregion

        #region Client

        Client client = new Client()
        {
            Name = "Simone",
            Fone = "(16)33334455",
            Address = new Address()
            {
                Stret = "Av Brasil",
                Neighborhood = "Jd. Paulistano",
                Number = 24,
                ZipCode = "14555000",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Birigui - SP"
                }
            },
            DtCadstre = DateTime.Now,
        };

        // Insert

        // if (new ClientController().Insert(client));

        // Select
          new ClientController().FindAll().ForEach(Console.WriteLine);

        // DELETE
        // new AddressController().Delete(1);
        #endregion
    }
}