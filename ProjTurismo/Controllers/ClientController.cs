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

        public List<Client> GetAll()
        {
            return new ClientService().GetAll();
        }
 /*      public int Delete(int Id)
        {
            return new ClientService().Delete(Id);
        }  */

        public bool Update(Client client)
        {
            return new ClientService().Update(client);
        }
    }
}
