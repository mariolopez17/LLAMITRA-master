using LlamitraApi.Models;

namespace LlamitraApi.Repository.IRepository
{
    public interface IStartRatingRepository
    {
        void AddRating(int productId, int rating, int userId);
        IEnumerable<int> GetRatings(int publicationId);
    }

}
