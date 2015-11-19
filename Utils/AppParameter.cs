using System;
using System.Configuration;

namespace smartRestaurant.Utils
{
	/// <summary>
	/// Summary description for AppParameter.
	/// </summary>
	public class AppParameter
	{
		public const int LANG_ENGLISH	= 0;
		public const int LANG_THAI		= 1;
		public const int LANG_FRENCH	= 2;

		private static int menuLanguage = -1;

		public static bool IsDemo()
		{
			string result = ConfigurationSettings.AppSettings["Demo"];
			return (result != null && result == "1");
		}

		public static int MenuLanguage
		{
			get
			{
				if (menuLanguage < 0)
				{
					string lang = ConfigurationSettings.AppSettings["MenuLanguage"];
					if (lang != null)
					{
						lang = lang.ToUpper();
						if (lang == "TH")
							menuLanguage = LANG_THAI;
						else if (lang == "FR")
							menuLanguage = LANG_FRENCH;
						else
							menuLanguage = LANG_ENGLISH;
					}
					else
						menuLanguage = LANG_ENGLISH;
				}
				return menuLanguage;
			}
		}

		public static string Tax1
		{
			get
			{
				CheckBillService.CheckBillService service = new CheckBillService.CheckBillService();
				string tax1 = service.GetDescription("TAX1");
				if (tax1 == null)
					return "Tax1";
				return tax1;
			}
		}

		public static string Tax2
		{
			get
			{
				CheckBillService.CheckBillService service = new CheckBillService.CheckBillService();
				string tax2 = service.GetDescription("TAX2");
				if (tax2 == null)
					return "Tax2";
				return tax2;
			}
		}
	}
}
