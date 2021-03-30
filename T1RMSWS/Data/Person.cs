using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1RMSWS.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string UserId { get; set; } //primary key, AspNetUser id is foreign key, person had id, everyone needs id, person id is nullable, think of this as a login, a person can have one or more logins
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
