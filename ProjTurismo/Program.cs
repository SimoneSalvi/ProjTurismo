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
        // new CityController().Update(3, "Araras");

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
            Name = "Fabio",
            Fone = "(16)99887766",
            Address = new Address()
            {
                Stret = "Av Castelo Branco",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Rio de Janeiro - RJ"
                }
            },
            DtCadstre = DateTime.Now,
        };

        // Insert
        // if (new ClientController().Insert(client));

        // DELETE
        // new ClientController().Delete(3);

        // Select
        // new ClientController().FindAll().ForEach(Console.WriteLine);

        #endregion

        #region Ticket
        Ticket ticket = new()
        {
            Origin = new Address()
            {
                Stret = "origem 1",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "cidade origem 1"
                }
            },
            Destination = new Address()
            {
                Stret = "origem 2",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "cidade origem 2"
                }
            },
            Client = new Client()
            {
                Name = "Cliente 1",
                Fone = "(16)99887766",
                Address = new Address()
                {
                    Stret = "endereço cliente 1",
                    Neighborhood = "Centro",
                    Number = 34,
                    ZipCode = "2345234",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "cidade cliente 1"
                    }
                },
                DtCadstre = DateTime.Now,
            },
            DtTicket = DateTime.Now,
            Value = 2.00M
        };

        // Insert
        // if (new TicketController().Insert(ticket));

        // DELETE
        // new ClientController().Delete(3);

        // Select
         new TicketController().FindAll().ForEach(Console.WriteLine);

        #endregion

    }
}