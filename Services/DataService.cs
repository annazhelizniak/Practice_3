using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice_3.Models;
using Practice_3.Repositories;

namespace Practice_3.Services
{
    //has method that represent all saved users (data)
    class DataService
    {
        private static FileRepository Repository = new FileRepository();

        public List<Person> GetAllUsers()
        {
            var res = new List<Person>();
            foreach (var user in Repository.GetAll()) res.Add(user);
            return res;

        }
    }
}
