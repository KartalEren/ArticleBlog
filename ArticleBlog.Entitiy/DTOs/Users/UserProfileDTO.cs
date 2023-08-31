﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Users
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; } //kişiyi parola değiştimeye zorunlu tutumadık.
       // public IFormFile? Photo { get; set; }
       // public string ImageFileName { get; set; } //***UPDATEVIEW DA RESİM KAYDETME YERİNDE SRC YE YAZDIK
    }
}
