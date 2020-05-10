using System;
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
            Activity Walking = Luissa.CreateActivity("the dog", "individualy",
                DateTime.Now, DateTime.Now.AddHours(1));

        } 
    }
}
