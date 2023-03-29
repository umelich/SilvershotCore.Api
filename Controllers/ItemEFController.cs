using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SilvershotCore.DataModels;
using SilvershotCore.Models;
using System.Data.SqlClient;
using System.Linq;

namespace SilvershotCore.Controllers
{
    [ApiController]
    public class ItemEFController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public ItemEFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetItemsEF")]
        public List<Item> GetItemsEF()
        {
            SilvershotDbContext context = new SilvershotDbContext();
            return context.Items.ToList();
        }

        [HttpGet]
        [Route("GetItemByIDEF")]
        public List<Item> GetItemByIDEF(int itemId)
        {
            SilvershotDbContext context = new SilvershotDbContext();
            return context.Items.Where(i => i.ItemId == itemId).ToList();
        }

        [HttpPost]
        [Route("PostItemEF")]
        public string PostItemEF(Item item)
        {
            SilvershotDbContext context = new SilvershotDbContext();
            context.Items.Add(item);
            context.SaveChanges();
            
            return "Item added successfully";
        }

        [HttpDelete]
        [Route("DeleteItemEF")]
        public string DeleteItemEF(int itemId)
        {
            SilvershotDbContext context = new SilvershotDbContext();
            Item item = context.Items.FirstOrDefault(i => i.ItemId == itemId);
            context.Items.Remove(item);
            
            context.SaveChanges();

            return "Item added successfully";
        }
    }
}
