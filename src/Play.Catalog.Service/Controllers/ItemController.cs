using System.ComponentModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Common;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Items> itemsRepository;
        private static int requestCounter = 0;

        public ItemsController(IRepository<Items> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }


        // 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemsDto>>> GetAsync()
        {
            requestCounter++;
            Console.WriteLine($"Request {requestCounter}: Starting..");

            if (requestCounter <= 2)
            {
                Console.WriteLine($"Request {requestCounter}: Delaying...");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }

            if (requestCounter <= 4)
            {
                Console.WriteLine($"Request {requestCounter}: 500 (Internal Server Error).");
                return StatusCode(500);
            }

            var items = (await itemsRepository.GetAllAsync())
                        .Select(items => items.AsDto());

            Console.WriteLine($"Request {requestCounter}: 200 (OK).");
            return Ok(items);
        }

        // GET /api/items
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemsDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();

        }

        // POST /api/items
        [HttpPost]
        public async Task<ActionResult<ItemsDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new Items
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await itemsRepository.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        // PUT /api/items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await itemsRepository.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await itemsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        // DELETE /api/items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await itemsRepository.RemoveAsync(item.Id);
            return NoContent();
        }
    }
}