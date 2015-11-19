using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using smartRestaurant.Data;
using smartRestaurant.TableService;
using smartRestaurant.OrderService;
using smartRestaurant.Business;

namespace smartRestaurant
{
	/// <summary>
	/// <b>MainForm</b> is main class for <i>smartTouch</i>.<br/>
	/// The <i>smartTouch</i> uses Multi-Document-Interface (MDI) window format.
	/// All windows use in smartTouch is child of <b>MainForm</b>.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// <i>Instance object</i>
		/// </summary>
		private static MainForm instance;

		/// <summary>
		/// <i>Current user profile object</i>
		/// </summary>
		private UserProfile userProfile;

		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private LoginForm loginForm;
		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private MainMenuForm mainMenuForm;
		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private TakeOrderForm takeOrderForm;
		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private PrintReceiptForm printReceiptForm;
		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private TakeOutForm takeOutForm;
		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private ReserveForm reserveForm;
		/// <summary>
		/// <i>Form object</i>
		/// </summary>
		private SalesForm salesForm;

		/// <summary>
		/// Constructure of class.<br/>
		/// Call InitializeForm() to pre-create object for all windows
		/// and call ShowLoginForm() to show Login windows.
		/// </summary>
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			instance = this;
			InitializeForm();
			ShowLoginForm();
		 }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// MainForm
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(1024, 768);
			this.ControlBox = false;
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.IsMdiContainer = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "smartRestaurant";

		}
		#endregion

		/// <summary>
		/// This method uses for create all MDI objects.
		/// </summary>
		private void InitializeForm()
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			loginForm = new LoginForm();
			loginForm.MdiParent = this;
			mainMenuForm = new MainMenuForm();
			mainMenuForm.MdiParent = this;
			takeOrderForm = new TakeOrderForm();
			takeOrderForm.MdiParent = this;
			printReceiptForm = new PrintReceiptForm();
			printReceiptForm.MdiParent = this;
			takeOutForm = new TakeOutForm();
			takeOutForm.MdiParent = this;
			reserveForm = new ReserveForm();
			reserveForm.MdiParent = this;
			salesForm = new SalesForm();
			salesForm.MdiParent = this;
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		/// <summary>
		/// Call LoginForm object and bring to front for user to input User/Password.
		/// </summary>
		public void ShowLoginForm()
		{
			loginForm.Show();
			loginForm.BringToFront();
			loginForm.UpdateForm();
		}

		/// <summary>
		/// Call MainMenuForm object and bring to front for user to select table or
		/// other <i>smartTouch</i> feature. Ex. reserve table, manager page, etc.
		/// </summary>
		public void ShowMainMenuForm()
		{
			mainMenuForm.Show();
			mainMenuForm.BringToFront();
			mainMenuForm.UpdateForm();
		}

		/// <summary>
		/// This method uses to show TakeOrderForm.<br/>
		/// TakeOrderForm uses in many cases. But this method uses in <u>Take Order</u> case.
		/// Take Order case has 2 sub cases. First case is new order, open new table.
		/// Second case is resume order, for new order item, cancel item, or check bill.
		/// </summary>
		/// <param name="table">Table Information object for open new order or resume order.</param>
		public void ShowTakeOrderForm(TableInformation table)
		{
			if (table != null)
			{
				takeOrderForm.Table = table;
				takeOrderForm.OrderID = 0;
				takeOrderForm.TakeOrderResume = false;
			}
			else
				takeOrderForm.TakeOrderResume = true;
			if (userProfile != null)
				takeOrderForm.EmployeeID = userProfile.UserID;
			takeOrderForm.Show();
			takeOrderForm.BringToFront();
			takeOrderForm.UpdateForm();
		}

		/// <summary>
		/// This method uses to show TakeOrderForm.<br/>
		/// TakeOrderForm uses in many cases. But this method uses in <u>New Take Out</u> case.
		/// This method use for new take out order or resume take out order. But not include
		/// change customer name case. If want to change customer name, use
		/// <i>ShowTakeOrderForm(string custName)</i>
		/// </summary>
		/// <param name="table">Table Information object. In this case uses table number 0 object.</param>
		/// <param name="orderID">For resume take out, uses Order ID. If new take out, uses 0 (zero).</param>
		/// <param name="custName">For predefine customer name.</param>
		public void ShowTakeOrderForm(TableInformation table, int orderID, string custName)
		{
			takeOrderForm.Table = table;
			takeOrderForm.OrderID = orderID;
			takeOrderForm.CustomerName = custName;
			takeOrderForm.TakeOrderResume = false;
			if (userProfile != null)
				takeOrderForm.EmployeeID = userProfile.UserID;
			takeOrderForm.Show();
			takeOrderForm.BringToFront();
			takeOrderForm.UpdateForm();
		}

		/// <summary>
		/// This method uses to show TakeOrderForm.<br/>
		/// TakeOrderForm uses in many cases. But this method uses in <u>Resume Take Out with change Customer Name</u> case.
		/// For other cases for Take Out, use <i>ShowTakeOrderForm(TableInformation table, int orderID, string custName)</i>
		/// </summary>
		/// <param name="custName">Customer name</param>
		public void ShowTakeOrderForm(string custName)
		{
			if (custName != null)
				takeOrderForm.CustomerName = custName;
			takeOrderForm.TakeOrderResume = true;
			if (userProfile != null)
				takeOrderForm.EmployeeID = userProfile.UserID;
			takeOrderForm.Show();
			takeOrderForm.BringToFront();
			takeOrderForm.UpdateForm();
		}

		/// <summary>
		/// This methods use for show PrintReceiptForm. Print Receipt Form is form to print
		/// receipt and check bill form. All cases, take order and take out, use this form to
		/// check bill too.
		/// </summary>
		/// <param name="table">Table object for print receipt and check bill.</param>
		/// <param name="order">Order object for print receipt and check bill.</param>
		/// <param name="orderBill">Order Bill object for print receipt and check bill.</param>
		public void ShowPrintReceiptForm(TableInformation table, OrderInformation order, OrderBill orderBill)
		{
			if (table == null || order == null || orderBill == null)
				return;
			printReceiptForm.Table = table;
			printReceiptForm.Order = order;
			printReceiptForm.OrderBill = orderBill;
			if (userProfile != null)
				printReceiptForm.EmployeeID = userProfile.UserID;
			printReceiptForm.Show();
			printReceiptForm.BringToFront();
			printReceiptForm.UpdateForm();
		}

		/// <summary>
		/// This method uses for show TakeOutForm. Take Out Form is form for users to
		/// select customer and new take out. Or for users to select order this already take out
		/// for edit for check bill.
		/// </summary>
		/// <param name="table">Table Information object. This case use table number 0 object.</param>
		/// <param name="custName">Predefine customer name. Use for users create order before select customer name or users change take out's customer name.</param>
		/// <param name="takeOrder">This boolean variable is true for change customer name after create order.</param>
		public void ShowTakeOutForm(TableInformation table, string custName, bool takeOrder)
		{
			takeOutForm.Table = table;
			takeOutForm.TakeOrderMode = takeOrder;
			takeOutForm.CustomerName = custName;
			if (userProfile != null)
				takeOutForm.EmployeeID = userProfile.UserID;
			takeOutForm.Show();
			takeOutForm.BringToFront();
			takeOutForm.UpdateForm();
		}

		/// <summary>
		/// This methods show ReserveForm.
		/// </summary>
		public void ShowReserveForm()
		{
			reserveForm.Show();
			reserveForm.BringToFront();
			reserveForm.UpdateForm();
		}

		/// <summary>
		/// This methods uses for show SalesForm (Manager Module).
		/// </summary>
		public void ShowSalesForm()
		{
			salesForm.Show();
			salesForm.BringToFront();
			salesForm.UpdateForm();
		}

		/// <summary>
		/// Use for close all MDI objects and exit from <i>smartTouch</i>
		/// </summary>
		public void Exit()
		{
			if (MdiChildren != null)
			{
				for (int i = 0;i < MdiChildren.Length;i++)
					MdiChildren[i].Close();
			}
			this.Close();
		}

		/// <summary>
		/// UserProfile object from current user that login to <i>smartTouch</i>.
		/// </summary>
		public UserProfile User
		{
			get
			{
				return userProfile;
			}
			set
			{
				userProfile = value;
			}
		}

		/// <summary>
		/// UserID from current user that login to <i>smartTouch</i>.
		/// </summary>
		public string UserID
		{
			get
			{
				if (userProfile == null)
					return "";
				return userProfile.UserID.ToString();
			}
		}

		/// <summary>
		/// Current Instance for MDI parent form. This property uses for one time create object for
		/// MainForm class. Other MDI children or object can call this object via this property (static).
		/// </summary>
		public static MainForm Instance
		{
			get
			{
				return instance;
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
	}
}
