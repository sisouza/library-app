
using System;
using Microsoft.AspNetCore.Identity;

namespace UsersApi.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime BirthDate {get; set; }
    }
}