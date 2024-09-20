using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using System.Collections.Generic;
using System.Linq;
namespace LlamitraApi.Services
{
    public class StartRatingService(IStartRatingRepository repository) : IStartRatingService
    {
        private readonly IStartRatingRepository _repository = repository;
        public void RateProduct(int publicationId, int rating)
        {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "La puntuación debe estar comprendida entre 1 y 5.");
            }

            _repository.AddRating(publicationId, rating); 
        }

        public double GetAverageRating(int publicationId)
        {
            var ratings = _repository.GetRatings(publicationId);
            if (!ratings.Any())
            {
                return 0; 
            }

            return ratings.Average();
        }
    }
}

