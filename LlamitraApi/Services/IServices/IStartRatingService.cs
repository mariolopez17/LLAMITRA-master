using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Services.IServices
{
    public interface IStartRatingService
    {
        void RateProduct(int publicationId, int rating, int userId);
        double GetAverageRating(int publicationId);
        void UpdateRating(int publicationId, int rating, int userId);
    }

}
