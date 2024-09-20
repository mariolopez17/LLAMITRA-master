using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                _ratingService.RateProduct(publicationId, rating); 
                return Ok("Calificación enviada correctamente.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{publicationId}/average-rating")]
        public IActionResult GetAverageRating(int publicationId)
        {
            var averageRating = _ratingService.GetAverageRating(publicationId); 
            return Ok(new { AverageRating = averageRating });
        }
    }

}
