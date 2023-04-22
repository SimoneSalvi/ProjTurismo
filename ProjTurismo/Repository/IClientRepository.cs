using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public interface IClientRepository
    {
        bool Insert(Client client);

        List<Client> GetAll();

        bool Update(Client client);

        bool Delete(int id);
    }
}
