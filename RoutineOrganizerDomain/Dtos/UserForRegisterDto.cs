using System;
//using System.ComponentModel.DataAnnotations;

namespace RoutineOrganizerDomain.Dtos
{
    public class UserForRegisterDto
    {
        public string UserName {get;set;}
    //    [Required]
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}

      //  [Required]
      //  [StringLength(8, MinimumLength= 4, ErrorMessage= "You must specify password between 4 and 8 characters")]        
        public string Password {get;set;}
        public DateTime Created { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}