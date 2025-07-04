using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.VehicleModels.Dto;
using Rento.Entities.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.VehicleModels
{
    [ApiController]
    [Route("VehicleModel")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IRepository<VehicleCategorie> _vehicleCategorierepository;
        private IRepository<VehicleModel> _vehicleModelrepository;
        private IMapper _mapper;

        public VehicleModelController(
            IRepository<VehicleCategorie> vehicleCategorierepository,
            IRepository<VehicleModel> vehicleModelrepository,
            IMapper mapper)
        {
            _vehicleCategorierepository = vehicleCategorierepository;
            _vehicleModelrepository = vehicleModelrepository;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<GetVehicleModelDto> GetVehicleModel(int id)
        {
            if (id <= 0) throw new Exception("Invalid Vehicle Model");
            var vehicleModel = await _vehicleModelrepository.GetEntityAsync(id);
            if (vehicleModel == null) throw new Exception("Invalid vehicle Model");

            return _mapper.Map<GetVehicleModelDto>(vehicleModel);
        }

        [HttpGet("GetAll")]
        public async Task<List<GetVehicleModelDto>> GetAllVehicleModels()
        {
            var vehicleModel = await _vehicleModelrepository.GetAll().ToListAsync();
            if (vehicleModel == null) throw new Exception("Invalid vehicle Model");
            return _mapper.Map<List<GetVehicleModelDto>>(vehicleModel);
        }

        [HttpDelete("Delete")]
        public async Task DeleteVehicleMode(int id)
        {
            if (id <= 0) throw new Exception("Invalid Vehicle Model");
            var vehicleModel = await _vehicleModelrepository.GetEntityAsync(id);
            if (vehicleModel == null) throw new Exception("Invalid vehicle Model");
            _vehicleModelrepository.DeleteEntity(vehicleModel);
            _vehicleModelrepository.Save();
        }

        [HttpPut("Update")]
        public async Task UpdateVehicleModel(UpdateVehicleModelDto updateVehicleModeDto)
        {
            if (!await _vehicleModelrepository.AnyAsync(i=> i.Id==updateVehicleModeDto.Id))
                throw new Exception("Invalid vehicle Model");
            var vehicleModel = await _vehicleModelrepository.GetEntityAsync(updateVehicleModeDto.Id);
            var vehicleModelmap = _mapper.Map<VehicleModel>(updateVehicleModeDto);

            _vehicleModelrepository.Clear();
            _vehicleModelrepository.UpdateEntity(vehicleModelmap);
            _vehicleModelrepository.Save();

        }

        [HttpPost("Create")]
        public async Task CreateVehicleModel(CreateVehicleModelDto createVehicleModelDto)
        {

            if (!await _vehicleCategorierepository
                .AnyAsync(i => i.Id == createVehicleModelDto.VehicleCategorieId))
                throw new Exception("Invalid Vehicle Categorie");

            var create = new VehicleModel(
                createVehicleModelDto.Name,
                createVehicleModelDto.VehicleCategorieId);

            _vehicleModelrepository.AddEntity(create);
            _vehicleModelrepository.Save();
        }
    }
}
