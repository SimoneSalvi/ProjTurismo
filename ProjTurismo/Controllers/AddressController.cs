using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismo.Services;

namespace ProjTurismo.Controllers
{
    public class AddressController
    {
        public bool Insert(Address address)
        {
            return new AddressService().Insert(address);
        }

        public List<Address> FindAll()
        {
            return new AddressService().GetAll();
        }

        public bool Delete(int id)
        {
            return new AddressService().Delete(id);
        }

        public bool Update(Address address)
        {
            return new AddressService().Update(address);
        }
    }
}
