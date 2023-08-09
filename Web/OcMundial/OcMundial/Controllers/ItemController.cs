using BlazorApp1.Data.Context;
using BlazorApp1.Data.Models;
using BlazorApp1.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OcMundial.Controllers
{
    [ApiController]
    [Route("api")]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemController()
        {
            _context = new AppDbContext();
        }

        [HttpGet("item")]
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
    }
}
