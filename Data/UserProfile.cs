using System;
using smartRestaurant.UserAuthorizeService;

namespace smartRestaurant.Data
{
	/// <summary>
	/// Summary description for UserProfile.
	/// </summary>
	public class UserProfile
	{
		private static int MANAGER_TYPE_ID		= 1;
		private static int AUDITOR_TYPE_ID		= 2;
		private static int EMPLOYEE_TYPE_ID		= 100;

		private int userID;
		private string userName;
		private int empTypeID;

		public UserProfile(int userID, string userName, int empTypeID)
		{
			this.userID = userID;
			this.userName = userName;
			this.empTypeID = empTypeID;
		}

		public static UserProfile CheckLogin(int userID, string password)
		{
			UserAuthorizeService.UserAuthorizeService service = new UserAuthorizeService.UserAuthorizeService();
			UserAuthorizeService.UserProfile user = service.CheckLogin(userID, password);
			if (user == null)
				return null;
			return new UserProfile(userID, user.Name, user.EmployeeTypeID);
		}

		public static void CheckLogout(int userID)
		{
			UserAuthorizeService.UserAuthorizeService service = new UserAuthorizeService.UserAuthorizeService();
			service.CheckLogout(userID);
		}

		public int UserID
		{
			get
			{
				return userID;
			}
		}

		public string UserName
		{
			get
			{
				return userName;
			}
		}

		public int EmployeeTypeID
		{
			get
			{
				return empTypeID;
			}
		}

		public bool IsManager()
		{
			return empTypeID == MANAGER_TYPE_ID;
		}

		public bool IsAuditor()
		{
			return empTypeID == AUDITOR_TYPE_ID;
		}
	}
}
