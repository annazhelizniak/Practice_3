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
    class FilterViewModel: INotifyPropertyChanged
    {
        private List<string> _columns;
        private ObservableCollection<Person> _allPeople;
        private ObservableCollection<Person> _selectedPeople;

        private Action _goToDataAction;

        private string _selectedColumn;
        private string _valueForSearch;
        private DateTime _seleDateTime;

        private DataService _dataService;

        private RelayCommand<object> _goToDataCommand;
        private RelayCommand<object> _filterCommand;



        public FilterViewModel(Action goToDataAction)
        {
            _goToDataAction = goToDataAction;
            _columns = new List<string>();
            _columns.Add("Name");
            _columns.Add("Surname");
            _columns.Add("Email");
            _columns.Add("Date of birth");
            _columns.Add("Age");
            _columns.Add("Is adult");
            _columns.Add("Is birthday");
            _columns.Add("Sun sign");
            _columns.Add("Chinese sign");

            _dataService = new DataService();
            _allPeople = new ObservableCollection<Person>(_dataService.GetAllUsers());


        }

        public List<string> Columns
        {
            get
            {
                return _columns;
            }

        }

        public string SelectedColumn
        {
            get
            {
                return _selectedColumn;
            }
            set
            {
                _selectedColumn = value;
                OnPropertyChanged();
            }
        }

        public string ValueForSearch
        {
            get
            {
                return _valueForSearch;
            }
            set
            {
                _valueForSearch = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> SelectedPeople
        {
            get
            {
                return _selectedPeople;
            }
            private set
            {
                _selectedPeople = value;
                OnPropertyChanged();
            }
        }
        public DateTime SelectedDate
        {
            get { return _seleDateTime; }
            set
            {
                _seleDateTime = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> GoToDataCommand
        {
            get
            {
                return _goToDataCommand ??= new RelayCommand<object>(_ => GoToData());
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ??= new RelayCommand<object>(_ => FilterData());
            }
        }

        public void GoToData()
        {
            _goToDataAction.Invoke();
        }

        public void FilterData()
        {
            switch (SelectedColumn)
            {
                case "Name":
                    var s = from person in _allPeople
                        where person.Name.Equals(ValueForSearch)
                        select person;
                    List<Person> list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Name {ValueForSearch}");
                    break;
                case "Surname":
                    s = from person in _allPeople
                        where person.Surname.Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Surname {ValueForSearch}");
                    break;
                case "Email":
                    s = from person in _allPeople
                        where person.Email.Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Email {ValueForSearch}");
                    break;
                case "Date of birth":
                    s = from person in _allPeople
                        where person.DateOfBirth.Date.Equals(SelectedDate.Date)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Date of birth {SelectedDate.Date}");
                    break;
                case "Age":
                    s = from person in _allPeople
                        where person.Age.ToString().Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Age {ValueForSearch}");
                    break;
                case "Is adult":
                    s = from person in _allPeople
                        where person.IsAdultString.Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Is adult {ValueForSearch}");
                    break;
                case "Is birthday":
                    s = from person in _allPeople
                        where person.IsBirthdayString.Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Is birthday {ValueForSearch}");
                    break;
                case "Sun sign":
                    s = from person in _allPeople
                        where person.SunSign.Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Sun sign {ValueForSearch}");
                    break;
                case "Chinese sign":
                    s = from person in _allPeople
                        where person.ChineseSign.Equals(ValueForSearch)
                        select person;
                    list = s.ToList();
                    SelectedPeople = new ObservableCollection<Person>(list);
                    MessageBox.Show($"Відфільтровано за катеогорією Chinese sign {ValueForSearch}");
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
