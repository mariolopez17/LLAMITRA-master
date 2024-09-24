using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LlamitraApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StartRatingController(IStartRatingService ratingService) : ControllerBase
    {
        private readonly IStartRatingService _ratingService = ratingService;

        [HttpPost("{publicationId}/rate")]
        public IActionResult RatePublication(int publicationId, [FromBody] int rating)
        {
            var userId = GetUserId(); 
            try
            {
                _ratingService.RateProduct(publicationId, rating, userId); 
                return Ok("Calificación enviada correctamente.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{publicationId}/rate")]
        public IActionResult UpdatePublicationRating(int publicationId, [FromBody] int rating)
        {
            var userId = GetUserId(); 
            try
            {
                _ratingService.UpdateRating(publicationId, rating, userId); 
                return Ok("Calificación actualizada correctamente.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound("La calificación no fue encontrada.");
            }

        }
            [HttpGet("{publicationId}/average-rating")]
            public IActionResult GetAverageRating(int publicationId)
            {
                var averageRating = _ratingService.GetAverageRating(publicationId);
                return Ok(new { AverageRating = averageRating });
            }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            throw new UnauthorizedAccessException("El usuario no está autenticado.");
        }

    }
    }
