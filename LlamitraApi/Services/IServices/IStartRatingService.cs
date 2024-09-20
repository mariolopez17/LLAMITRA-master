namespace LlamitraApi.Services.IServices
{
    public interface IStartRatingService
    {
        void RateProduct(int productId, int rating);
        double GetAverageRating(int productId);
    }

}
