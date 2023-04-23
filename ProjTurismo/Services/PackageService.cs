using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismoADO.Repository;

namespace ProjTurismo.Services
{
    public class PackageService
    {
        private IPackageRepository packageRepository;

        public PackageService()
        {
            packageRepository = new PackageRepository();
        }

        public bool Insert(Package package)
        {
            return packageRepository.Insert(package);
        }

        public List<Package> GetAll()
        {
            return packageRepository.GetAll();
        }

        public bool Update(Package package)
        {
            return packageRepository.Update(package);
        }

        public bool Delete(int id)
        {
            return packageRepository.Delete(id);
        }
    }
}
