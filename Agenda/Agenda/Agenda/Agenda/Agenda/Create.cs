using System.Collections.Generic;
using System.Data;
using Agenda;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

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
        public static Agend CreateAgenda(this Person person)
        {
            Agend agenda = new Agend()
            {
                Activities = new List<Activity>(),
                Owner = person
            };
            person.Agenda = agenda;
            Agendas.Add(agenda);
            Console.WriteLine($"Agenda created for{person.Name()}.");
            return agenda;
        }
        public static Activity CreateActivity(this Person person,
            string name,string description, DateTime start,DateTime end)
        {
            Activity activity = new Activity()
            {
                Name = name,
                Description = description,
                Start = start,
                End = end
            };
            activity.InvolvedPeople = new List<Person>() { person};
            if (person.Agenda == null) person.CreateAgenda();
            person.Agenda.Activities.Add(activity);
            Activities.Add(activity);
            Console.WriteLine($"Created activity: {activity.Details()}and added to {person.Name()}'s agenda");
            return activity;
        }

        public static Activity CreateActivity(string name, string description, DateTime start, DateTime end)
        {
            Activity activity = new Activity()
            {
                Name = name,
                Description = description,
                Start = start,
                End = end
            };
            activity.InvolvedPeople = new List<Person>();
            Activities.Add(activity);
            Console.WriteLine($"Created activity{activity.Details()}");
            return activity;
        }
        public static  Activity AddActivity(this Person person,Activity activity)
        {
            activity.InvolvedPeople.Add(person);
            if (person.Agenda == null) person.CreateAgenda();
            person.Agenda.Activities.Add(activity);
            Console.WriteLine($"Activity:{activity.Details()} was added to {person.Name()}'s agenda");
            return activity;
        }
        public static Activity RemoveActivity(this Person person,Activity activity)
        {
            if (person.Agenda == null) return activity;
            person.Agenda.Activities.Remove(activity);
            Console.WriteLine($"Activity:{activity.Details()} deleted");
            return activity;
        }
        public static Activity DeleteActivity(Activity activity)
        {
            foreach (Person person in activity.InvolvedPeople)
                person.RemoveActivity(activity);
            activity.InvolvedPeople.Clear();
            Activities.Remove(activity);
            
            Console.WriteLine($"Deleted activity:{activity.Details()}");
            return activity;
        }
        public static List<Activity>FindActivityByNameGlobal(string name)
        {
            name.ToLower().Trim();
            List<Activity> result = Activities.Where(a => a.Name.ToLower().Contains(name)).ToList();
            return result;
        }
        public static List<Activity> FindActivitiesByName(this Person person,string name)
        {
            name.ToLower().Trim();
            if (person.Agenda == null) return new List<Activity>();
            List<Activity>result=person.Agenda.Activities.Where(a => a.Name.ToLower().Contains(name)).ToList();
            return result;
        }
        public static List<Activity> FindActivitiesByInterval(this Person person, DateTime start, DateTime end)
        {
            if (person.Agenda == null) return new List<Activity>();
            List<Activity> result = person.Agenda.Activities.Where(a => a.Start >= start && a.End <= end).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("No activity found in this interval");
                return result;
            }
            foreach(Activity activity in result)
                Console.WriteLine($"Activity{activity.Details()}is scheduled between the given inverval");
            return result;
        }
        public static Activity FindActivityWithGroup(int maxHour, params Person[] people)
        {
            Activity meeting = new Activity(){ Name = "Group meeting", Description = "Talking" };
            meeting.InvolvedPeople = people.ToList();
            DateTime maxtime = new DateTime();
            foreach (Person person in people)
                if (person.Agenda != null)
                    foreach (Activity activity in person.Agenda.Activities)
                        if (activity.End > maxtime) maxtime = activity.End;
            meeting.Start = maxtime;
            meeting.End = maxtime.AddHours(maxHour);
            Console.WriteLine($"Meeting was found :{meeting.Details()}");
            foreach (Person person in people)
                person.AddActivity(meeting);
            return meeting;
        }

    }
}