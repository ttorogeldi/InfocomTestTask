using InfocomTestTask.Interfaces;
using InfocomTestTask.Models;

namespace InfocomTestTask.Data
{
    public class SqlPersonData : IPersonData
    {
        private PersonContext _personContext;
        public SqlPersonData(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public Person AddPerson(Person person)
        {

            person.Id = Guid.NewGuid();
            _personContext.People.Add(person);
            _personContext.SaveChanges();
            return person;
        }

        public void DeletePerson(Person person)
        {
            _personContext.People.Remove(person);
            _personContext.SaveChanges();
        }

        public Person EditPerson(Person person)
        {
            var _person = _personContext.People.Find(person.Id);

            if(_person != null)
            {
                _person.SureName = person.SureName;
                _person.LastName = person.LastName;
                _person.Sex= person.Sex;
                _personContext.People.Update(_person);
                _personContext.SaveChanges();
            }
            return person;
        }

        
        public Person GetPerson(Guid id)
        {
            var person = _personContext.People.Find(id);
            return person;
        }
        
        public List<Person> GetPeople()
        {
            return _personContext.People.ToList();
        }

    }
}
