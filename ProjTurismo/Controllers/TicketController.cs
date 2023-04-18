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
        /*        public int Delete(int Id)
                {
                    return new TicketService().DeleteById(Id);
                }*/
    }
}
