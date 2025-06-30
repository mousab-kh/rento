using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.Vehicle.Dto;
using Rento.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.NewFolder
{

    [ApiController]
    [Route("Vehicle")]
    public class VehicleController
    {
        private IRepository<Entities.Vehicle> _inventoryVehicleRepository;
        private IMapper _mapper;

        public VehicleController(IRepository<Entities.Vehicle> inventoryRepository, IMapper mapper)
        {
            _inventoryVehicleRepository = inventoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<GetVehicleDto> GetVehicle(int Id)
        {
            if (Id < 0) throw new Exception
                     ("Invalid branch Id");
            
            var inventory = await _inventoryVehicleRepository.GetEntityAsync(Id);
            if (inventory == null)
                throw new Exception("Invalid Vehicle");
            
            return _mapper.Map<GetVehicleDto>(inventory);
        }

        [HttpGet]
        public async Task<List<GetVehicleDto>> GetAllVehicle()
        {
            var inventory = await _inventoryVehicleRepository.GetAll().ToListAsync();
            if (inventory == null)
                throw new Exception("Invalid Vehicle");

            return _mapper.Map<List<GetVehicleDto>>(inventory);
        }


    }
}
