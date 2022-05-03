using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Practice_3.Annotations;
using Practice_3.Models;
using Practice_3.Services;
using Practice_3.Tools;

namespace Practice_3.ViewModels
{
    class DataViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _createPersonCommand;
        private RelayCommand<object> _deletePersonCommand;
        private RelayCommand<object> _editPersonCommand;
        private RelayCommand<object> _goToFilterCommand;

        private Action _goToCreatePersonAction;
        private Action _goToFilterAction;

        private Person _current;
        public ObservableCollection<Person> _people;
        private DataService _dataService;
        private FunctionsService _functionsService;


        public ObservableCollection<Person> People
        {
            get
            {
                return _people;
            }
            private set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        public Person Current
        {
            get
            {
                return _current;
            }
            set
            {
                if (_current == value) return;
                _current = value;
                OnPropertyChanged();
            }
        }



        public DataViewModel(Action goToCreatePersonAction, Action goToFilterAction)
        {
            _goToCreatePersonAction = goToCreatePersonAction;
            _goToFilterAction = goToFilterAction;
            _functionsService = new FunctionsService();
            _dataService = new DataService();
            _people = new ObservableCollection<Person>(_dataService.GetAllUsers());
        }

        public RelayCommand<object> GoToCreatePersonCommand
        {
            get
            {
                return _createPersonCommand ??= new RelayCommand<object>(_ => GoToCreatePerson());
            }
        }
        public RelayCommand<object> DeletePersonCommand
        {
            get
            {
                return _deletePersonCommand ??= new RelayCommand<object>(_ => DeletePerson());
            }
        }
        public RelayCommand<object> EditPersonCommand
        {
            get
            {
                return _editPersonCommand ??= new RelayCommand<object>(_ => EditPerson());
            }
        }
        public RelayCommand<object> GoToFilterCommand
        {
            get
            {
                return _goToFilterCommand ??= new RelayCommand<object>(_ => GoToFilter());
            }
        }
        

        private void GoToCreatePerson()
        {
            _goToCreatePersonAction.Invoke();

        }
        private async void DeletePerson()
        {
            await Task.Run(() => _functionsService.DeletePerson(Current));
            People.Remove(Current);
            MessageBox.Show("Людину успішно видалено");

        }
        private async void EditPerson()
        {
            if (!Current.IsValid()) MessageBox.Show("Некоректна дата народження");
            else if (!Current.CorrectEmail()) MessageBox.Show("Некоректна електронна адреса");
            else
            {
                await Task.Run(() => _functionsService.EditPerson(Current));
                MessageBox.Show("Людину успішно відредаговано");
            }
        }

        private void GoToFilter()
        {
            _goToFilterAction.Invoke();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
