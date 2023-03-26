using Business.Contracts;
using Data.Config;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly ApplicationDbContext _dbContext;

        public RestaurantsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            return await _dbContext.Restaurants.Include(r => r.Cuisine).ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantAsync(int id)
        {
            return await _dbContext.Restaurants.Include(r => r.Cuisine).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _dbContext.Restaurants.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            _dbContext.Entry(restaurant).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(id);
            if (restaurant is null)
                return;

            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();
        }
    }
}
