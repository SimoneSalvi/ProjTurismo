using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    public interface IPackageRepository
    {
        bool Insert(Package package);

        List<Package> GetAll();

        bool Update(Package package);

        bool Delete(int id);
    }
}
