using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;


namespace PhBE
{
    class Program
    {
        static void Main(string[] args) 
        {
            var service = new PhBService();
            Console.WriteLine("Start programm");
           
            service.DeleteDb();
            Person person1 = new Person
            {
                PersonId = 1,
                Name = "Alex",
                PhoneNumber = "12345"
            };

            service.AddPerson(person1);

            var persons = service.GetPeople();
            foreach (var person in persons)
            {
                Console.WriteLine(person.Name);
                Console.WriteLine(person.PhoneNumber);
            }

            Console.WriteLine("End programm");
            Console.ReadKey();
        }
    }
}
