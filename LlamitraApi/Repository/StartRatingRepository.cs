﻿using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace LlamitraApi.Repository
{
    

    public class StartRatingRepository(ProyectoIContext dbContext) : IStartRatingRepository
    {
        private readonly ProyectoIContext _dbContext = dbContext;

        
        public void AddRating(int publicationId, int rating)
        {
            var ratingEntity = new PublicationRating
            {
                IdPublication = publicationId, 
                Rating = rating
            };

            _dbContext.PublicationRatings.Add(ratingEntity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<int> GetRatings(int publicationId)
        {
            return _dbContext.PublicationRatings
                           .Where(r => r.IdPublication == publicationId) 
                           .Select(r => r.Rating)
                           .ToList();
        }
    }
}
