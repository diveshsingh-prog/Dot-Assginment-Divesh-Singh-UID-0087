using RestaurantManagement.Data;
using RestaurantManagement.Models.Dto;
using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Enum;
using RestaurantManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RestaurantManagement.services;
using RestaurantManagement.repository;

namespace RestaurantManagement.Services
{
	public class UserService :IUserService
	{
		private readonly IUserRepository _userrepository;
		public UserService(IUserRepository userre) {
			_userrepository = userre;
		}
		public string Adduser(AddUserRequest adduser)
		{
			if (!_userrepository.CheckEmailIsPresent(adduser.Email) && !_userrepository.CheckPhoneNumberIsPresent(adduser.PhoneNumber))
			{
				try
				{
					var userentity = new User()
					{
						Name = adduser.Name,
						Password = BCrypt.Net.BCrypt.HashPassword(adduser.Password),
						Email = adduser.Email,
						BirthDate = adduser.BirthDate,
						PhoneNumber = adduser.PhoneNumber,
						Role = UserRole.Customer,
						Balance = 1000
					};
					var res = _userrepository.AddUser(userentity);
					return res;
				}
				catch (Exception e)
				{
					return "Error while binding";
				}
			}
			else
			{
				return "Same email and phone number";
			}




        }
	}
}