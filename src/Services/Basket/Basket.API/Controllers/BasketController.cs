using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCard), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCard>> GetBasket(string userName)
        {
            ShoppingCard basket = await _repository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCard(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCard), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCard>> UpdateBasket([FromBody] ShoppingCard shoppingCard)
        {
            return Ok(await _repository.UpdateBasket(shoppingCard));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ShoppingCard), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);

            return Ok();
        }
    }
}
