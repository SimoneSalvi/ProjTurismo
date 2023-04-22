using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismo.Services;

namespace ProjTurismo.Controllers
{
    public class PackageController
    {
        public bool Insert(Package package)
        {
            return new PackageService().Insert(package);
        }

        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }
/*        public int Delete(int Id)
        {
            return new PackageService().DeleteById(Id);
        }

       public bool Update(int id, int origin, int destn, int client, decimal value)
        {
            return new HotelService().Update(id, origin, destn, client, value);
        }*/
    }
}
