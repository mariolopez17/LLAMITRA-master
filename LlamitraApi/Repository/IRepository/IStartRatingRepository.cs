namespace LlamitraApi.Repository.IRepository
{
    public interface IStartRatingRepository
    {
        void AddRating(int productId, int rating);
        IEnumerable<int> GetRatings(int productId);
    }

}
