using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    internal class Contact
    {

        public string FullName {  get; set; }
        public string PhoneNumber { get; set; }


        public Contact(string? fullName, string? phoneNumber)
        {
            this.FullName = fullName ?? string.Empty;
            this.PhoneNumber = phoneNumber?? string.Empty;
        }


        public override string ToString()
        {
            return $"\nContact Name: {FullName}\nMobile: {PhoneNumber}";
        }



    }
}
