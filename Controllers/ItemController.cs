using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.LayoutRenderers.Wrappers;
using SilvershotCore.Models;


namespace SilvershotCore.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        [Route("GetItems")]
        public List<ItemModel> GetItems()
        {
            return LoadList();
        }

        private List<ItemModel> LoadList()
        {
            List<ItemModel> itemList = new List<ItemModel>();

            ItemModel itemModel = new ItemModel();
            itemModel.ItemCode = 1;
            itemModel.ItemName = "ItemName_1";
            itemModel.ItemPrice = 10;
            itemModel.ItemDetails = "ItemDetails_1";
            itemList.Add(itemModel);

            itemModel.ItemCode = 2;
            itemModel.ItemName = "ItemName_2";
            itemModel.ItemPrice = 20;
            itemModel.ItemDetails = "ItemDetails_2";
            itemList.Add(itemModel);

            return itemList;
        }
    }
}
