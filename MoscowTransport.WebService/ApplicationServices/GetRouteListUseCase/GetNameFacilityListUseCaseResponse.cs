using NameFacilities.DomainObjects;
using NameFacilities.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameFacilities.ApplicationServices.GetNameFacilityListUseCase
{
    public class GetNameFacilityListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.NameFacility> NameFacilities { get; }

        public GetNameFacilityListUseCaseResponse(IEnumerable<DomainObjects.NameFacility> nameFacilities) => NameFacilities = nameFacilities;
    }
}
