using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Homework2
{
    public class PhoneCount
    {
        private string _phoneNumber;
        private int _phoneNumberCount;

        //Constructor Iniitalizes values for the Phone Number and Phone Number Count
        public PhoneCount(string number, int count)
        {
            _phoneNumber = number;
            _phoneNumberCount = count;
        }

        /// <summary>
        /// A property that holds the current phone number.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
        }

        /// <summary>
        /// A property that holds the number of occurences of the given phone number.
        /// </summary>
        public int PhoneNumberCount
        {
            get
            {
                return _phoneNumberCount;
            }
            set
            {
                _phoneNumberCount = value;
            }
        }

        
    }
}
