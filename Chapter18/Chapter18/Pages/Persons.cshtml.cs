using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18.Pages
{
    public class PersonsModel : PageModel
    {
        List<Person> people;
        public List<Person> DisplayedPeople { get; set; }
        public PersonsModel()
        {
            people = new List<Person>()
            {
                new Person{ Name="Tom", Age=23},
                new Person {Name = "Sam", Age=25},
                new Person {Name="Bob", Age=23},
                new Person{Name="Tom", Age=25}
            };
        }
        public void OnGet()
        {
            DisplayedPeople = people;
        }
        public void OnPostName(string name)
        {
            DisplayedPeople = people.Where(p => p.Name.Contains(name)).ToList();
        }
        public void OnPostAgeGreater(int age)
        {
            DisplayedPeople = people.Where(p => p.Age > age).ToList();
        }
        public void OnPostAgeLess(int age)
        {
            DisplayedPeople = people.Where(p => p.Age < age).ToList();
        }
    }
}
