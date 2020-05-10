using System.Collections.Generic;
using System.Data;
using System;

namespace Agenda
{
    static class Create
    {
        public static List<Person> People = new List<Person>();
        public static List<Activity> Activities = new List<Activity>();
        public static List<Agend> Agendas = new List<Agend>();
        public static Person CreatPerson(string lastname,
            string firstname, DateTime birth, string email)
        {
            Person person = new Person()
            {
                LastName = lastname,
                FirstName = firstname,
                BirthData = birth,
                EmailAdress = email
            };
            People.Add(person);
            Console.WriteLine($"Peron:{person.Info()} was added");
            return person;
        }
    }
}