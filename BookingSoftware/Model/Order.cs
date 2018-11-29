using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware.Model
{
    class Order
    {
        private string _facilityName;
        private string _address;
        private int _area;
        private int _price;
        private string _owner;
        private int _phoneNumber;
        private string _email;
        private int _rating;


        public string FacilityName
        {
            get { return _facilityName; }
            set { _facilityName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }





    }
}

