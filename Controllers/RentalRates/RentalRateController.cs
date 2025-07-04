using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.RentalRates.Dto;
using Rento.Entities.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.RentalRates
{
    [ApiController]
    [Route("RentalRate")]
    public class RentalRateController
    {
        private IRepository<RentalRate> _repositoryRentalRate;
        private readonly IRepository<RentalRateSchema> _repositoryRentalRateSchema;
        private readonly IRepository<VehicleCategorie> _vehicleCategorierepository;
        private readonly IRepository<VehicleModel> _vehicleModelrepository;
        private IMapper _mapper;

        public RentalRateController(
            IRepository<RentalRate> repositoryRentalRate,
            IRepository<RentalRateSchema> repositoryRentalRateSchema,
            IMapper mapper,
            IRepository<VehicleModel> vehicleModelrepository,
            IRepository<VehicleCategorie> vehicleCategorierepository)
        {
            _repositoryRentalRate = repositoryRentalRate;
            _repositoryRentalRateSchema = repositoryRentalRateSchema;
            _mapper = mapper;
            _vehicleModelrepository = vehicleModelrepository;
            _vehicleCategorierepository = vehicleCategorierepository;
        }

        [HttpGet("Get")]
        public async Task<GetRentalRateDto> GetRentalRate(int id)
        {
            if (id <= 0) throw new Exception("Invalid RentalRateSchema");
            var rentalRate = await _repositoryRentalRate.GetEntityAsync(id);
            if (rentalRate == null) throw new Exception("Invalid RentalRate");
            return _mapper.Map<GetRentalRateDto>(rentalRate);
        }

        [HttpGet("GetAll")]
        public async Task<List<GetRentalRateDto>> GetAllRentalRates()
        {
            var rentalRate = await _repositoryRentalRate.GetAll().ToListAsync();
            if (rentalRate== null) throw new Exception("Invalid RentalRate");
            return _mapper.Map<List<GetRentalRateDto>>(rentalRate);
        }

        [HttpDelete("Delete")]
        public async Task DeleteRentalRate(int id)
        {
            if (id <= 0) throw new Exception("Invalid RentalRateSchema");
            var rentalRate = await _repositoryRentalRate.GetEntityAsync(id);
            if (rentalRate == null) throw new Exception("Invalid RentalRate");
            _repositoryRentalRate.DeleteEntity(rentalRate);
            _repositoryRentalRate.Save();

        }

        [HttpPut("Update")]
        public async Task UpdateRentalRate(
            UpdateRentalRateDto updateRentalRateDto)
        {
            var rentalRate = await _repositoryRentalRate
                .GetEntityAsync(updateRentalRateDto.Id);
            if (rentalRate == null) throw new Exception("Invalid RentalRate");
            var rentalRatemap = _mapper.Map<RentalRate>(rentalRate);
            _repositoryRentalRate.Clear();
            _repositoryRentalRate.UpdateEntity(rentalRatemap);
            _repositoryRentalRate.Save();
        }

        [HttpPost("Create")]
        public async Task CreateRentalRate(
            CreateRentalRateDto createRentalRateDto)
        {
            if (await _repositoryRentalRateSchema
                .AnyAsync(t => t.Id == createRentalRateDto.RentalRateSchemasId))
                throw new Exception("Invalid RentalRate SchemasId");

            if (await _vehicleCategorierepository
                .AnyAsync(t => t.Id == createRentalRateDto.VehicleCategorieId))
            throw new Exception("Invalid VehicleCategorieId");

            if (await _vehicleModelrepository
                .AnyAsync(t => t.Id == createRentalRateDto.VehicleModelId))
                throw new Exception("Invalid VehicleModelId");


            var create = new RentalRate(
                createRentalRateDto.StartDate,
                createRentalRateDto.EndDate,
                createRentalRateDto.VehicleCategorieId,
                createRentalRateDto.VehicleModelId,
                createRentalRateDto.Price,
                createRentalRateDto.RentalRateSchemasId);

            _repositoryRentalRate.AddEntity(create);
            _repositoryRentalRate.Save();

        }
        
    }
}
