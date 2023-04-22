using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;

namespace ProjTurismoADO.Repository
{
    internal interface IAddressRepository
    {
        bool Insert(Address address);

        List<Address> GetAll();

        bool Update(Address address);

        bool Delete(int id);
    }
}
