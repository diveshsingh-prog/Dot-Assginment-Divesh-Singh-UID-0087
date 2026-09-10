using RestaurantManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models.Dto
{
    public class AddUserRequest
    {
         public  string Name { get; set; }
         public string Password { get; set; }
        public  string Email { get; set; }
        public  DateTime BirthDate { get; set; }
        public  string PhoneNumber { get; set; }
         

    }
}