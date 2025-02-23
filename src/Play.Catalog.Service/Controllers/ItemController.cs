using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Common;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Items> itemsRepository;

        public ItemsController(IRepository<Items> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }


        // 
        [HttpGet]
        public async Task<IEnumerable<ItemsDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
                        .Select(items => items.AsDto());
            return items;
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