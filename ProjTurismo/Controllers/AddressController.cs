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
            return new AddressService().FindAll();
        }

        public int Delete(int Id)
        {
            return new AddressService().DeleteById(Id);
        }
    }
}
