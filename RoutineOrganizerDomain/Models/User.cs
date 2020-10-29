using System;
using System.Collections.Generic;

namespace RoutineOrganizerDomain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName {get;set;}
        public string Password {get;set;}
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt {get;set;}
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }

    }
}