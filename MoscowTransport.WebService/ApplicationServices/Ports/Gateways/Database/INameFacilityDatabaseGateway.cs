using NameFacilities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NameFacilities.ApplicationServices.Ports.Gateways.Database
{
    public interface INameFacilityDatabaseGateway
    {
        Task AddNameFacility(DomainObjects.NameFacility nameFacility);

        Task RemoveNameFacility(DomainObjects.NameFacility nameFacility);

        Task UpdateNameFacility(DomainObjects.NameFacility nameFacility);

        Task<DomainObjects.NameFacility> GetNameFacility(long id);

        Task<IEnumerable<DomainObjects.NameFacility>> GetAllNameFacilities();

        Task<IEnumerable<DomainObjects.NameFacility>> QueryNameFacilities(Expression<Func<DomainObjects.NameFacility, bool>> filter);
    }
}
