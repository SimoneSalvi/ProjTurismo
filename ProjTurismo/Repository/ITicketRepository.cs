using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public interface ITicketRepository
    {
        bool Insert(Ticket ticket);

        List<Ticket> GetAll();

        bool Update(Ticket ticket);

        bool Delete(int id);
    }
}
