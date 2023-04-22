using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProjTurismo.Models;
using ProjTurismoADO.Repository;

namespace ProjTurismo.Services
{
    public class CityService
    {
        private ICityRepository cityRepository;

        public CityService()
        {
            cityRepository = new CityRepository();
        }

        public bool Insert(City city)
        {
            return cityRepository.Insert(city);
        }

        public List<City> GetAll()
        {
            return cityRepository.GetAll();
        }

        public bool Update(City city)
        {
            return cityRepository.Update(city);
        }

        public bool Delete(int id)
        {
            return cityRepository.Delete(id);
        }

    }
}
