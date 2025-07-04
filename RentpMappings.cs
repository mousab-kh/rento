using AutoMapper;
using Rento.Controllers.Branchs.Dto;
using Rento.Controllers.BranchWorkingHours.Dto;
using Rento.Controllers.RentalRates.Dto;
using Rento.Controllers.RentalRateSchemasController.Dto;
using Rento.Controllers.VehicleCategories.Dto;
using Rento.Controllers.VehicleManufacturers.Dto;
using Rento.Controllers.VehicleModels.Dto;
using Rento.Controllers.Vehicles.Dto;
using Rento.Entities.Entities;
using Rento.Entities.ValueObjects;

namespace Rento
{
    public class RentpMappings : Profile
    {
        public RentpMappings()
        {
            CreateMap<UpdateBranchDto, Branch>();
            CreateMap<Branch, GetBranchDto>();

            CreateMap<BranchWorkingHour, GetBranchWorkingHourOutputDto>();
            CreateMap<WorkingHourIntervalValueObject, WorkingHourIntervalDto>();
            CreateMap<WorkingHourIntervalDto,WorkingHourIntervalValueObject> ();

            CreateMap<Vehicle, GetVehicleDto>();
            CreateMap<Vehicle, UpdateVehicleDto>();

            CreateMap<VehicleCategorie, GetVehicleCategorieDto>();
            CreateMap<UpdateVehicleCategorieDto, VehicleCategorie>();

            CreateMap<VehicleModel, GetVehicleModelDto>();
            CreateMap<UpdateVehicleModelDto, VehicleModel>();

            CreateMap<VehicleManufacturer, GetVehicleManufacturerDto>();
            CreateMap<UpdateVehicleManufacturerDto,  VehicleManufacturer>();

            CreateMap<RentalRateSchema, GetRentalRateSchemaDto>();
            CreateMap<UpdateRentalRateSchemaDto, RentalRateSchema>();

            CreateMap<RentalRate, GetRentalRateDto>();
            CreateMap<UpdateRentalRateDto, RentalRate>();
        }
    }
}
