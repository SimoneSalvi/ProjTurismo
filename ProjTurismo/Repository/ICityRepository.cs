using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public interface ICityRepository
    {
        bool Insert(City city);

        List<City> GetAll();

        bool Update(City city);

        bool Delete(int id);
    }
}
