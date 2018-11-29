using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using BookingSoftware.Model;
using Newtonsoft.Json;

namespace BookingSoftware.Persistency
{
    static class OrdersPersistency
    {
        public static StorageFolder folder = ApplicationData.Current.LocalFolder;

        public static StorageFile Orders;

        public static StorageFile OrdersLogFile;

        public static string TempStringOrders;

        private static Order _order = new Order();


        public static async void SavingOrdersToFile(List<Order> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Orders = await folder.CreateFileAsync("Orders.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(Orders, json);
        }


        private static async Task<string> GetOrderStringFromJson()
        {
            Orders = await folder.CreateFileAsync("Order.json", CreationCollisionOption.OpenIfExists);
            string json = await FileIO.ReadTextAsync(Orders);
            if (json == null)
            {
                TempStringOrders = "";
            }
            else
                TempStringOrders = json;
            return TempStringOrders;
        }


        public static async void AddLog(string log)
        {
            try
            {
                OrdersLogFile = await folder.CreateFileAsync("Logfile.txt", CreationCollisionOption.OpenIfExists);
                log = log + await FileIO.ReadTextAsync(OrdersLogFile);
                await FileIO.WriteTextAsync(OrdersLogFile, log);
            }
            catch (Exception)
            {

            }
        }


        public static async Task<List<Order>> GetOrdersListFromFile()
        {
            await GetOrderStringFromJson();
            List<Order> returnedlist = new List<Order>();
            try
            {
                returnedlist = JsonConvert.DeserializeObject<List<Order>>(TempStringOrders);
            }
            catch (Exception e)
            {
                OrdersPersistency.AddLog($"{DateTime.Now} exception {e.Message} was caught while getting Orders list\n");
            }

            if (returnedlist == null)
            {
                return new List<Order>();
            }
            else return returnedlist;
        }


    }
}