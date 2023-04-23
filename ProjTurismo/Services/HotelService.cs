using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismoADO.Repository;

namespace ProjTurismo.Services
{
    public class HotelService
    {
        private IHotelRepository hotelRepository;

        public HotelService()
        {
            hotelRepository = new HotelRepository();
        }

        public bool Insert(Hotel hotel)
        {
            return hotelRepository.Insert(hotel);
        }

        public List<Hotel> GetAll()
        {
            return hotelRepository.GetAll();
        }

        public bool Update(Hotel hotel)
        {
            return hotelRepository.Update(hotel);
        }

        public bool Delete(int id)
        {
            return hotelRepository.Delete(id);
        }
    }
}
