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
        //It makes folder with files somwhere in %appdata%. We will be able to figure out exact path with breakpoints later. But it doesnt really matter.
        public static StorageFolder folder = ApplicationData.Current.LocalFolder;
        //Makes file with customer models.
        public static StorageFile Customers;
        //Makes file with log(All exceptions will be saved there)-Its useless but makes project more professional. Am I right?
        public static StorageFile logfile;
        //Just some string that is being used while serializing  and deserializing.
        public static string TempStringCustomer;

       private static Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;


        //Saving customer list to .json file.
        public static async void SavingCustomerToFile(List<Customer> list)
        {
            //Serialize list to .json format.
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            //Create .json file with given name. If its already created then content will be replaced.
            Customers = await folder.CreateFileAsync("Customer.json", CreationCollisionOption.ReplaceExisting);
            //Writes .json format to file.
            await FileIO.WriteTextAsync(Customers, json);
        }
       
        
        //Getting Customers string from Json.
        private static async Task<string> GetCustomersStrigFromJson()
        {
            //Open file if it exist.
            Customers = await folder.CreateFileAsync("HostsList.json", CreationCollisionOption.OpenIfExists);
            //Read file to json
            string json = await FileIO.ReadTextAsync(Customers);
            //If there is nothing in  file then  return empty string.
            if (json == null)
            {
                TempStringCustomer = "";
            }
            //if its not empty then rewrite content to TempStringCustomer and return it.
            else { TempStringCustomer = json; }
            return TempStringCustomer;
        }
       
        
        //Creating log file to store there all exceptions. No need to read from it anyway.
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
            //return TempStringCustomer string(You can find method above).
            await GetCustomersStrigFromJson();
            //Implementing list in which we will save objects.
            List<Customer> returnedlist = new List<Customer>();
            try
            {
                //Read TempStringCustomer string to list.
                returnedlist = JsonConvert.DeserializeObject<List<Customer>>(TempStringCustomer);

            }
            //If smth will go wrong, extception will be saved to file.
            catch (Exception e)
            {
                AuthentificationPersistency.AddLog($"{DateTime.Now}   exception {e.Message} was caught while getting Customers list\n");

            }
            //if there is nothing in TempStringCustomer, then make a new list. If there is data in TempStringCustomer then return returnedlist.
            if (returnedlist == null)
            {
                return new List<Customer>();
            }
            else return returnedlist;

        }

        
        //Checking existence of user.
        public static async Task<bool> CheckIfExists()
        {
            //Read list from file.
            List<Customer> Customers = await GetCustomersListFromFile();
            //checks if any object's email from the list is same as the one from singleton. Same with Phone Number.
             if ((Customers.FirstOrDefault(x => x.Email == _customer.Email) == null) || (Customers.FirstOrDefault(x => x.PhoneNumber == _customer.PhoneNumber) == null))
            {
                return false;
            }
            else { return true; }
        }
        
        
        //return customer with given email(may be usefull some day).
        public static async Task<Customer> GetUserByEmail()
        {
            Customer returnedCustomer = new Customer();
           
            List<Customer> clist = await GetCustomersListFromFile();
            returnedCustomer = clist.FirstOrDefault(x => x.Email == _customer.Email);
            return returnedCustomer;

        }
       
        
        //Create Account
        public static async Task<bool> CreateAccount()
        {
            //Check if account with given email and password exists. If not then MesssegeDialog is being thrown on  screen.
            if (await CheckIfExists())
            {
               var dialog = new MessageDialog("You need to use other Email or Phone Number.");
                await dialog.ShowAsync();
                return false;
            }
            else
            {
                List<Customer> clist = await GetCustomersListFromFile();
                //Adding customer to the list and then saving it into the file.
                clist.Add(_customer);
                SavingCustomerToFile(clist);
                return true;
            }
        }
        //Modify account(dunno how it is supposed to work. I guess we need an other singleton object?)
        //public static async void ModifyAccount()
        //{
        //    Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;
        //    List<Customer> clist = await GetCustomersListFromFile();
        //    int index = clist.FindIndex(x => x.Name == _customer.Name);
        //    clist[index] =

        //}
        

        //Login to account.
        public static async Task<bool> LoginToAcc()
        {
                List<Customer> clist = await GetCustomersListFromFile();
            //if any object from list has same email and password as the ones from singleton then return true if not throw MessageDialog.
            if (clist.FirstOrDefault(x => (x.Email == _customer.Email && x.Password == _customer.Password)) == null)
            {

                var dialog = new MessageDialog("You need to use different Email or password.");
                await dialog.ShowAsync();
                return false;
            }
            else
            {
                return true;
            }

                
                
            
            
            
               
            
           



            }
        }

    }

