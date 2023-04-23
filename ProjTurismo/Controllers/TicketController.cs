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

        public List<Ticket> GetAll()
        {
            return new TicketService().GetAll();
        }
        public bool Delete(int Id)
        {
            return new TicketService().Delete(Id);
        }

        public bool Update(Ticket ticket)
        {
            return new TicketService().Update(ticket);
        }
    }
}
