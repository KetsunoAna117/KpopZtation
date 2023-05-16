using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using KpopZtation.Repository;
using KpopZtation.Handler;

namespace KpopZtation.Controller
{
    public class RegisterController
    {
        public static void InsertToDatabase(string name, string email, bool male, bool female, string address, string password)
        {
            String gender = "";
            if (male)
            {
                gender = "Male";
            }
            else if (female)
            {
                gender = "Female";
            }

            String role = "CST";
            CustomerRepository.insertCustomer(name, email, password, gender, address, role);
        }

        public static string checkName(String name)
        {
            String response = "";
            if (name.Equals("")) response = "Name cannot be empty";
            else if (name.Length < 5 || name.Length > 50) response = "Name must between 5 and 50 character(s)";

            return response;
        }

        public static String checkEmail(string email)
        {
            String response = "";
            if (email.Equals("")) response = "Email cannot be empty";
            else response = CustomerController.checkUniqueEmail(email);

            return response;
        }

        public static String checkGender(Boolean male, Boolean female)
        {
            String response = "";
            if (!male && !female) response = "Gender must be selected";

            return response;
        }

        public static String checkAddress(String address)
        {
            String response = "";
            if (address.Equals("")) response = "Must be filled";
            else if (!address.EndsWith("Street")) response = "Must end with street";

            return response; 
        }

        public static String checkPassword(String password)
        {
            String response = "";
            if (password.Equals("")) response = "Password Must be filled";
            else if (!isAlphaNumeric(password)) response = "Password must be alphanumeric";
            
            return response;
        }

        public static Boolean isAlphaNumeric(String input)
        {
            bool hasCharacter = false;
            bool hasNumber = false;

            foreach(char c in input)
            {
                if (char.IsLetter(c))
                {
                    hasCharacter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
            }

            if(hasCharacter && hasNumber)
            {
                return true;
            }
            return false;
        }
    }
}