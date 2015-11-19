using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Controls;
using smartRestaurant.Data;
using smartRestaurant.MenuService;
using smartRestaurant.OrderService;
using smartRestaurant.PaymentService;
using smartRestaurant.TableService;
using smartRestaurant.Utils;

namespace smartRestaurant
{
	/// <summary>
	/// <b>PrintReceiptForm</b> is form for print receipt and check bill form.
	/// </summary>
	public class PrintReceiptForm : SmartForm
	{
		/* Input State Value */
		/// <summary>
		/// Constanct variable for form to know no input status
		/// </summary>
		private const int INPUT_NONE		= 0;
		/// <summary>
		/// Constanct variable for form to know input status is select payment method (not use for now)
		/// </summary>
		private const int INPUT_PAYMENT		= 1;
		/// <summary>
		/// Constanct variable for form to know input status is payment value.
		/// </summary>
		private const int INPUT_PAYVALUE	= 2;
		/// <summary>
		/// Constanct variable for form to know input status is point amount value (not use for now).
		/// </summary>
		private const int INPUT_POINTAMOUNT	= 3;
		/// <summary>
		/// Constanct variable for form to know input status to select coupon (not use for now).
		/// </summary>
		private const int INPUT_COUPON		= 4;
		/// <summary>
		/// Constanct variable for form to know input status to select gift (not use for now).
		/// </summary>
		private const int INPUT_GIFT		= 5;

		/// <summary>
		/// <i>Employee ID variable</i>
		/// </summary>
		private int		employeeID;
		/// <summary>
		/// <i>Input state variable, see value from INPUT_* variable</i>
		/// </summary>
		private int		inputState;
		/// <summary>
		/// <i>Current input value</i>
		/// </summary>
		private string	inputValue;
		/// <summary>
		/// <i>Number of guest variable</i>
		/// </summary>
		private int		guestNumber;
		/// <summary>
		/// <i>Bill ID for this order</i>
		/// </summary>
		private int		billNumber;

		/// <summary>
		/// <i>Table information object</i>
		/// </summary>
		private TableInformation	tableInfo;
		/// <summary>
		/// <i>Menu option object list</i>
		/// </summary>
		private MenuOption[]		menuOptions;
		/// <summary>
		/// <i>Menu type object list</i>
		/// </summary>
		private MenuType[]			menuTypes;
		/// <summary>
		/// <i>Order Information object</i>
		/// </summary>
		private OrderInformation	orderInfo;
		/// <summary>
		/// <i>Order Bill object</i>
		/// </summary>
		private OrderBill			selectedBill;
		/// <summary>
		/// <i>Selected Bill Item object</i>
		/// </summary>
		private OrderBillItem		selectedItem;
		/// <summary>
		/// <i>Payment method object list</i>
		/// </summary>
		private PaymentMethod[]		paymentMethods;
		/// <summary>
		/// <i>Receipt object, for compute and contain receipt value.</i>
		/// </summary>
		private Receipt				receipt;
		/// <summary>
		/// <i>List for discount(s) that selected</i>
		/// </summary>
		private ArrayList			discountSelected;
		/// <summary>
		/// <i>List for payment method(s) that selected</i>
		/// </summary>
		private ArrayList			paymentSelected;

		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel OrderPanel;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldBill;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblBill;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldGuest;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblGuest;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldTable;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTable;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnDown;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnUp;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnUndo;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnCancel;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList NumberImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList ButtonImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldCurrentInput;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldInputType;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.NumberPad NumberKeyPad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel groupPanel2;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnPay;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnPrintReceipt;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblAmountDue;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTax1;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTax2;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTotalDiscount;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTotalDue;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTotalReceive;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblTotalChange;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldAmountDue;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldTax1;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldTotalDiscount;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldTax2;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldTotalReceive;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldTotalDue;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldChange;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel groupPanel3;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnBack;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.ComponentModel.IContainer components;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblDiscount;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPayment;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList ButtonLiteImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldPayValue;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPay;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ItemsList ListOrderItem;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ButtonListPad DiscountPad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPageID;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ItemsList ListOrderItemPrice;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblCopyright;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ButtonListPad PaymentTypePad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnFillPay;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ItemsList ListOrderCount;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnPayClear;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnPayClearAll;

		/// <summary>
		/// Constructure for class.<br/>
		/// Load and initiable some variable.
		/// </summary>
		public PrintReceiptForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			LblTax1.Text = AppParameter.Tax1;
			LblTax2.Text = AppParameter.Tax2;
			paymentMethods = Receipt.PaymentMethods;
			discountSelected = new ArrayList();
			paymentSelected = new ArrayList();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PrintReceiptForm));
			this.OrderPanel = new smartRestaurant.Controls.GroupPanel();
			this.FieldBill = new System.Windows.Forms.Label();
			this.LblBill = new System.Windows.Forms.Label();
			this.FieldGuest = new System.Windows.Forms.Label();
			this.LblGuest = new System.Windows.Forms.Label();
			this.FieldTable = new System.Windows.Forms.Label();
			this.LblTable = new System.Windows.Forms.Label();
			this.BtnDown = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnUp = new smartRestaurant.Controls.ImageButton();
			this.BtnUndo = new smartRestaurant.Controls.ImageButton();
			this.BtnCancel = new smartRestaurant.Controls.ImageButton();
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.FieldCurrentInput = new System.Windows.Forms.Label();
			this.FieldInputType = new System.Windows.Forms.Label();
			this.NumberKeyPad = new smartRestaurant.Controls.NumberPad();
			this.groupPanel2 = new smartRestaurant.Controls.GroupPanel();
			this.FieldChange = new System.Windows.Forms.Label();
			this.FieldTotalReceive = new System.Windows.Forms.Label();
			this.FieldTotalDue = new System.Windows.Forms.Label();
			this.FieldTotalDiscount = new System.Windows.Forms.Label();
			this.FieldTax2 = new System.Windows.Forms.Label();
			this.FieldTax1 = new System.Windows.Forms.Label();
			this.FieldAmountDue = new System.Windows.Forms.Label();
			this.LblTotalChange = new System.Windows.Forms.Label();
			this.LblTotalReceive = new System.Windows.Forms.Label();
			this.LblTotalDue = new System.Windows.Forms.Label();
			this.LblTotalDiscount = new System.Windows.Forms.Label();
			this.LblTax2 = new System.Windows.Forms.Label();
			this.LblTax1 = new System.Windows.Forms.Label();
			this.LblAmountDue = new System.Windows.Forms.Label();
			this.BtnPay = new smartRestaurant.Controls.ImageButton();
			this.BtnPrintReceipt = new smartRestaurant.Controls.ImageButton();
			this.groupPanel3 = new smartRestaurant.Controls.GroupPanel();
			this.BtnPayClearAll = new smartRestaurant.Controls.ImageButton();
			this.ButtonLiteImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnPayClear = new smartRestaurant.Controls.ImageButton();
			this.BtnFillPay = new smartRestaurant.Controls.ImageButton();
			this.PaymentTypePad = new smartRestaurant.Controls.ButtonListPad();
			this.FieldPayValue = new System.Windows.Forms.Label();
			this.LblPay = new System.Windows.Forms.Label();
			this.LblPayment = new System.Windows.Forms.Label();
			this.LblDiscount = new System.Windows.Forms.Label();
			this.DiscountPad = new smartRestaurant.Controls.ButtonListPad();
			this.BtnBack = new smartRestaurant.Controls.ImageButton();
			this.ListOrderItem = new smartRestaurant.Controls.ItemsList();
			this.ListOrderCount = new smartRestaurant.Controls.ItemsList();
			this.ListOrderItemPrice = new smartRestaurant.Controls.ItemsList();
			this.LblPageID = new System.Windows.Forms.Label();
			this.LblCopyright = new System.Windows.Forms.Label();
			this.OrderPanel.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			this.groupPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// OrderPanel
			// 
			this.OrderPanel.BackColor = System.Drawing.Color.Transparent;
			this.OrderPanel.Caption = null;
			this.OrderPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.FieldBill,
																					 this.LblBill,
																					 this.FieldGuest,
																					 this.LblGuest,
																					 this.FieldTable,
																					 this.LblTable});
			this.OrderPanel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.OrderPanel.Location = new System.Drawing.Point(560, 0);
			this.OrderPanel.Name = "OrderPanel";
			this.OrderPanel.ShowHeader = false;
			this.OrderPanel.Size = new System.Drawing.Size(449, 58);
			this.OrderPanel.TabIndex = 2;
			// 
			// FieldBill
			// 
			this.FieldBill.BackColor = System.Drawing.Color.White;
			this.FieldBill.Location = new System.Drawing.Point(384, 1);
			this.FieldBill.Name = "FieldBill";
			this.FieldBill.Size = new System.Drawing.Size(64, 56);
			this.FieldBill.TabIndex = 11;
			this.FieldBill.Text = "1";
			this.FieldBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblBill
			// 
			this.LblBill.BackColor = System.Drawing.Color.Orange;
			this.LblBill.Location = new System.Drawing.Point(312, 1);
			this.LblBill.Name = "LblBill";
			this.LblBill.Size = new System.Drawing.Size(72, 56);
			this.LblBill.TabIndex = 10;
			this.LblBill.Text = "Bill:";
			this.LblBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FieldGuest
			// 
			this.FieldGuest.BackColor = System.Drawing.Color.White;
			this.FieldGuest.Location = new System.Drawing.Point(248, 1);
			this.FieldGuest.Name = "FieldGuest";
			this.FieldGuest.Size = new System.Drawing.Size(64, 56);
			this.FieldGuest.TabIndex = 9;
			this.FieldGuest.Text = "1";
			this.FieldGuest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblGuest
			// 
			this.LblGuest.BackColor = System.Drawing.Color.Orange;
			this.LblGuest.Location = new System.Drawing.Point(176, 1);
			this.LblGuest.Name = "LblGuest";
			this.LblGuest.Size = new System.Drawing.Size(72, 56);
			this.LblGuest.TabIndex = 8;
			this.LblGuest.Text = "Seat:";
			this.LblGuest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FieldTable
			// 
			this.FieldTable.BackColor = System.Drawing.Color.White;
			this.FieldTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.FieldTable.Location = new System.Drawing.Point(73, 1);
			this.FieldTable.Name = "FieldTable";
			this.FieldTable.Size = new System.Drawing.Size(103, 56);
			this.FieldTable.TabIndex = 7;
			this.FieldTable.Text = "1";
			this.FieldTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblTable
			// 
			this.LblTable.BackColor = System.Drawing.Color.Orange;
			this.LblTable.Location = new System.Drawing.Point(1, 1);
			this.LblTable.Name = "LblTable";
			this.LblTable.Size = new System.Drawing.Size(72, 56);
			this.LblTable.TabIndex = 6;
			this.LblTable.Text = "Table:";
			this.LblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BtnDown
			// 
			this.BtnDown.BackColor = System.Drawing.Color.Transparent;
			this.BtnDown.Blue = 2F;
			this.BtnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDown.Green = 1F;
			this.BtnDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnDown.Image")));
			this.BtnDown.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnDown.ImageClick")));
			this.BtnDown.ImageClickIndex = 5;
			this.BtnDown.ImageIndex = 4;
			this.BtnDown.ImageList = this.ButtonImgList;
			this.BtnDown.Location = new System.Drawing.Point(208, 692);
			this.BtnDown.Name = "BtnDown";
			this.BtnDown.ObjectValue = null;
			this.BtnDown.Red = 2F;
			this.BtnDown.Size = new System.Drawing.Size(110, 60);
			this.BtnDown.TabIndex = 24;
			this.BtnDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnUp
			// 
			this.BtnUp.BackColor = System.Drawing.Color.Transparent;
			this.BtnUp.Blue = 2F;
			this.BtnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnUp.Green = 1F;
			this.BtnUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnUp.Image")));
			this.BtnUp.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnUp.ImageClick")));
			this.BtnUp.ImageClickIndex = 3;
			this.BtnUp.ImageIndex = 2;
			this.BtnUp.ImageList = this.ButtonImgList;
			this.BtnUp.Location = new System.Drawing.Point(16, 692);
			this.BtnUp.Name = "BtnUp";
			this.BtnUp.ObjectValue = null;
			this.BtnUp.Red = 2F;
			this.BtnUp.Size = new System.Drawing.Size(110, 60);
			this.BtnUp.TabIndex = 23;
			this.BtnUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
			// 
			// BtnUndo
			// 
			this.BtnUndo.BackColor = System.Drawing.Color.Transparent;
			this.BtnUndo.Blue = 2F;
			this.BtnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnUndo.Green = 1F;
			this.BtnUndo.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnUndo.Image")));
			this.BtnUndo.ImageClick = null;
			this.BtnUndo.ImageClickIndex = 0;
			this.BtnUndo.ImageIndex = 0;
			this.BtnUndo.ImageList = this.ButtonImgList;
			this.BtnUndo.Location = new System.Drawing.Point(120, 64);
			this.BtnUndo.Name = "BtnUndo";
			this.BtnUndo.ObjectValue = null;
			this.BtnUndo.Red = 2F;
			this.BtnUndo.Size = new System.Drawing.Size(110, 60);
			this.BtnUndo.TabIndex = 21;
			this.BtnUndo.Text = "Undo";
			this.BtnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
			this.BtnCancel.Blue = 2F;
			this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCancel.Green = 1F;
			this.BtnCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.Image")));
			this.BtnCancel.ImageClick = null;
			this.BtnCancel.ImageClickIndex = 0;
			this.BtnCancel.ImageIndex = 0;
			this.BtnCancel.ImageList = this.ButtonImgList;
			this.BtnCancel.Location = new System.Drawing.Point(8, 64);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.ObjectValue = null;
			this.BtnCancel.Red = 2F;
			this.BtnCancel.Size = new System.Drawing.Size(110, 60);
			this.BtnCancel.TabIndex = 20;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// FieldCurrentInput
			// 
			this.FieldCurrentInput.BackColor = System.Drawing.Color.Black;
			this.FieldCurrentInput.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FieldCurrentInput.ForeColor = System.Drawing.Color.Cyan;
			this.FieldCurrentInput.Location = new System.Drawing.Point(136, 312);
			this.FieldCurrentInput.Name = "FieldCurrentInput";
			this.FieldCurrentInput.Size = new System.Drawing.Size(200, 40);
			this.FieldCurrentInput.TabIndex = 9;
			this.FieldCurrentInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FieldInputType
			// 
			this.FieldInputType.BackColor = System.Drawing.Color.Black;
			this.FieldInputType.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FieldInputType.ForeColor = System.Drawing.Color.Cyan;
			this.FieldInputType.Location = new System.Drawing.Point(8, 312);
			this.FieldInputType.Name = "FieldInputType";
			this.FieldInputType.Size = new System.Drawing.Size(128, 40);
			this.FieldInputType.TabIndex = 8;
			this.FieldInputType.Text = "none";
			this.FieldInputType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NumberKeyPad
			// 
			this.NumberKeyPad.BackColor = System.Drawing.Color.White;
			this.NumberKeyPad.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.NumberKeyPad.Image = ((System.Drawing.Bitmap)(resources.GetObject("NumberKeyPad.Image")));
			this.NumberKeyPad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("NumberKeyPad.ImageClick")));
			this.NumberKeyPad.ImageClickIndex = 1;
			this.NumberKeyPad.ImageIndex = 0;
			this.NumberKeyPad.ImageList = this.NumberImgList;
			this.NumberKeyPad.Location = new System.Drawing.Point(64, 360);
			this.NumberKeyPad.Name = "NumberKeyPad";
			this.NumberKeyPad.Size = new System.Drawing.Size(226, 255);
			this.NumberKeyPad.TabIndex = 7;
			this.NumberKeyPad.Text = "numberPad1";
			this.NumberKeyPad.PadClick += new smartRestaurant.Controls.NumberPadEventHandler(this.NumberKeyPad_PadClick);
			// 
			// groupPanel2
			// 
			this.groupPanel2.BackColor = System.Drawing.Color.White;
			this.groupPanel2.Caption = null;
			this.groupPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.FieldChange,
																					  this.FieldTotalReceive,
																					  this.FieldTotalDue,
																					  this.FieldTotalDiscount,
																					  this.FieldTax2,
																					  this.FieldTax1,
																					  this.FieldAmountDue,
																					  this.LblTotalChange,
																					  this.LblTotalReceive,
																					  this.LblTotalDue,
																					  this.LblTotalDiscount,
																					  this.LblTax2,
																					  this.LblTax1,
																					  this.LblAmountDue,
																					  this.FieldCurrentInput,
																					  this.FieldInputType,
																					  this.NumberKeyPad});
			this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel2.Location = new System.Drawing.Point(328, 128);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.ShowHeader = false;
			this.groupPanel2.Size = new System.Drawing.Size(344, 624);
			this.groupPanel2.TabIndex = 25;
			// 
			// FieldChange
			// 
			this.FieldChange.Location = new System.Drawing.Point(168, 256);
			this.FieldChange.Name = "FieldChange";
			this.FieldChange.Size = new System.Drawing.Size(160, 40);
			this.FieldChange.TabIndex = 23;
			this.FieldChange.Text = "0.00";
			this.FieldChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTotalReceive
			// 
			this.FieldTotalReceive.Location = new System.Drawing.Point(168, 216);
			this.FieldTotalReceive.Name = "FieldTotalReceive";
			this.FieldTotalReceive.Size = new System.Drawing.Size(160, 40);
			this.FieldTotalReceive.TabIndex = 22;
			this.FieldTotalReceive.Text = "0.00";
			this.FieldTotalReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTotalDue
			// 
			this.FieldTotalDue.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FieldTotalDue.ForeColor = System.Drawing.Color.Green;
			this.FieldTotalDue.Location = new System.Drawing.Point(168, 176);
			this.FieldTotalDue.Name = "FieldTotalDue";
			this.FieldTotalDue.Size = new System.Drawing.Size(160, 40);
			this.FieldTotalDue.TabIndex = 21;
			this.FieldTotalDue.Text = "0.00";
			this.FieldTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTotalDiscount
			// 
			this.FieldTotalDiscount.Location = new System.Drawing.Point(168, 56);
			this.FieldTotalDiscount.Name = "FieldTotalDiscount";
			this.FieldTotalDiscount.Size = new System.Drawing.Size(160, 40);
			this.FieldTotalDiscount.TabIndex = 20;
			this.FieldTotalDiscount.Text = "0.00";
			this.FieldTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTax2
			// 
			this.FieldTax2.Location = new System.Drawing.Point(168, 136);
			this.FieldTax2.Name = "FieldTax2";
			this.FieldTax2.Size = new System.Drawing.Size(160, 40);
			this.FieldTax2.TabIndex = 19;
			this.FieldTax2.Text = "0.00";
			this.FieldTax2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTax1
			// 
			this.FieldTax1.Location = new System.Drawing.Point(168, 96);
			this.FieldTax1.Name = "FieldTax1";
			this.FieldTax1.Size = new System.Drawing.Size(160, 40);
			this.FieldTax1.TabIndex = 18;
			this.FieldTax1.Text = "0.00";
			this.FieldTax1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldAmountDue
			// 
			this.FieldAmountDue.Location = new System.Drawing.Point(168, 16);
			this.FieldAmountDue.Name = "FieldAmountDue";
			this.FieldAmountDue.Size = new System.Drawing.Size(160, 40);
			this.FieldAmountDue.TabIndex = 17;
			this.FieldAmountDue.Text = "0.00";
			this.FieldAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblTotalChange
			// 
			this.LblTotalChange.Location = new System.Drawing.Point(16, 256);
			this.LblTotalChange.Name = "LblTotalChange";
			this.LblTotalChange.Size = new System.Drawing.Size(144, 40);
			this.LblTotalChange.TabIndex = 16;
			this.LblTotalChange.Text = "Change";
			this.LblTotalChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTotalReceive
			// 
			this.LblTotalReceive.Location = new System.Drawing.Point(16, 216);
			this.LblTotalReceive.Name = "LblTotalReceive";
			this.LblTotalReceive.Size = new System.Drawing.Size(144, 40);
			this.LblTotalReceive.TabIndex = 15;
			this.LblTotalReceive.Text = "Total Receive";
			this.LblTotalReceive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTotalDue
			// 
			this.LblTotalDue.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblTotalDue.ForeColor = System.Drawing.Color.Green;
			this.LblTotalDue.Location = new System.Drawing.Point(16, 176);
			this.LblTotalDue.Name = "LblTotalDue";
			this.LblTotalDue.Size = new System.Drawing.Size(144, 40);
			this.LblTotalDue.TabIndex = 14;
			this.LblTotalDue.Text = "Total Due";
			this.LblTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTotalDiscount
			// 
			this.LblTotalDiscount.Location = new System.Drawing.Point(16, 56);
			this.LblTotalDiscount.Name = "LblTotalDiscount";
			this.LblTotalDiscount.Size = new System.Drawing.Size(144, 40);
			this.LblTotalDiscount.TabIndex = 13;
			this.LblTotalDiscount.Text = "Total Discount";
			this.LblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTax2
			// 
			this.LblTax2.Location = new System.Drawing.Point(16, 136);
			this.LblTax2.Name = "LblTax2";
			this.LblTax2.Size = new System.Drawing.Size(144, 40);
			this.LblTax2.TabIndex = 12;
			this.LblTax2.Text = "Tax2";
			this.LblTax2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTax1
			// 
			this.LblTax1.Location = new System.Drawing.Point(16, 96);
			this.LblTax1.Name = "LblTax1";
			this.LblTax1.Size = new System.Drawing.Size(144, 40);
			this.LblTax1.TabIndex = 11;
			this.LblTax1.Text = "Tax1";
			this.LblTax1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblAmountDue
			// 
			this.LblAmountDue.Location = new System.Drawing.Point(16, 16);
			this.LblAmountDue.Name = "LblAmountDue";
			this.LblAmountDue.Size = new System.Drawing.Size(144, 40);
			this.LblAmountDue.TabIndex = 10;
			this.LblAmountDue.Text = "Amount Due";
			this.LblAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BtnPay
			// 
			this.BtnPay.BackColor = System.Drawing.Color.Transparent;
			this.BtnPay.Blue = 1F;
			this.BtnPay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPay.Green = 1F;
			this.BtnPay.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPay.Image")));
			this.BtnPay.ImageClick = null;
			this.BtnPay.ImageClickIndex = 0;
			this.BtnPay.ImageIndex = 0;
			this.BtnPay.ImageList = this.ButtonImgList;
			this.BtnPay.Location = new System.Drawing.Point(904, 64);
			this.BtnPay.Name = "BtnPay";
			this.BtnPay.ObjectValue = null;
			this.BtnPay.Red = 1.75F;
			this.BtnPay.Size = new System.Drawing.Size(110, 60);
			this.BtnPay.TabIndex = 28;
			this.BtnPay.Text = "Close-Bill";
			this.BtnPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPay.Click += new System.EventHandler(this.BtnPay_Click);
			// 
			// BtnPrintReceipt
			// 
			this.BtnPrintReceipt.BackColor = System.Drawing.Color.Transparent;
			this.BtnPrintReceipt.Blue = 1.75F;
			this.BtnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPrintReceipt.Green = 1F;
			this.BtnPrintReceipt.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPrintReceipt.Image")));
			this.BtnPrintReceipt.ImageClick = null;
			this.BtnPrintReceipt.ImageClickIndex = 0;
			this.BtnPrintReceipt.ImageIndex = 0;
			this.BtnPrintReceipt.ImageList = this.ButtonImgList;
			this.BtnPrintReceipt.Location = new System.Drawing.Point(792, 64);
			this.BtnPrintReceipt.Name = "BtnPrintReceipt";
			this.BtnPrintReceipt.ObjectValue = null;
			this.BtnPrintReceipt.Red = 1.75F;
			this.BtnPrintReceipt.Size = new System.Drawing.Size(110, 60);
			this.BtnPrintReceipt.TabIndex = 27;
			this.BtnPrintReceipt.Text = "Print-Receipt";
			this.BtnPrintReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPrintReceipt.Click += new System.EventHandler(this.BtnPrintReceipt_Click);
			// 
			// groupPanel3
			// 
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.Caption = null;
			this.groupPanel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.BtnPayClearAll,
																					  this.BtnPayClear,
																					  this.BtnFillPay,
																					  this.PaymentTypePad,
																					  this.FieldPayValue,
																					  this.LblPay,
																					  this.LblPayment,
																					  this.LblDiscount,
																					  this.DiscountPad});
			this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel3.Location = new System.Drawing.Point(672, 128);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.ShowHeader = false;
			this.groupPanel3.Size = new System.Drawing.Size(344, 624);
			this.groupPanel3.TabIndex = 29;
			// 
			// BtnPayClearAll
			// 
			this.BtnPayClearAll.BackColor = System.Drawing.Color.Transparent;
			this.BtnPayClearAll.Blue = 2F;
			this.BtnPayClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPayClearAll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.BtnPayClearAll.Green = 1F;
			this.BtnPayClearAll.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPayClearAll.Image")));
			this.BtnPayClearAll.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnPayClearAll.ImageClick")));
			this.BtnPayClearAll.ImageClickIndex = 1;
			this.BtnPayClearAll.ImageIndex = 0;
			this.BtnPayClearAll.ImageList = this.ButtonLiteImgList;
			this.BtnPayClearAll.Location = new System.Drawing.Point(8, 532);
			this.BtnPayClearAll.Name = "BtnPayClearAll";
			this.BtnPayClearAll.ObjectValue = null;
			this.BtnPayClearAll.Red = 1F;
			this.BtnPayClearAll.Size = new System.Drawing.Size(110, 40);
			this.BtnPayClearAll.TabIndex = 44;
			this.BtnPayClearAll.Text = "Clear All";
			this.BtnPayClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPayClearAll.Click += new System.EventHandler(this.BtnPayClearAll_Click);
			// 
			// ButtonLiteImgList
			// 
			this.ButtonLiteImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonLiteImgList.ImageSize = new System.Drawing.Size(110, 40);
			this.ButtonLiteImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonLiteImgList.ImageStream")));
			this.ButtonLiteImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnPayClear
			// 
			this.BtnPayClear.BackColor = System.Drawing.Color.Transparent;
			this.BtnPayClear.Blue = 2F;
			this.BtnPayClear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPayClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.BtnPayClear.Green = 1F;
			this.BtnPayClear.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPayClear.Image")));
			this.BtnPayClear.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnPayClear.ImageClick")));
			this.BtnPayClear.ImageClickIndex = 1;
			this.BtnPayClear.ImageIndex = 0;
			this.BtnPayClear.ImageList = this.ButtonLiteImgList;
			this.BtnPayClear.Location = new System.Drawing.Point(230, 532);
			this.BtnPayClear.Name = "BtnPayClear";
			this.BtnPayClear.ObjectValue = null;
			this.BtnPayClear.Red = 1F;
			this.BtnPayClear.Size = new System.Drawing.Size(110, 40);
			this.BtnPayClear.TabIndex = 43;
			this.BtnPayClear.Text = "Clear";
			this.BtnPayClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPayClear.Click += new System.EventHandler(this.BtnPayClear_Click);
			// 
			// BtnFillPay
			// 
			this.BtnFillPay.BackColor = System.Drawing.Color.Transparent;
			this.BtnFillPay.Blue = 2F;
			this.BtnFillPay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnFillPay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.BtnFillPay.Green = 1F;
			this.BtnFillPay.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnFillPay.Image")));
			this.BtnFillPay.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnFillPay.ImageClick")));
			this.BtnFillPay.ImageClickIndex = 1;
			this.BtnFillPay.ImageIndex = 0;
			this.BtnFillPay.ImageList = this.ButtonLiteImgList;
			this.BtnFillPay.Location = new System.Drawing.Point(230, 576);
			this.BtnFillPay.Name = "BtnFillPay";
			this.BtnFillPay.ObjectValue = null;
			this.BtnFillPay.Red = 1F;
			this.BtnFillPay.Size = new System.Drawing.Size(110, 40);
			this.BtnFillPay.TabIndex = 42;
			this.BtnFillPay.Text = "Fill Pay";
			this.BtnFillPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnFillPay.Click += new System.EventHandler(this.BtnFillPay_Click);
			// 
			// PaymentTypePad
			// 
			this.PaymentTypePad.AutoRefresh = true;
			this.PaymentTypePad.BackColor = System.Drawing.Color.White;
			this.PaymentTypePad.Blue = 1F;
			this.PaymentTypePad.Column = 3;
			this.PaymentTypePad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.PaymentTypePad.Green = 1F;
			this.PaymentTypePad.Image = ((System.Drawing.Bitmap)(resources.GetObject("PaymentTypePad.Image")));
			this.PaymentTypePad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("PaymentTypePad.ImageClick")));
			this.PaymentTypePad.ImageClickIndex = 1;
			this.PaymentTypePad.ImageIndex = 0;
			this.PaymentTypePad.ImageList = this.ButtonImgList;
			this.PaymentTypePad.ItemStart = 0;
			this.PaymentTypePad.Location = new System.Drawing.Point(8, 344);
			this.PaymentTypePad.Name = "PaymentTypePad";
			this.PaymentTypePad.Padding = 1;
			this.PaymentTypePad.Red = 1F;
			this.PaymentTypePad.Row = 3;
			this.PaymentTypePad.Size = new System.Drawing.Size(332, 182);
			this.PaymentTypePad.TabIndex = 41;
			this.PaymentTypePad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.PaymentTypePad_PadClick);
			this.PaymentTypePad.PageChange += new smartRestaurant.Controls.ButtonListPadEventHandler(this.PaymentTypePad_PageChange);
			// 
			// FieldPayValue
			// 
			this.FieldPayValue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldPayValue.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldPayValue.Location = new System.Drawing.Point(88, 576);
			this.FieldPayValue.Name = "FieldPayValue";
			this.FieldPayValue.Size = new System.Drawing.Size(128, 40);
			this.FieldPayValue.TabIndex = 28;
			this.FieldPayValue.Text = "0.00";
			this.FieldPayValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.FieldPayValue.Visible = false;
			this.FieldPayValue.Click += new System.EventHandler(this.FieldPayValue_Click);
			// 
			// LblPay
			// 
			this.LblPay.Location = new System.Drawing.Point(16, 576);
			this.LblPay.Name = "LblPay";
			this.LblPay.Size = new System.Drawing.Size(72, 40);
			this.LblPay.TabIndex = 24;
			this.LblPay.Text = "Pay";
			this.LblPay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LblPay.Visible = false;
			// 
			// LblPayment
			// 
			this.LblPayment.BackColor = System.Drawing.Color.Black;
			this.LblPayment.ForeColor = System.Drawing.Color.White;
			this.LblPayment.Location = new System.Drawing.Point(0, 296);
			this.LblPayment.Name = "LblPayment";
			this.LblPayment.Size = new System.Drawing.Size(344, 40);
			this.LblPayment.TabIndex = 1;
			this.LblPayment.Text = "Payment Receive";
			this.LblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblDiscount
			// 
			this.LblDiscount.BackColor = System.Drawing.Color.Black;
			this.LblDiscount.ForeColor = System.Drawing.Color.White;
			this.LblDiscount.Name = "LblDiscount";
			this.LblDiscount.Size = new System.Drawing.Size(344, 40);
			this.LblDiscount.TabIndex = 0;
			this.LblDiscount.Text = "Discount";
			this.LblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DiscountPad
			// 
			this.DiscountPad.AutoRefresh = true;
			this.DiscountPad.BackColor = System.Drawing.Color.White;
			this.DiscountPad.Blue = 1F;
			this.DiscountPad.Column = 3;
			this.DiscountPad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.DiscountPad.Green = 1F;
			this.DiscountPad.Image = ((System.Drawing.Bitmap)(resources.GetObject("DiscountPad.Image")));
			this.DiscountPad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("DiscountPad.ImageClick")));
			this.DiscountPad.ImageClickIndex = 1;
			this.DiscountPad.ImageIndex = 0;
			this.DiscountPad.ImageList = this.ButtonImgList;
			this.DiscountPad.ItemStart = 0;
			this.DiscountPad.Location = new System.Drawing.Point(6, 48);
			this.DiscountPad.Name = "DiscountPad";
			this.DiscountPad.Padding = 1;
			this.DiscountPad.Red = 1F;
			this.DiscountPad.Row = 4;
			this.DiscountPad.Size = new System.Drawing.Size(332, 243);
			this.DiscountPad.TabIndex = 40;
			this.DiscountPad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.DiscountPad_PadClick);
			this.DiscountPad.PageChange += new smartRestaurant.Controls.ButtonListPadEventHandler(this.DiscountPad_PageChange);
			// 
			// BtnBack
			// 
			this.BtnBack.BackColor = System.Drawing.Color.Transparent;
			this.BtnBack.Blue = 2F;
			this.BtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnBack.Green = 2F;
			this.BtnBack.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnBack.Image")));
			this.BtnBack.ImageClick = null;
			this.BtnBack.ImageClickIndex = 0;
			this.BtnBack.ImageIndex = 0;
			this.BtnBack.ImageList = this.ButtonImgList;
			this.BtnBack.Location = new System.Drawing.Point(424, 64);
			this.BtnBack.Name = "BtnBack";
			this.BtnBack.ObjectValue = null;
			this.BtnBack.Red = 1F;
			this.BtnBack.Size = new System.Drawing.Size(110, 60);
			this.BtnBack.TabIndex = 30;
			this.BtnBack.Text = "Back";
			this.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
			// 
			// ListOrderItem
			// 
			this.ListOrderItem.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.ListOrderItem.AutoRefresh = true;
			this.ListOrderItem.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListOrderItem.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListOrderItem.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListOrderItem.BackNormalColor = System.Drawing.Color.White;
			this.ListOrderItem.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListOrderItem.BindList1 = this.ListOrderCount;
			this.ListOrderItem.BindList2 = null;
			this.ListOrderItem.Border = 0;
			this.ListOrderItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListOrderItem.ForeAlterColor = System.Drawing.Color.Black;
			this.ListOrderItem.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListOrderItem.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListOrderItem.ForeNormalColor = System.Drawing.Color.Black;
			this.ListOrderItem.ForeSelectedColor = System.Drawing.Color.White;
			this.ListOrderItem.ItemHeight = 40;
			this.ListOrderItem.ItemWidth = 200;
			this.ListOrderItem.Location = new System.Drawing.Point(8, 128);
			this.ListOrderItem.Name = "ListOrderItem";
			this.ListOrderItem.Row = 14;
			this.ListOrderItem.SelectedIndex = 0;
			this.ListOrderItem.Size = new System.Drawing.Size(200, 560);
			this.ListOrderItem.TabIndex = 31;
			this.ListOrderItem.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListOrderItem_ItemClick);
			// 
			// ListOrderCount
			// 
			this.ListOrderCount.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.ListOrderCount.AutoRefresh = true;
			this.ListOrderCount.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListOrderCount.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListOrderCount.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListOrderCount.BackNormalColor = System.Drawing.Color.White;
			this.ListOrderCount.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListOrderCount.BindList1 = this.ListOrderItem;
			this.ListOrderCount.BindList2 = this.ListOrderItemPrice;
			this.ListOrderCount.Border = 0;
			this.ListOrderCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListOrderCount.ForeAlterColor = System.Drawing.Color.Black;
			this.ListOrderCount.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListOrderCount.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListOrderCount.ForeNormalColor = System.Drawing.Color.Black;
			this.ListOrderCount.ForeSelectedColor = System.Drawing.Color.White;
			this.ListOrderCount.ItemHeight = 40;
			this.ListOrderCount.ItemWidth = 40;
			this.ListOrderCount.Location = new System.Drawing.Point(208, 128);
			this.ListOrderCount.Name = "ListOrderCount";
			this.ListOrderCount.Row = 14;
			this.ListOrderCount.SelectedIndex = 0;
			this.ListOrderCount.Size = new System.Drawing.Size(40, 560);
			this.ListOrderCount.TabIndex = 37;
			this.ListOrderCount.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListOrderItem_ItemClick);
			// 
			// ListOrderItemPrice
			// 
			this.ListOrderItemPrice.Alignment = System.Drawing.ContentAlignment.MiddleRight;
			this.ListOrderItemPrice.AutoRefresh = true;
			this.ListOrderItemPrice.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListOrderItemPrice.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListOrderItemPrice.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListOrderItemPrice.BackNormalColor = System.Drawing.Color.White;
			this.ListOrderItemPrice.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListOrderItemPrice.BindList1 = this.ListOrderCount;
			this.ListOrderItemPrice.BindList2 = null;
			this.ListOrderItemPrice.Border = 0;
			this.ListOrderItemPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListOrderItemPrice.ForeAlterColor = System.Drawing.Color.Black;
			this.ListOrderItemPrice.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListOrderItemPrice.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListOrderItemPrice.ForeNormalColor = System.Drawing.Color.Black;
			this.ListOrderItemPrice.ForeSelectedColor = System.Drawing.Color.White;
			this.ListOrderItemPrice.ItemHeight = 40;
			this.ListOrderItemPrice.ItemWidth = 80;
			this.ListOrderItemPrice.Location = new System.Drawing.Point(248, 128);
			this.ListOrderItemPrice.Name = "ListOrderItemPrice";
			this.ListOrderItemPrice.Row = 14;
			this.ListOrderItemPrice.SelectedIndex = 0;
			this.ListOrderItemPrice.Size = new System.Drawing.Size(80, 560);
			this.ListOrderItemPrice.TabIndex = 33;
			this.ListOrderItemPrice.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListOrderItem_ItemClick);
			// 
			// LblPageID
			// 
			this.LblPageID.BackColor = System.Drawing.Color.Transparent;
			this.LblPageID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblPageID.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblPageID.Location = new System.Drawing.Point(792, 752);
			this.LblPageID.Name = "LblPageID";
			this.LblPageID.Size = new System.Drawing.Size(216, 23);
			this.LblPageID.TabIndex = 32;
			this.LblPageID.Text = "STCB011";
			this.LblPageID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LblCopyright
			// 
			this.LblCopyright.BackColor = System.Drawing.Color.Transparent;
			this.LblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblCopyright.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblCopyright.Location = new System.Drawing.Point(8, 752);
			this.LblCopyright.Name = "LblCopyright";
			this.LblCopyright.Size = new System.Drawing.Size(280, 16);
			this.LblCopyright.TabIndex = 36;
			this.LblCopyright.Text = "Copyright (c) 2004. All rights reserved.";
			// 
			// PrintReceiptForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ListOrderCount,
																		  this.LblCopyright,
																		  this.ListOrderItemPrice,
																		  this.LblPageID,
																		  this.ListOrderItem,
																		  this.BtnBack,
																		  this.groupPanel3,
																		  this.BtnPay,
																		  this.BtnPrintReceipt,
																		  this.groupPanel2,
																		  this.BtnDown,
																		  this.BtnUp,
																		  this.BtnUndo,
																		  this.BtnCancel,
																		  this.OrderPanel});
			this.Name = "PrintReceiptForm";
			this.Text = "Check Bill";
			this.OrderPanel.ResumeLayout(false);
			this.groupPanel2.ResumeLayout(false);
			this.groupPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Set variable to prepare each step.
		/// <summary>
		/// Method to clear variable to INPUT_NONE state.
		/// </summary>
		private void StartInputNone()
		{
			inputState = INPUT_NONE;
			inputValue = "";
			NumberKeyPad.Enabled = false;
			receipt.PaymentMethod = null;
			UpdateMonitor();
		}

		/// <summary>
		/// Method to clear variable to INPUT_PAYVALUE state.
		/// </summary>
		private void StartInputPayValue()
		{
			inputState = INPUT_PAYVALUE;
			inputValue = "";
			NumberKeyPad.Enabled = true;
			UpdateMonitor();
		}

		/// <summary>
		/// Method to clear variable to INPUT_POINTAMOUNT state. (not use for now)
		/// </summary>
		private void StartInputPointAmount()
		{
			inputState = INPUT_POINTAMOUNT;
			inputValue = "";
			NumberKeyPad.Enabled = true;
			UpdateMonitor();
		}

		/// <summary>
		/// Load discount list from receipt and create them to <i>discountSelected</i>
		/// variable for use to display on screen.
		/// </summary>
		private void LoadDiscountSelected()
		{
			if (receipt.UseDiscount.Count > 0)
			{
				for (int i = 0;i < receipt.UseDiscount.Count;i++)
				{
					for (int j = 0;j < Receipt.Discounts.Length;j++)
					{
						if (((Discount)receipt.UseDiscount[i]).promotionID == Receipt.Discounts[j].promotionID)
						{
							discountSelected.Add(j);
							break;
						}
					}
				}
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Table Information object property. (Set Only) Use for MainForm to set table
		/// information object to PrintReceiptForm.
		/// </summary>
		public TableInformation Table
		{
			set
			{
				tableInfo = value;
			}
		}

		/// <summary>
		/// Order Information object property. (Set Only) Use for MainForm to set order
		/// information object to PrintReceiptForm.
		/// </summary>
		public OrderInformation Order
		{
			set
			{
				orderInfo = value;
				guestNumber = orderInfo.NumberOfGuest;
				billNumber = orderInfo.Bills.Length;
			}
		}

		/// <summary>
		/// Order Bill object property. (Set Only) Use for MainForm to set order
		/// bill object to PrintReceiptForm.
		/// </summary>
		public OrderBill OrderBill
		{
			set
			{
				selectedBill = value;
			}
		}

		/// <summary>
		/// Employee ID property. (Set Only) Use for MainForm to set employee ID
		/// object to PrintReceiptForm.
		/// </summary>
		public int EmployeeID
		{
			set
			{
				employeeID = value;
			}
		}
		#endregion

		#region Initialize screen and Update screen
		/// <summary>
		/// Initial form when start show PrintReceiptForm class.
		/// Call this method from MainForm. This method will clear all variable and
		/// load new value from property that MainForm seted. After that, will update
		/// screen object for show all value.
		/// </summary>
		public override void UpdateForm()
		{
			// Clear Input
			selectedItem = null;
			// Get Menu
			menuTypes = MenuManagement.MenuTypes;
			menuOptions = MenuManagement.MenuOptions;
			// Create Receipt
			int employeeID;
			if (((MainForm)MdiParent).User != null)
				employeeID = ((MainForm)MdiParent).User.UserID;
			else
				employeeID = selectedBill.EmployeeID;
			receipt = new Receipt(selectedBill, employeeID);
			// Clear Discount Pad
			DiscountPad.Items.Clear();
			discountSelected.Clear();
			paymentSelected.Clear();
			LoadDiscountSelected();
			// Update screen
			LblPageID.Text = "Employee ID:" + employeeID.ToString() + " | STCB011";
			if (AppParameter.IsDemo())
			{
				LblTotalChange.Text = "Change";
				LblGuest.Text = "Guest";
			}
			else
			{
				LblTotalChange.Text = "Tip";
				LblGuest.Text = "Seat";
			}
			StartInputNone();
			UpdateTableInformation();
			UpdateSummary();
			UpdateOrderGrid();
			UpdateDiscountList();
			UpdatePaymentTypeList();
		}

		/// <summary>
		/// Update screen for table, number of guest, and number of bill.
		/// </summary>
		private void UpdateTableInformation()
		{
			FieldTable.Text = tableInfo.TableName;;
			FieldGuest.Text = guestNumber.ToString();
			FieldBill.Text = billNumber.ToString();
		}

		/// <summary>
		/// Update screen in monitor panel. Include input state and input value.
		/// </summary>
		private void UpdateMonitor()
		{
			bool showInitial = false;

			switch (inputState)
			{
				case INPUT_NONE:
					goto default;
				case INPUT_PAYMENT:
					FieldInputType.Text = "Payment";
					break;
				case INPUT_PAYVALUE:
					FieldInputType.Text = "Pay";
					showInitial = true;
					break;
				case INPUT_POINTAMOUNT:
					FieldInputType.Text = "Point";
					showInitial = true;
					break;
				case INPUT_COUPON:
					FieldInputType.Text = "Coupon";
					break;
				case INPUT_GIFT:
					FieldInputType.Text = "Gift Voucher";
					break;
				default:
					inputState = INPUT_NONE;
					FieldInputType.Text = "";
					break;
			}
			if (showInitial && inputValue == "")
			{
				FieldCurrentInput.ForeColor = Color.Yellow;
				if (inputState == INPUT_PAYVALUE)
					FieldCurrentInput.Text = receipt.PayValue.ToString("N");
				else if (inputState == INPUT_POINTAMOUNT)
					FieldCurrentInput.Text = receipt.PointAmount.ToString();
			}
			else
			{
				FieldCurrentInput.ForeColor = Color.Cyan;
				FieldCurrentInput.Text = inputValue;
			}
		}

		/// <summary>
		/// Update screen for receipt summary and payment value.
		/// </summary>
		private void UpdateSummary()
		{
			receipt.Compute();
			FieldAmountDue.Text = receipt.AmountDue.ToString("N");
			FieldTax1.Visible = (LblTax1.Text != "" || receipt.Tax1 > 0);
			FieldTax2.Visible = (LblTax2.Text != "" || receipt.Tax2 > 0);
			FieldTax1.Text = receipt.Tax1.ToString("N");
			FieldTax2.Text = receipt.Tax2.ToString("N");
			FieldTotalDiscount.Text = receipt.TotalDiscount.ToString("N");
			FieldTotalDue.Text = receipt.TotalDue.ToString("N");
			FieldTotalReceive.Text = receipt.TotalReceive.ToString("N");
			FieldChange.Text = receipt.Change.ToString("N");
			if (receipt.TotalReceive < receipt.TotalDue)
				FieldTotalReceive.ForeColor = Color.Red;
			else
				FieldTotalReceive.ForeColor = Color.Black;
			if (receipt.Change > 0.00)
				FieldChange.ForeColor = Color.Blue;
			else
				FieldChange.ForeColor = Color.Black;
			// Payment
			FieldPayValue.Text = receipt.PayValue.ToString("N");
			UpdateFlowButton();
		}

		/// <summary>
		/// Update order item grid.
		/// </summary>
		private void UpdateOrderGrid()
		{
			StringBuilder sb = new StringBuilder();
			int itemCnt;
			OrderBillItem[] items;
			DataItem data;

			ListOrderItem.AutoRefresh = false;
			ListOrderCount.AutoRefresh = false;
			ListOrderItemPrice.AutoRefresh = false;
			ListOrderItem.Items.Clear();
			ListOrderCount.Items.Clear();
			ListOrderItemPrice.Items.Clear();

			// Add bill title to grid.
			sb.Length = 0;
			if (AppParameter.IsDemo())
				sb.Append("Bill #");
			else
				sb.Append("Seat #");
			sb.Append(selectedBill.BillID);
			data = new DataItem(sb.ToString(), selectedBill, true);
			ListOrderItem.Items.Add(data);
			// Add bill title to grid order count (dummp)
			data = new DataItem("", selectedBill, true);
			ListOrderCount.Items.Add(data);
			// Add bill title to grid order price (dummp)
			data = new DataItem("", selectedBill, true);
			ListOrderItemPrice.Items.Add(data);
			// Selected Bill
			if (selectedItem == null)
			{
				ListOrderItem.SelectedIndex = ListOrderItem.Items.Count - 1;
				ListOrderCount.SelectedIndex = ListOrderCount.Items.Count - 1;
				ListOrderItemPrice.SelectedIndex = ListOrderItemPrice.Items.Count - 1;
			}
			items = selectedBill.Items;
			if (items != null)
			{
				// Loop for all items in bill
				for (itemCnt = 0;itemCnt < items.Length;itemCnt++)
				{
					// Add item to grid
					data = new DataItem(OrderManagement.OrderBillItemDisplayString(items[itemCnt]), items[itemCnt], false);
					if (OrderManagement.IsCancel(items[itemCnt]))
						data.Strike = true;
					ListOrderItem.Items.Add(data);
					// Add item to grid order price
					data = new DataItem(items[itemCnt].Unit.ToString(), items[itemCnt], false);
					if (OrderManagement.IsCancel(items[itemCnt]))
						data.Strike = true;
					ListOrderCount.Items.Add(data);
					// Add item to grid order price
					data = new DataItem(MenuManagement.GetMenuItemFromID(items[itemCnt].MenuID).Price.ToString("N"), items[itemCnt], false);
					if (OrderManagement.IsCancel(items[itemCnt]))
						data.Strike = true;
					ListOrderItemPrice.Items.Add(data);
					// Selected Item
					if (selectedItem == items[itemCnt])
					{
						ListOrderItem.SelectedIndex = ListOrderItem.Items.Count - 1;
						ListOrderCount.SelectedIndex = ListOrderCount.Items.Count - 1;
						ListOrderItemPrice.SelectedIndex = ListOrderItemPrice.Items.Count - 1;
					}
				}
			}
			ListOrderItem.AutoRefresh = true;
			ListOrderCount.AutoRefresh = true;
			ListOrderItemPrice.AutoRefresh = true;
			UpdateOrderButton();
			UpdateFlowButton();
		}

		/// <summary>
		/// Update list of discount in button list
		/// </summary>
		private void UpdateDiscountList()
		{
			Discount[] discounts = Receipt.Discounts;
			if (discounts == null)
				return;
			DiscountPad.AutoRefresh = false;
			if (DiscountPad.Items.Count == 0)
			{
				// Add discount to pad
				for (int i = 0;i < discounts.Length;i++)
				{
					ButtonItem item = new ButtonItem(discounts[i].description, discounts[i].promotionID.ToString());
					DiscountPad.Items.Add(item);
				}
			}
			DiscountPad.Red = 1;
			DiscountPad.Green = 1;
			DiscountPad.Blue = 1;
			for (int i = 0;i < discountSelected.Count;i++)
			{
				int index = (int)discountSelected[i];
				int pos = DiscountPad.GetPosition(index);
				if (pos > -1)
					DiscountPad.SetMatrix(pos, 1, 2, 1);
			}
			DiscountPad.AutoRefresh = true;
		}

		/// <summary>
		/// Update list of payment type in button list
		/// </summary>
		private void UpdatePaymentTypeList()
		{
			ButtonItem item;
			if (paymentMethods == null)
				return;
			PaymentTypePad.AutoRefresh = false;
			if (PaymentTypePad.Items.Count == 0)
			{
				// Add payment method to pad
				for (int i = 0;i < paymentMethods.Length;i++)
				{
					item = new ButtonItem(paymentMethods[i].paymentMethodName, paymentMethods[i].paymentMethodID.ToString());
					PaymentTypePad.Items.Add(item);
				}
			}

			int pos;
			for (int i = 0;i < paymentMethods.Length;i++)
			{
				item = (ButtonItem)PaymentTypePad.Items[i];
				pos = receipt.PaymentMethodList.IndexOf(paymentMethods[i]);
				if (paymentMethods[i] == receipt.PaymentMethod)
				{
					PaymentTypePad.SetMatrix(i, 1, 1.75F, 1.75F);
					if (pos >= 0)
						item.Text = paymentMethods[i].paymentMethodName + "\n"
							+ ((double)receipt.PayValueList[pos]).ToString("N");
					continue;
				}
				if (pos >= 0)
				{
					PaymentTypePad.SetMatrix(i, 1, 2, 2);
					item.Text = paymentMethods[i].paymentMethodName + "\n"
						+ ((double)receipt.PayValueList[pos]).ToString("N");
				}
				else
				{
					PaymentTypePad.SetMatrix(i, 1, 1, 1);
					item.Text = paymentMethods[i].paymentMethodName;
				}
			}
			PaymentTypePad.AutoRefresh = true;
			UpdatePaymentButtion();
		}

		/// <summary>
		/// Update enabled status for cancel/undo/up/down button
		/// </summary>
		private void UpdateOrderButton()
		{
			// Update enabled for cancel/undo button
			if (selectedItem != null && selectedBill.CloseBillDate == DateTime.MinValue)
			{
				BtnCancel.Enabled = !OrderManagement.IsCancel(selectedItem);
				BtnUndo.Enabled = OrderManagement.IsCancel(selectedItem);
			}
			else
			{
				BtnCancel.Enabled = false;
				BtnUndo.Enabled = false;
			}
			// Update enabled for un/down button
			BtnUp.Enabled = ListOrderItem.CanUp;
			BtnDown.Enabled = ListOrderItem.CanDown;
		}

		/// <summary>
		/// Update enabled status for all flow buttons
		/// </summary>
		private void UpdateFlowButton()
		{
			if (receipt.IsCompleted)
				BtnPay.Enabled = true;
			else
				BtnPay.Enabled = false;
		}

		/// <summary>
		/// Update enabled status for all payment buttons
		/// </summary>
		private void UpdatePaymentButtion()
		{
			if (inputState == INPUT_PAYVALUE)
			{
				BtnPayClear.Enabled = true;
				BtnFillPay.Enabled = true;
			}
			else
			{
				BtnPayClear.Enabled = false;
				BtnFillPay.Enabled = false;
			}
		}
		#endregion

		/// <summary>
		/// This event use when user click at Back button. If user come from Take Order form,
		/// this method will send back to take order form. But if user come from Take Out form,
		/// this method will send back to main menu form (select table form).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnBack_Click(object sender, System.EventArgs e)
		{
			if (orderInfo.TableID != 0)
				((MainForm)MdiParent).ShowTakeOrderForm((TableInformation)null);
			else
				((MainForm)MdiParent).ShowMainMenuForm();
		}

		/// <summary>
		/// This method work when user select bill item and click cancel.
		/// Cancel item command will process and receipt will compute new price.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
			{
				OrderManagement.CancelOrderBillItem(selectedBill, selectedItem, employeeID);
				UpdateOrderGrid();
				OrderService.OrderService service = new OrderService.OrderService();
				string msg = service.SendOrderBill(selectedBill);
				if (msg != null)
				{
					MessageBox.Show(this, msg);
					return;
				}
				UpdateSummary();
			}
		}

		/// <summary>
		/// This method work when user select bill item and click Undo button.
		/// Undo command will process and receipt will compute new price.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnUndo_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
			{
				OrderManagement.UndoCancelOrderBillItem(selectedItem, employeeID);
				UpdateOrderGrid();
				OrderService.OrderService service = new OrderService.OrderService();
				string msg = service.SendOrderBill(selectedBill);
				if (msg != null)
				{
					MessageBox.Show(this, msg);
					return;
				}
				UpdateSummary();
			}
		}

		/// <summary>
		/// This method use for user click Up button to scroll bill item page up.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnUp_Click(object sender, System.EventArgs e)
		{
			ListOrderItem.Up(5);
			UpdateOrderButton();
		}

		/// <summary>
		/// This method use for user click Down button to scroll bill item page down.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnDown_Click(object sender, System.EventArgs e)
		{
			ListOrderItem.Down(5);
			UpdateOrderButton();
		}

		/// <summary>
		/// This method use for user to select bill item list. This method will check for user
		/// click is bill item or order bill and will change selectedBill and selectedItem variable
		/// to.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void ListOrderItem_ItemClick(object sender, smartRestaurant.Controls.ItemsListEventArgs e)
		{
			StartInputNone();
			if (e.Item.Value is OrderBill)
			{
				selectedBill = (OrderBill)e.Item.Value;
				selectedItem = null;
				UpdateOrderGrid();
			}
			else if (e.Item.Value is OrderBillItem)
			{
				selectedItem = (OrderBillItem)e.Item.Value;
				for (int i = 0;i >= 0 && i < orderInfo.Bills.Length;i++)
				{
					if (orderInfo.Bills[i].Items != null)
					{
						for (int j = 0;j < orderInfo.Bills[i].Items.Length;j++)
							if (orderInfo.Bills[i].Items[j] == selectedItem)
							{
								selectedBill = orderInfo.Bills[i];
								i = -2;
								break;
							}
					}
				}
				UpdateOrderGrid();
			}
		}

		/// <summary>
		/// This event use when user type number pad. When input state is INPUT_PAYVALUE,
		/// number value will send to input value.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumberKeyPad_PadClick(object sender, smartRestaurant.Controls.NumberPadEventArgs e)
		{
			if (inputState == INPUT_NONE)
				return;
			if (e.IsNumeric)
			{
				if (inputState == INPUT_PAYVALUE)
				{
					try
					{
						double tmpValue = Double.Parse(inputValue);
						tmpValue = (tmpValue * 10.0) + (0.01 * (double)e.Number);
						inputValue = tmpValue.ToString("N");
					}
					catch (Exception)
					{
						inputValue = "0.0" + e.Number.ToString();
					}
				}
				else
				{
					inputValue += e.Number.ToString();
				}
				UpdateMonitor();
			}
			else if (e.IsCancel)
			{
				if (inputState == INPUT_PAYVALUE)
				{
					try
					{
						double tmpValue = Double.Parse(inputValue);
						tmpValue = Math.Floor(tmpValue * 10.0) / 100.0;
						inputValue = tmpValue.ToString("N");
						if (tmpValue == 0)
						{
							StartInputNone();
							receipt.PaymentMethod = null;
							UpdatePaymentTypeList();
						}
						else
							UpdateMonitor();
					}
					catch (Exception)
					{
						StartInputNone();
						receipt.PaymentMethod = null;
						UpdatePaymentTypeList();
					}
					receipt.PaymentMethod = null;
				}
				else
				{
					if (inputValue.Length > 1)
					{
						inputValue = inputValue.Substring(0, inputValue.Length - 1);
						UpdateMonitor();
					}
					else
						StartInputNone();
				}
			}
			else if (e.IsEnter)
			{
				inputValue = inputValue.Replace(",","");
				if (inputValue != "")
				{
					int intValue;
					double doubleValue;
					// Set Value from string to int
					try
					{
						intValue = Int32.Parse(inputValue);
					}
					catch (Exception)
					{
						intValue = 0;
					}
					// Set Value from string to double
					try
					{
						doubleValue = Double.Parse(inputValue);
					}
					catch (Exception)
					{
						doubleValue = 0.0;
					}
					// Check for each case
					switch (inputState)
					{
						case INPUT_PAYVALUE:
							receipt.PayValue = doubleValue;
							receipt.SetPaymentMethod(receipt.PaymentMethod, receipt.PayValue);
							break;
						case INPUT_POINTAMOUNT:
							receipt.PointAmount = intValue;
							break;
					}
				}
				receipt.PaymentMethod = null;
				UpdatePaymentTypeList();
				StartInputNone();
				UpdateSummary();
			}
		}

		/// <summary>
		/// This method use when user click at PayValue field. (not use for now)
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldPayValue_Click(object sender, System.EventArgs e)
		{
			StartInputPayValue();
		}

		/// <summary>
		/// This method work when user click on PrintReceipt button. Thie method will
		/// send print receipt command and return user to TakeOrderForm or MainMenuForm if
		/// user come from TakeOrderForm or TakeOutForm by order.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnPrintReceipt_Click(object sender, System.EventArgs e)
		{
			OrderService.OrderService service = new OrderService.OrderService();
			WaitingForm.Show("Print Receipt");
			this.Enabled = false;
			string msg = service.SendOrderBill(selectedBill);
			if (msg != null)
			{
				this.Enabled = true;
				WaitingForm.HideForm();
				MessageBox.Show(this, msg);
				return;
			}
			bool result = receipt.SendInvoice(false, true);
			this.Enabled = true;
			WaitingForm.HideForm();

			if (result && orderInfo.TableID != 0)
				((MainForm)MdiParent).ShowTakeOrderForm((TableInformation)null);
			else
				((MainForm)MdiParent).ShowMainMenuForm();
		}

		/// <summary>
		/// This method work when user click on Pay button. Thie method will
		/// send receive value and print bill. After that, return user to TakeOrderForm
		/// or MainMenuForm if user come from TakeOrderForm or TakeOutForm by order.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnPay_Click(object sender, System.EventArgs e)
		{
			OrderService.OrderService service = new OrderService.OrderService();
			WaitingForm.Show("Print Bill");
			this.Enabled = false;
			string msg = service.SendOrderBill(selectedBill);
			if (msg != null)
			{
				this.Enabled = true;
				WaitingForm.HideForm();
				MessageBox.Show(this, msg);
				return;
			}
			bool result = receipt.SendInvoice(true, true);
			this.Enabled = true;
			WaitingForm.HideForm();

			if (result)
				((MainForm)MdiParent).ShowTakeOrderForm((TableInformation)null);
			else
				((MainForm)MdiParent).ShowMainMenuForm();
		}

		/// <summary>
		/// This method work when user click at Discount button and update value in
		/// <i>discountSelected</i>. After that, receipt compute new price.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void DiscountPad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			if (e.Value == null)
				return;
			Discount dis = Receipt.SearchDiscountByID(int.Parse(e.Value));
			if (discountSelected.Contains(e.Index))
			{
				// Deselect discount
				discountSelected.Remove(e.Index);
				receipt.UseDiscountRemove(dis);
			}
			else
			{
				// Select discount
				discountSelected.Add(e.Index);
				receipt.UseDiscountAdd(dis);
			}
			UpdateDiscountList();
			UpdateSummary();
		}

		/// <summary>
		/// This method work when user click change page for discount list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void DiscountPad_PageChange(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			UpdateDiscountList();
		}

		/// <summary>
		/// This method work when user click on PaymentType button list. This method will
		/// set input state to INPUT_PAYVALUE.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void PaymentTypePad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			if (e.Value == null)
				return;
			receipt.PaymentMethod = Receipt.SearchPaymentMethodByID(int.Parse(e.Value));
			int pos = receipt.PaymentMethodList.IndexOf(receipt.PaymentMethod);
			if (pos >= 0)
				receipt.PayValue = (double)receipt.PayValueList[pos];
			else
				receipt.PayValue = 0;
			StartInputPayValue();
			UpdatePaymentTypeList();
			UpdateSummary();
		}

		/// <summary>
		/// This method work when user change page in PaymentType button list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void PaymentTypePad_PageChange(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			UpdatePaymentTypeList();
		}

		/// <summary>
		/// After user select payment method and click FillPay button, This method will work
		/// and compute price that customer should pay in selected payment method.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnFillPay_Click(object sender, System.EventArgs e)
		{
			double oldValue;
			try
			{
				int pos = receipt.PaymentMethodList.IndexOf(receipt.PaymentMethod);
				oldValue = (double)receipt.PayValueList[pos];
			}
			catch (Exception)
			{
				oldValue = 0;
			}
			receipt.PayValue = receipt.TotalDue - receipt.TotalReceive + oldValue;
			receipt.SetPaymentMethod(receipt.PaymentMethod, receipt.PayValue);
			receipt.PaymentMethod = null;
			StartInputNone();
			UpdatePaymentTypeList();
			UpdateSummary();
		}

		/// <summary>
		/// After user select payment method and click PayClear Button, this method will
		/// clear pay value to 0 (zero) and set this selected payment method.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnPayClear_Click(object sender, System.EventArgs e)
		{
			receipt.PayValue = 0;
			receipt.SetPaymentMethod(receipt.PaymentMethod, receipt.PayValue);
			receipt.PaymentMethod = null;
			StartInputNone();
			UpdatePaymentTypeList();
			UpdateSummary();
		}

		/// <summary>
		/// After user click PayClearAll button, this method will clear all payment method
		/// to 0 (zero).
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnPayClearAll_Click(object sender, System.EventArgs e)
		{
			receipt.SetPaymentMethod(null, 0);
			receipt.PaymentMethod = null;
			StartInputNone();
			UpdatePaymentTypeList();
			UpdateSummary();
		}
	}
}
