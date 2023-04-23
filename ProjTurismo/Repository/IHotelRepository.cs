using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public interface IHotelRepository
    {
        bool Insert(Hotel hotel);

        List<Hotel> GetAll();

        bool Update(Hotel hotel);

        bool Delete(int id);
    }
}
