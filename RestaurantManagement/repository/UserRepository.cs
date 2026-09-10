using RestaurantManagement.Data;
using RestaurantManagement.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;

namespace RestaurantManagement.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository()
        {
            _db = new ApplicationDbContext();
        }

        public Boolean CheckEmail(string email)
        {
            return _db.Users.Any(e => e.Email == email);
        }
        public Boolean CheckPhoneNumber(String ph)
        {
            return _db.Users.Any(e => e.PhoneNumber == ph);
        }
           public  String AddUser(User userentity)
            {
              
                if (!CheckEmail(userentity.Email) && !CheckPhoneNumber(userentity.PhoneNumber))
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
            else
            {
                return "Same email and phone number";
            }
            }

        }
    }