using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Repositories
{
    public class InMemoryNameFacilityRepository : IReadOnlyNameFacilityRepository,
                                           INameFacilityRepository 
    {
        private readonly List<DomainObjects.NameFacility> _routes = new List<DomainObjects.NameFacility>();

        public InMemoryNameFacilityRepository(IEnumerable<DomainObjects.NameFacility> routes = null)
        {
            if (routes != null)
            {
                _routes.AddRange(routes);
            }
        }

        public Task AddNameFacility(DomainObjects.NameFacility route)
        {
            _routes.Add(route);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.NameFacility>> GetAllNameFacility()
        {
            return Task.FromResult(_routes.AsEnumerable());
        }

        public Task<DomainObjects.NameFacility> GetNameFacility(long id)
        {
            return Task.FromResult(_routes.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.NameFacility>> QueryNameFacility(ICriteria<DomainObjects.NameFacility> criteria)
        {
            return Task.FromResult(_routes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveNameFacility(DomainObjects.NameFacility route)
        {
            _routes.Remove(route);
            return Task.CompletedTask;
        }

        public Task UpdateNameFacility(DomainObjects.NameFacility route)
        {
            var foundRoute = GetNameFacility(route.Id).Result;
            if (foundRoute == null)
            {
                AddNameFacility(route);
            }
            else
            {
                if (foundRoute != route)
                {
                    _routes.Remove(foundRoute);
                    _routes.Add(route);
                }
            }
            return Task.CompletedTask;
        }
    }
}
