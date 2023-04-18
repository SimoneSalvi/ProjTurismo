using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismo.Services;

namespace ProjTurismo.Controllers
{
    public class ClientController
    {
        public bool Insert(Client client)
        {
            return new ClientService().Insert(client);
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll();
        }
 /*      public int Delete(int Id)
        {
            return new ClientService().DeleteById(Id);
        }  */

        public bool Update(int id, string name, string fone)
        {
            return new ClientService().Update(id, name, fone);
        }
    }
}
