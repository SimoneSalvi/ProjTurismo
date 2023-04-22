using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ProjTurismo.Models;
using ProjTurismoADO.Repository;

namespace ProjTurismo.Services
{
    public class AddressService
    {
        private IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        public bool Insert(Address address)
        {
            return addressRepository.Insert(address);
        }

        public List<Address> GetAll()
        {
            return addressRepository.GetAll();
        }

        public bool Update(Address address)
        {
            return addressRepository.Update(address);
        }

        public bool Delete(int id)
        {
            return addressRepository.Delete(id);
        }



    }
}
