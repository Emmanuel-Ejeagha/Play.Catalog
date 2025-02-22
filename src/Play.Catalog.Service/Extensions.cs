using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service
{
    public static class Extensions
    {
        public static ItemsDto AsDto(this Items item)
        {
            return new ItemsDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}