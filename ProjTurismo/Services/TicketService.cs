using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjTurismo.Models;
using ProjTurismoADO.Repository;

namespace ProjTurismo.Services
{
    public class TicketService
    {
        private ITicketRepository ticketRepository;

        public TicketService()
        {
            ticketRepository = new TicketRepository();
        }

        public bool Insert(Ticket ticket)
        {
            return ticketRepository.Insert(ticket);
        }

        public List<Ticket> GetAll()
        {
            return ticketRepository.GetAll();
        }

        public bool Update(Ticket ticket)
        {
            return ticketRepository.Update(ticket);
        }

        public bool Delete(int id)
        {
            return ticketRepository.Delete(id);
        }
    }
}
