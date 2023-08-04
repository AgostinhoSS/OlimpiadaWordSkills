using BlazorApp1.Data.Context;
using BlazorApp1.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OcMundial.Data.Models;

namespace BlazorApp1.Data.Services
{
    public class ItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public List<Items> GetItems()
        {

            var sql = @"SELECT Items.ID, Items.AreaID, Items.Title, Items.Capacity, ItemPictures.PictureFileName, ItemPrices.Price
                         FROM Items INNER JOIN
                         ItemPrices ON Items.ID = ItemPrices.ItemID INNER JOIN
                         ItemPictures ON Items.ID = ItemPictures.ItemID INNER JOIN
                         Areas ON Items.AreaID = Areas.ID";
            var result = _context.Items.FromSqlRaw(sql).ToList();
            return result;
        }

        public List<ItemAmenitie> GetItemsAmenities(int idItem)
        {

            var sql = @"SELECT        Items.ID, ItemAmenities.ItemID, Amenities.Name, Amenities.IconName
                        FROM            Items INNER JOIN
                                                    ItemAmenities ON Items.ID = ItemAmenities.ItemID INNER JOIN
                                                    Amenities ON ItemAmenities.AmenityID = Amenities.ID
                        WHERE        (ItemAmenities.ItemID = @idItem)";
            var result = _context.ItemAmenitie.FromSqlRaw(sql, new { idItem }).ToList();
            return result;

        }
    }
}
