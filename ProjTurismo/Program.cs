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
            Description = "Barretos - SP",
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

        // UPDATE
        // new CityController().Update(1065, "Lagoas - SP");

        // DELETE
        // new CityController().Delete(1);


        // Select
        //new CityController().FindAll().ForEach(Console.WriteLine);
        #endregion

        #region Address
        Address address = new()
        {
            Stret = "Av Pernambuco",
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

        // UPDATE
        //new AddressController().Update(4, "Rua A", "Bairro A", 100, "zip A", "complemento A");

        // DELETE
        // new AddressController().Delete(1);


        // Select
        Console.WriteLine("\nEndereços:");
        new AddressController().FindAll().ForEach(Console.WriteLine);
        #endregion

        #region Client

        Client client = new Client()
        {
            Name = "Simone",
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
                    Description = "Rio de Janeiro - RJ",
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
        //new ClientController().Update(5, "Susi", "foneSusi");

        // Select
        //Console.WriteLine("\n Clientes\n");
        //new ClientController().FindAll().ForEach(Console.WriteLine);

        #endregion

        #region Ticket
        Ticket ticket = new()
        {
            Origin = new Address()
            {
                Stret = "Origem M",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Origem M ",
                    DtCadastro = DateTime.Now
                }
            },
            Destination = new Address()
            {
                Stret = "Destino M",
                Neighborhood = "Centro",
                Number = 34,
                ZipCode = "2345234",
                Complement = "",
                DtCadastre = DateTime.Now,
                City = new City()
                {
                    Description = "Destino M",
                    DtCadastro = DateTime.Now
                }
            },
            Client = new Client()
            {
                Name = "Cliente M",
                Fone = "(16)99887766",
                Address = new Address()
                {
                    Stret = "endereço M",
                    Neighborhood = "Centro",
                    Number = 34,
                    ZipCode = "2345234",
                    Complement = "",
                    DtCadastre = DateTime.Now,
                    City = new City()
                    {
                        Description = "cidade cliente M",
                        DtCadastro = DateTime.Now
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
        //new TicketController().Delete(3);

        // Update
        //new TicketController().Update(1, 2, 2, 7, 70);

        // Select
        //Console.WriteLine("\n TICKETS :\n");
        //new TicketController().FindAll().ForEach(Console.WriteLine);

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