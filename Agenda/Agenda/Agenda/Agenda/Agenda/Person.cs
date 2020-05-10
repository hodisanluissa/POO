using System;
using System.Data;

namespace Agenda
{
    public class Person
    {
        public string LastName;
        public string FirstName;
        public DateTime BirthData;
        public string EmailAdress;
        public string Name()
        {
            return $"{LastName}{FirstName}";
        }
        public string Info()
        {
            return $"{Name()},{BirthData.ToShortDateString()}," +
                $"{EmailAdress}";
        }
    }
}