using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Practice_3.Models;
using Practice_3.Repositories;
using Practice_3.Tools;

namespace Practice_3.Services
{
    class FunctionsService
    {
        private static FileRepository repository = new FileRepository();

        public async Task<bool> AddPerson(Person person)
        {
            await repository.AddOrUpdateAsync(person);
                return true;
        }

        public async Task<bool> EditPerson(Person person)
        {
            await repository.AddOrUpdateAsync(person);
            return true;
        }

        public async Task<bool> DeletePerson(Person person)
        {
            await repository.DeleteAsync(person);
            return true;
        }

    }
}
