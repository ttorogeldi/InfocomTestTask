namespace InfocomTestTask.Models
{
    public class Person
    {  
        public Guid Id { get; set; }
        public string SureName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }


        public string GetData()
        {
            return SureName;
        }
    }
}
