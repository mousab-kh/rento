using AutoMapper;
using Rento.Controllers.Branchs.Dto;
using Rento.Controllers.BranchWorkingHours.Dto;
using Rento.Controllers.Vehicle.Dto;
using Rento.Entities;
using Rento.Entities.ValueObjects;

namespace Rento
{
    public class RentpMappings : Profile
    {
        public RentpMappings()
        {
            CreateMap<UpdateBranchDto, Branch>();
            CreateMap<Branch, GetBranchDto>();
            CreateMap<Branch, GetBranchDto>();
            CreateMap<BranchWorkingHour, GetBranchWorkingHourOutputDto>();
            CreateMap<WorkingHourIntervalValueObject, WorkingHourIntervalDto>();
            CreateMap<WorkingHourIntervalDto,WorkingHourIntervalValueObject> ();

            CreateMap<GetVehicleDto, Vehicle>();

        }
    }
}
