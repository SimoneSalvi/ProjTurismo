using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismo.Services;

namespace ProjTurismo.Controllers
{
    public class TicketController
    {
        public bool Insert(Ticket ticket)
        {
            return new TicketService().Insert(ticket);
        }

        public List<Ticket> FindAll()
        {
            return new TicketService().FindAll();
        }
        public int Delete(int Id)
        {
            return new TicketService().DeleteById(Id);
        }

        public bool Update(int id, int origin, int destn, int client, decimal value)
        {
            return new TicketService().Update(id, origin, destn, client, value);
        }
    }
}
