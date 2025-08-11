using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.RentalRateSchemasController.Dto;
using Rento.Entities.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.RentalRateSchemasController
{
    [ApiController]
    [Route("RentalRateSchemas")]
    public class RentalRateSchemaController : ControllerBase
    {
        private IRepository<RentalRateSchema> _repositoryRentalRateSchema;
        private IMapper _mapper;
        public RentalRateSchemaController(
            IRepository<RentalRateSchema> repositoryRentalRateSchema, 
            IMapper mapper)
        {
            _repositoryRentalRateSchema = repositoryRentalRateSchema;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<GetRentalRateSchemaDto> GetRentalRateSchema(int id)
        {
            if (id <= 0) throw new Exception("Invalid RentalRateSchema");
            var rentalRateSchema = await _repositoryRentalRateSchema.GetEntityAsync(id);
            if(rentalRateSchema== null) throw new Exception("Invalid RentalRateSchema");
            return _mapper.Map<GetRentalRateSchemaDto>(rentalRateSchema);
        }

        [HttpGet]
        public async Task<List<GetRentalRateSchemaDto>> GetAllRentalRateSchemas()
        {
            var rentalRateSchema = await _repositoryRentalRateSchema.GetAll().ToListAsync();
            if (rentalRateSchema == null) throw new Exception("Invalid RentalRateSchema");
            return _mapper.Map<List<GetRentalRateSchemaDto>>(rentalRateSchema);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRentalRateSchema(int id)
        {
            if (id <= 0) throw new Exception("Invalid RentalRateSchema");
            var rentalRateSchema = await _repositoryRentalRateSchema.GetEntityAsync(id);
            if (rentalRateSchema == null) throw new Exception("Invalid RentalRateSchema");
            _repositoryRentalRateSchema.DeleteEntity(rentalRateSchema);
            _repositoryRentalRateSchema.Save();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRentalRateSchema(
            UpdateRentalRateSchemaDto updateRentalRateSchemaDto)
        {
            var rentalRateSchema = await _repositoryRentalRateSchema
                .GetEntityAsync(updateRentalRateSchemaDto.Id);
            if (rentalRateSchema == null) throw new Exception("Invalid RentalRateSchema");
            var rentalRateSchemamap = _mapper.Map<RentalRateSchema>(updateRentalRateSchemaDto);
            _repositoryRentalRateSchema.Clear();
            _repositoryRentalRateSchema.UpdateEntity(rentalRateSchemamap);
            _repositoryRentalRateSchema.Save();

            return Ok(rentalRateSchemamap);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentalRateSchema(
            CreateRentalRateSchemaDto createRentalRateSchemaDto)
        {
            var create = new RentalRateSchema(
                createRentalRateSchemaDto.RentalName,
                createRentalRateSchemaDto.DayRentFrom,
                createRentalRateSchemaDto.DayRentTo);

            _repositoryRentalRateSchema.AddEntity(create);
            _repositoryRentalRateSchema.Save();

            return Ok(create);
        }
    }
}
