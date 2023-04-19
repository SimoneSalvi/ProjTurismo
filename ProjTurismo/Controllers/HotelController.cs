using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismo.Services;

namespace ProjTurismo.Controllers
{
    public class HotelController
    {
        public bool Insert(Hotel hotel)
        {
            return new HotelService().Insert(hotel);
        }

       public List<Hotel> FindAll()
        {
            return new HotelService().FindAll();
        }
       public int Delete(int Id)
        {
            return new HotelService().DeleteById(Id);
        }

        public bool Update(int id, int address, string name, decimal value)
        {
            return new HotelService().Update(id, address, name, value);
        }
    }
}
