using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.Vehicles.Dto;
using Rento.Entities.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.Vehicles
{

    [ApiController]
    [Route("Vehicle")]
    public class VehicleController : ControllerBase
    {
        private IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<Branch> _Branchrepository;
        private readonly IRepository<VehicleManufacturer> _VehicleManufacturerrepository;
        private readonly IRepository<VehicleModel> _VehicleModelrepository;
        private IMapper _mapper;

        public VehicleController(
            IRepository<Vehicle> vehicleRepository,
            IMapper mapper,
            IRepository<Branch> branchrepository,
            IRepository<VehicleManufacturer> vehicleManufacturerrepository,
            IRepository<VehicleModel> vehicleModelrepository)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _Branchrepository = branchrepository;
            _VehicleManufacturerrepository = vehicleManufacturerrepository;
            _VehicleModelrepository = vehicleModelrepository;
        }

        [HttpGet("Get")]
        public async Task<GetVehicleDto> GetVehicle(int id)
        {
            if (id < 0) throw new Exception ("Invalid branch Id");

            var vehicle = await _vehicleRepository.GetEntityAsync(id);
            if (vehicle == null) throw new Exception("Invalid Vehicle");

            return _mapper.Map<GetVehicleDto>(vehicle);
        }

        [HttpGet("GetAll")]
        public async Task<List<GetVehicleDto>> GetAllVehicle()
        {
            var vehicle = await _vehicleRepository.GetAll().ToListAsync();
            if (vehicle == null)
                throw new Exception("Invalid Vehicle");

            return _mapper.Map<List<GetVehicleDto>>(vehicle);
        }

        [HttpDelete("Delete")]
        public async Task DeleteVehicle(int id)
        {
            if (id <= 0) throw new Exception
                 ("Invalid Vehicl Id");

            var isValidVehicle = await _vehicleRepository.GetEntityAsync(id);
            if (isValidVehicle== null)
                throw new Exception("Invalid Vehicle");

            _vehicleRepository.DeleteEntity(isValidVehicle);
            _vehicleRepository.Save();
        }

        [HttpPut("Update")]
        public async Task UpdateVehicle(UpdateVehicleDto updateVehicle)
        {
            var isValidVehicle = await _vehicleRepository.AnyAsync(d=> d.Id== updateVehicle.Id);
            if (isValidVehicle)
                throw new Exception("Invalid Vehicle");

            var vehicleMap = _mapper.Map<Vehicle>(updateVehicle);

            _vehicleRepository.UpdateEntity(vehicleMap);
            _vehicleRepository.Save();
        }

        [HttpPost("Create")]
        public async Task CreateVehicle(CreateVehicleDto vehicleDto)
        {
            var isValidBranch = await _Branchrepository.AnyAsync(b => b.Id == vehicleDto.BranchId);
            if (!isValidBranch)
                throw new Exception("Invalid Branch");

            var isValidManufacturer = await _VehicleManufacturerrepository.AnyAsync(v => v.Id == vehicleDto.VehicleManufacturerId);
            if (!isValidManufacturer)
                throw new Exception("Invalid Vehicle Manufacturer");

            var Model = await _VehicleModelrepository.AnyAsync(v=> v.Id==vehicleDto.VehicleModelId);
            if (!Model)
                throw new Exception("Invalid Vehicle Model");

            var create = new Vehicle(
                vehicleDto.VehicleModelId,
                vehicleDto.Year,
                vehicleDto.VehicleManufacturerId,
                vehicleDto.LicensePlateNumber,
                vehicleDto.FuelTypes,
                vehicleDto.BranchId);

            _vehicleRepository.AddEntity(create);
            _vehicleRepository.Save();
        }
    }
}
