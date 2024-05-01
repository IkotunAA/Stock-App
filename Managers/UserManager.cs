using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using STOCKPROFITANDLOSSAPP.Context;
using STOCKPROFITANDLOSSAPP.Models.Entities;
using STOCKPROFITANDLOSSAPP.Models.Enums;

namespace STOCKPROFITANDLOSSAPP
{
	public class UserManager
	{
		public User _currentUser;
		public User Login(string email, string password)
		{
			foreach (var user in StockContext.Users)
			{
				if (user.Email == email && user.Password == password)
				{
					Console.WriteLine("Login successful");
					_currentUser = user;
					return user;
				}
			}
			Console.WriteLine("Email or password incorrect");
			return null;
		}
		public User GetCurrentUser()
		{
			return _currentUser;
		}
	}
}