﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    internal class ClientRepository : IClientRepository
    {
        private string Conn { get; set; }

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\BancoAula\ProjTurismoDB.mdf";
        readonly SqlConnection conn;

        public ClientRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(Client client)
        {
            bool status = false;
            string strInsertC = "insert into client (Name, Fone, IdAddress, DtCadstre) " +
                "values (@Name, @Fone, @IdAddress, @DtCadstre)";

            string strInsertA = "insert into Address(Stret, Neighborhood, Number, ZipCode, Complement, DtCadastre, IdCity) " +
                 "values (@Stret, @Neighborhood, @Number, @ZipCode, @Complement, @DtCadastre, @IdCity)";


            string strInsertCi = "insert into City (Description, DtCadastro) values (@Description, @DtCadastro)";

            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                var cidade = db.ExecuteScalar(strInsertCi, client.Address.City);

                var endereco = db.Execute(strInsertA, new
                {
                    IdCity = cidade,
                    Stret = client.Address.Stret,
                    Neighborhood = client.Address.Neighborhood,
                    Number = client.Address.Number,
                    ZipCode = client.Address.ZipCode,
                    Complement = client.Address.Complement,
                    DtCadastre = client.Address.DtCadastre
                });

                db.Execute(strInsertC, new
                {
                    IdAddress = endereco,
                    Nome = client.Name,
                    Fone = client.Fone,
                    DtCadastre = client.DtCadstre
                });
            }
            return status;
        }


        public List<Client> GetAll()
        {
            string strSelect = "select c.Id, c.Name, c.Fone, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, ci.Description, c.DtCadstre from Client c, Address a, City ci where a.Id = c.IdAddress and ci.Id = a.idCity";

            using (var db = new SqlConnection(Conn))
            {
                var ClientLst = db.Query<Client>(strSelect);
                return (List<Client>)ClientLst;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool Update(Client client)
        {
            string strUpdate = "update Client set Name = @Name, Fone = @Fone where Id = @Id";

            var status = false;
            using (var db = new SqlConnection(strConn))
            {
                db.Open();
                db.Execute(strUpdate, new
                {
                    ID = client.Id,
                    Name = client.Name,
                    Fone = client.Fone
                });
                return status;

            }
        }

        // Select
        public List<Client> FindAll()
        {
            List<Client> clientLst = new List<Client>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, c.Name, c.Fone, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, ci.Description, c.DtCadstre from Client c, Address a, City ci where a.Id = c.IdAddress and ci.Id = a.idCity");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Client client = new Client();
                client.Id = (int)reader["Id"];
                client.Name = (string)reader["Name"];
                client.Fone = (string)reader["Fone"];
                client.DtCadstre = (DateTime)reader["DtCadstre"];
                client.Address = new Address()
                {
                    Stret = (string)reader["Stret"],
                    Neighborhood = (string)reader["Neighborhood"],
                    Number = (int)reader["Number"],
                    ZipCode = (string)reader["ZipCode"],
                    Complement = (string)reader["Complement"],
                    DtCadastre = (DateTime)reader["DtCadastre"],
                    City = new City()
                    {
                        Description = (string)reader["Description"]
                    }
                };
                clientLst.Add(client);
            }
            return clientLst;
        }

        /*       // DELETE
               public int DeleteById(int id)
               {

                   string strDelete = "delete from Client where id = @id";
                   SqlCommand commandDelete = new SqlCommand(strDelete, conn);
                   commandDelete.Parameters.Add(new SqlParameter("@id", id));
                   return (int)commandDelete.ExecuteNonQuery();

               }  */

        // UPDATE
        // update Client set Name = 'RRRR', Fone = 'RRR fone' where Id = 6

        public bool Update(int id, string name, string fone)
        {
            Client client = new();
            bool status = false;

            try
            {
                string strUpdate = "update Client set Name = @Name, Fone = @Fone where Id = @Id";
                SqlCommand commandUpdate = new SqlCommand(strUpdate, conn);


                commandUpdate.Parameters.Add(new SqlParameter("@Name", name));
                commandUpdate.Parameters.Add(new SqlParameter("@Fone", fone));
                commandUpdate.Parameters.Add(new SqlParameter("@Id", id));

                commandUpdate.ExecuteNonQuery();

                status = true;
            }
            catch
            {
                status = false;
                throw;
            }


            return status;
        }
    }
}
