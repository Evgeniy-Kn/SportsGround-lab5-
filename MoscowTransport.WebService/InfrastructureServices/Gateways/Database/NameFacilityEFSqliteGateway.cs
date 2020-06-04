using NameFacilities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using NameFacilities.ApplicationServices.Ports.Gateways.Database;

namespace NameFacilities.InfrastructureServices.Gateways.Database
{
    public class NameFacilityEFSqliteGateway : INameFacilityDatabaseGateway
    {
        private readonly NameFacilityContext _nameFacilityContext;

        public NameFacilityEFSqliteGateway(NameFacilityContext transportContext)
            => _nameFacilityContext = transportContext;

        public async Task<DomainObjects.NameFacility> GetNameFacility(long id)
           => await _nameFacilityContext.NameFacilities.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<DomainObjects.NameFacility>> GetAllNameFacilities()
            => await _nameFacilityContext.NameFacilities.ToListAsync();
          
        public async Task<IEnumerable<DomainObjects.NameFacility>> QueryNameFacilities(Expression<Func<DomainObjects.NameFacility, bool>> filter)
            => await _nameFacilityContext.NameFacilities.Where(filter).ToListAsync();

        public async Task AddNameFacility(DomainObjects.NameFacility nameFacility)
        {
            _nameFacilityContext.NameFacilities.Add(nameFacility);
            await _nameFacilityContext.SaveChangesAsync();
        }

        public async Task UpdateNameFacility(DomainObjects.NameFacility nameFacility)
        {
            _nameFacilityContext.Entry(nameFacility).State = EntityState.Modified;
            await _nameFacilityContext.SaveChangesAsync();
        }

        public async Task RemoveNameFacility(DomainObjects.NameFacility nameFacility)
        {
            _nameFacilityContext.NameFacilities.Remove(nameFacility);
            await _nameFacilityContext.SaveChangesAsync();
        }

    }
}
