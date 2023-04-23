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

       public List<Hotel> GetAll()
        {
            return new HotelService().GetAll();
        }
       public bool Delete(int Id)
        {
            return new HotelService().Delete(Id);
        }

        public bool Update(Hotel hotel)
        {
            return new HotelService().Update(hotel);
        }
    }
}
