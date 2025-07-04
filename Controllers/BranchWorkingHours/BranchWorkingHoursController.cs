using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.BranchWorkingHours.Dto;
using Rento.Entities.Entities;
using Rento.Entities.ValueObjects;
using Rento.Infrastructure.Interfaces;
using System.Threading.Tasks;


namespace Rento.Controllers.BranchWorkingHours
{
    [ApiController]
    [Route("BranchWorkingHours")]
    public class BranchWorkingHoursController : ControllerBase
    {
        private IRepository<BranchWorkingHour> _branchWorkingHourRepository;
        private readonly IRepository<Branch> _branchRepository;
        private IMapper _mapper;

        public BranchWorkingHoursController(
            IRepository<BranchWorkingHour> repository,
            IRepository<Branch> repositoryBranch,
            IMapper mapper)
        {
            _branchRepository = repositoryBranch;
            _branchWorkingHourRepository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Create(CreateBranchWorkingHourInputDto input)
        {
            if (input == null)
                throw new Exception("Invalid input");
            if (input.BranchId<0)
                throw new Exception("Invalid input");
            if (await _branchRepository.GetEntityAsync(input.BranchId) == null)
                throw new Exception("Invalid branch id");

            var workingHoursInterval = _mapper.Map<List<WorkingHourIntervalValueObject>>(input.Intervals);
            var branchWorkingHour = BranchWorkingHour.Create(
                input.StartTime,
                input.EndTime,
                input.BranchId,
                workingHoursInterval);

            _branchWorkingHourRepository.AddEntity(branchWorkingHour);
            _branchWorkingHourRepository.Save();
        }

        [HttpGet("{id}")]
        public async Task<GetBranchWorkingHourOutputDto> Get(int id)
        {
            if (id < 0)
                throw new Exception("Invalid id");

            var branchWorkingHour = await _branchWorkingHourRepository.GetEntityAsync(id);
            if (branchWorkingHour == null)
                throw new Exception("Invalid branch working hour");

            return _mapper.Map<GetBranchWorkingHourOutputDto>(branchWorkingHour);
        }

        [HttpGet]
        public async Task<List<GetBranchWorkingHourOutputDto>> GetAll()
        {
            var branchWorkingHoures = await _branchWorkingHourRepository.GetAll().ToListAsync();

            return _mapper.Map<List<GetBranchWorkingHourOutputDto>>(branchWorkingHoures);
        }

        [HttpPut]
        public async Task Update(UpdateBranchWorkingHourInputDto input)
        {
            if (await _branchRepository.GetEntityAsync(input.BranchId) == null)
                throw new Exception("Invalid branch id");

            var branchWorkingHour = await _branchWorkingHourRepository.GetEntityAsync(input.Id);
            if (branchWorkingHour == null)
                throw new Exception("Invalid branch working hour");

            var workingHoursInterval = _mapper
                .Map<List<WorkingHourIntervalValueObject>>(input.Intervals);
            branchWorkingHour.Update(
                input.StartTime, 
                input.EndTime, 
                input.BranchId, 
                workingHoursInterval, 
                input.IsActive);

            _branchWorkingHourRepository.UpdateEntity(branchWorkingHour);
            _branchWorkingHourRepository.Save();
        }

        [HttpDelete]
        public async Task DeleteBranch(int id)
        {
            var branchWorkingHourentity = await _branchWorkingHourRepository.GetEntityAsync(id);
            if (branchWorkingHourentity == null)
                throw new Exception("Invalid branch working hour");

            _branchWorkingHourRepository.DeleteEntity(branchWorkingHourentity);
            _branchWorkingHourRepository.Save();
        }
    }
}
