using InfocomTestTask.Models;

namespace InfocomTestTask.Interfaces
{
    public class MockPersonData : IPersonData
    {
        private List<Person> people = new()
        {
            new Person()
            {
                Id=Guid.NewGuid(),
                LastName = "Toha",
                SureName = "Bratan",
                Sex = false
            },
            new Person()
            {
                Id=Guid.NewGuid(),
                LastName = "Sergei",
                SureName = "Bratan",
                Sex = false
            }
        };


        public Person GetPerson(Guid id)
        {
            return people.SingleOrDefault(x=> x.Id == id);
        }
        public Person AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            people.Add(person);
            return person;
        }

        public void DeletePerson(Person person)
        {
            people.Remove(person);
        }

        public Person EditPerson(Person person)
        {
            var _person = GetPerson(person.Id);
            _person.SureName = person.SureName;
            _person.SureName = person.SureName;
            _person.Sex = person.Sex;
            return _person;
        }   

        public List<Person> GetPeople()
        {
            return people;
        }

    }
}
