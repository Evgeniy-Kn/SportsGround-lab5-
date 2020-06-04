using System.Threading.Tasks;
using System.Collections.Generic;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using NameFacilities.ApplicationServices.Ports;

namespace NameFacilities.ApplicationServices.GetNameFacilityListUseCase
{
    public class GetNameFacilityListUseCase : IGetNameFacilityListUseCase
    {
        private readonly IReadOnlyNameFacilityRepository _readOnlyNameFacilityRepository;

        public GetNameFacilityListUseCase(IReadOnlyNameFacilityRepository readOnlyNameFacilityRepository) 
            => _readOnlyNameFacilityRepository = readOnlyNameFacilityRepository;

        public async Task<bool> Handle(GetNameFacilityListUseCaseRequest request, IOutputPort<GetNameFacilityListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.NameFacility> nameFacilities = null;
            if (request.NameFacilityId != null)
            {
                var nameFacility = await _readOnlyNameFacilityRepository.GetNameFacility(request.NameFacilityId.Value);
                nameFacilities = (nameFacility != null) ? new List<DomainObjects.NameFacility>() { nameFacility } : new List<DomainObjects.NameFacility>();
                
            }
            else if (request.NameofSportsGround != null)
            {
                nameFacilities = await _readOnlyNameFacilityRepository.QueryNameFacility(new TypeofSportsGroundCriteria(request.NameofSportsGround));
            }
            else
            {
                nameFacilities = await _readOnlyNameFacilityRepository.GetAllNameFacility();
            }
            outputPort.Handle(new GetNameFacilityListUseCaseResponse(nameFacilities));
            return true;
        }
    }
}
