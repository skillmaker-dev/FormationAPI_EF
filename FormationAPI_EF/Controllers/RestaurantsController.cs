using Business.Contracts;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FormationAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantService;

        public RestaurantsController(IRestaurantsService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Restaurant>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Restaurant), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(id);

            if (restaurant is null)
                return NotFound("Could not find the restaurant.");

            return Ok(restaurant);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Restaurant),(int)HttpStatusCode.Created)]
        public async Task<ActionResult<Restaurant>> AddRestaurant(Restaurant restaurant)
        {
            await _restaurantService.AddRestaurantAsync(restaurant);
            return CreatedAtRoute(nameof(GetRestaurant), new { id = restaurant.Id },restaurant); // Produit un erreur 500  "No route matches the supplied values"
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
                return BadRequest("Ids do not match.");

            await _restaurantService.UpdateRestaurantAsync(restaurant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantAsync(id);

            if (restaurant is null)
                return NotFound("Could not find the restaurant to delete");

            await _restaurantService.DeleteRestaurantAsync(id);

            return NoContent();
        }
    }
}
