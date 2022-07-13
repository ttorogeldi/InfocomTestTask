using InfocomTestTask.Models;

namespace InfocomTestTask.Interfaces
{
    public interface IPersonData
    {
        Task<IEnumerable<Person>> Search(string name);
        List<Person> GetPeople();

        Person GetPerson(Guid id);

        Person AddPerson(Person person);

        void DeletePerson(Person person);

        Person EditPerson(Person person);
    }
}
