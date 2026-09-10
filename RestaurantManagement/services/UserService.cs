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

namespace RestaurantManagement.Services
{
	public class UserService
	{
		private readonly UserRepository _userrepository;
		public UserService() {
			_userrepository = new UserRepository();
		}
		public string Adduser(AddUserRequest adduser)
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
				if (res.Equals("ok")){
					return "ok";
				}
				else {
					return res;
				}
			}
			catch (Exception e) {
				return "Error while binding";
			}




		}
	}
}