
using STOCKPROFITANDLOSSAPP.Models.Enums;

namespace STOCKPROFITANDLOSSAPP.Models.Entities
{
	public class User
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public Gender Gender { get; set; }
		public double Wallet { get; set; }
		public User(string name, string email, string password, Gender gender, double wallet)
		{
			FullName = name;
			Email = email;
			Password = password;
			Gender = gender;
			Wallet = wallet;
		}
	}
}