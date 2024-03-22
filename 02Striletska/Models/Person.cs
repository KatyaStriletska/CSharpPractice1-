using _02Striletska.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _02Striletska.Models
{
    internal class Person 
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthday;
        private bool _isAdult;
        private string _chineseSign; 
        private string _sunSign;
        private bool _isBirthday;
        #endregion

        #region Constructors
        public Person(string firstName, string lastName, string email, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;    
            Email = email;
            Birthday = birthday;
            _isAdult = canculateIsAdult();
            _chineseSign = canculateChineseSign();  
            _sunSign = canculateSunSign();  
            _isBirthday = isTodayBirthday();
            Thread.Sleep(1000);
        }
        public Person(string name, string lastName, string email):this(name, lastName, email, DateTime.MinValue)  {}
        public Person(string name, string lastName, DateTime birthday): this (name, lastName, "", birthday) {}
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                isValidatedName(value);
                _firstName = value; 
            }
           
        }
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                isValidatedLastName(value);
                _lastName = value;
            }
        }
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                isValidateAge(value);
                _birthday = value; 
            }  
        }
        public string Email
        {
            get { return _email; }
            set
            {
                isValidatedEmail(value);
                _email = value; 
            } 
        }
        public bool IsAdult
        {
            get { return _isAdult; }
        }
        public string SunSign
        {
            get { return _sunSign; }
        }
        public string ChineseSign
        {
            get { return _chineseSign; }
        }
        public bool IsBirthday
        {
            get { return _isBirthday; }
        }
        #endregion
        public bool canculateIsAdult()
        {
            int age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now > Birthday)
                age--;
            return age > 18;
        }
        public string canculateSunSign()
        {
            if ((Birthday.Month == 03 && Birthday.Day >= 21) || (Birthday.Month == 04 && Birthday.Day <= 20))
                return "Aries";
            if ((Birthday.Month == 04 && Birthday.Day >= 21) || (Birthday.Month == 05 && Birthday.Day <= 21))
                return "Taurus";
            if ((Birthday.Month == 05 && Birthday.Day >= 22) || (Birthday.Month == 06 && Birthday.Day <= 21))
                return "Gemini";
            if ((Birthday.Month == 06 && Birthday.Day >= 22) || (Birthday.Month == 07 && Birthday.Day <= 22))
                return "Cancer";
            if ((Birthday.Month == 07 && Birthday.Day >= 23) || (Birthday.Month == 08 && Birthday.Day <= 23))
                return "Leo";
            if ((Birthday.Month == 08 && Birthday.Day >= 24) || (Birthday.Month == 09 && Birthday.Day <= 23))
                return "Virgo";
            if ((Birthday.Month == 09 && Birthday.Day >= 24) || (Birthday.Month == 10 && Birthday.Day <= 23))
                return "Libra";
            if ((Birthday.Month == 10 && Birthday.Day >= 23) || (Birthday.Month == 11 && Birthday.Day <= 22))
                return "Scorpion";
            if ((Birthday.Month == 11 && Birthday.Day >= 23) || (Birthday.Month == 12 && Birthday.Day <= 22))
                return "Sagittarius";
            if ((Birthday.Month == 12 && Birthday.Day >= 23) || (Birthday.Month == 01 && Birthday.Day <= 20))
                return "Capricorn";
            if ((Birthday.Month == 01 && Birthday.Day >= 21) || (Birthday.Month == 02 && Birthday.Day <= 20))
                return "Aquarius";
            return "Pisces";
        }
        public string canculateChineseSign()
        {
            string[] chineseZodiacSigns = { "Mouse", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey", "Cock", "Dog", "Pig" };
            return chineseZodiacSigns[(Birthday.Year - 1888) % 12];
        }
        public bool isTodayBirthday()
        { return DateTime.Now.Day == Birthday.Day && DateTime.Now.Month == Birthday.Month; }
        private void isValidateAge(DateTime bd)
        {
            if (bd > DateTime.Now) throw new InvalidAgeInFutureException();

            int age = DateTime.Now.Year - bd.Year;
            if (DateTime.Now.Month < bd.Month || (DateTime.Now.Month == bd.Month && DateTime.Now.Day < bd.Day))
                age--;
            if (age >= 135) throw new InvalidAgeTooOldException();

        }
        private void isValidatedEmail(string email)
        {
            string correctEmail = "^\\S+@\\S+\\.\\S+$";
            if(!Regex.IsMatch(email, correctEmail, RegexOptions.IgnoreCase)) throw new InvalidEmailException();
        }
        private void isValidatedName(string name)
        {
            string correctName = "^[A-Z](?:[a-z.,'_ -]*[a-zA-Z0-9])?$";
            if (!Regex.IsMatch(name, correctName)) throw new InvalidNameException();
        }
        private void isValidatedLastName(string name)
        {
            string correctLastName = "^[A-Z](?:[a-z.,'_ -]*[a-zA-Z0-9])?$";
            if (!Regex.IsMatch(name, correctLastName)) throw new InvalidLastNameException();
        }
    }
}
