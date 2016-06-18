using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhBE
{
    public class PhBService
    {
        public void AddCategory(Category category)
        {
            var db = new PhBContext();
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void AddPerson(Person person)
        {
            var db = new PhBContext();
            db.People.Add(person);
            db.SaveChanges();
        }

        public void UpdateCategory(int id, Category category)
        {
            var db = new PhBContext();
            var ocategory = db.Categories.Single(c => c.CategoryId == id);
            ocategory.Name = category.Name;

            db.SaveChanges();
        }

        public void UpdatePerson(int id, Person person)
        {
            var db = new PhBContext();
            var operson = db.People.Single(p => p.PersonId == id);
            operson.Name = person.Name;
            operson.PhoneNumber = person.PhoneNumber;
            db.SaveChanges();
        }
        
        public void DeleteCategory(int categoryId)
        {
            var db = new PhBContext();
            var category = db.Categories.SingleOrDefault(c => c.CategoryId == categoryId);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public void DeletePerson(Person person)
        {
            DeletePerson(person.PersonId);
        }

        public void DeletePerson(int personId)
        {
            var db = new PhBContext();
            var person = db.People.SingleOrDefault(p => p.PersonId == personId);
            if (person != null)
            {
                db.People.Remove(person);
                db.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            var db = new PhBContext();
            return db.Categories.Include("People");
        }

        public Category GetCategory(int categoryId)
        {
            var db = new PhBContext();
            var q = db.Categories.Single(p => p.CategoryId == categoryId);
            return q;
        }
        
        public IEnumerable<Person> GetPeople()
        {
            var db = new PhBContext();
            return db.People;
        }
        
        public Person GetPerson(int id)
        {
            var db = new PhBContext();
            var q = db.People.Include("Category").Single(p => p.PersonId == id);
            return q;
        }
        
        public void DeleteDb()
        {
            var db = new PhBContext();
            db.Database.Delete();
        }
    }
}
