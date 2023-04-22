﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismo.Services;

namespace ProjTurismo.Controllers
{
    public class CityController
    {
        public bool Insert(City city)
        {
            return new CityService().InsertCity(city);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }

        
        public bool Update(City city)
        {
            return new CityService().Update(city);
        }
        

        public bool Delete(int Id)
        {
            return new CityService().DeleteById(Id);
        }
    }
}
