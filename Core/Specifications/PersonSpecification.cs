using Core.Models;
using ElrouteCore.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{

    public sealed class PersonSpecification : BaseSpecification<Person>
    {
        public PersonSpecification()
            : base(b => b.Id != Guid.Empty)
        {
            //AddInclude(b => b.Project);
            //AddInclude(b => b.Revisions);
            //AddInclude($"{nameof(Circuit.Revisions)}.{nameof(CircuitRevision.StartDevice)}.{nameof(Device.Revisions)}.{nameof(DeviceRevision.DeviceRevisionTranslations)}");
            //AddInclude($"{nameof(Circuit.Revisions)}.{nameof(CircuitRevision.StopDevice)}.{nameof(Device.Revisions)}.{nameof(DeviceRevision.DeviceRevisionTranslations)}");
        }
    }
}
