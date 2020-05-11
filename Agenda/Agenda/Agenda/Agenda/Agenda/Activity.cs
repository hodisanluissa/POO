using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class Activity
    {
        public string Name;
        public string Description;
        public DateTime Start;
        public DateTime End;
        public List<Person> InvolvedPeople;
        public string Details()
        {
            return $"{Name},{Description}," +
                $"{Start.ToString()},{End.ToString()}";
        }
    }
}