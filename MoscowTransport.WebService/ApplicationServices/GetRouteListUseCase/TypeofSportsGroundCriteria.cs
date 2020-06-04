using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NameFacilities.ApplicationServices.GetNameFacilityListUseCase
{
    public class TypeofSportsGroundCriteria : ICriteria<DomainObjects.NameFacility>
    {
        public string TypeofSportsGround { get; }

        public TypeofSportsGroundCriteria(string typeofSportsGround)
            => TypeofSportsGround = typeofSportsGround;

        public Expression<Func<DomainObjects.NameFacility, bool>> Filter
            => nf => nf.TypeofSportsGround == TypeofSportsGround;
    }
}
