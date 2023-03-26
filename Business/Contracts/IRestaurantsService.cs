using Data.Entities;

namespace Business.Contracts
{
    public interface IRestaurantsService
    {
        Task AddRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int id);
        Task<Restaurant?> GetRestaurantAsync(int id);
        Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
        Task UpdateRestaurantAsync(Restaurant restaurant);
    }
}