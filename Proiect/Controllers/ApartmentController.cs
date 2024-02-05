using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Dto;
using Proiect.Interface;
using Proiect.Models;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ApartmentController(IApartmentRepository apartmentRepository,
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Apartment>))]
        public IActionResult GetApartments()
        {
            var apartments = _mapper.Map<List<ApartmentDto>>(_apartmentRepository.GetApartments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(apartments);
        }

        [HttpGet("{apartmentId}")]
        [Authorize(Roles = "User")]
        [ProducesResponseType(200, Type = typeof(Apartment))]
        [ProducesResponseType(400)]
        public IActionResult GetApartment(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            var apartment = _mapper.Map<ApartmentDto>(_apartmentRepository.GetApartment(apartmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(apartment);
        }

        [HttpGet("{apartmetId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetApartmentRating(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            var rating = _apartmentRepository.GetApartmentRating(apartmentId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApartment([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] ApartmentDto apartmentCreate)
        {
            if (apartmentCreate == null)
                return BadRequest(ModelState);

            var apartments = _apartmentRepository.GetApartmentTrimToUpper(apartmentCreate);

            if (apartments != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var apartmentMap = _mapper.Map<Apartment>(apartmentCreate);


            if (!_apartmentRepository.CreateApartment(ownerId, catId, apartmentMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{apartmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateApartment(int apartmentId,
            [FromQuery] int ownerId, [FromQuery] int catId,
            [FromBody] ApartmentDto updatedApartment)
        {
            if (updatedApartment == null)
                return BadRequest(ModelState);

            if (apartmentId != updatedApartment.Id)
                return BadRequest(ModelState);

            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var apartmentMap = _mapper.Map<Apartment>(updatedApartment);

            if (!_apartmentRepository.UpdateApartment(ownerId, catId, apartmentMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{apartmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteApartment(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfAnApartment(apartmentId);
            var ApartmentToDelete = _apartmentRepository.GetApartment(apartmentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_apartmentRepository.DeleteApartment(ApartmentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

    }
}
