using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Practice_3.Models;
using System.Text.Json;

namespace Practice_3.Repositories
{
    class FileRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Practice3");

        private ObservableCollection<Person> _defaultData=new ObservableCollection<Person>()
        {
            new Person() {Guid=new Guid("11111111111111111111111111111111"), Name = "Станіслав", Surname = "Мельниченко", Email = "mel@gmail.com", DateOfBirth = new DateTime(2005, 12, 6)},
            new Person() {Guid=new Guid("22222222222222222222222222222222"), Name = "Судивой", Surname = "Соневицький", Email = "sonev@gmail.com", DateOfBirth = new DateTime(1990, 10, 25)},
            new Person() {Guid=new Guid("33333333333333333333333333333333"), Name = "Святовид", Surname = "Абраменко", Email = "abr@gmail.com", DateOfBirth = new DateTime(1985, 1, 1)},
            new Person() {Guid=new Guid("44444444444444444444444444444444"), Name = "Андрій", Surname = "Остапюк", Email = "ostapyuk@gmail.com", DateOfBirth = new DateTime(1990, 10, 25)},
            new Person() {Guid=new Guid("55555555555555555555555555555555"), Name = "Олег", Surname = "Сенчук", Email = "sench@gmail.com", DateOfBirth = new DateTime(2012, 5, 15)},
            new Person() {Guid=new Guid("66666666666666666666666666666666"), Name = "Станіслав", Surname = "Янович", Email = "yanovych@gmail.com", DateOfBirth = new DateTime(2019, 8, 23)},
            new Person() {Guid=new Guid("77777777777777777777777777777777"), Name = "Андрій", Surname = "Рудик", Email = "rudyk@gmail.com", DateOfBirth = new DateTime(1999, 7, 29)},
            new Person() {Guid=new Guid("88888888888888888888888888888888"), Name = "Роман", Surname = "Пашко", Email = "pashko@gmail.com", DateOfBirth = new DateTime(2003, 4, 17)},
            new Person() {Guid=new Guid("99999999999999999999999999999999"), Name = "Євген", Surname = "Лукач", Email = "lukach@gmail.com", DateOfBirth = new DateTime(1997, 11, 20)},
            new Person() {Guid=new Guid("10101010101010101010101010101010"), Name = "Олександр", Surname = "Ратушний", Email = "ratush@gmail.com", DateOfBirth = new DateTime(1980, 10, 25)},
            new Person() {Guid=new Guid("1111111111111111111111111111111a"), Name = "Олександра", Surname = "Бутрим", Email = "butrym@gmail.com", DateOfBirth = new DateTime(1990, 5, 19)},
            new Person() {Guid=new Guid("12121212121212121212121212121212"), Name = "Марія", Surname = "Тарасович", Email = "tarasovych@gmail.com", DateOfBirth = new DateTime(1973, 3, 21)},
            new Person() {Guid=new Guid("13131313131313131313131313131313"), Name = "Анастасія", Surname = "Врецьона", Email = "vretsyuna@gmail.com", DateOfBirth = new DateTime(1954, 10, 11)},
            new Person() {Guid=new Guid("14141414141414141414141414141414"), Name = "Юлія", Surname = "Линниченко", Email = "lun@gmail.com", DateOfBirth =new DateTime(1980, 10, 25)},
            new Person() {Guid=new Guid("15151515151515151515151515151515"), Name = "Анна", Surname = "Гальчук", Email = "halchyuk@gmail.com", DateOfBirth = new DateTime(1980, 10, 25)},
            new Person() {Guid=new Guid("16161616161616161616161616161616"), Name = "Олександра", Surname = "Янко", Email = "yanko@gmail.com", DateOfBirth = new DateTime(2000, 3, 23)},
            new Person() {Guid=new Guid("17171717171717171717171717171717"), Name = "Анастасія", Surname = "Луценко", Email = "lytsenko@gmail.com", DateOfBirth = new DateTime(2003, 6, 8)},
            new Person() {Guid=new Guid("18181818181818181818181818181818"), Name = "Дарія", Surname = "Дудинська", Email = "dudunska@gmail.com", DateOfBirth = new DateTime(2003, 6, 8)},
            new Person() {Guid=new Guid("19191919191919191919191919191919"), Name = "Ірина", Surname = "Синько", Email = "sunko@gmail.com", DateOfBirth = new DateTime(2005, 2, 1)},
            new Person() {Guid=new Guid("20202020202020202020202020202020"), Name = "Damon", Surname = "Thompson", Email = "dthompson@gmail.com", DateOfBirth = new DateTime(1963, 7, 27)},
            new Person() {Guid=new Guid("21212121212121212121212121212121"), Name = "Cannon", Surname = "Bennett", Email = "cbennett@gmail.com", DateOfBirth = new DateTime(1959, 9, 13)},
            new Person() {Guid=new Guid("2222222222222222222222222222222a"), Name = "Mateo", Surname = "Butler", Email = "butler@gmail.com", DateOfBirth = new DateTime(1950, 11, 3)},
            new Person() {Guid=new Guid("23232323232323232323232323232323"), Name = "Quinto", Surname = "Long", Email = "qlong@gmail.com", DateOfBirth = new DateTime(2000, 2, 2)},
            new Person() {Guid=new Guid("24242424242424242424242424242424"), Name = "Izaak", Surname = "Thompson", Email = "ithompson@gmail.com", DateOfBirth = new DateTime(2000, 2, 2)},
            new Person() {Guid=new Guid("25252525252525252525252525252525"), Name = "Hank", Surname = "Cooper", Email = "cooper@gmail.com", DateOfBirth = new DateTime(2000, 2, 2)},
            new Person() {Guid=new Guid("26262626262626262626262626262626"), Name = "John", Surname = "Williams", Email = "williams@gmail.com", DateOfBirth = new DateTime(2000, 2, 2)},
            new Person() {Guid=new Guid("27272727272727272727272727272727"), Name = "Jameson", Surname = "Flores", Email = "flores@gmail.com", DateOfBirth = new DateTime(2000, 2, 2)},
            new Person() {Guid=new Guid("28282828282828282828282828282828"), Name = "Ziya", Surname = "Baker", Email = "ziya@gmail.com", DateOfBirth = new DateTime(2001, 10, 25)},
            new Person() {Guid=new Guid("29292929292929292929292929292929"), Name = "Damon", Surname = "Taylor", Email = "dtaylor@gmail.com", DateOfBirth = new DateTime(2005, 10, 25)},
            new Person() {Guid=new Guid("30303030303030303030303030303030"), Name = "John", Surname = "Williams", Email = "jwilliams@gmail.com", DateOfBirth = new DateTime(2013, 10, 25)},
            new Person() {Guid=new Guid("31313131313131313131313131313131"), Name = "Kevin", Surname = "Jenkins", Email = "jenkins@gmail.com", DateOfBirth =new DateTime(2004, 10, 11)},
            new Person() {Guid=new Guid("32323232323232323232323232323232"), Name = "Saul", Surname = "Phillips", Email = "phillips@gmail.com", DateOfBirth = new DateTime(2009, 9, 23)},
            new Person() {Guid=new Guid("3333333333333333333333333333333a"), Name = "Emery", Surname = "Sanders", Email = "sanders@gmail.com", DateOfBirth = new DateTime(2010, 5, 21)},
            new Person() {Guid=new Guid("34343434343434343434343434343434"), Name = "Luke", Surname = "Peterson", Email = "peterson@gmail.com", DateOfBirth = new DateTime(2001, 4, 20)},
            new Person() {Guid=new Guid("35353535353535353535353535353535"), Name = "Shepherd", Surname = "Sanchez", Email = "shsanchez@gmail.com", DateOfBirth = new DateTime(2004, 8, 8)},
            new Person() {Guid=new Guid("36363636363636363636363636363636"), Name = "Abigail", Surname = "Roberts", Email = "abroberts@gmail.com", DateOfBirth = new DateTime(2004, 8, 8)},
            new Person() {Guid=new Guid("37373737373737373737373737373737"), Name = "Alana", Surname = "Roberts", Email = "alroberts@gmail.com", DateOfBirth = new DateTime(1999, 8, 8)},
            new Person() {Guid=new Guid("38383838383838383838383838383838"), Name = "Arianna", Surname = "Roberts", Email = "aroberts@gmail.com", DateOfBirth = new DateTime(2006, 7, 8)},
            new Person() {Guid=new Guid("39393939393939393939393939393939"), Name = "Yoshie", Surname = "Roberts", Email = "yroberts@gmail.com", DateOfBirth = new DateTime(2004, 2, 10)},
            new Person() {Guid=new Guid("40404040404040404040404040404040"), Name = "Charleigh", Surname = "Roberts", Email = "chroberts@gmail.com", DateOfBirth = new DateTime(2000, 8, 8)},
            new Person() {Guid=new Guid("41414141414141414141414141414141"), Name = "Ziva", Surname = "Roberts", Email = "croberts@gmail.com", DateOfBirth = new DateTime(2001, 6, 5)},
            new Person() {Guid=new Guid("42424242424242424242424242424242"), Name = "Hana", Surname = "Sanchez", Email = "hsanchez@gmail.com", DateOfBirth = new DateTime(1990, 11, 11)},
            new Person() {Guid=new Guid("43434343434343434343434343434343"), Name = "Leila", Surname = "Long", Email = "llong@gmail.com", DateOfBirth = new DateTime(1993, 8, 8)},
            new Person() {Guid=new Guid("4444444444444444444444444444444a"), Name = "Leila", Surname = "Murphy", Email = "lmurphy@gmail.com", DateOfBirth = new DateTime(1970, 2, 7)},
            new Person() {Guid=new Guid("45454545454545454545454545454545"), Name = "Leila", Surname = "Rodriguez", Email = "lrodriguez@gmail.com", DateOfBirth = new DateTime(1980, 10, 10)},
            new Person() {Guid=new Guid("46464646464646464646464646464646"), Name = "Leila", Surname = "Wilson", Email = "lwilson@gmail.com", DateOfBirth = new DateTime(2004, 2, 23)},
            new Person() {Guid=new Guid("47474747474747474747474747474747"), Name = "Vada", Surname = "Peterson", Email = "peterson@gmail.com", DateOfBirth = new DateTime(2019, 8, 26)},
            new Person() {Guid=new Guid("48484848484848484848484848484848"), Name = "Ursula", Surname = "Patterson", Email = "patterson@gmail.com", DateOfBirth = new DateTime(2020, 1, 29)},
            new Person() {Guid=new Guid("49494949494949494949494949494949"), Name = "Cecelia", Surname = "Walker", Email = "cwalker@gmail.com", DateOfBirth = new DateTime(2004, 2, 19)},
            new Person() {Guid=new Guid("50505050505050505050505050505050"), Name = "Julianna", Surname = "Cox", Email = "cox@gmail.com", DateOfBirth = new DateTime(2002, 9, 8)}
        };
        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);

            foreach (Person person in _defaultData)
            {
                string filePath = Path.Combine(BaseFolder, person.Guid.ToString());

                if (!File.Exists(filePath))
                    _ = AddOrUpdateAsync(person);
            }
        }

        public async Task AddOrUpdateAsync(Person person)
        {
            var stringObj = JsonSerializer.Serialize(person);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, person.Guid.ToString()), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<Person> GetAsync(Guid guid)
        {
            string stringObj;
            string filePath = Path.Combine(BaseFolder, guid.ToString());

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<Person>(stringObj);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var res = new List<Person>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<Person>(stringObj));
            }

            return res;
        }

        public List<Person> GetAll()
        {
            var res = new List<Person>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<Person>(stringObj));
            }

            return res;
        }

        public async Task DeleteAsync(Person person)
        {
            string filePath = Path.Combine(BaseFolder, person.Guid.ToString());

            if (File.Exists(filePath))
                File.Delete(filePath);

        }

    }
}
