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
            { return _current; }
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
            AddDefaultPeople();
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
            if (!_current.IsValid()) MessageBox.Show("Некоректна дата народження");
            else if (!_current.CorrectEmail()) MessageBox.Show("Некоректна електронна адреса");
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


        private async void AddDefaultPeople()
        {
            FunctionsService functionsService = new FunctionsService();
            
            Person p1 = new Person(Guid.Parse("11111111-1111-1111-1111-111111111111"),"Станіслав", "Мельниченко",new DateTime(2005, 12, 6),"mel@gmail.com");
            Person p2 = new Person(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Судивой", "Соневицький", new DateTime(1990, 10, 25), "sonev@gmail.com");

            if (functionsService.AddPerson(p1).Result && functionsService.AddPerson(p2).Result)
            {
                Person p3 = new Person("Святовид", "Абраменко", new DateTime(1985, 1, 1),
                    "abr@gmail.com");
                Person p4 = new Person( "Андрій", "Остапюк", new DateTime(2000, 2, 3),
                    "ostapyuk@gmail.com");
                Person p5 = new Person("Олег", "Сенчук", new DateTime(2012, 5, 15), "sench@gmail.com");
                Person p6 = new Person( "Станіслав", "Янович", new DateTime(2019, 8, 23),
                    "yanovych@gmail.com");
                Person p7 = new Person( "Андрій", "Рудик", new DateTime(1999, 7, 29),
                    "rudyk@gmail.com");
                Person p8 = new Person( "Роман", "Пашко", new DateTime(2003, 4, 17),
                    "pashko@gmail.com");
                Person p9 = new Person("Євген", "Лукач", new DateTime(1997, 11, 20),
                    "lukach@gmail.com");
                Person p10 = new Person( "Олександр", "Ратушний", new DateTime(1980, 10, 25),
                    "ratush@gmail.com");
                Person p11 = new Person( "Олександра", "Бутрим", new DateTime(1990, 5, 19),
                    "butrym@gmail.com");
                Person p12 = new Person( "Марія", "Тарасович", new DateTime(1973, 3, 21),
                    "tarasovych@gmail.com");
                Person p13 = new Person( "Анастасія", "Врецьона", new DateTime(1954, 10, 11),
                    "vretsyuna@gmail.com");
                Person p14 = new Person( "Юлія", "Линниченко", new DateTime(1980, 10, 25),
                    "lun@gmail.com");
                Person p15 = new Person( "Анна", "Гальчук", new DateTime(1980, 10, 25),
                    "halchyuk@gmail.com");
                Person p16 = new Person( "Олександра", "Янко", new DateTime(2000, 3, 23),
                    "yanko@gmail.com");
                Person p17 = new Person( "Анастасія", "Луценко", new DateTime(2003, 6, 8),
                    "lytsenko@gmail.com");
                Person p18 = new Person( "Дарія", "Дудинська", new DateTime(2003, 6, 8),
                    "dudunska@gmail.com");
                Person p19 = new Person( "Ірина", "Синько", new DateTime(2005, 2, 1),
                    "sunko@gmail.com");
                Person p20 = new Person( "Damon", "Thompson", new DateTime(1963, 7, 27),
                    "dthompson@gmail.com");
                Person p21 = new Person( "Cannon ", "Bennett", new DateTime(1959, 9, 13),
                    "cbennett@gmail.com");
                Person p22 = new Person( "Mateo", "Butler", new DateTime(1950, 11, 3),
                    "butler@gmail.com");
                Person p23 = new Person( "Quinto", "Long", new DateTime(2000, 2, 2),
                    "qlong@gmail.com");
                Person p24 = new Person( "Izaak", "Thompson", new DateTime(2000, 2, 2),
                    "ithompson@gmail.com");
                Person p25 = new Person( "Hank", "Cooper", new DateTime(2000, 2, 2),
                    "cooper@gmail.com");
                Person p26 = new Person( "John", "Williams", new DateTime(2000, 2, 2),
                    "williams@gmail.com");
                Person p27 = new Person( "Jameson", "Flores", new DateTime(2000, 2, 2),
                    "flores@gmail.com");
                Person p28 = new Person( "Ziya", "Baker", new DateTime(2001, 10, 25),
                    "ziya@gmail.com");
                Person p29 = new Person( "Damon", "Taylor", new DateTime(2005, 10, 25),
                    "dtaylor@gmail.com");
                Person p30 = new Person( "John", "Williams", new DateTime(2013, 10, 25),
                    "jwilliams@gmail.com");
                Person p31 = new Person( "Kevin", "Jenkins", new DateTime(2004, 10, 11),
                    "jenkins@gmail.com");
                Person p32 = new Person( "Saul", "Phillips", new DateTime(2009, 9, 23),
                    "phillips@gmail.com");
                Person p33 = new Person( "Emery", "Sanders", new DateTime(2010, 5, 21),
                    "sanders@gmail.com");
                Person p34 = new Person( "Luke", "Peterson", new DateTime(2001, 4, 20),
                    "peterson@gmail.com");
                Person p35 = new Person( "Shepherd", "Sanchez", new DateTime(2004, 8, 8),
                    "shsanchez@gmail.com");
                Person p36 = new Person( "Abigail", "Roberts", new DateTime(2004, 8, 8),
                    "abroberts@gmail.com");
                Person p37 = new Person( "Alana", "Roberts", new DateTime(1999, 8, 8),
                    "alroberts@gmail.com");
                Person p38 = new Person( "Arianna", "Roberts", new DateTime(2006, 7, 8),
                    "aroberts@gmail.com");
                Person p39 = new Person( "Yoshie", "Roberts", new DateTime(2004, 2, 10),
                    "yroberts@gmail.com");
                Person p40 = new Person( "Charleigh", "Roberts", new DateTime(2000, 8, 8),
                    "chroberts@gmail.com");
                Person p41 = new Person( "Ziva", "Roberts", new DateTime(2001, 6, 5),
                    "croberts@gmail.com");
                Person p42 = new Person( "Hana", "Sanchez", new DateTime(1990, 11, 11),
                    "hsanchez@gmail.com");
                Person p43 = new Person( "Leila", "Long", new DateTime(1993, 8, 8), "llong@gmail.com");
                Person p44 = new Person( "Leila", "Murphy", new DateTime(1970, 2, 7),
                    "lmurphy@gmail.com");
                Person p45 = new Person( "Leila", "Rodriguez", new DateTime(1980, 10, 10),
                    "lrodriguez@gmail.com");
                Person p46 = new Person( "Leila", "Wilson", new DateTime(2004, 2, 23),
                    "lwilson@gmail.com");
                Person p47 = new Person( "Vada", "Peterson", new DateTime(2019, 8, 26),
                    "peterson@gmail.com");
                Person p48 = new Person( "Ursula", "Patterson", new DateTime(2020, 1, 29),
                    "patterson@gmail.com");
                Person p49 = new Person( "Cecelia", "Walker", new DateTime(2004, 2, 19),
                    "cwalker@gmail.com");
                Person p50 = new Person( "Julianna", "Cox", new DateTime(2002, 9, 8), "cox@gmail.com");

                await Task.Run(() => functionsService.AddPerson(p3));
                await Task.Run(() => functionsService.AddPerson(p4));
                await Task.Run(() => functionsService.AddPerson(p5));
                await Task.Run(() => functionsService.AddPerson(p6));
                await Task.Run(() => functionsService.AddPerson(p7));
                await Task.Run(() => functionsService.AddPerson(p8));
                await Task.Run(() => functionsService.AddPerson(p9));
                await Task.Run(() => functionsService.AddPerson(p10));
                await Task.Run(() => functionsService.AddPerson(p11));
                await Task.Run(() => functionsService.AddPerson(p12));
                await Task.Run(() => functionsService.AddPerson(p13));
                await Task.Run(() => functionsService.AddPerson(p14));
                await Task.Run(() => functionsService.AddPerson(p15));
                await Task.Run(() => functionsService.AddPerson(p16));
                await Task.Run(() => functionsService.AddPerson(p17));
                await Task.Run(() => functionsService.AddPerson(p18));
                await Task.Run(() => functionsService.AddPerson(p19));
                await Task.Run(() => functionsService.AddPerson(p20));
                await Task.Run(() => functionsService.AddPerson(p21));
                await Task.Run(() => functionsService.AddPerson(p22));
                await Task.Run(() => functionsService.AddPerson(p23));
                await Task.Run(() => functionsService.AddPerson(p24));
                await Task.Run(() => functionsService.AddPerson(p25));
                await Task.Run(() => functionsService.AddPerson(p26));
                await Task.Run(() => functionsService.AddPerson(p27));
                await Task.Run(() => functionsService.AddPerson(p28));
                await Task.Run(() => functionsService.AddPerson(p29));
                await Task.Run(() => functionsService.AddPerson(p30));
                await Task.Run(() => functionsService.AddPerson(p31));
                await Task.Run(() => functionsService.AddPerson(p32));
                await Task.Run(() => functionsService.AddPerson(p33));
                await Task.Run(() => functionsService.AddPerson(p34));
                await Task.Run(() => functionsService.AddPerson(p35));
                await Task.Run(() => functionsService.AddPerson(p36));
                await Task.Run(() => functionsService.AddPerson(p37));
                await Task.Run(() => functionsService.AddPerson(p38));
                await Task.Run(() => functionsService.AddPerson(p39));
                await Task.Run(() => functionsService.AddPerson(p40));
                await Task.Run(() => functionsService.AddPerson(p41));
                await Task.Run(() => functionsService.AddPerson(p42));
                await Task.Run(() => functionsService.AddPerson(p43));
                await Task.Run(() => functionsService.AddPerson(p44));
                await Task.Run(() => functionsService.AddPerson(p45));
                await Task.Run(() => functionsService.AddPerson(p46));
                await Task.Run(() => functionsService.AddPerson(p47));
                await Task.Run(() => functionsService.AddPerson(p48));
                await Task.Run(() => functionsService.AddPerson(p49));
                await Task.Run(() => functionsService.AddPerson(p50));

            }
        }


    }
}
