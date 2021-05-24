using System.Collections.Generic;
using Models;
using SDL;
namespace SBL
{
    public class LocationBL : ILocationBL
    {
        private IRepository _repo;
        public LocationBL(IRepository repository){
            _repo = repository;
        }

        public MLocation AddStore(MLocation location)
        {
            return _repo.AddStore(location);
        }

        public List<MLocation> GetAllLocation()
        {
            return _repo.GetAllLocation();
        }

        public List<MInventory> GetProductInStock(MLocation mLocation)
        {
            return _repo.GetProductInStock(mLocation);
        }

        public MLocation GetStore(MLocation location)
        {
            return _repo.GetAStore(location);
        }
    }
}