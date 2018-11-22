using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Newtonsoft.Json;
using Windows.Storage;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.AppExtensions;
using BookingSoftware.Model;
using System.Windows;
using Windows.UI.Popups;

namespace BookingSoftware.Persistency
{
   static class AuthentificationPersistency
    {
        public static StorageFolder folder = ApplicationData.Current.LocalFolder;
        public static StorageFile Customers;
        public static StorageFile logfile;
        public static string TempStringCustomer;

        


        //Writing Dicionary to JSON and file.
        public static async void SavngCustomerToFile(List<Customer> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Customers = await folder.CreateFileAsync("Customer.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(Customers, json);
        }
       
        
        //Getting Customers string from Json.
        private static async Task<string> GetCustomersStrigFromJson()
        {
            Customers = await folder.CreateFileAsync("HostsList.json", CreationCollisionOption.OpenIfExists);
            string json = await FileIO.ReadTextAsync(Customers);

            if (json == null)
            {
                TempStringCustomer = "";
            }
            else { TempStringCustomer = json; }
            return TempStringCustomer;
        }
       
        
        //Creating log file to store there all exceptions.
        public static async void AddLog(string log)
        {

            try
            {
                logfile = await folder.CreateFileAsync("Logfile.txt", CreationCollisionOption.OpenIfExists);
                log = log + await FileIO.ReadTextAsync(logfile);
                await FileIO.WriteTextAsync(logfile, log);
            }
            catch (Exception)
            {

            }
        }

      
        //Getting Customers list from File.
        public static async Task<List<Customer>> GetCustomersListFromFile()
        {

            await GetCustomersStrigFromJson();
            List<Customer> returnedlist = new List<Customer>();
            try
            {
                returnedlist = JsonConvert.DeserializeObject<List<Customer>>(TempStringCustomer);

            }
            catch (Exception e)
            {
                AuthentificationPersistency.AddLog($"{DateTime.Now}   exception {e.Message} was caught while getting Customers list\n");

            }
            if (returnedlist == null)
            {
                return new List<Customer>();
            }
            else return returnedlist;

        }

        
        //Checking existence of user.
        public static async Task<bool> CheckIfExists()
        {
            Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;
            List<Customer> Customers = await GetCustomersListFromFile();
            Customer customer = Customers.FirstOrDefault(x => x.Email == _customer.Email);
            Customer customer3 = Customers.FirstOrDefault(x => x.PhoneNumber == _customer.PhoneNumber);
            if (customer3 == null || customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static async Task<Customer> GetUserByEmail()
        {
            Customer returnedCusomer = new Customer();
            Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;
            List<Customer> clist = await GetCustomersListFromFile();
            returnedCusomer = clist.FirstOrDefault(x => x.Email == _customer.Email);
            return returnedCusomer;

        }
        //Create Account
        public static async void CreateAccount()
        {

            if (await CheckIfExists())
            {
               var dialog = new MessageDialog("You need to use other Email or Phone Number.");
                await dialog.ShowAsync();
            }
            else
            {
                Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;
                List<Customer> clist = await GetCustomersListFromFile();
                clist.Add(_customer);
                SavngCustomerToFile(clist);
            }
        }
        //Modify account
        //public static async void ModifyAccount()
        //{
        //    Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;
        //    List<Customer> clist = await GetCustomersListFromFile();
        //    int index = clist.FindIndex(x => x.Name == _customer.Name);
        //    clist[index] =

        //}
        

        //Login to account.
        public static async void LoginToAcc()
        {
            if (await CheckIfExists())
            {
                var dialog = new MessageDialog("You need to use other Email or Phone Number.");
                await dialog.ShowAsync();
            }
            else

        }

    }
}
