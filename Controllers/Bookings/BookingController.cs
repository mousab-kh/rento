using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rento.Controllers.Bookings.Dto;
using Rento.Entities.Entities;
using Rento.Entities.Enums;
using Rento.Infrastructure.Implemenation.Repository;
using Rento.Infrastructure.Interfaces;


namespace Rento.Controllers.Bookings
{
    [ApiController]
    [Route("Booking")]
    public class BookingController : ControllerBase
    {
        private IRepository<Booking> _repositoryBooking;
        private readonly IRepository<Branch> _repositoryBranch;
        private readonly IRepository<RentalRate> _repositoryRentalRate;
        private readonly IRepository<VehicleModel> _vehicleModelrepository;
        private readonly IRepository<BranchWorkingHour> _branchWorkingHourRepository;
        private IMapper _mapper;

        public BookingController(
            IRepository<Booking> repositoryBooking, 
            IRepository<Branch> repositoryBranch,
            IRepository<RentalRate> repositoryRentalRate, 
            IRepository<VehicleCategorie> vehicleCategorierepository, 
            IRepository<VehicleModel> vehicleModelrepository, 
            IMapper mapper)
        {
            _repositoryBooking = repositoryBooking;
            _repositoryBranch = repositoryBranch;
            _repositoryRentalRate = repositoryRentalRate;
            _vehicleModelrepository = vehicleModelrepository;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<GetBookingDto> GetBooking(int id)
        {
            if (id <= 0) throw new Exception("Invalid Booking id");
            var booking= await _repositoryBooking.GetEntityAsync(id);
            if (booking == null) throw new Exception("Invalid Booking");
            return _mapper.Map<GetBookingDto>(booking);
        }

        [HttpGet("GetAll")]
        public async Task<List<GetBookingDto>> GetAllBooking()
        {
            var booking = await _repositoryBooking.GetAll().ToListAsync();
            if (booking == null) throw new Exception("Invalid Booking");
            return _mapper.Map<List<GetBookingDto>>(booking);
        }

        [HttpDelete("Delete")]
        public async Task DeleteBooking(int id)
        {
            if (id <= 0) throw new Exception("Invalid Booking id");
            var booking = await _repositoryBooking.GetEntityAsync(id);
            if (booking == null) throw new Exception("Invalid Booking");
            _repositoryBooking.DeleteEntity(booking);
            _repositoryBooking.Save();
        }

        [HttpPut("Update")]
        public async Task UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var booking = await _repositoryBooking.GetEntityAsync(updateBookingDto.Id);
            _repositoryBooking.Clear();
            if (booking == null) throw new Exception("Invalid Booking");
            var bookingmap = _mapper.Map<Booking>(booking);
            _repositoryBooking.UpdateEntity(bookingmap);
            _repositoryBooking.Save();
        }

        [HttpPost("Create")]

        public async Task CreateBooking(CreateBookingDto createBookingDto)
        {
            if (!await _repositoryBranch.AnyAsync(i => i.Id == createBookingDto.PickupBranchId))
                throw new Exception("Invalid Pickup Branch");
            if (!await _repositoryBranch.AnyAsync(i => i.Id == createBookingDto.DropOffBranchId))
                throw new Exception("Invalid DropOff Branch");
            if (!await _repositoryRentalRate.AnyAsync(i => i.Id == createBookingDto.RentalRateId))
                throw new Exception("Invalid Rental Rate");
            if (!await _vehicleModelrepository.AnyAsync(i => i.Id == createBookingDto.VehicleModelId))
                throw new Exception("Invalid Vehicle Model");

            var PickupBranchWorkingHour = await _branchWorkingHourRepository.GetAll()
                .Where(i => i.BranchId == createBookingDto.PickupBranchId)
                .Where(m => m.StartTime < createBookingDto.PickupDate)
                .Where(e => e.EndTime > createBookingDto.PickupDate)
                .ToListAsync();
            if (PickupBranchWorkingHour == null) throw new Exception("Invalid Pickup Branch WorkingHour Time");



            var DropOffBranchWorkingHour = await _branchWorkingHourRepository.GetAll()
                .Where(i => i.BranchId == createBookingDto.DropOffBranchId)
                .Where(m => m.StartTime < createBookingDto.DropffDate)
                .Where(e => e.EndTime > createBookingDto.DropffDate)
                .ToListAsync();
            if (DropOffBranchWorkingHour == null) throw new Exception("Invalid DropOff Branch WorkingHour Time");

                var create = new Booking(
                    createBookingDto.PickupBranchId,
                    createBookingDto.DropOffBranchId,
                    createBookingDto.RentalRateId,
                    createBookingDto.VehicleModelId,
                    createBookingDto.PickupDate,
                    createBookingDto.DropffDate,
                    BookingStatus.Open);
        }

    }
}
