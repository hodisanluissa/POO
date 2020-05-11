using System;
using Agenda;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Luissa = Create.CreatPerson("Hodisan",
                "Luissa", new DateTime(2000, 11, 11),"luissa_izabela@yahoo.com");
            Activity jogging = Luissa.CreateActivity("jogging with someone", "jogging individualy", DateTime.Now, DateTime.Now.AddHours(1));
            Activity cleaning = Luissa.CreateActivity("Daily clean", "Weekly cleaniing",DateTime.Now, DateTime.Now.AddHours(2));
            Console.WriteLine();
            Person Izabela = Create.CreatPerson("Hok",
                "Izabela", new DateTime(2000, 5, 11), "20_izabela@yahoo.com");
            Activity work = Create.CreateActivity("Work", "More work",
                DateTime.Now, DateTime.Now.AddHours(3));
            Izabela.AddActivity(work);
            Izabela.AddActivity(jogging);
            Console.WriteLine();

            List<Activity> allactivities = Luissa.FindActivitiesByName("walking");
            Izabela.FindActivitiesByInterval(new DateTime(2020, 5, 10), new DateTime(2020, 5, 10));
            Console.WriteLine();

            Create.DeleteActivity(work);
            Console.WriteLine();
            Create.FindActivityWithGroup(2, Luissa, Izabela);
            
            Console.ReadLine();
        } 
    }
}
