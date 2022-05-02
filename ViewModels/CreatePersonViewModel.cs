using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Practice_3.Models;
using Practice_3.Services;
using Practice_3.Tools;

namespace Practice_3.ViewModels
{
    class CreatePersonViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _user = new Person(null, null, DateTime.Now, null);
        private RelayCommand<object> _createPerson;
        private Action _goToDataAction;
        private bool _isEnabled=true;

        #region Constructor
        public CreatePersonViewModel(Action goToDataAction)
        {
            _goToDataAction = goToDataAction;

        }

        #endregion


        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _user.Name;
            }
            set { _user.Name = value; }
        }

        public string Surname
        {
            get
            {
                return _user.Surname;
            }
            set
            {
                _user.Surname = value;
            }
        }

        public string Email
        {
            get
            {
                return _user.Email;
            }
            set
            {
                _user.Email = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _user.DateOfBirth; }
            set
            {
                _user.DateOfBirth = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
            }
        }
        #endregion
        public RelayCommand<object> CreatePersonCommand
        {
            get
            {
                return _createPerson ??= new RelayCommand<object>(_ => CreatePerson(), CanExecute);
            }
        }

        private async void CreatePerson()
        {
            if (!_user.IsValid()) MessageBox.Show("Некоректна дата народження");
            else if (!_user.CorrectEmail()) MessageBox.Show("Некоректна електронна адреса");
            else
            {
                var functionsService = new FunctionsService();
                _isEnabled = false;
                await Task.Run(() => functionsService.AddPerson(_user));
                _isEnabled = true;
                MessageBox.Show("Людину успішно додано");

                _goToDataAction.Invoke();
            }
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_user.Name) && !String.IsNullOrWhiteSpace(_user.Surname) && !String.IsNullOrWhiteSpace(_user.Email);
        }


    }
}
