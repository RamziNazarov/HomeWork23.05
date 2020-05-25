using HomeWork21._05.Reps;

namespace HomeWork21._05.Models
{
    public class Person : DbWorker<Person>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}
