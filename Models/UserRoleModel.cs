using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZantosMvc.Models
{
    public class UserViewModel
    {   
        public string UserId { get; set; }  
        public string Username { get; set; }  
        public string Email { get; set; }  
        public string Role { get; set; }  
    }  
}