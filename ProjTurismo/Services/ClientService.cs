using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjTurismo.Models;
using ProjTurismoADO.Repository;

namespace ProjTurismo.Services
{
    public class ClientService 
    {
        private IClientRepository clientRepository;

        public ClientService()
        {
            clientRepository = new ClientRepository();
        }

        public bool Insert(Client client)
        {
            return clientRepository.Insert(client);
        }

        public List<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public bool Update(Client client)
        {
            return clientRepository.Update(client);
        }

        public bool Delete(int id)
        {
            return clientRepository.Delete(id);
        }

    }
}
