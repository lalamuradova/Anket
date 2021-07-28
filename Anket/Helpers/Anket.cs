using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anket.Helpers
{
    class Questions
    {
        public Questions() { }
        public Questions(string name, string surname, DateTime birthday, string education, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Education = education;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $@"{Name} {Surname}
Birthday: {Birthday.ToShortDateString()}
Education: {Education}
Email: {Email}
Phone: {Phone}";
        }

    }

    class Database
    {
        public List<Questions> Ankets { get; set; } = new List<Questions>();
        public void AddAnket(Questions questions)
        {
            Ankets.Add(questions);
        }
    }
}
