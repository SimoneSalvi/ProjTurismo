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
            Description = "Teste Dapper 2 - SP",
            DtCadastro = DateTime.Now
        };

        City cityUpdate = new City()
        {
            Id = 1095,
            Description = "Lagoas - SP",
            DtCadastro = DateTime.Now
        };

        // Insert
        //new CityController().Insert(city);

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

        // UPDATE
        //new CityController().Update(cityUpdate);

        // DELETE
        // new CityController().Delete(1094);


        // Select
        //new CityController().GetAll().ForEach(Console.WriteLine);
        #endregion

        #region Address
        Address address = new()
        {
            Stret = "Teste dapper",
            Neighborhood = "Centro",
            Number = 160,
            ZipCode = "14555000",
            Complement = "",
            DtCadastre = DateTime.Now,
            City = new City()
            {
                Description = "Belo Horizonte - BH",
                DtCadastro = DateTime.Now
            }
        };

        Address addressUpdate = new()
        {
            Id = 1085,
            Stret = "teste XX",
            Neighborhood = "Centro",
            Number = 160,
            ZipCode = "14555000",
            Complement = "",
            DtCadastre = DateTime.Now,
            City = new City()
            {
                Id = 1093,
                Description = "teste Update XX",
                DtCadastro = DateTime.Now
            }
        };

        // Insert
        //new AddressController().Insert(address);

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

        // UPDATE
        //new AddressController().Update(addressUpdate);

        // DELETE
        // new AddressController().Delete(1085);


        // Select
        //Console.WriteLine("\nEndereços:");
        //new AddressController().FindAll().ForEach(Console.WriteLine);
        #endregion

        #region Client

        Client client = new Client()
        {
            Name = "Simone Dapper Z",
            Fone = "(16)99887766",
            Address = new Address()
            {
                Stret = "Av Dapper Z",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Dapper ZS - RJ",
                    DtCadastro = DateTime.Now
                }
            },
            DtCadstre = DateTime.Now,
        };
        Client clientUpdate = new Client()
        {
            Id = 1032,
            Name = "Simone Dapper Update",
            Fone = "(16)99887766",
            Address = new Address()
            {
                Stret = "Av Dapper Update Z",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Dapper Update ZS - RJ",
                    DtCadastro = DateTime.Now
                }
            },
            DtCadstre = DateTime.Now,
        };

        // Insert
        //if (new ClientController().Insert(client));

        // DELETE
        //new ClientController().Delete(15);

        //UPDATE
        //new ClientController().Update(clientUpdate);

        // Select
        //Console.WriteLine("\n Clientes\n");
        //new ClientController().GetAll().ForEach(Console.WriteLine);

        #endregion

        #region Ticket
        Ticket ticket = new()
        {
            Origin = new Address()
            {
                Stret = "Origem DD",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Cidade Origem DD ",
                    DtCadastro = DateTime.Now
                }
            },
            Destination = new Address()
            {
                Stret = "Destino DD",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Cidade Destino DD",
                    DtCadastro = DateTime.Now
                }
            },
            Client = new Client()
            {
                Name = "Cliente DD",
                Fone = "(16)99887766",
                Address = new Address()
                {
                    Stret = "Cliente endereço DD",
                    Neighborhood = "Centro",
                    Number = 34,
                    ZipCode = "2345234",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "cidade cliente DD",
                        DtCadastro = DateTime.Now
                    }
                },
                DtCadstre = DateTime.Now,
            },
            DtTicket = DateTime.Now,
            Value = 2.00M
        };

        // Insert
        //if (new TicketController().Insert(ticket));

        // DELETE
        //new TicketController().Delete(3);

        // Update
        //new TicketController().Update(1, 2, 2, 7, 70);

        // Select
        //Console.WriteLine("\n TICKETS :\n");
        //new TicketController().GetAll().ForEach(Console.WriteLine);

        #endregion

        #region Hotel
        Hotel hotel = new()
        {
            Name = "Hotel 1",
            Address = new Address()
            {
                Stret = "Av do Hotel 1",
                Neighborhood = "Bairro do H1",
                Number = 160,
                ZipCode = "14555000",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Piracicaba - SP",
                    DtCadastro = DateTime.Now
                }
            },
            DtCadastre = DateTime.Now,
            Value = 50
        };

        // INSERT
        //new HotelController().Insert(hotel);

        // SELECT
        new HotelController().FindAll().ForEach(Console.WriteLine);

        //UPDATE
        //new HotelController().Update(1, 40, "Hotel 10000", 31);

        // DELETE
        //new HotelController().Delete(1);
        #endregion

        #region Package
        Package package = new()
        {
            Hotel = new Hotel()
            {
                Name = "Hotel ",
                Address = new Address()
                {
                    Stret = "Rua Hotel 1",
                    Neighborhood = "Bairro do H1",
                    Number = 160,
                    ZipCode = "14555000",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "Cidade Hotel 1 - SP, ",
                        DtCadastro = DateTime.Now
                    }
                },
                DtCadastre = DateTime.Now,
                Value = 50
            },
            Ticket = new Ticket()
            {
                Origin = new Address()
                {
                    Stret = "Origem H1",
                    Neighborhood = "Centro",
                    Number = 34,
                    ZipCode = "2345234",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "cidade origem H1",
                        DtCadastro = DateTime.Now
                    }
                },
                Destination = new Address()
                {
                    Stret = "Destino H1",
                    Neighborhood = "Centro",
                    Number = 34,
                    ZipCode = "2345234",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "cidade destino H1",
                        DtCadastro = DateTime.Now
                    }
                },
                Client = new Client()
                {
                    Name = "Cliente H1",
                    Fone = "(16)99887766",
                    Address = new Address()
                    {
                        Stret = "endereço cliente H1",
                        Neighborhood = "Centro",
                        Number = 34,
                        ZipCode = "2345234",
                        Complement = "",
                        DtCadastre = DateTime.Now,
                        City = new City()
                        {
                            Description = "cidade cliente H1",
                            DtCadastro = DateTime.Now
                        }
                    },
                    DtCadstre = DateTime.Now,
                },
                DtTicket = DateTime.Now,
                Value = 2.00M

            },
            DtCadastre = DateTime.Now,
            Value = 5555,
            Client = new Client()
            {
                Name = "Cliente H1",
                Fone = "(16)99887766",
                Address = new Address()
                {
                    Stret = "endereço cliente H1",
                    Neighborhood = "Centro",
                    Number = 34,
                    ZipCode = "2345234",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "cidade cliente H1",
                        DtCadastro = DateTime.Now
                    }
                },
                DtCadstre = DateTime.Now,
            }
        };

        //INSERT
        //new PackageController().Insert(package);

        // UPDATE
        // new CityController().Update();

        // DELETE
        // new CityController().Delete(1);

        //SELECT
        //Console.WriteLine("\n Pacotes:");
        //new PackageController().FindAll().ForEach(Console.WriteLine);

        #endregion
    }
}