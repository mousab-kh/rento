using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.VehicleCategories.Dto;
using Rento.Infrastructure.Interfaces;
using VehicleCategorie = Rento.Entities.Entities.VehicleCategorie;

namespace Rento.Controllers.VehicleCategories
{
    [ApiController]
    [Route("VehicleCategorie")]
    public class VehicleCategorieController  : ControllerBase
    {

        private IRepository<VehicleCategorie> _vehicleCategorierrepository;
        private IMapper _mapper;

        public VehicleCategorieController(
            IRepository<VehicleCategorie> _vehiclecategorierrepository, 
            IMapper mapper)
        {
            _vehicleCategorierrepository = _vehiclecategorierrepository;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<GetVehicleCategorieDto> GetVehicleCategorie(int id)
        {
            if (id <= 0) throw new Exception ("Invalid Vehicle Categorie");

            var categorie = await _vehicleCategorierrepository.GetEntityAsync(id);
            if (categorie == null) throw new Exception("Invalid Vehicle Categorie");

            return _mapper.Map<GetVehicleCategorieDto>(categorie);
        }

        [HttpGet("GetAll")]
        public async Task<List<GetVehicleCategorieDto>> GetAllCategorie()
        {
            var categorie = await _vehicleCategorierrepository.GetAll().ToListAsync();
            if (categorie == null) throw new Exception("Invalid Vehicle Categorie");

            return _mapper.Map<List<GetVehicleCategorieDto>>(categorie);

        }

        [HttpDelete("Delete")]
        public async Task DeleteCategorie(int id)
        {
            var categorie = await _vehicleCategorierrepository.GetEntityAsync(id);
            if (categorie == null) throw new Exception("Invalid Vehicle Categorie");
            _vehicleCategorierrepository.DeleteEntity(categorie);
            _vehicleCategorierrepository.Save();

        }

        [HttpPut("Update")]
        public async Task UpdateCategorie(UpdateVehicleCategorieDto updateVehicleCategorieDto)
        {
            if(!await _vehicleCategorierrepository.AnyAsync(i=> i.Id== updateVehicleCategorieDto.Id))
                throw new Exception("Invalid Vehicle Categorie");

            var categorie = await _vehicleCategorierrepository.GetEntityAsync(updateVehicleCategorieDto.Id);
            _vehicleCategorierrepository.Clear();

            var categoriemap = _mapper.Map< VehicleCategorie>(updateVehicleCategorieDto);
            _vehicleCategorierrepository.DeleteEntity(categoriemap);
            _vehicleCategorierrepository.Save();
        }

        [HttpPost("Create")]
        public async Task CreateCategorie(CreateVehicleCategorieDto createVehicleCategorieDto)
        {
            var create = new VehicleCategorie(createVehicleCategorieDto.Name);
            _vehicleCategorierrepository.AddEntity(create);
            _vehicleCategorierrepository.Save();
        }
    }
}
