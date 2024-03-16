using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02Striletska.Models;
using _02Striletska.Tools;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Xml.Linq;

namespace _02Striletska.ViewModels
{
    internal class PersoneViewModel : INotifyPropertyChanged
    {
        private Person? _person;
        private RelayCommand<object> _inputDateCommand;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthday;
        private bool _isEnabled = true;

        #region Properties
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set 
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }   
        }
        public string FirstName
        {
            get 
            {
                return _person.FirstName;
            }
            set
            {
               
             
                _firstName = value;
                
            }
        }
        public string LastName
        {
            get { return _person.LastName; }
            set 
            { 
                
         
                _lastName = value;
                
            }
        }
        public DateTime Birthday
        {
            get { return _person.Birthday; }
            set 
            {

                _birthday = value;
               

            }
        }
        public string Email
        {
            get { return _person.Email; }
            set 
            {
               
         
                _email = value;
               

            }
        }
        public bool IsAdult
        {
            get { return _person.IsAdult; }
        }
        public string SunSign
        {
            get { return _person.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person.ChineseSign; }
        }
        public bool IsBirthday
        {
            get { return _person.IsBirthday; }
        }
        #endregion
            
        public RelayCommand<object> ProceedCommand
        {
            get { return _inputDateCommand ??= new RelayCommand<object>(_ => Proceed(), CanProceed); }


        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool CanProceed(object obj)
        {
            return !string.IsNullOrWhiteSpace(_firstName)
        && !string.IsNullOrWhiteSpace(_lastName)
        && !string.IsNullOrWhiteSpace(_email)
        && _birthday != DateTime.MinValue;
        }
        private async void Proceed()
        {
          
         
                try
                {
                    IsEnabled = false;
                    _person = await Task.Run(() => new Person(_firstName, _lastName, _email, _birthday));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
                finally
                {
                int age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now > Birthday)
                    age--;
                if (age >= 135 || Birthday > DateTime.Now)
                {
                    _person = null;
                    MessageBox.Show("It's not valid Date!", "Whoops, Exception!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                   
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(Birthday));
                    OnPropertyChanged(nameof(IsAdult));
                    OnPropertyChanged(nameof(IsBirthday));
                    OnPropertyChanged(nameof(SunSign));
                    OnPropertyChanged(nameof(ChineseSign));
                    if (Birthday.Day == DateTime.Now.Day && DateTime.Now.Month == Birthday.Month && Birthday.Year == DateTime.Now.Year)
                        MessageBox.Show("I congratulate you on today's birthday. Be happy and smile a lot!", "Who have a birthday today!?", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                IsEnabled = true;
            }
            
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
