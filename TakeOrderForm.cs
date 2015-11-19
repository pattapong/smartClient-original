using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Controls;
using smartRestaurant.Data;
using smartRestaurant.Utils;
using smartRestaurant.MenuService;
using smartRestaurant.OrderService;
using smartRestaurant.TableService;

namespace smartRestaurant
{
	/// <summary>
	/// Summary description for TakeOrderForm.
	/// </summary>
	public class TakeOrderForm : SmartForm
	{
		/* Input State Value */
		private const int INPUT_MENU		= 0;
		private const int INPUT_UNIT		= 1;
		private const int INPUT_OPTION		= 2;
		private const int INPUT_GUEST		= 10;
		private const int INPUT_BILL		= 11;
		private const int INPUT_MOVEITEM	= 20;

		private static string FIELD_CUST_TEXT = "- Please input name -";

		private smartRestaurant.Controls.GroupPanel OrderPanel;
		private System.Windows.Forms.Label FieldBill;
		private System.Windows.Forms.Label LblBill;
		private System.Windows.Forms.Label FieldGuest;
		private System.Windows.Forms.Label LblGuest;
		private System.Windows.Forms.Label FieldTable;
		private System.Windows.Forms.Label LblTable;
		private System.Windows.Forms.ImageList ButtonImgList;
		private smartRestaurant.Controls.ImageButton BtnMain;
		private System.Windows.Forms.ImageList NumberImgList;
		private smartRestaurant.Controls.ImageButton BtnCancel;
		private smartRestaurant.Controls.ImageButton BtnUndo;
		private smartRestaurant.Controls.ImageButton BtnMessage;
		private smartRestaurant.Controls.ImageButton BtnPrintKitchen;
		private smartRestaurant.Controls.GroupPanel groupPanel2;
		private smartRestaurant.Controls.GroupPanel groupPanel3;
		private smartRestaurant.Controls.ButtonListPad CategoryPad;
		private smartRestaurant.Controls.ButtonListPad OptionPad;
		private System.ComponentModel.IContainer components;
		private smartRestaurant.Controls.NumberPad NumberKeyPad;
		private System.Windows.Forms.Label FieldInputType;
		private System.Windows.Forms.Label FieldCurrentInput;
		private smartRestaurant.Controls.ImageButton BtnDown;
		private smartRestaurant.Controls.ImageButton BtnUp;
		private smartRestaurant.Controls.ItemsList ListOrderItem;
		private smartRestaurant.Controls.ImageButton BtnPrintReceiptAll;
		private smartRestaurant.Controls.ImageButton BtnPrintReceipt;
		private smartRestaurant.Controls.ImageButton BtnMoveItem;
		private smartRestaurant.Controls.ImageButton BtnSearch;
		private System.Windows.Forms.Label FieldCustName;
		private smartRestaurant.Controls.GroupPanel PanCustName;
		private smartRestaurant.Controls.ImageButton BtnServeItem;
		private smartRestaurant.Controls.ItemsList ListOrderItemBy;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label LblPageID;

		private int		inputState;
		private string	inputValue;
		private int		guestNumber, billNumber;
		private int		employeeID;
		private bool	isChanged;
		private bool	moveItem;

		// Take Out Mode
		private int		takeOutOrderID;
		private bool	takeOutMode;
		private bool	takeOrderResume;

		private TableInformation	tableInfo;
		private int[]				tableIDList;
		private MenuOption[]		menuOptions;
		private MenuType[]			menuTypes;
		private MenuType			selectedType;
		private OrderInformation	orderInfo;
		private OrderBill			selectedBill;
		private smartRestaurant.Controls.ImageButton BtnAmount;
		private smartRestaurant.Controls.ItemsList ListOrderCount;
		private OrderBillItem		selectedItem;

		public TakeOrderForm() : base()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			employeeID = 1;
			takeOutMode = false;
			LoadMenus();
			SetCategory();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TakeOrderForm));
			this.OrderPanel = new smartRestaurant.Controls.GroupPanel();
			this.FieldBill = new System.Windows.Forms.Label();
			this.LblBill = new System.Windows.Forms.Label();
			this.FieldGuest = new System.Windows.Forms.Label();
			this.LblGuest = new System.Windows.Forms.Label();
			this.FieldTable = new System.Windows.Forms.Label();
			this.LblTable = new System.Windows.Forms.Label();
			this.BtnMain = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnCancel = new smartRestaurant.Controls.ImageButton();
			this.BtnUndo = new smartRestaurant.Controls.ImageButton();
			this.BtnMessage = new smartRestaurant.Controls.ImageButton();
			this.BtnPrintKitchen = new smartRestaurant.Controls.ImageButton();
			this.BtnPrintReceiptAll = new smartRestaurant.Controls.ImageButton();
			this.BtnPrintReceipt = new smartRestaurant.Controls.ImageButton();
			this.groupPanel2 = new smartRestaurant.Controls.GroupPanel();
			this.BtnAmount = new smartRestaurant.Controls.ImageButton();
			this.FieldCurrentInput = new System.Windows.Forms.Label();
			this.FieldInputType = new System.Windows.Forms.Label();
			this.NumberKeyPad = new smartRestaurant.Controls.NumberPad();
			this.CategoryPad = new smartRestaurant.Controls.ButtonListPad();
			this.groupPanel3 = new smartRestaurant.Controls.GroupPanel();
			this.OptionPad = new smartRestaurant.Controls.ButtonListPad();
			this.ListOrderItem = new smartRestaurant.Controls.ItemsList();
			this.ListOrderCount = new smartRestaurant.Controls.ItemsList();
			this.ListOrderItemBy = new smartRestaurant.Controls.ItemsList();
			this.BtnDown = new smartRestaurant.Controls.ImageButton();
			this.BtnUp = new smartRestaurant.Controls.ImageButton();
			this.BtnMoveItem = new smartRestaurant.Controls.ImageButton();
			this.PanCustName = new smartRestaurant.Controls.GroupPanel();
			this.FieldCustName = new System.Windows.Forms.Label();
			this.BtnSearch = new smartRestaurant.Controls.ImageButton();
			this.BtnServeItem = new smartRestaurant.Controls.ImageButton();
			this.LblPageID = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.OrderPanel.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			this.groupPanel3.SuspendLayout();
			this.PanCustName.SuspendLayout();
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
			this.OrderPanel.ShowHeader = true;
			this.OrderPanel.Size = new System.Drawing.Size(449, 58);
			this.OrderPanel.TabIndex = 1;
			// 
			// FieldBill
			// 
			this.FieldBill.BackColor = System.Drawing.Color.White;
			this.FieldBill.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldBill.Location = new System.Drawing.Point(384, 1);
			this.FieldBill.Name = "FieldBill";
			this.FieldBill.Size = new System.Drawing.Size(64, 56);
			this.FieldBill.TabIndex = 11;
			this.FieldBill.Text = "1";
			this.FieldBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.FieldBill.Click += new System.EventHandler(this.FieldBill_Click);
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
			this.FieldGuest.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldGuest.Location = new System.Drawing.Point(248, 1);
			this.FieldGuest.Name = "FieldGuest";
			this.FieldGuest.Size = new System.Drawing.Size(64, 56);
			this.FieldGuest.TabIndex = 9;
			this.FieldGuest.Text = "1";
			this.FieldGuest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.FieldGuest.Click += new System.EventHandler(this.FieldGuest_Click);
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
			this.FieldTable.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldTable.Location = new System.Drawing.Point(73, 1);
			this.FieldTable.Name = "FieldTable";
			this.FieldTable.Size = new System.Drawing.Size(103, 56);
			this.FieldTable.TabIndex = 7;
			this.FieldTable.Text = "1";
			this.FieldTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.FieldTable.Click += new System.EventHandler(this.FieldTable_Click);
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
			// BtnMain
			// 
			this.BtnMain.BackColor = System.Drawing.Color.Transparent;
			this.BtnMain.Blue = 2F;
			this.BtnMain.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnMain.Green = 2F;
			this.BtnMain.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnMain.Image")));
			this.BtnMain.ImageClick = null;
			this.BtnMain.ImageClickIndex = 0;
			this.BtnMain.ImageIndex = 0;
			this.BtnMain.ImageList = this.ButtonImgList;
			this.BtnMain.Location = new System.Drawing.Point(456, 64);
			this.BtnMain.Name = "BtnMain";
			this.BtnMain.ObjectValue = null;
			this.BtnMain.Red = 1F;
			this.BtnMain.Size = new System.Drawing.Size(110, 60);
			this.BtnMain.TabIndex = 2;
			this.BtnMain.Text = "Main";
			this.BtnMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnMain.Click += new System.EventHandler(this.BtnMain_Click);
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
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
			this.BtnCancel.TabIndex = 8;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
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
			this.BtnUndo.TabIndex = 9;
			this.BtnUndo.Text = "Undo";
			this.BtnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
			// 
			// BtnMessage
			// 
			this.BtnMessage.BackColor = System.Drawing.Color.Transparent;
			this.BtnMessage.Blue = 1F;
			this.BtnMessage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnMessage.Green = 1.75F;
			this.BtnMessage.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnMessage.Image")));
			this.BtnMessage.ImageClick = null;
			this.BtnMessage.ImageClickIndex = 0;
			this.BtnMessage.ImageIndex = 0;
			this.BtnMessage.ImageList = this.ButtonImgList;
			this.BtnMessage.Location = new System.Drawing.Point(568, 64);
			this.BtnMessage.Name = "BtnMessage";
			this.BtnMessage.ObjectValue = null;
			this.BtnMessage.Red = 1.75F;
			this.BtnMessage.Size = new System.Drawing.Size(110, 60);
			this.BtnMessage.TabIndex = 10;
			this.BtnMessage.Text = "Message";
			this.BtnMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnMessage.Click += new System.EventHandler(this.BtnMessage_Click);
			// 
			// BtnPrintKitchen
			// 
			this.BtnPrintKitchen.BackColor = System.Drawing.Color.Transparent;
			this.BtnPrintKitchen.Blue = 0.75F;
			this.BtnPrintKitchen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPrintKitchen.Green = 1F;
			this.BtnPrintKitchen.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPrintKitchen.Image")));
			this.BtnPrintKitchen.ImageClick = null;
			this.BtnPrintKitchen.ImageClickIndex = 0;
			this.BtnPrintKitchen.ImageIndex = 0;
			this.BtnPrintKitchen.ImageList = this.ButtonImgList;
			this.BtnPrintKitchen.Location = new System.Drawing.Point(680, 64);
			this.BtnPrintKitchen.Name = "BtnPrintKitchen";
			this.BtnPrintKitchen.ObjectValue = null;
			this.BtnPrintKitchen.Red = 1F;
			this.BtnPrintKitchen.Size = new System.Drawing.Size(110, 60);
			this.BtnPrintKitchen.TabIndex = 11;
			this.BtnPrintKitchen.Text = "Print-Kitchen / Save";
			this.BtnPrintKitchen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPrintKitchen.Click += new System.EventHandler(this.BtnPrintKitchen_Click);
			// 
			// BtnPrintReceiptAll
			// 
			this.BtnPrintReceiptAll.BackColor = System.Drawing.Color.Transparent;
			this.BtnPrintReceiptAll.Blue = 1.75F;
			this.BtnPrintReceiptAll.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPrintReceiptAll.Green = 1F;
			this.BtnPrintReceiptAll.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPrintReceiptAll.Image")));
			this.BtnPrintReceiptAll.ImageClick = null;
			this.BtnPrintReceiptAll.ImageClickIndex = 0;
			this.BtnPrintReceiptAll.ImageIndex = 0;
			this.BtnPrintReceiptAll.ImageList = this.ButtonImgList;
			this.BtnPrintReceiptAll.Location = new System.Drawing.Point(792, 64);
			this.BtnPrintReceiptAll.Name = "BtnPrintReceiptAll";
			this.BtnPrintReceiptAll.ObjectValue = null;
			this.BtnPrintReceiptAll.Red = 1.75F;
			this.BtnPrintReceiptAll.Size = new System.Drawing.Size(110, 60);
			this.BtnPrintReceiptAll.TabIndex = 12;
			this.BtnPrintReceiptAll.Text = "Print-Receipt All";
			this.BtnPrintReceiptAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPrintReceiptAll.Click += new System.EventHandler(this.BtnPrintReceiptAll_Click);
			// 
			// BtnPrintReceipt
			// 
			this.BtnPrintReceipt.BackColor = System.Drawing.Color.Transparent;
			this.BtnPrintReceipt.Blue = 1F;
			this.BtnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPrintReceipt.Green = 1F;
			this.BtnPrintReceipt.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPrintReceipt.Image")));
			this.BtnPrintReceipt.ImageClick = null;
			this.BtnPrintReceipt.ImageClickIndex = 0;
			this.BtnPrintReceipt.ImageIndex = 0;
			this.BtnPrintReceipt.ImageList = this.ButtonImgList;
			this.BtnPrintReceipt.Location = new System.Drawing.Point(904, 64);
			this.BtnPrintReceipt.Name = "BtnPrintReceipt";
			this.BtnPrintReceipt.ObjectValue = null;
			this.BtnPrintReceipt.Red = 0.75F;
			this.BtnPrintReceipt.Size = new System.Drawing.Size(110, 60);
			this.BtnPrintReceipt.TabIndex = 13;
			this.BtnPrintReceipt.Text = "Pay";
			this.BtnPrintReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPrintReceipt.Click += new System.EventHandler(this.BtnPrintReceipt_Click);
			// 
			// groupPanel2
			// 
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.Caption = null;
			this.groupPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.BtnAmount,
																					  this.FieldCurrentInput,
																					  this.FieldInputType,
																					  this.NumberKeyPad,
																					  this.CategoryPad});
			this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel2.Location = new System.Drawing.Point(328, 128);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.ShowHeader = false;
			this.groupPanel2.Size = new System.Drawing.Size(344, 624);
			this.groupPanel2.TabIndex = 15;
			// 
			// BtnAmount
			// 
			this.BtnAmount.BackColor = System.Drawing.Color.Transparent;
			this.BtnAmount.Blue = 1F;
			this.BtnAmount.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnAmount.Green = 1F;
			this.BtnAmount.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnAmount.Image")));
			this.BtnAmount.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnAmount.ImageClick")));
			this.BtnAmount.ImageClickIndex = 1;
			this.BtnAmount.ImageIndex = 0;
			this.BtnAmount.ImageList = this.NumberImgList;
			this.BtnAmount.Location = new System.Drawing.Point(256, 555);
			this.BtnAmount.Name = "BtnAmount";
			this.BtnAmount.ObjectValue = null;
			this.BtnAmount.Red = 2F;
			this.BtnAmount.Size = new System.Drawing.Size(72, 60);
			this.BtnAmount.TabIndex = 20;
			this.BtnAmount.Text = "Amount";
			this.BtnAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnAmount.Click += new System.EventHandler(this.BtnAmount_Click);
			this.BtnAmount.DoubleClick += new System.EventHandler(this.BtnAmount_Click);
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
			this.FieldInputType.Text = "Menu";
			this.FieldInputType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NumberKeyPad
			// 
			this.NumberKeyPad.BackColor = System.Drawing.Color.White;
			this.NumberKeyPad.Image = ((System.Drawing.Bitmap)(resources.GetObject("NumberKeyPad.Image")));
			this.NumberKeyPad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("NumberKeyPad.ImageClick")));
			this.NumberKeyPad.ImageClickIndex = 1;
			this.NumberKeyPad.ImageIndex = 0;
			this.NumberKeyPad.ImageList = this.NumberImgList;
			this.NumberKeyPad.Location = new System.Drawing.Point(24, 360);
			this.NumberKeyPad.Name = "NumberKeyPad";
			this.NumberKeyPad.Size = new System.Drawing.Size(226, 255);
			this.NumberKeyPad.TabIndex = 7;
			this.NumberKeyPad.Text = "numberPad1";
			this.NumberKeyPad.PadClick += new smartRestaurant.Controls.NumberPadEventHandler(this.NumberKeyPad_PadClick);
			// 
			// CategoryPad
			// 
			this.CategoryPad.AutoRefresh = true;
			this.CategoryPad.BackColor = System.Drawing.Color.White;
			this.CategoryPad.Blue = 1F;
			this.CategoryPad.Column = 3;
			this.CategoryPad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.CategoryPad.Green = 1F;
			this.CategoryPad.Image = ((System.Drawing.Bitmap)(resources.GetObject("CategoryPad.Image")));
			this.CategoryPad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("CategoryPad.ImageClick")));
			this.CategoryPad.ImageClickIndex = 1;
			this.CategoryPad.ImageIndex = 0;
			this.CategoryPad.ImageList = this.ButtonImgList;
			this.CategoryPad.Location = new System.Drawing.Point(5, 5);
			this.CategoryPad.Name = "CategoryPad";
			this.CategoryPad.Padding = 1;
			this.CategoryPad.Red = 1F;
			this.CategoryPad.Row = 5;
			this.CategoryPad.Size = new System.Drawing.Size(332, 304);
			this.CategoryPad.TabIndex = 6;
			this.CategoryPad.Text = "buttonListPad2";
			this.CategoryPad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.CategoryPad_PadClick);
			// 
			// groupPanel3
			// 
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.Caption = null;
			this.groupPanel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.OptionPad});
			this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel3.Location = new System.Drawing.Point(672, 128);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.ShowHeader = false;
			this.groupPanel3.Size = new System.Drawing.Size(344, 624);
			this.groupPanel3.TabIndex = 16;
			// 
			// OptionPad
			// 
			this.OptionPad.AutoRefresh = true;
			this.OptionPad.BackColor = System.Drawing.Color.White;
			this.OptionPad.Blue = 1F;
			this.OptionPad.Column = 3;
			this.OptionPad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.OptionPad.Green = 1F;
			this.OptionPad.Image = ((System.Drawing.Bitmap)(resources.GetObject("OptionPad.Image")));
			this.OptionPad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("OptionPad.ImageClick")));
			this.OptionPad.ImageClickIndex = 1;
			this.OptionPad.ImageIndex = 0;
			this.OptionPad.ImageList = this.ButtonImgList;
			this.OptionPad.Location = new System.Drawing.Point(5, 5);
			this.OptionPad.Name = "OptionPad";
			this.OptionPad.Padding = 1;
			this.OptionPad.Red = 1F;
			this.OptionPad.Row = 10;
			this.OptionPad.Size = new System.Drawing.Size(332, 609);
			this.OptionPad.TabIndex = 5;
			this.OptionPad.Text = "buttonListPad1";
			this.OptionPad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.OptionPad_PadClick);
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
			this.ListOrderItem.ItemWidth = 240;
			this.ListOrderItem.Location = new System.Drawing.Point(8, 128);
			this.ListOrderItem.Name = "ListOrderItem";
			this.ListOrderItem.Row = 14;
			this.ListOrderItem.SelectedIndex = 0;
			this.ListOrderItem.Size = new System.Drawing.Size(240, 560);
			this.ListOrderItem.TabIndex = 17;
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
			this.ListOrderCount.BindList2 = this.ListOrderItemBy;
			this.ListOrderCount.Border = 0;
			this.ListOrderCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListOrderCount.ForeAlterColor = System.Drawing.Color.Black;
			this.ListOrderCount.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListOrderCount.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListOrderCount.ForeNormalColor = System.Drawing.Color.Black;
			this.ListOrderCount.ForeSelectedColor = System.Drawing.Color.White;
			this.ListOrderCount.ItemHeight = 40;
			this.ListOrderCount.ItemWidth = 40;
			this.ListOrderCount.Location = new System.Drawing.Point(248, 128);
			this.ListOrderCount.Name = "ListOrderCount";
			this.ListOrderCount.Row = 14;
			this.ListOrderCount.SelectedIndex = 0;
			this.ListOrderCount.Size = new System.Drawing.Size(40, 560);
			this.ListOrderCount.TabIndex = 36;
			this.ListOrderCount.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListOrderItem_ItemClick);
			// 
			// ListOrderItemBy
			// 
			this.ListOrderItemBy.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.ListOrderItemBy.AutoRefresh = true;
			this.ListOrderItemBy.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListOrderItemBy.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListOrderItemBy.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListOrderItemBy.BackNormalColor = System.Drawing.Color.White;
			this.ListOrderItemBy.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListOrderItemBy.BindList1 = this.ListOrderCount;
			this.ListOrderItemBy.BindList2 = null;
			this.ListOrderItemBy.Border = 0;
			this.ListOrderItemBy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListOrderItemBy.ForeAlterColor = System.Drawing.Color.Black;
			this.ListOrderItemBy.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListOrderItemBy.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListOrderItemBy.ForeNormalColor = System.Drawing.Color.Black;
			this.ListOrderItemBy.ForeSelectedColor = System.Drawing.Color.White;
			this.ListOrderItemBy.ItemHeight = 40;
			this.ListOrderItemBy.ItemWidth = 40;
			this.ListOrderItemBy.Location = new System.Drawing.Point(288, 128);
			this.ListOrderItemBy.Name = "ListOrderItemBy";
			this.ListOrderItemBy.Row = 14;
			this.ListOrderItemBy.SelectedIndex = 0;
			this.ListOrderItemBy.Size = new System.Drawing.Size(40, 560);
			this.ListOrderItemBy.TabIndex = 34;
			this.ListOrderItemBy.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListOrderItem_ItemClick);
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
			this.BtnDown.TabIndex = 19;
			this.BtnDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
			this.BtnDown.DoubleClick += new System.EventHandler(this.BtnDown_Click);
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
			this.BtnUp.TabIndex = 18;
			this.BtnUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
			this.BtnUp.DoubleClick += new System.EventHandler(this.BtnUp_Click);
			// 
			// BtnMoveItem
			// 
			this.BtnMoveItem.BackColor = System.Drawing.Color.Transparent;
			this.BtnMoveItem.Blue = 2F;
			this.BtnMoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnMoveItem.Green = 1F;
			this.BtnMoveItem.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnMoveItem.Image")));
			this.BtnMoveItem.ImageClick = null;
			this.BtnMoveItem.ImageClickIndex = 0;
			this.BtnMoveItem.ImageIndex = 0;
			this.BtnMoveItem.ImageList = this.ButtonImgList;
			this.BtnMoveItem.Location = new System.Drawing.Point(232, 64);
			this.BtnMoveItem.Name = "BtnMoveItem";
			this.BtnMoveItem.ObjectValue = null;
			this.BtnMoveItem.Red = 2F;
			this.BtnMoveItem.Size = new System.Drawing.Size(110, 60);
			this.BtnMoveItem.TabIndex = 20;
			this.BtnMoveItem.Text = "Move Item";
			this.BtnMoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnMoveItem.Click += new System.EventHandler(this.BtnMoveItem_Click);
			// 
			// PanCustName
			// 
			this.PanCustName.BackColor = System.Drawing.Color.Transparent;
			this.PanCustName.Caption = null;
			this.PanCustName.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.FieldCustName});
			this.PanCustName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.PanCustName.Location = new System.Drawing.Point(248, 0);
			this.PanCustName.Name = "PanCustName";
			this.PanCustName.ShowHeader = false;
			this.PanCustName.Size = new System.Drawing.Size(200, 58);
			this.PanCustName.TabIndex = 22;
			// 
			// FieldCustName
			// 
			this.FieldCustName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldCustName.Location = new System.Drawing.Point(1, 1);
			this.FieldCustName.Name = "FieldCustName";
			this.FieldCustName.Size = new System.Drawing.Size(199, 56);
			this.FieldCustName.TabIndex = 0;
			this.FieldCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldCustName.Click += new System.EventHandler(this.FieldCustName_Click);
			// 
			// BtnSearch
			// 
			this.BtnSearch.BackColor = System.Drawing.Color.Transparent;
			this.BtnSearch.Blue = 0.5F;
			this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSearch.Green = 1F;
			this.BtnSearch.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnSearch.Image")));
			this.BtnSearch.ImageClick = null;
			this.BtnSearch.ImageClickIndex = 0;
			this.BtnSearch.ImageIndex = 0;
			this.BtnSearch.ImageList = this.ButtonImgList;
			this.BtnSearch.Location = new System.Drawing.Point(449, 0);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.ObjectValue = null;
			this.BtnSearch.Red = 1F;
			this.BtnSearch.Size = new System.Drawing.Size(110, 60);
			this.BtnSearch.TabIndex = 23;
			this.BtnSearch.Text = "Search";
			this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// BtnServeItem
			// 
			this.BtnServeItem.BackColor = System.Drawing.Color.Transparent;
			this.BtnServeItem.Blue = 2F;
			this.BtnServeItem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnServeItem.Green = 1F;
			this.BtnServeItem.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnServeItem.Image")));
			this.BtnServeItem.ImageClick = null;
			this.BtnServeItem.ImageClickIndex = 0;
			this.BtnServeItem.ImageIndex = 0;
			this.BtnServeItem.ImageList = this.ButtonImgList;
			this.BtnServeItem.Location = new System.Drawing.Point(344, 64);
			this.BtnServeItem.Name = "BtnServeItem";
			this.BtnServeItem.ObjectValue = null;
			this.BtnServeItem.Red = 2F;
			this.BtnServeItem.Size = new System.Drawing.Size(110, 60);
			this.BtnServeItem.TabIndex = 24;
			this.BtnServeItem.Text = "Serve Item";
			this.BtnServeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnServeItem.Click += new System.EventHandler(this.BtnServeItem_Click);
			// 
			// LblPageID
			// 
			this.LblPageID.BackColor = System.Drawing.Color.Transparent;
			this.LblPageID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblPageID.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblPageID.Location = new System.Drawing.Point(816, 752);
			this.LblPageID.Name = "LblPageID";
			this.LblPageID.Size = new System.Drawing.Size(192, 23);
			this.LblPageID.TabIndex = 33;
			this.LblPageID.Text = "| STTO011";
			this.LblPageID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.label1.Location = new System.Drawing.Point(8, 752);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 16);
			this.label1.TabIndex = 35;
			this.label1.Text = "Copyright (c) 2004. All rights reserved.";
			// 
			// TakeOrderForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ListOrderCount,
																		  this.label1,
																		  this.LblPageID,
																		  this.BtnServeItem,
																		  this.BtnSearch,
																		  this.PanCustName,
																		  this.BtnMoveItem,
																		  this.BtnDown,
																		  this.BtnUp,
																		  this.ListOrderItem,
																		  this.groupPanel3,
																		  this.groupPanel2,
																		  this.BtnPrintReceipt,
																		  this.BtnPrintReceiptAll,
																		  this.BtnPrintKitchen,
																		  this.BtnMessage,
																		  this.BtnUndo,
																		  this.BtnCancel,
																		  this.BtnMain,
																		  this.OrderPanel,
																		  this.ListOrderItemBy});
			this.Name = "TakeOrderForm";
			this.Text = "Take Order";
			this.OrderPanel.ResumeLayout(false);
			this.groupPanel2.ResumeLayout(false);
			this.groupPanel3.ResumeLayout(false);
			this.PanCustName.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Main button click and back to main page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnMain_Click(object sender, System.EventArgs e)
		{
			((MainForm)MdiParent).ShowMainMenuForm();
		}

		private void LoadMenus()
		{
			MenuManagement.LoadMenus();
			menuTypes = MenuManagement.MenuTypes;
			menuOptions = MenuManagement.MenuOptions;
		}

		#region Set variable to prepare each step.
		/// <summary>
		/// Method to clear variable and prepare for next menu entry.
		/// </summary>
		private void StartInputMenu()
		{
			inputState = INPUT_MENU;
			inputValue = "";
			selectedItem = null;
			selectedType = null;
			moveItem = false;
			CategoryPad.AutoRefresh = false;
			CategoryPad.ItemStart = 0;
			CategoryPad.AutoRefresh = true;
			UpdateOrderGrid();
			UpdateMonitor();
			OptionPad.AutoRefresh = false;
			OptionPad.Items.Clear();
			OptionPad.ItemStart = 0;
			OptionPad.Red = 1;
			OptionPad.Green = 1;
			OptionPad.Blue = 1;
			OptionPad.AutoRefresh = true;
		}

		/// <summary>
		/// Method to set variable to prepare for input amount of menu item.
		/// </summary>
		private void StartInputUnit()
		{
			inputState = INPUT_UNIT;
			inputValue = "";
			selectedType = null;
			moveItem = false;
			CategoryPad.AutoRefresh = false;
			CategoryPad.ItemStart = 0;
			CategoryPad.AutoRefresh = true;
			UpdateOrderGrid();
			UpdateMonitor();
			OptionPad.AutoRefresh = false;
			OptionPad.Items.Clear();
			OptionPad.ItemStart = 0;
			OptionPad.Red = 1;
			OptionPad.Green = 1;
			OptionPad.Blue = 1;
			OptionPad.AutoRefresh = true;
		}

		/// <summary>
		/// Method to set variable and screen to show menu option.
		/// </summary>
		private void StartInputOption()
		{
			// Get Menu object and check for exist.
			MenuService.MenuItem menu = MenuManagement.GetMenuItemFromID(selectedItem.MenuID);
			if (menu == null)
			{
				StartInputMenu();
				return;
			}
			// Set variable to prepare for input option state.
			inputState = INPUT_OPTION;
			inputValue = "";
			selectedType = null;
			moveItem = false;
			CategoryPad.AutoRefresh = false;
			CategoryPad.ItemStart = 0;
			CategoryPad.AutoRefresh = true;
			UpdateOrderGrid();
			UpdateMonitor();
			// Load Option to panel
			OptionPad.AutoRefresh = false;
			OptionPad.Items.Clear();
			OptionPad.ItemStart = 0;
			OptionPad.Red = 1;
			OptionPad.Green = 1;
			OptionPad.Blue = 1;
			if (menuOptions != null)
			{
				// Loop for all Menu Option
				for (int i = 0;i < menuOptions.Length;i++)
				{
					int len = 0;
					if (selectedItem.DefaultOption)
					{
						if (menu.MenuDefaults != null)
							len = menu.MenuDefaults.Length;
					}
					else
					{
						if (selectedItem.ItemChoices != null)
							len = selectedItem.ItemChoices.Length;
					}
					// Loop for Menu Item Default/Selected Option
					for (int j = 0;j < len;j++)
					{
						int choiceID;
						if (selectedItem.DefaultOption)
							choiceID = menu.MenuDefaults[j].OptionID;
						else
							choiceID = selectedItem.ItemChoices[j].OptionID;
						// In case of Menu Option is use in Menu Item
						if (menuOptions[i].OptionID == choiceID)
						{
							// Loop and set Menu Option Choice to button pad
							for (int k = 0;k < menuOptions[i].OptionChoices.Length;k++)
							{
								ButtonItem btn = new ButtonItem(menuOptions[i].OptionChoices[k].ChoiceName, 
									menuOptions[i].OptionChoices[k].OptionID.ToString()+":"+menuOptions[i].OptionChoices[k].ChoiceID.ToString());
								if ((j % 2) == 0)
									btn.ForeColor = Color.Red;
								else
									btn.ForeColor = Color.Blue;
								OptionPad.Items.Add(btn);
								if (selectedItem.DefaultOption)
								{
									if (menuOptions[i].OptionChoices[k].ChoiceID == menu.MenuDefaults[j].DefaultChoiceID)
										OptionPad.SetMatrix(OptionPad.Items.Count - 1, 2, 1, 2);
								}
								else
								{
									if (selectedItem.ItemChoices != null &&
										menuOptions[i].OptionChoices[k].ChoiceID == selectedItem.ItemChoices[j].ChoiceID)
										OptionPad.SetMatrix(OptionPad.Items.Count - 1, 2, 1, 2);
								}
							}
						}
					}
				}
			}
			OptionPad.AutoRefresh = true;
		}

		/// <summary>
		/// Method to clear variable and prepare for move item.
		/// </summary>
		private void StartMoveItem()
		{
			inputState = INPUT_MOVEITEM;
			inputValue = "-> Select Seat";
			selectedType = null;
			moveItem = true;
			CategoryPad.AutoRefresh = false;
			CategoryPad.ItemStart = 0;
			CategoryPad.AutoRefresh = true;
			UpdateOrderGrid();
			UpdateMonitor();
			OptionPad.AutoRefresh = false;
			OptionPad.Items.Clear();
			OptionPad.ItemStart = 0;
			OptionPad.Red = 1;
			OptionPad.Green = 1;
			OptionPad.Blue = 1;
			OptionPad.AutoRefresh = true;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Set Table object
		/// </summary>
		public TableInformation Table
		{
			set
			{
				if (value != null)
				{
					tableInfo = value;
					guestNumber = value.NumberOfSeat;
					billNumber = value.NumberOfSeat;
				}
			}
		}

		/// <summary>
		/// Order ID for load in reverse mode
		/// </summary>
		public int OrderID
		{
			set
			{
				takeOutOrderID = value;
			}
		}

		/// <summary>
		/// Set customer full name from take out list form
		/// </summary>
		public string CustomerName
		{
			set
			{
				FieldCustName.Text = value;
			}
		}

		public bool TakeOrderResume
		{
			set
			{
				takeOrderResume = value;
			}
		}

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
		/// Initialize category pad
		/// </summary>
		private void SetCategory()
		{
			CategoryPad.AutoRefresh = false;
			CategoryPad.SetMatrix(0, 1, 1, 1);
			CategoryPad.SetMatrix(1, 2, 1, 1);
			CategoryPad.SetMatrix(2, 1, 2, 1);
			CategoryPad.SetMatrix(3, 1, 1, 2);
			CategoryPad.SetMatrix(4, 2, 2, 1);
			CategoryPad.SetMatrix(5, 2, 1, 2);
			CategoryPad.SetMatrix(6, 1, 2, 2);
			CategoryPad.SetMatrix(7, 1.75f, 1, 1);
			CategoryPad.SetMatrix(8, 1, 1.75f, 1);
			CategoryPad.SetMatrix(9, 1, 1, 1.75f);
			CategoryPad.SetMatrix(10, 1.75f, 1.75f, 1);
			CategoryPad.SetMatrix(11, 1.75f, 1, 1.75f);
			CategoryPad.SetMatrix(12, 1, 1.75f, 1.75f);
			CategoryPad.SetMatrix(13, .75f, 1, 1);
			CategoryPad.SetMatrix(14, 1, 1, 1);

			for (int i = 0;i < menuTypes.Length;i++)
				CategoryPad.Items.Add(new ButtonItem(menuTypes[i].Name, i.ToString()));
			CategoryPad.AutoRefresh = true;
		}

		/// <summary>
		/// Initial form when start take order.
		/// (Call this method from outside)
		/// </summary>
		public override void UpdateForm()
		{
			LoadMenus();
			// Check for reserve mode
			takeOutMode = (tableInfo.TableID == 0);
			OrderService.OrderService service = new OrderService.OrderService();
			if (!takeOrderResume)
			{
				// Load old table order information (Web Services)
				if (!takeOutMode)
				{
					orderInfo = service.GetOrder(tableInfo.TableID);
					if (orderInfo != null)
					{
						if (tableInfo.TableID != orderInfo.TableID)
						{
							TableService.TableService tabService = new TableService.TableService();
							tableInfo = tabService.GetTableInformation(orderInfo.TableID);
						}
						tableIDList = service.GetTableReference(orderInfo.OrderID);
					}
					else
						tableIDList = null;
				}
				else if (takeOutOrderID > 0)
				{
					orderInfo = service.GetOrderByOrderID(takeOutOrderID);
					tableIDList = null;
				}
				else
				{
					orderInfo = null;
					tableIDList = null;
				}
				// Reset input
				isChanged = false;
			}
			else
			{
				if (!takeOutMode)
					orderInfo = service.GetOrder(tableInfo.TableID);
			}
			// Check exist order information
			if (orderInfo != null)
			{
				// Found (Edit order)
				guestNumber = orderInfo.NumberOfGuest;
				billNumber = orderInfo.Bills.Length;
			}
			else if (guestNumber <= 0)
			{
				// Not found (New order)
				guestNumber = billNumber = 1;
			}
			// Check Demo version
			if (AppParameter.IsDemo())
			{
				ListOrderItem.ItemWidth = 240;
				ListOrderCount.Left = 248;
				ListOrderItemBy.Visible = true;
				LblGuest.Text = "Guest";
			}
			else
			{
				ListOrderItem.ItemWidth = 280;
				ListOrderCount.Left = 288;
				ListOrderItemBy.Visible = false;
				LblGuest.Text = "Seat";
			}
			ListOrderCount.Left = ListOrderItem.Left + ListOrderItem.ItemWidth;
			// Clear Input
			selectedBill = null;
			selectedItem = null;
			selectedType = null;
			if (orderInfo != null && orderInfo.Bills != null)
			{
				for (int i = 0;i < orderInfo.Bills.Length;i++)
					if (orderInfo.Bills[i].CloseBillDate == DateTime.MinValue)
					{
						selectedBill = orderInfo.Bills[i];
						break;
					}
			}
			// Update screen
			LblPageID.Text = "Employee ID:" + ((MainForm)MdiParent).UserID + " | ";
			if (takeOutMode)
				LblPageID.Text += "STTO021";
			else
				LblPageID.Text += "STTO011";
			PanCustName.Visible = takeOutMode;
			BtnSearch.Visible = takeOutMode;
			OptionPad.AutoRefresh = false;
			OptionPad.Red = OptionPad.Green = OptionPad.Blue = 1;
			OptionPad.AutoRefresh = true;
			ListOrderItem.Reset();
			ListOrderCount.Reset();
			ListOrderItemBy.Reset();
			UpdateTableInformation();
			StartInputMenu();
		}

		/// <summary>
		/// Update screen for table, number of guest, and number of bill.
		/// </summary>
		private void UpdateTableInformation()
		{
			FieldTable.Text = tableInfo.TableName;;
			FieldGuest.Text = guestNumber.ToString();
			FieldBill.Text = billNumber.ToString();
			if (orderInfo != null)
				orderInfo.NumberOfGuest = guestNumber;
		}

		/// <summary>
		/// Update screen in monitor panel.
		/// </summary>
		private void UpdateMonitor()
		{
			switch (inputState)
			{
				case INPUT_MENU:
					goto default;
				case INPUT_UNIT:
					FieldInputType.Text = "Unit";
					break;
				case INPUT_OPTION:
					FieldInputType.Text = "Option";
					break;
				case INPUT_GUEST:
					FieldInputType.Text = "Guest";
					break;
				case INPUT_BILL:
					FieldInputType.Text = "Bill";
					break;
				case INPUT_MOVEITEM:
					FieldInputType.Text = "Move Item";
					break;
				default:
					inputState = INPUT_MENU;
					FieldInputType.Text = "Menu";
					break;
			}
			if (inputState == INPUT_UNIT && inputValue == "")
			{
				FieldCurrentInput.ForeColor = Color.Yellow;
				FieldCurrentInput.Text = selectedItem.Unit.ToString();
			}
			else
			{
				FieldCurrentInput.ForeColor = Color.Cyan;
				FieldCurrentInput.Text = inputValue;
			}
			if (inputState == INPUT_GUEST)
			{
				FieldGuest.BackColor = Color.Blue;
				FieldGuest.ForeColor = Color.White;
			}
			else
			{
				FieldGuest.BackColor = Color.White;
				FieldGuest.ForeColor = Color.Black;
			}
			if (inputState == INPUT_BILL)
			{
				FieldBill.BackColor = Color.Blue;
				FieldBill.ForeColor = Color.White;
			}
			else
			{
				FieldBill.BackColor = Color.White;
				FieldBill.ForeColor = Color.Black;
			}
			if (takeOutMode)
			{
				if (FieldCustName.Text == "")
					FieldCustName.Text = FIELD_CUST_TEXT;
			}
		}

		/// <summary>
		/// Update order item grid.
		/// </summary>
		private void UpdateOrderGrid()
		{
			StringBuilder sb = new StringBuilder();
			int billCnt, itemCnt;
			OrderBill[] bills;
			OrderBillItem[] items;
			DataItem data;

			ListOrderItem.AutoRefresh = false;
			ListOrderCount.AutoRefresh = false;
			ListOrderItemBy.AutoRefresh = false;
			ListOrderItem.Items.Clear();
			ListOrderCount.Items.Clear();
			ListOrderItemBy.Items.Clear();
			if (orderInfo == null || orderInfo.Bills.Length != billNumber)
			{
				orderInfo = OrderManagement.CreateOrderObject(orderInfo, employeeID, tableInfo, guestNumber, billNumber);
			}
			bills = orderInfo.Bills;
			if (selectedBill == null)
				selectedBill = bills[0];
			// Loop for all bills.
			for (billCnt = 0;billCnt < bills.Length;billCnt++)
			{
				// Add bill title to grid.
				sb.Length = 0;
				if (AppParameter.IsDemo())
					sb.Append("Bill #");
				else
					sb.Append("Seat #");
				sb.Append(billCnt + 1);
				if (bills[billCnt].CloseBillDate != DateTime.MinValue)
					sb.Append(" (Closed)");
				data = new DataItem(sb.ToString(), bills[billCnt], true);
				ListOrderItem.Items.Add(data);
				// Add bill title to order count
				data = new DataItem("Amt.", bills[billCnt], true);
				ListOrderCount.Items.Add(data);
				// Add bill title to order by grid
				data = new DataItem("Emp#", bills[billCnt], true);
				ListOrderItemBy.Items.Add(data);
				// Selected Bill
				if (selectedBill == bills[billCnt] && selectedItem == null)
				{
					ListOrderItem.SelectedIndex = ListOrderItem.Items.Count - 1;
					ListOrderCount.SelectedIndex = ListOrderCount.Items.Count - 1;
					ListOrderItemBy.SelectedIndex = ListOrderItemBy.Items.Count - 1;
				}
				items = bills[billCnt].Items;
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
						// Add item to grid order count
						data = new DataItem(items[itemCnt].Unit.ToString(), items[itemCnt], false);
						if (OrderManagement.IsCancel(items[itemCnt]))
							data.Strike = true;
						ListOrderCount.Items.Add(data);
						// Add item to grid order by
						data = new DataItem(items[itemCnt].EmployeeID.ToString(), items[itemCnt], false);
						if (OrderManagement.IsCancel(items[itemCnt]))
							data.Strike = true;
						ListOrderItemBy.Items.Add(data);
						// Selected Item
						if (selectedItem == items[itemCnt])
						{
							ListOrderItem.SelectedIndex = ListOrderItem.Items.Count - 1;
							ListOrderCount.SelectedIndex = ListOrderCount.Items.Count - 1;
							ListOrderItemBy.SelectedIndex = ListOrderItemBy.Items.Count - 1;
						}
					}
				}
			}
			ListOrderItem.AutoRefresh = true;
			ListOrderCount.AutoRefresh = true;
			ListOrderItemBy.AutoRefresh = true;
			UpdateOrderButton();
			UpdateFlowButton();
		}

		/// <summary>
		/// Update enabled status for cancel/undo/up/down button
		/// </summary>
		private void UpdateOrderButton()
		{
			// Update enabled for cancel/undo button
			if (!moveItem && selectedItem != null &&
				selectedBill.CloseBillDate == DateTime.MinValue)
			{
				if (selectedItem.ServeTime == DateTime.MinValue)
				{
					BtnCancel.Enabled = !OrderManagement.IsCancel(selectedItem);
					BtnUndo.Enabled = OrderManagement.IsCancel(selectedItem);
					BtnServeItem.Enabled = !OrderManagement.IsCancel(selectedItem);
					BtnMessage.Enabled = !OrderManagement.IsCancel(selectedItem);
					BtnAmount.Enabled = !OrderManagement.IsCancel(selectedItem);
				}
				BtnMoveItem.Enabled = !OrderManagement.IsCancel(selectedItem) && (orderInfo.Bills.Length > 1);
			}
			else
			{
				BtnCancel.Enabled = false;
				BtnUndo.Enabled = false;
				BtnMoveItem.Enabled = false;
				BtnServeItem.Enabled = false;
				BtnMessage.Enabled = false;
				BtnAmount.Enabled = false;
			}
			// Update enabled for up/down button
			BtnUp.Enabled = ListOrderItem.CanUp;
			BtnDown.Enabled = ListOrderItem.CanDown;
		}

		/// <summary>
		/// Update enabled status for all flow buttons
		/// </summary>
		private void UpdateFlowButton()
		{
			if (isChanged)
			{
				if (takeOutMode)
				{
					if (FieldCustName.Text == null || FieldCustName.Text == "" ||
						FieldCustName.Text == FIELD_CUST_TEXT)
						BtnPrintKitchen.Enabled = false;
					else
						BtnPrintKitchen.Enabled = true;
				}
				else
					BtnPrintKitchen.Enabled = true;
			}
			else
				BtnPrintKitchen.Enabled = false;
			if (orderInfo.OrderID != 0 && !isChanged &&
				selectedBill != null && selectedBill.CloseBillDate == DateTime.MinValue)
			{
				BtnPrintReceipt.Enabled = true;
				BtnPrintReceiptAll.Enabled = true;
			}
			else
			{
				BtnPrintReceipt.Enabled = false;
				BtnPrintReceiptAll.Enabled = false;
			}
		}
		#endregion

		#region Manage order and bills
		/// <summary>
		/// Add Menu Item to Selected Bill by menu item.
		/// </summary>
		/// <param name="menu">Menu Item for insert to selected bill.</param>
		private void AddOrderBillItem(MenuService.MenuItem menu)
		{
			OrderBillItem item = OrderManagement.AddOrderBillItem(selectedBill, menu, employeeID);
			if (item != null)
			{
				selectedItem = item;
				isChanged = true;
				StartInputOption();
			}
			else
			{
				StartInputMenu();
				isChanged = false;
			}
		}

		private void ChangeBillCount()
		{
			if (billNumber < orderInfo.Bills.Length && billNumber >= 1)
			{
				for (int i = billNumber;i < orderInfo.Bills.Length;i++)
				{
					OrderBillItem[] items = orderInfo.Bills[i].Items;
					if (items == null)
						continue;
					OrderBillItem[] oItems = orderInfo.Bills[0].Items;
					orderInfo.Bills[0].Items = new OrderBillItem[oItems.Length + items.Length];
					int cnt = 0;
					for (int j = 0;j < oItems.Length;j++)
						orderInfo.Bills[0].Items[cnt++] = oItems[j];
					for (int j = 0;j < items.Length;j++)
						orderInfo.Bills[0].Items[cnt++] = items[j];
					orderInfo.Bills[i].Items = null;
				}
			}
		}

		private void SaveBeforePrintReceipt()
		{
			OrderService.OrderService service = new OrderService.OrderService();
			string result;
			if (!takeOutMode)
			{
				result = service.SendOrderPrint(orderInfo, null, false);
				int orderID = 0;
				try
				{
					orderID = int.Parse(result);
					service.SetTableReference(orderID, tableIDList);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					orderID = 0;
				}
			}
			else
				result = service.SendOrderPrint(orderInfo, FieldCustName.Text, false);
		}

		#endregion

		private void FieldGuest_Click(object sender, System.EventArgs e)
		{
			if (!takeOutMode)
			{
				inputState = INPUT_GUEST;
				inputValue = "";
				UpdateMonitor();
			}
		}

		private void FieldBill_Click(object sender, System.EventArgs e)
		{
			if (!takeOutMode)
			{
				inputState = INPUT_BILL;
				inputValue = "";
				UpdateMonitor();
			}
		}

		private void CategoryPad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			int typeIndex;
			// Check for click in other input state
			if (inputState == INPUT_UNIT || inputState == INPUT_OPTION)
				StartInputMenu();
			if (inputState != INPUT_MENU)
				return;
			// Get type button index
			if (e.Value == null)
				return;
			try
			{
				typeIndex = int.Parse(e.Value);
			}
			catch (Exception ex)
			{
				MessageForm.Show(ex.ToString(), "Exception");
				return;
			}
			// Show at monitor
			inputValue = e.Button.Text.Substring(0,2);
			UpdateMonitor();
			// Set Menu Item
			selectedType = menuTypes[typeIndex];
			MenuService.MenuItem[] menuItems = selectedType.MenuItems;
			OptionPad.AutoRefresh = false;
			OptionPad.Items.Clear();
			OptionPad.ItemStart = 0;
			if (menuItems != null)
				for (int i = 0;i < menuItems.Length;i++)
					OptionPad.Items.Add(new ButtonItem(MenuManagement.GetMenuLanguageName(menuItems[i]), i.ToString()));
			OptionPad.Red = e.Button.Red;
			OptionPad.Green = e.Button.Green;
			OptionPad.Blue = e.Button.Blue;
			OptionPad.AutoRefresh = true;
		}

		private void NumberKeyPad_PadClick(object sender, smartRestaurant.Controls.NumberPadEventArgs e)
		{
			if (e.IsNumeric)
			{
				if (inputState == INPUT_OPTION || inputState == INPUT_MOVEITEM)
					StartInputMenu();
				inputValue += e.Number.ToString();
				UpdateMonitor();
			}
			else if (e.IsCancel)
			{
				if (inputValue.Length > 1)
				{
					inputValue = inputValue.Substring(0, inputValue.Length - 1);
					UpdateMonitor();
				}
				else
					StartInputMenu();
			}
			else if (e.IsEnter)
			{
				int intValue;
				// Set Value from string to int
				try
				{
					intValue = Int32.Parse(inputValue);
				}
				catch (Exception)
				{
					intValue = 0;
				}
				// Check for each case
				switch (inputState)
				{
					case INPUT_MENU:
						if (intValue != 0 && selectedBill != null)
						{
							MenuService.MenuItem menu = MenuManagement.GetMenuItemKeyID(intValue);
							if (menu != null)
							{
								AddOrderBillItem(menu);
								return;
							}
						}
						break;
					case INPUT_UNIT:
						if (selectedItem != null)
						{
							if (intValue > 0 && selectedItem.Unit != intValue)
							{
								selectedItem.Unit = intValue;
								selectedItem.ChangeFlag = true;
								isChanged = true;
							}
							StartInputMenu();
							return;
						}
						break;
					case INPUT_OPTION:
						break;
					case INPUT_GUEST:
						if (intValue > 0)
						{
							guestNumber = intValue;
							UpdateTableInformation();
						}
						break;
					case INPUT_BILL:
						if (intValue > 0)
						{
							billNumber = intValue;
							if (billNumber > guestNumber)
								guestNumber = billNumber;
							ChangeBillCount();
							UpdateOrderGrid();
							UpdateTableInformation();
						}
						break;
					case INPUT_MOVEITEM:
						break;
				}
				StartInputMenu();
			}
		}

		private void OptionPad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			if ((inputState != INPUT_MENU && inputState != INPUT_OPTION) ||
				(inputState == INPUT_MENU && (inputValue == null || inputValue.Length == 0)))
				return;
			// Get Index
			int index;
			int optionID, choiceID;
			if (e.Value == null)
				return;
			try
			{
				if (inputState == INPUT_OPTION)
				{
					string[] strs = e.Value.Split(':');
					optionID = int.Parse(strs[0]);
					choiceID = int.Parse(strs[1]);
					index = 0;
				}
				else
				{
					optionID = choiceID = 0;
					index = int.Parse(e.Value);
				}
			}
			catch (Exception ex)
			{
				MessageForm.Show(ex.ToString(), "Exception");
				return;
			}
			MenuService.MenuItem menu;
			switch (inputState)
			{
				case INPUT_MENU:
					menu = selectedType.MenuItems[index];
					AddOrderBillItem(menu);
					break;
				case INPUT_OPTION:
					string optionStr = optionID + ":";
					string choiceStr = choiceID.ToString();
					// Set Default to item
					if (selectedItem.ItemChoices == null)
					{
						menu = MenuManagement.GetMenuItemFromID(selectedItem.MenuID);
						selectedItem.ItemChoices = new OrderItemChoice[menu.MenuDefaults.Length];
						for (int i = 0;i < menu.MenuDefaults.Length;i++)
						{
							selectedItem.ItemChoices[i] = new OrderItemChoice();
							selectedItem.ItemChoices[i].OptionID = menu.MenuDefaults[i].OptionID;
							selectedItem.ItemChoices[i].ChoiceID = menu.MenuDefaults[i].DefaultChoiceID;
						}
						selectedItem.DefaultOption = false;
					}
					// Update Screen
					for (int i = 0;i < OptionPad.Items.Count;i++)
					{
						ButtonItem bItem = (ButtonItem)OptionPad.Items[i];
						if (bItem.Value.Substring(0, optionStr.Length) == optionStr)
						{
							if (bItem.Value.Substring(optionStr.Length) == choiceStr)
								OptionPad.SetMatrix(i, 2, 1, 2);
							else
								OptionPad.SetMatrix(i, 1, 1, 1);
						}
					}
					// Update Data Object
					for (int i = 0;i < selectedItem.ItemChoices.Length;i++)
					{
						if (selectedItem.ItemChoices[i].OptionID == optionID)
						{
							selectedItem.ItemChoices[i].ChoiceID = choiceID;
							selectedItem.DefaultOption = false;
							selectedItem.ChangeFlag = true;
							isChanged = true;
							break;
						}
					}
					break;
			}
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
			{
				isChanged |= OrderManagement.CancelOrderBillItem(selectedBill, selectedItem, employeeID);
				UpdateOrderGrid();
			}
		}

		private void BtnUndo_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
			{
				isChanged |= OrderManagement.UndoCancelOrderBillItem(selectedItem, employeeID);
				UpdateOrderGrid();
			}
		}

		private void BtnMoveItem_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
				StartMoveItem();
		}

		private void BtnUp_Click(object sender, System.EventArgs e)
		{
			ListOrderItem.Up(5);
			UpdateOrderButton();
		}

		private void BtnDown_Click(object sender, System.EventArgs e)
		{
			ListOrderItem.Down(5);
			UpdateOrderButton();
		}

		private void ListOrderItem_ItemClick(object sender, smartRestaurant.Controls.ItemsListEventArgs e)
		{
			OrderBill bill = null;
			OrderBillItem item = null;
			// Check for move item
			if (moveItem)
			{
				bill = selectedBill;
				item = selectedItem;
			}
			// Check for selected item and selected bill
			if (e.Item.Value is OrderBill)
			{
				selectedBill = (OrderBill)e.Item.Value;
				selectedItem = null;
				StartInputMenu();
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
				if (selectedBill.CloseBillDate != DateTime.MinValue)
					StartInputMenu();
				else
					StartInputOption();
			}
			// Move item
			if (item != null)
			{
				if (bill != selectedBill)
				{
					if (OrderManagement.MoveOrderBillItem(bill, selectedBill, item))
					{
						isChanged = true;
						UpdateOrderGrid();
					}
				}
				else
					UpdateOrderGrid();
			}
		}

		private void BtnMessage_Click(object sender, System.EventArgs e)
		{
			if (selectedItem == null)
				return;
			string result = KeyboardForm.Show("Message", selectedItem.Message);
			if (result != null)
			{
				selectedItem.Message = (result == "")?null:result;
				selectedItem.ChangeFlag = true;
				isChanged = true;
			}
			UpdateOrderGrid();
		}

		private void BtnPrintKitchen_Click(object sender, System.EventArgs e)
		{
			OrderService.OrderService service = new OrderService.OrderService();
			string result;
			WaitingForm.Show("Print to Kitchen");
			this.Enabled = false;
			if (!takeOutMode)
			{
				result = service.SendOrder(orderInfo, null);
				int orderID = 0;
				try
				{
					orderID = int.Parse(result);
					service.SetTableReference(orderID, tableIDList);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					orderID = 0;
				}
			}
			else
				result = service.SendOrder(orderInfo, FieldCustName.Text);
			this.Enabled = true;
			WaitingForm.HideForm();
			try 
			{
				orderInfo.OrderID = Int32.Parse(result);
			}
			catch (Exception)
			{
				MessageBox.Show(result);
				return;
			}
			((MainForm)MdiParent).ShowMainMenuForm();
		}

		private void BtnPrintReceiptAll_Click(object sender, System.EventArgs e)
		{
			SaveBeforePrintReceipt();
			WaitingForm.Show("Print Receipt");
			this.Enabled = false;
			Receipt.PrintReceiptAll(orderInfo);
			this.Enabled = true;
			WaitingForm.HideForm();
			((MainForm)MdiParent).ShowMainMenuForm();
		}

		private void BtnPrintReceipt_Click(object sender, System.EventArgs e)
		{
			SaveBeforePrintReceipt();
			((MainForm)MdiParent).ShowPrintReceiptForm(tableInfo, orderInfo, selectedBill);
		}

		private void FieldCustName_Click(object sender, System.EventArgs e)
		{
			string oldName;
			if (FieldCustName.Text == "" || FieldCustName.Text == FIELD_CUST_TEXT)
				oldName = "";
			else
				oldName = FieldCustName.Text;
			string result = KeyboardForm.Show("Customer Name", oldName);
			if (result != null)
			{
				if (result != "")
					FieldCustName.Text = result;
				else
					FieldCustName.Text = FIELD_CUST_TEXT;
			}
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			if (FieldCustName.Text == FIELD_CUST_TEXT)
				FieldCustName.Text = "";
			((MainForm)MdiParent).ShowTakeOutForm(tableInfo, FieldCustName.Text, true);
		}

		private void BtnServeItem_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
			{
				selectedItem.ServeTime = DateTime.Now;
				isChanged |= true;
				UpdateOrderGrid();
			}
		}

		private void FieldTable_Click(object sender, System.EventArgs e)
		{
			if (!takeOutMode)
			{
				int[] tables = TableForm.ShowMulti("Merge Table", tableInfo, tableIDList);
				if (tables != null)
				{
					int count;
					if (tables.Length == 1 && tables[0] == -1)
						count = 0;
					else
						count = tables.Length;
					if (tableIDList != null)
					{
						if (count != tableIDList.Length)
							isChanged = true;
						else
						{
							for (int i = 0;i < count;i++)
								if (tables[i] != tableIDList[i])
								{
									isChanged = true;
									break;
								}
						}
					}
					else
						if (count > 0)
							isChanged = true;
					if (count == 0)
						tableIDList = null;
					else
						tableIDList = tables;
					UpdateFlowButton();
				}
			}
		}

		private void BtnAmount_Click(object sender, System.EventArgs e)
		{
			if (selectedItem != null)
				StartInputUnit();
		}
	}
}
