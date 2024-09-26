using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace LlamitraApi.Services
{
    public class StartRatingService(IStartRatingRepository repository, ProyectoIContext dbContext) : IStartRatingService
    {
        private readonly ProyectoIContext _dbContext = dbContext;
        private readonly IStartRatingRepository _repository = repository;
        public void RateProduct(int publicationId, int rating, int userId)
        {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "La puntuación debe estar comprendida entre 1 y 5.");
            }

            _repository.AddRating(publicationId, rating, userId);
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
        public int GetUserRating(int publicationId, int userId)
        {
            var publicationRating = _dbContext.PublicationRatings
                .FirstOrDefault(pr => pr.IdPublication == publicationId && pr.IdUser == userId);

            if (publicationRating == null)
            {
                return 0; // O lanzar una excepción si prefieres
            }

            return publicationRating.Rating;
        }

        public void UpdateRating(int publicationId, int rating, int userId)
        {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "La calificación debe estar entre 1 y 5.");
            }

            var publicationRating = _dbContext.PublicationRatings
                .FirstOrDefault(pr => pr.IdPublication == publicationId && pr.IdUser == userId);

            if (publicationRating == null)
            {
                throw new KeyNotFoundException("La calificación para esta publicación no fue encontrada.");
            }

            publicationRating.Rating = rating;
            _dbContext.SaveChanges();
        }

    }
}