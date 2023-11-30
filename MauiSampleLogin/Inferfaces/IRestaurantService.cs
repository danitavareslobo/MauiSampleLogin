using MauiSampleLogin.Models.Restaurant;

namespace MauiSampleLogin.Inferfaces
{
    public interface IRestaurantService
    {
        Task<IList<RestaurantResponse>> GetAllAsync(string token);
    }
}
