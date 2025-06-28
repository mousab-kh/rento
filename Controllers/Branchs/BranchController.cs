using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.Branchs.Dto;
using Rento.Entities;
using Rento.Infrastructure.Interfaces;

namespace Rento.Controllers.Branchs
{
    [ApiController]
    [Route("Branch")]
    public class BranchController : ControllerBase
    {
        
        private IRepository<Branch> _branchrepository;
        private IMapper _mapper;

        public BranchController(IRepository<Branch> repository,IMapper mapper)
        {

            _branchrepository = repository;
            _mapper = mapper;
        }

        [HttpDelete]
        public async Task DeleteBranch(int Id)
        {
            if (Id<0) throw new Exception
                    ("Invalid branch Id");

            var branchtodelete = await _branchrepository.GetEntityAsync(Id);
            if (branchtodelete == null) 
                throw new Exception("Invalid branch");
            
            _branchrepository.DeleteEntity(branchtodelete);
            _branchrepository.Save();
        }
        [HttpPut]
        public async Task UpdateBranch(UpdateBranchDto branchdto)
        {
            var branchenitity = await _branchrepository.GetEntityAsync(branchdto.Id);
            if (branchenitity == null) 
                throw new Exception("Invalid Update branch");
            _branchrepository.Clear();

            var branchUpdate = _mapper.Map<Branch>(branchdto);
            _branchrepository.UpdateEntity(branchUpdate);
            _branchrepository.Save();
        }

        [HttpPost]
        public void AddBranch(CreateBranchDto branch)
        {
            if (branch.Name == null) 
                throw new Exception("Invalid branch");

            Branch BranchEntity = new Branch(
                branch.Name,
                branch.Coordinateslatitude,
                branch.Coordinateslongitude, 
                true );

            _branchrepository.AddEntity(BranchEntity);
            _branchrepository.Save();
        }

        [HttpGet("{Id}")]
        public async Task<GetBranchDto> GetBranch(int Id)
        {
            if (Id < 0) throw new Exception
                     ("Invalid branch Id");
            var branchrepository = await _branchrepository.GetEntityAsync(Id);
            if (branchrepository == null) 
                throw new Exception("Invalid branch/branch Id");
            return _mapper.Map<GetBranchDto>(branchrepository);
             
        }


        [HttpGet]
        public async Task<List<GetBranchDto>> GetAll()
        {
            var branchsentity = await _branchrepository.GetAll().ToListAsync();
            if (branchsentity == null) throw new Exception("Invalid branchs");

            return _mapper.Map<List<GetBranchDto>>(branchsentity); 
        }

    }

    

    
}
