using MicroMultiBusiness.Basket.DTOs;
using MicroMultiBusiness.Basket.Settings;
using System.Text.Json;

namespace MicroMultiBusiness.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDTO> GetBasket(string userId)
        {
            return JsonSerializer.Deserialize<BasketTotalDTO>(await _redisService.GetDb().StringGetAsync(userId));
        }

        public async Task SaveBasket(BasketTotalDTO basketTotalDTO)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDTO.UserId, JsonSerializer.Serialize(basketTotalDTO));
        }
    }
}
