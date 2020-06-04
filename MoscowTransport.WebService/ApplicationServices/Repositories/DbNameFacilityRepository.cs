using NameFacilities.ApplicationServices.Ports.Gateways.Database;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Repositories
{
    public class DbNameFacilityRepository : IReadOnlyNameFacilityRepository,
                                     INameFacilityRepository
    {
        private readonly INameFacilityDatabaseGateway _databaseGateway;

        public DbNameFacilityRepository(INameFacilityDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<DomainObjects.NameFacility> GetNameFacility(long id)
            => await _databaseGateway.GetNameFacility(id);

        public async Task<IEnumerable<DomainObjects.NameFacility>> GetAllNameFacility()
            => await _databaseGateway.GetAllNameFacilities();

        public async Task<IEnumerable<DomainObjects.NameFacility>> QueryNameFacility(ICriteria<DomainObjects.NameFacility> criteria)
            => await _databaseGateway.QueryNameFacilities(criteria.Filter);

        public async Task AddNameFacility(DomainObjects.NameFacility nameFacility)
            => await _databaseGateway.AddNameFacility(nameFacility);

        public async Task RemoveNameFacility(DomainObjects.NameFacility nameFacility)
            => await _databaseGateway.RemoveNameFacility(nameFacility);

        public async Task UpdateNameFacility(DomainObjects.NameFacility nameFacility)
            => await _databaseGateway.UpdateNameFacility(nameFacility);
    }
}
