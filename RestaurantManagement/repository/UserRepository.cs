using RestaurantManagement.Data;
using RestaurantManagement.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;
using RestaurantManagement.repository;

namespace RestaurantManagement.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext context)
        {
            _db = context;
        }

      

        public User GetUser(string email)
        {
            return _db.Users.FirstOrDefault(e => e.Email == email);
        }
        public Boolean CheckEmailIsPresent(string email)
        {
            return _db.Users.Any(e => e.Email == email);
        }
        public Boolean CheckPhoneNumberIsPresent(String ph)
        {
            return _db.Users.Any(e => e.PhoneNumber == ph);
        }
           public  String AddUser(User userentity)
            {
              
               
                try
                {
                    _db.Users.Add(userentity);
                    _db.SaveChanges();
                    return "ok";
                }
                catch(Exception e)
                {
                    return "Plz check the db connection, Error in DB";

                }
                }
           

        }
    }