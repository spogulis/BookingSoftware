using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSoftware.Model;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace BookingSoftware.Persistency
{
    class AuthentificationPersistency
    {
        //Model of customer.
        public Customer _customer = ActiveUserSingleton.GetActiveUser() as Customer;
        //We need dictionary to store data while program is running.
        private Dictionary<int, object> _customers = new Dictionary<int, object>();
        //ID which will increment after creating new account.
        private int ID = 0;

        
       
       
        //Writing Dicionary to JSON and file.
        public void Writing(string path, Dictionary<int,object> dictionary)
        {
          using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, dictionary);
            }
        }
        //Reading File to JSON and JSON to Dicionary.
        public void Reading(string path)
            {
            using (StreamReader file = File.OpenText(path))
                {
                JsonSerializer serializer = new JsonSerializer();
                Dictionary<int,object> dictionary = (Dictionary<int,object>)serializer.Deserialize(file, typeof(Dictionary<int,object>));
                }
            }


        //Create Account
        public void CreateAccount()
        {
            _customers.Add(ID,_customer);
            Writing(@"c:\Projekt\CustomerModel.json",_customers);
            ID++;
        }
    }
}
