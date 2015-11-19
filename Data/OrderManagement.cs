using System;
using System.Text;
using smartRestaurant.MenuService;
using smartRestaurant.OrderService;
using smartRestaurant.TableService;

namespace smartRestaurant.Data
{
	/// <summary>
	/// Summary description for OrderManagement.
	/// </summary>
	public class OrderManagement
	{
		/// <summary>
		/// If not found order object, create new order object.
		/// If found order object, allocate bills array.
		/// </summary>
		public static OrderInformation CreateOrderObject(OrderInformation orderInfo, int employeeID,
			TableInformation tableInfo, int guestNumber, int billNumber)
		{
			if (orderInfo == null)
			{
				// Create new order object
				orderInfo = new OrderInformation();
				orderInfo.OrderID = 0;
				orderInfo.OrderTime = DateTime.Now;
				orderInfo.TableID = tableInfo.TableID;;
				orderInfo.EmployeeID = employeeID;
				orderInfo.NumberOfGuest = guestNumber;
				orderInfo.CloseOrderDate = DateTime.MinValue;
				orderInfo.CreateDate = DateTime.Now;
				// Allocate bills array
				orderInfo.Bills = new OrderBill[billNumber];
				for (int i = 0;i < billNumber;i++)
				{
					orderInfo.Bills[i] = new OrderBill();
					orderInfo.Bills[i].CloseBillDate = DateTime.MinValue;
					orderInfo.Bills[i].EmployeeID = employeeID;
					orderInfo.Bills[i].BillID = i + 1;
				}
			}
			else
			{
				int lastID = 0;
				// Reallocate bills array
				OrderBill[] oldBills = orderInfo.Bills;
				orderInfo.Bills = new OrderBill[billNumber];
				for (int i = 0;i < billNumber;i++)
				{
					if (i < oldBills.Length)
					{
						orderInfo.Bills[i] = oldBills[i];
						lastID = orderInfo.Bills[i].BillID;
					}
					else
					{
						orderInfo.Bills[i] = new OrderBill();
						orderInfo.Bills[i].CloseBillDate = DateTime.MinValue;
						orderInfo.Bills[i].EmployeeID = employeeID;
						orderInfo.Bills[i].BillID = ++lastID;
					}
				}
			}
			return orderInfo;
		}

		/// <summary>
		/// Add Menu Item to Selected Bill by order bill item.
		/// </summary>
		/// <param name="item">Order bill item for insert to selected bill.</param>
		/// <returns>true = success, false = fail</returns>
		public static bool AddOrderBillItem(OrderBill selectedBill, OrderBillItem item)
		{
			if (selectedBill == null || selectedBill.CloseBillDate != DateTime.MinValue)
				return false;
			OrderBillItem[] oldItems = selectedBill.Items;
			if (oldItems != null)
			{
				// Append new order
				selectedBill.Items = new OrderBillItem[oldItems.Length + 1];
				for (int i = 0;i < oldItems.Length;i++)
					selectedBill.Items[i] = oldItems[i];
			}
			else
				selectedBill.Items = new OrderBillItem[1];
			selectedBill.Items[selectedBill.Items.Length - 1] = item;
			return true;
		}

		/// <summary>
		/// Add Menu Item to Selected Bill by menu item.
		/// </summary>
		/// <param name="menu">Menu Item for insert to selected bill.</param>
		public static OrderBillItem AddOrderBillItem(OrderBill selectedBill, MenuService.MenuItem menu, int employeeID)
		{
			OrderBillItem item = new OrderBillItem();
			item.MenuID = menu.ID;
			item.Unit = 1;
			item.DefaultOption = true;
			item.Status = 1; // New Order Status
			item.EmployeeID = employeeID;
			item.ChangeFlag = true;
			if (AddOrderBillItem(selectedBill, item))
				return item;
			else
				return null;
		}

		/// <summary>
		/// Cancel selected menu order item.
		/// If this item is new order, delete from list.
		/// If this item already print to kitchen, mark for cancel.
		/// </summary>
		/// <param name="item">Order bill item to cancel</param>
		/// <returns>true = success, false = fail</returns>
		public static bool CancelOrderBillItem(OrderBill selectedBill, OrderBillItem item, int employeeID)
		{
			if (selectedBill == null || selectedBill.CloseBillDate != DateTime.MinValue)
				return false;
			if (item.BillDetailID == 0)
			{
				// Case item is new order
				OrderBillItem[] oldItems = selectedBill.Items;
				if (oldItems != null && oldItems.Length > 1)
				{
					// Remove old item
					selectedBill.Items = new OrderBillItem[oldItems.Length - 1];
					int cnt = 0;
					for (int i = 0;i < oldItems.Length;i++)
					{
						if (oldItems[i] != item)
						{
							selectedBill.Items[cnt] = oldItems[i];
							cnt++;
						}
					}
				}
				else
					selectedBill.Items = null;
			}
			else
			{
				// Case item already print to kitchen.
				item.CancelReasonID = Utils.CancelForm.Show("Select Cancel Reason");
				item.Status = 0; // Cancel status
				item.EmployeeID = employeeID;
				item.ChangeFlag = true;
			}
			return true;
		}

		/// <summary>
		/// Undo cancel order (Already send to kitchen)
		/// </summary>
		/// <param name="item">Order bill item to undo candel.</param>
		/// <returns>true = success, false = fail</returns>
		public static bool UndoCancelOrderBillItem(OrderBillItem item, int employeeID)
		{
			if (item == null)
				return false;
			if (IsCancel(item))
			{
				item.Status = 1;
				item.CancelReasonID = 0;
				item.EmployeeID = employeeID;
				item.ChangeFlag = true;
			}
			return true;
		}

		/// <summary>
		/// Cancel all bill detail in order
		/// </summary>
		/// <param name="orderInfo">Order to cancel</param>
		/// <returns>true = success, false = fail</returns>
		public static bool CancelOrder(OrderInformation orderInfo, int employeeID)
		{
			if (orderInfo == null)
				return false;
			for (int i = 0;i < orderInfo.Bills.Length;i++)
			{
				for (int j = 0;j < orderInfo.Bills[i].Items.Length;j++)
					CancelOrderBillItem(orderInfo.Bills[i], orderInfo.Bills[i].Items[j], employeeID);
				orderInfo.Bills[i].CloseBillDate = DateTime.Now;
			}
			orderInfo.CloseOrderDate = DateTime.Now;
			return true;
		}

		/// <summary>
		/// Move Menu Item to Selected Bill.
		/// </summary>
		/// <param name="item">Order bill item for move.</param>
		/// <returns>true = success, false = fail</returns>
		public static bool MoveOrderBillItem(OrderBill sourceBill, OrderBill destBill, OrderBillItem item)
		{
			if (sourceBill == null || sourceBill.CloseBillDate != DateTime.MinValue ||
				destBill == null || destBill.CloseBillDate != DateTime.MinValue)
				return false;
			// Append order
			OrderBillItem[] oldItems = destBill.Items;
			if (oldItems != null)
			{
				destBill.Items = new OrderBillItem[oldItems.Length + 1];
				for (int i = 0;i < oldItems.Length;i++)
					destBill.Items[i] = oldItems[i];
			}
			else
				destBill.Items = new OrderBillItem[1];
			destBill.Items[destBill.Items.Length - 1] = item;
			// Remove old item
			oldItems = sourceBill.Items;
			if (oldItems != null && oldItems.Length > 1)
			{
				sourceBill.Items = new OrderBillItem[oldItems.Length - 1];
				int cnt = 0;
				for (int i = 0;i < oldItems.Length;i++)
				{
					if (oldItems[i] != item)
					{
						sourceBill.Items[cnt] = oldItems[i];
						cnt++;
					}
				}
			}
			else
				sourceBill.Items = null;
			return true;
		}

		public static bool IsCancel(OrderBillItem item)
		{
			return (item.Status == 0);
		}

		/// <summary>
		/// Return OrderBillItem to string format
		/// (amount) name*
		/// - option/option/...
		/// </summary>
		/// <param name="item">OrderBillItem object to show</param>
		/// <returns>Output of bill item string.</returns>
		public static string OrderBillItemDisplayString(OrderBillItem item)
		{
			StringBuilder sb = new StringBuilder();
			if (item.ServeTime != DateTime.MinValue)
				sb.Append("[F] ");
			else
				sb.Append("[O] ");
			MenuItem menuItem = MenuManagement.GetMenuItemFromID(item.MenuID);
			if (menuItem == null)
				sb.Append("Unknown");
			else
				sb.Append(MenuManagement.GetMenuLanguageName(menuItem));
			if (item.Message != null && item.Message.Length > 0)
				sb.Append("*");
			if (!item.DefaultOption && item.ItemChoices != null)
			{
				bool found;
				int cnt = 0;
				for (int optionCnt = 0;optionCnt < item.ItemChoices.Length;optionCnt++)
				{
					found = false;
					for (int defaultCnt = 0;defaultCnt < menuItem.MenuDefaults.Length;defaultCnt++)
						if (menuItem.MenuDefaults[defaultCnt].DefaultChoiceID == item.ItemChoices[optionCnt].ChoiceID)
							found = true;
					if (found)
						continue;
					OptionChoice option = MenuManagement.GetOptionChoiceFromID(item.ItemChoices[optionCnt].ChoiceID);
					if (option != null)
					{
						if (cnt == 0)
							sb.Append("\n-");
						else
							sb.Append("/");
						sb.Append(option.ChoiceName);
						cnt++;
					}
				}
			}
			return sb.ToString();
		}
	}
}
