using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Agenda
{
    public class Person
    {
        public string LastName;
        public string FirstName;
        public DateTime BirthData;
        public string EmailAdress;
        public Agend Agenda;
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