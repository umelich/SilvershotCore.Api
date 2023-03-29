using Microsoft.AspNetCore.Mvc;
using SilvershotCore.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;

namespace SilvershotCore.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public ItemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetItems")]
        public List<ItemModel> GetItems()
        {
            return LoadListFromDB();
        }

        [HttpGet]
        [Route("GetItemByID")]
        public List<ItemModel> GetItemByID(string itemID)
        {
            return LoadListFromDB().Where(i => i.ItemCode == itemID).ToList();
        }

        // TODO:
        // rewrite string 42 itemModel.ItemPrice
        [HttpPost]
        [Route("PostItem")]
        public string PostItem(ItemModel itemModel)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Item VALUES('"+ itemModel.ItemCode + "','"+ itemModel.ItemName + "','" + itemModel.ItemPrice + "','"+ itemModel.ItemDetails + "')", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            List<ItemModel> itemList = new List<ItemModel>();
            itemList.Add(itemModel);
            return "Item added successfully";
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public string DeleteItem(string itemID)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Item WHERE ItemID='"+ itemID + "'; ", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return "Item deleted successfully";
        }

        private List<ItemModel> LoadListFromDB()
        {
            List<ItemModel> itemList = new List<ItemModel>();
            
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Item", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ItemModel itemModel = new ItemModel();
                itemModel.ItemCode = dataTable.Rows[i]["ItemCode"].ToString();
                itemModel.ItemName = dataTable.Rows[i]["ItemName"].ToString();
                itemModel.ItemPrice = decimal.Parse(dataTable.Rows[i]["ItemPrice"].ToString());
                itemModel.ItemDetails = dataTable.Rows[i]["ItemDetails"].ToString();
                itemList.Add(itemModel);
            }
            
            return itemList;
        }
    }
}
