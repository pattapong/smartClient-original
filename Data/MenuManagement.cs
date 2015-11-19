using System;
using smartRestaurant.MenuService;
using smartRestaurant.Utils;

namespace smartRestaurant.Data
{
	/// <summary>
	/// Summary description for Menu.
	/// </summary>
	public class MenuManagement
	{
		private static MenuType[]	menuTypes;
		private static MenuOption[]	menuOptions;

		/// <summary>
		/// This method call Web Services and get Menu and Menu Option.
		/// Class will call this method only one time.
		/// </summary>
		public static void LoadMenus()
		{
			MenuService.MenuService service = new MenuService.MenuService();
			menuTypes = service.GetMenus("TOUCH");
			menuOptions = service.GetOptions("TOUCH");
		}

		public static MenuType[] MenuTypes
		{
			get
			{
				return menuTypes;
			}
		}

		public static MenuOption[] MenuOptions
		{
			get
			{
				return menuOptions;
			}
		}

		/// <summary>
		/// Get menu type by menu type id
		/// </summary>
		/// <param name="id">Menu Type ID</param>
		/// <returns>Menu type by menu type id. return null if not found.</returns>
		public static MenuType GetMenuTypeFromID(int id)
		{
			MenuType menuType = null;
			for (int i = 0;i < menuTypes.Length;i++)
			{
				if (menuTypes[i].ID == id)
				{
					menuType = menuTypes[i];
					break;
				}
			}
			return menuType;
		}

		/// <summary>
		/// Get menu item by KeyID (Shortcut key)
		/// </summary>
		/// <param name="id">Shortcut key number</param>
		/// <returns>Menu item for shortcut. return null if not found.</returns>
		public static MenuItem GetMenuItemKeyID(int id)
		{
			MenuItem menuItem = null;
			for (int i = 0;i < menuTypes.Length;i++)
			{
				if (menuTypes[i].MenuItems != null && menuTypes[i].MenuItems.Length > 0)
				{
					for (int j = 0;j < menuTypes[i].MenuItems.Length;j++)
						if (menuTypes[i].MenuItems[j].KeyID == id)
						{
							menuItem = menuTypes[i].MenuItems[j];
							break;
						}
				}
			}
			return menuItem;
		}

		/// <summary>
		/// Get menu item by menu type and menu id
		/// </summary>
		/// <param name="type">Menu type</param>
		/// <param name="id">Menu ID</param>
		/// <returns>Menu item for menu type/id. return null if not found.</returns>
		public static MenuItem GetMenuItemFromID(MenuType type, int id)
		{
			MenuItem menuItem = null;
			if (type.MenuItems != null && type.MenuItems.Length > 0)
			{
				for (int j = 0;j < type.MenuItems.Length;j++)
					if (type.MenuItems[j].ID == id)
					{
						menuItem = type.MenuItems[j];
						break;
					}
			}
			return menuItem;
		}

		/// <summary>
		/// Get menu item from all menu type by menu id
		/// </summary>
		/// <param name="id">Menu ID</param>
		/// <returns>Menu item from all menu type by menu id. return null if not found.</returns>
		public static MenuItem GetMenuItemFromID(int id)
		{
			MenuItem menuItem = null;
			for (int i = 0;i < menuTypes.Length;i++)
			{
				menuItem = GetMenuItemFromID(menuTypes[i], id);
				if (menuItem != null)
					break;
			}
			return menuItem;
		}

		public static OptionChoice GetOptionChoiceFromID(int id)
		{
			for (int i = 0;i < menuOptions.Length;i++)
			{
				for (int j = 0;j < menuOptions[i].OptionChoices.Length;j++)
				{
					if (menuOptions[i].OptionChoices[j].ChoiceID == id)
						return menuOptions[i].OptionChoices[j];
				}
			}
			return null;
		}

		public static string GetMenuLanguageName(MenuItem menuItem)
		{
			/*switch (AppParameter.MenuLanguage)
			{
				case AppParameter.LANG_THAI:
					return menuItem.NameThai;
				case AppParameter.LANG_FRENCH:
					return menuItem.NameFrench;
			}*/
			return menuItem.Name;
		}
	}
}
