using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.VehicleManufacturers.Dto;
using Rento.Entities.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.VehicleManufacturers
{
    [ApiController]
    [Route("Vehicle/VehicleManufacturer")]
    public class VehicleManufacturerController : ControllerBase
    {
        private IRepository<VehicleManufacturer> _vehicleManufacturer;
        private IMapper _mapper;

        public VehicleManufacturerController(
            IRepository<VehicleManufacturer> vehicleManufacturer, 
            IMapper mapper)
        {
            _vehicleManufacturer = vehicleManufacturer;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<GetVehicleManufacturerDto> GetVehicleManufacturerAsync(int id)
        {
            if (id <= 0) throw new Exception("Invalid Vehicle manufacturer");
            var manufacturer = await _vehicleManufacturer.GetEntityAsync(id);
            return _mapper.Map<GetVehicleManufacturerDto>(manufacturer);
        }

        [HttpGet]
        public async Task<List<GetVehicleManufacturerDto>> GetAllVehicleManufacturerAsync()
        {
            var manufacturer = await _vehicleManufacturer.GetAll().ToListAsync();
            return _mapper.Map<List<GetVehicleManufacturerDto>>(manufacturer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleManufacturer(int id)
        {
            if (id <= 0) throw new Exception("Invalid Vehicle manufacturer");

            var manufacturer = await _vehicleManufacturer.GetEntityAsync(id);
            if(manufacturer == null) throw new Exception("Invalid Vehicle manufacturer");

            _vehicleManufacturer.DeleteEntity(manufacturer);
            _vehicleManufacturer.Save();

            return Ok(new { message = "تمت العملية بنجاح" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicleManufacturer(
            UpdateVehicleManufacturerDto updateVehicleManufacturerDto)
        {
            var manufacturer = await _vehicleManufacturer.GetEntityAsync(updateVehicleManufacturerDto.Id);
            if (manufacturer== null) throw new Exception("Invalid Vehicle manufacturer");
            var manufacturermap = _mapper.Map<VehicleManufacturer>(updateVehicleManufacturerDto);
            _vehicleManufacturer.Clear();
            _vehicleManufacturer.UpdateEntity(manufacturermap);
            _vehicleManufacturer.Save();
            return Ok(manufacturermap);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleManufacturer(
            CreateVehicleManufacturerDto createVehicleManufacturerDto)
        {
            var create =  new VehicleManufacturer(
                createVehicleManufacturerDto.Name);
            _vehicleManufacturer.AddEntity(create);
            _vehicleManufacturer.Save();

            return Ok(create);
        }
    }
}
