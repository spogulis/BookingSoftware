using BookingSoftware.Model;
using BookingSoftware.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware.Persistency
{
    public class ActiveUserSingleton
    {
        private static ActiveUserSingleton _instance;
        private static IUser _user;

        private ActiveUserSingleton()
        {
            
        }

        public static ActiveUserSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ActiveUserSingleton();
                }
                return _instance;
            }
        }

        public static void SetActiveUser(IUser user)
        {
            _user = user;
        }

        public static IUser GetActiveUser()
        {
            return _user;
        }
    }
}
