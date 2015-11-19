using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Controls;
using smartRestaurant.Data;
using smartRestaurant.TableService;
using smartRestaurant.CustomerService;
using smartRestaurant.OrderService;
using smartRestaurant.Utils;

namespace smartRestaurant
{
	/// <summary>
	/// Summary description for TakeOutForm.
	/// </summary>
	public class TakeOutForm : SmartForm
	{
		/* Input State Value */
		private const int INPUT_FIRSTNAME	= 0;
		private const int INPUT_MIDDLENAME	= 1;
		private const int INPUT_LASTNAME	= 2;
		private const int INPUT_ADDRESS		= 3;
		private const int INPUT_MEMO		= 4;

		private smartRestaurant.Controls.ImageButton BtnCancel;
		private smartRestaurant.Controls.ImageButton BtnMain;
		private System.Windows.Forms.ImageList NumberImgList;
		private System.Windows.Forms.ImageList ButtonImgList;
		private smartRestaurant.Controls.ImageButton BtnPay;
		private smartRestaurant.Controls.ImageButton BtnTakeOrder;
		private smartRestaurant.Controls.ImageButton BtnDown;
		private smartRestaurant.Controls.ImageButton BtnUp;
		private smartRestaurant.Controls.ItemsList ListOrderQueue;
		private smartRestaurant.Controls.NumberPad NumberKeyPad;
		private smartRestaurant.Controls.ImageButton BtnCustDown;
		private smartRestaurant.Controls.ImageButton BtnCustUp;
		private smartRestaurant.Controls.ImageButton BtnCustList;
		private smartRestaurant.Controls.ImageButton BtnCustSearch;
		private System.Windows.Forms.ImageList ButtonLiteImgList;
		private System.Windows.Forms.Label LblHeaderName;
		private System.Windows.Forms.Label LblHeaderPhone;
		private System.Windows.Forms.Label LblMemo;
		private System.Windows.Forms.Label LblLName;
		private System.Windows.Forms.Label LblMName;
		private System.Windows.Forms.Label LblFName;
		private System.Windows.Forms.Label LblPhone;
		private System.Windows.Forms.Label LblAddress;
		private System.Windows.Forms.Label FieldPhone;
		private System.Windows.Forms.Label FieldFName;
		private System.Windows.Forms.Label FieldMName;
		private System.Windows.Forms.Label FieldLName;
		private System.Windows.Forms.Label FieldAddress;
		private System.Windows.Forms.Label FieldMemo;
		private smartRestaurant.Controls.ImageButton BtnClear;
		private smartRestaurant.Controls.ImageButton BtnSave;
		private smartRestaurant.Controls.ImageButton BtnDelete;
		private smartRestaurant.Controls.ItemsList ListCustPhone;
		private smartRestaurant.Controls.ItemsList ListCustName;
		private System.Windows.Forms.Label LblHeaderOrder;
		private System.ComponentModel.IContainer components;
		private smartRestaurant.Controls.KeyboardPad MessagePad;
		private smartRestaurant.Controls.GroupPanel PanCustField;
		private smartRestaurant.Controls.ImageButton BtnEditOrder;

		private int employeeID;
		private bool takeOrderMode;
		private int inputState;

		private TableInformation tableInfo;
		private CustomerService.CustomerInformation[] custList;
		private CustomerService.CustomerInformation selectedCust;
		private TakeOutInformation[] takeOutList;
		private System.Windows.Forms.Label LblPageID;
		private System.Windows.Forms.Label LblCopyright;
		private TakeOutInformation selectedTakeOut;

		public TakeOutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			selectedCust = null;
			takeOrderMode = false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TakeOutForm));
			this.BtnPay = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnTakeOrder = new smartRestaurant.Controls.ImageButton();
			this.BtnCancel = new smartRestaurant.Controls.ImageButton();
			this.BtnMain = new smartRestaurant.Controls.ImageButton();
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnDown = new smartRestaurant.Controls.ImageButton();
			this.BtnUp = new smartRestaurant.Controls.ImageButton();
			this.ListOrderQueue = new smartRestaurant.Controls.ItemsList();
			this.PanCustField = new smartRestaurant.Controls.GroupPanel();
			this.BtnDelete = new smartRestaurant.Controls.ImageButton();
			this.ButtonLiteImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnSave = new smartRestaurant.Controls.ImageButton();
			this.BtnClear = new smartRestaurant.Controls.ImageButton();
			this.FieldMemo = new System.Windows.Forms.Label();
			this.FieldAddress = new System.Windows.Forms.Label();
			this.FieldLName = new System.Windows.Forms.Label();
			this.FieldMName = new System.Windows.Forms.Label();
			this.FieldFName = new System.Windows.Forms.Label();
			this.FieldPhone = new System.Windows.Forms.Label();
			this.LblAddress = new System.Windows.Forms.Label();
			this.LblMemo = new System.Windows.Forms.Label();
			this.LblLName = new System.Windows.Forms.Label();
			this.LblMName = new System.Windows.Forms.Label();
			this.LblFName = new System.Windows.Forms.Label();
			this.LblPhone = new System.Windows.Forms.Label();
			this.NumberKeyPad = new smartRestaurant.Controls.NumberPad();
			this.ListCustPhone = new smartRestaurant.Controls.ItemsList();
			this.ListCustName = new smartRestaurant.Controls.ItemsList();
			this.BtnCustDown = new smartRestaurant.Controls.ImageButton();
			this.BtnCustUp = new smartRestaurant.Controls.ImageButton();
			this.BtnCustList = new smartRestaurant.Controls.ImageButton();
			this.BtnCustSearch = new smartRestaurant.Controls.ImageButton();
			this.LblHeaderName = new System.Windows.Forms.Label();
			this.LblHeaderPhone = new System.Windows.Forms.Label();
			this.LblHeaderOrder = new System.Windows.Forms.Label();
			this.MessagePad = new smartRestaurant.Controls.KeyboardPad();
			this.BtnEditOrder = new smartRestaurant.Controls.ImageButton();
			this.LblPageID = new System.Windows.Forms.Label();
			this.LblCopyright = new System.Windows.Forms.Label();
			this.PanCustField.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnPay
			// 
			this.BtnPay.BackColor = System.Drawing.Color.Transparent;
			this.BtnPay.Blue = 1F;
			this.BtnPay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPay.Green = 1F;
			this.BtnPay.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnPay.Image")));
			this.BtnPay.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnPay.ImageClick")));
			this.BtnPay.ImageClickIndex = 1;
			this.BtnPay.ImageIndex = 0;
			this.BtnPay.ImageList = this.ButtonImgList;
			this.BtnPay.Location = new System.Drawing.Point(232, 64);
			this.BtnPay.Name = "BtnPay";
			this.BtnPay.ObjectValue = null;
			this.BtnPay.Red = 2F;
			this.BtnPay.Size = new System.Drawing.Size(110, 60);
			this.BtnPay.TabIndex = 28;
			this.BtnPay.Text = "Pay";
			this.BtnPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPay.Click += new System.EventHandler(this.BtnPay_Click);
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnTakeOrder
			// 
			this.BtnTakeOrder.BackColor = System.Drawing.Color.Transparent;
			this.BtnTakeOrder.Blue = 1.75F;
			this.BtnTakeOrder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnTakeOrder.Green = 1F;
			this.BtnTakeOrder.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnTakeOrder.Image")));
			this.BtnTakeOrder.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnTakeOrder.ImageClick")));
			this.BtnTakeOrder.ImageClickIndex = 1;
			this.BtnTakeOrder.ImageIndex = 0;
			this.BtnTakeOrder.ImageList = this.ButtonImgList;
			this.BtnTakeOrder.Location = new System.Drawing.Point(904, 64);
			this.BtnTakeOrder.Name = "BtnTakeOrder";
			this.BtnTakeOrder.ObjectValue = null;
			this.BtnTakeOrder.Red = 1.75F;
			this.BtnTakeOrder.Size = new System.Drawing.Size(112, 60);
			this.BtnTakeOrder.TabIndex = 27;
			this.BtnTakeOrder.Text = "Take Order";
			this.BtnTakeOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnTakeOrder.Click += new System.EventHandler(this.BtnTakeOrder_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
			this.BtnCancel.Blue = 2F;
			this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCancel.Green = 1F;
			this.BtnCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.Image")));
			this.BtnCancel.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.ImageClick")));
			this.BtnCancel.ImageClickIndex = 1;
			this.BtnCancel.ImageIndex = 0;
			this.BtnCancel.ImageList = this.ButtonImgList;
			this.BtnCancel.Location = new System.Drawing.Point(8, 64);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.ObjectValue = null;
			this.BtnCancel.Red = 2F;
			this.BtnCancel.Size = new System.Drawing.Size(110, 60);
			this.BtnCancel.TabIndex = 22;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnMain
			// 
			this.BtnMain.BackColor = System.Drawing.Color.Transparent;
			this.BtnMain.Blue = 2F;
			this.BtnMain.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnMain.Green = 2F;
			this.BtnMain.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnMain.Image")));
			this.BtnMain.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnMain.ImageClick")));
			this.BtnMain.ImageClickIndex = 1;
			this.BtnMain.ImageIndex = 0;
			this.BtnMain.ImageList = this.ButtonImgList;
			this.BtnMain.Location = new System.Drawing.Point(424, 64);
			this.BtnMain.Name = "BtnMain";
			this.BtnMain.ObjectValue = null;
			this.BtnMain.Red = 1F;
			this.BtnMain.Size = new System.Drawing.Size(110, 60);
			this.BtnMain.TabIndex = 21;
			this.BtnMain.Text = "Main";
			this.BtnMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnMain.Click += new System.EventHandler(this.BtnMain_Click);
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
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
			this.BtnDown.TabIndex = 31;
			this.BtnDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
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
			this.BtnUp.TabIndex = 30;
			this.BtnUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
			// 
			// ListOrderQueue
			// 
			this.ListOrderQueue.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.ListOrderQueue.AutoRefresh = true;
			this.ListOrderQueue.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListOrderQueue.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListOrderQueue.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListOrderQueue.BackNormalColor = System.Drawing.Color.White;
			this.ListOrderQueue.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListOrderQueue.BindList1 = null;
			this.ListOrderQueue.BindList2 = null;
			this.ListOrderQueue.Border = 0;
			this.ListOrderQueue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListOrderQueue.ForeAlterColor = System.Drawing.Color.Black;
			this.ListOrderQueue.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListOrderQueue.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListOrderQueue.ForeNormalColor = System.Drawing.Color.Black;
			this.ListOrderQueue.ForeSelectedColor = System.Drawing.Color.White;
			this.ListOrderQueue.ItemHeight = 40;
			this.ListOrderQueue.ItemWidth = 320;
			this.ListOrderQueue.Location = new System.Drawing.Point(8, 168);
			this.ListOrderQueue.Name = "ListOrderQueue";
			this.ListOrderQueue.Row = 13;
			this.ListOrderQueue.SelectedIndex = 0;
			this.ListOrderQueue.Size = new System.Drawing.Size(320, 520);
			this.ListOrderQueue.TabIndex = 29;
			this.ListOrderQueue.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListOrderQueue_ItemClick);
			// 
			// PanCustField
			// 
			this.PanCustField.BackColor = System.Drawing.Color.Transparent;
			this.PanCustField.Caption = null;
			this.PanCustField.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.BtnDelete,
																					   this.BtnSave,
																					   this.BtnClear,
																					   this.FieldMemo,
																					   this.FieldAddress,
																					   this.FieldLName,
																					   this.FieldMName,
																					   this.FieldFName,
																					   this.FieldPhone,
																					   this.LblAddress,
																					   this.LblMemo,
																					   this.LblLName,
																					   this.LblMName,
																					   this.LblFName,
																					   this.LblPhone,
																					   this.NumberKeyPad});
			this.PanCustField.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.PanCustField.Location = new System.Drawing.Point(328, 128);
			this.PanCustField.Name = "PanCustField";
			this.PanCustField.ShowHeader = false;
			this.PanCustField.Size = new System.Drawing.Size(344, 624);
			this.PanCustField.TabIndex = 32;
			// 
			// BtnDelete
			// 
			this.BtnDelete.BackColor = System.Drawing.Color.Transparent;
			this.BtnDelete.Blue = 2F;
			this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnDelete.Green = 2F;
			this.BtnDelete.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnDelete.Image")));
			this.BtnDelete.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnDelete.ImageClick")));
			this.BtnDelete.ImageClickIndex = 1;
			this.BtnDelete.ImageIndex = 0;
			this.BtnDelete.ImageList = this.ButtonLiteImgList;
			this.BtnDelete.Location = new System.Drawing.Point(229, 312);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.ObjectValue = null;
			this.BtnDelete.Red = 1F;
			this.BtnDelete.Size = new System.Drawing.Size(110, 40);
			this.BtnDelete.TabIndex = 37;
			this.BtnDelete.Text = "Delete";
			this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDelete.Visible = false;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// ButtonLiteImgList
			// 
			this.ButtonLiteImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonLiteImgList.ImageSize = new System.Drawing.Size(110, 40);
			this.ButtonLiteImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonLiteImgList.ImageStream")));
			this.ButtonLiteImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnSave
			// 
			this.BtnSave.BackColor = System.Drawing.Color.Transparent;
			this.BtnSave.Blue = 2F;
			this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnSave.Green = 1F;
			this.BtnSave.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnSave.Image")));
			this.BtnSave.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnSave.ImageClick")));
			this.BtnSave.ImageClickIndex = 1;
			this.BtnSave.ImageIndex = 0;
			this.BtnSave.ImageList = this.ButtonLiteImgList;
			this.BtnSave.Location = new System.Drawing.Point(229, 312);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.ObjectValue = null;
			this.BtnSave.Red = 2F;
			this.BtnSave.Size = new System.Drawing.Size(112, 40);
			this.BtnSave.TabIndex = 36;
			this.BtnSave.Text = "Save";
			this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// BtnClear
			// 
			this.BtnClear.BackColor = System.Drawing.Color.Transparent;
			this.BtnClear.Blue = 2F;
			this.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnClear.Green = 1F;
			this.BtnClear.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnClear.Image")));
			this.BtnClear.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnClear.ImageClick")));
			this.BtnClear.ImageClickIndex = 1;
			this.BtnClear.ImageIndex = 0;
			this.BtnClear.ImageList = this.ButtonLiteImgList;
			this.BtnClear.Location = new System.Drawing.Point(5, 312);
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.ObjectValue = null;
			this.BtnClear.Red = 1F;
			this.BtnClear.Size = new System.Drawing.Size(110, 40);
			this.BtnClear.TabIndex = 35;
			this.BtnClear.Text = "Clear";
			this.BtnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
			// 
			// FieldMemo
			// 
			this.FieldMemo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldMemo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldMemo.Location = new System.Drawing.Point(96, 240);
			this.FieldMemo.Name = "FieldMemo";
			this.FieldMemo.Size = new System.Drawing.Size(232, 64);
			this.FieldMemo.TabIndex = 34;
			this.FieldMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldMemo.Click += new System.EventHandler(this.FieldMemo_Click);
			// 
			// FieldAddress
			// 
			this.FieldAddress.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldAddress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldAddress.Location = new System.Drawing.Point(96, 176);
			this.FieldAddress.Name = "FieldAddress";
			this.FieldAddress.Size = new System.Drawing.Size(232, 64);
			this.FieldAddress.TabIndex = 33;
			this.FieldAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldAddress.Click += new System.EventHandler(this.FieldAddress_Click);
			// 
			// FieldLName
			// 
			this.FieldLName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldLName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldLName.Location = new System.Drawing.Point(96, 136);
			this.FieldLName.Name = "FieldLName";
			this.FieldLName.Size = new System.Drawing.Size(232, 40);
			this.FieldLName.TabIndex = 32;
			this.FieldLName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldLName.Click += new System.EventHandler(this.FieldLName_Click);
			// 
			// FieldMName
			// 
			this.FieldMName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldMName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldMName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldMName.Location = new System.Drawing.Point(96, 96);
			this.FieldMName.Name = "FieldMName";
			this.FieldMName.Size = new System.Drawing.Size(232, 40);
			this.FieldMName.TabIndex = 31;
			this.FieldMName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldMName.Click += new System.EventHandler(this.FieldMName_Click);
			// 
			// FieldFName
			// 
			this.FieldFName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldFName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldFName.Location = new System.Drawing.Point(96, 56);
			this.FieldFName.Name = "FieldFName";
			this.FieldFName.Size = new System.Drawing.Size(232, 40);
			this.FieldFName.TabIndex = 30;
			this.FieldFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldFName.Click += new System.EventHandler(this.FieldFName_Click);
			// 
			// FieldPhone
			// 
			this.FieldPhone.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldPhone.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldPhone.Location = new System.Drawing.Point(96, 16);
			this.FieldPhone.Name = "FieldPhone";
			this.FieldPhone.Size = new System.Drawing.Size(232, 40);
			this.FieldPhone.TabIndex = 29;
			this.FieldPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblAddress
			// 
			this.LblAddress.Location = new System.Drawing.Point(16, 176);
			this.LblAddress.Name = "LblAddress";
			this.LblAddress.Size = new System.Drawing.Size(80, 40);
			this.LblAddress.TabIndex = 24;
			this.LblAddress.Text = "Address";
			this.LblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblMemo
			// 
			this.LblMemo.Location = new System.Drawing.Point(16, 240);
			this.LblMemo.Name = "LblMemo";
			this.LblMemo.Size = new System.Drawing.Size(80, 40);
			this.LblMemo.TabIndex = 22;
			this.LblMemo.Text = "Memo";
			this.LblMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblLName
			// 
			this.LblLName.Location = new System.Drawing.Point(16, 136);
			this.LblLName.Name = "LblLName";
			this.LblLName.Size = new System.Drawing.Size(80, 40);
			this.LblLName.TabIndex = 20;
			this.LblLName.Text = "L.Name";
			this.LblLName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblMName
			// 
			this.LblMName.Location = new System.Drawing.Point(16, 96);
			this.LblMName.Name = "LblMName";
			this.LblMName.Size = new System.Drawing.Size(80, 40);
			this.LblMName.TabIndex = 19;
			this.LblMName.Text = "M.Name";
			this.LblMName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblFName
			// 
			this.LblFName.Location = new System.Drawing.Point(16, 56);
			this.LblFName.Name = "LblFName";
			this.LblFName.Size = new System.Drawing.Size(80, 40);
			this.LblFName.TabIndex = 18;
			this.LblFName.Text = "F.Name";
			this.LblFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblPhone
			// 
			this.LblPhone.Location = new System.Drawing.Point(16, 16);
			this.LblPhone.Name = "LblPhone";
			this.LblPhone.Size = new System.Drawing.Size(80, 40);
			this.LblPhone.TabIndex = 17;
			this.LblPhone.Text = "Phone#";
			this.LblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NumberKeyPad
			// 
			this.NumberKeyPad.BackColor = System.Drawing.Color.White;
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
			// ListCustPhone
			// 
			this.ListCustPhone.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.ListCustPhone.AutoRefresh = true;
			this.ListCustPhone.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListCustPhone.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListCustPhone.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListCustPhone.BackNormalColor = System.Drawing.Color.White;
			this.ListCustPhone.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListCustPhone.BindList1 = this.ListCustName;
			this.ListCustPhone.BindList2 = null;
			this.ListCustPhone.Border = 0;
			this.ListCustPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListCustPhone.ForeAlterColor = System.Drawing.Color.Black;
			this.ListCustPhone.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListCustPhone.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListCustPhone.ForeNormalColor = System.Drawing.Color.Black;
			this.ListCustPhone.ForeSelectedColor = System.Drawing.Color.White;
			this.ListCustPhone.ItemHeight = 40;
			this.ListCustPhone.ItemWidth = 144;
			this.ListCustPhone.Location = new System.Drawing.Point(672, 168);
			this.ListCustPhone.Name = "ListCustPhone";
			this.ListCustPhone.Row = 13;
			this.ListCustPhone.SelectedIndex = 0;
			this.ListCustPhone.Size = new System.Drawing.Size(144, 520);
			this.ListCustPhone.TabIndex = 33;
			this.ListCustPhone.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListCustPhone_ItemClick);
			// 
			// ListCustName
			// 
			this.ListCustName.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.ListCustName.AutoRefresh = true;
			this.ListCustName.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListCustName.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListCustName.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListCustName.BackNormalColor = System.Drawing.Color.White;
			this.ListCustName.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListCustName.BindList1 = this.ListCustPhone;
			this.ListCustName.BindList2 = null;
			this.ListCustName.Border = 0;
			this.ListCustName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListCustName.ForeAlterColor = System.Drawing.Color.Black;
			this.ListCustName.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListCustName.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListCustName.ForeNormalColor = System.Drawing.Color.Black;
			this.ListCustName.ForeSelectedColor = System.Drawing.Color.White;
			this.ListCustName.ItemHeight = 40;
			this.ListCustName.ItemWidth = 196;
			this.ListCustName.Location = new System.Drawing.Point(816, 168);
			this.ListCustName.Name = "ListCustName";
			this.ListCustName.Row = 13;
			this.ListCustName.SelectedIndex = 0;
			this.ListCustName.Size = new System.Drawing.Size(196, 520);
			this.ListCustName.TabIndex = 40;
			this.ListCustName.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListCustPhone_ItemClick);
			// 
			// BtnCustDown
			// 
			this.BtnCustDown.BackColor = System.Drawing.Color.Transparent;
			this.BtnCustDown.Blue = 1F;
			this.BtnCustDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCustDown.Green = 1F;
			this.BtnCustDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustDown.Image")));
			this.BtnCustDown.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustDown.ImageClick")));
			this.BtnCustDown.ImageClickIndex = 5;
			this.BtnCustDown.ImageIndex = 4;
			this.BtnCustDown.ImageList = this.ButtonImgList;
			this.BtnCustDown.Location = new System.Drawing.Point(904, 692);
			this.BtnCustDown.Name = "BtnCustDown";
			this.BtnCustDown.ObjectValue = null;
			this.BtnCustDown.Red = 2F;
			this.BtnCustDown.Size = new System.Drawing.Size(110, 60);
			this.BtnCustDown.TabIndex = 35;
			this.BtnCustDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustDown.Click += new System.EventHandler(this.BtnCustDown_Click);
			// 
			// BtnCustUp
			// 
			this.BtnCustUp.BackColor = System.Drawing.Color.Transparent;
			this.BtnCustUp.Blue = 1F;
			this.BtnCustUp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCustUp.Green = 1F;
			this.BtnCustUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustUp.Image")));
			this.BtnCustUp.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustUp.ImageClick")));
			this.BtnCustUp.ImageClickIndex = 3;
			this.BtnCustUp.ImageIndex = 2;
			this.BtnCustUp.ImageList = this.ButtonImgList;
			this.BtnCustUp.Location = new System.Drawing.Point(680, 692);
			this.BtnCustUp.Name = "BtnCustUp";
			this.BtnCustUp.ObjectValue = null;
			this.BtnCustUp.Red = 2F;
			this.BtnCustUp.Size = new System.Drawing.Size(110, 60);
			this.BtnCustUp.TabIndex = 34;
			this.BtnCustUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustUp.Click += new System.EventHandler(this.BtnCustUp_Click);
			// 
			// BtnCustList
			// 
			this.BtnCustList.BackColor = System.Drawing.Color.Transparent;
			this.BtnCustList.Blue = 1F;
			this.BtnCustList.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCustList.Green = 1F;
			this.BtnCustList.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustList.Image")));
			this.BtnCustList.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustList.ImageClick")));
			this.BtnCustList.ImageClickIndex = 1;
			this.BtnCustList.ImageIndex = 0;
			this.BtnCustList.ImageList = this.ButtonImgList;
			this.BtnCustList.Location = new System.Drawing.Point(792, 64);
			this.BtnCustList.Name = "BtnCustList";
			this.BtnCustList.ObjectValue = null;
			this.BtnCustList.Red = 2F;
			this.BtnCustList.Size = new System.Drawing.Size(110, 60);
			this.BtnCustList.TabIndex = 37;
			this.BtnCustList.Text = "List All";
			this.BtnCustList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustList.Click += new System.EventHandler(this.BtnCustList_Click);
			// 
			// BtnCustSearch
			// 
			this.BtnCustSearch.BackColor = System.Drawing.Color.Transparent;
			this.BtnCustSearch.Blue = 1F;
			this.BtnCustSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCustSearch.Green = 1F;
			this.BtnCustSearch.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustSearch.Image")));
			this.BtnCustSearch.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustSearch.ImageClick")));
			this.BtnCustSearch.ImageClickIndex = 1;
			this.BtnCustSearch.ImageIndex = 0;
			this.BtnCustSearch.ImageList = this.ButtonImgList;
			this.BtnCustSearch.Location = new System.Drawing.Point(680, 64);
			this.BtnCustSearch.Name = "BtnCustSearch";
			this.BtnCustSearch.ObjectValue = null;
			this.BtnCustSearch.Red = 2F;
			this.BtnCustSearch.Size = new System.Drawing.Size(110, 60);
			this.BtnCustSearch.TabIndex = 36;
			this.BtnCustSearch.Text = "Search";
			this.BtnCustSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustSearch.Click += new System.EventHandler(this.BtnCustSearch_Click);
			// 
			// LblHeaderName
			// 
			this.LblHeaderName.BackColor = System.Drawing.Color.Black;
			this.LblHeaderName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderName.ForeColor = System.Drawing.Color.White;
			this.LblHeaderName.Location = new System.Drawing.Point(816, 128);
			this.LblHeaderName.Name = "LblHeaderName";
			this.LblHeaderName.Size = new System.Drawing.Size(196, 40);
			this.LblHeaderName.TabIndex = 39;
			this.LblHeaderName.Text = "Name";
			this.LblHeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblHeaderPhone
			// 
			this.LblHeaderPhone.BackColor = System.Drawing.Color.Black;
			this.LblHeaderPhone.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderPhone.ForeColor = System.Drawing.Color.White;
			this.LblHeaderPhone.Location = new System.Drawing.Point(672, 128);
			this.LblHeaderPhone.Name = "LblHeaderPhone";
			this.LblHeaderPhone.Size = new System.Drawing.Size(144, 40);
			this.LblHeaderPhone.TabIndex = 38;
			this.LblHeaderPhone.Text = "Phone#";
			this.LblHeaderPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblHeaderOrder
			// 
			this.LblHeaderOrder.BackColor = System.Drawing.Color.Black;
			this.LblHeaderOrder.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderOrder.ForeColor = System.Drawing.Color.White;
			this.LblHeaderOrder.Location = new System.Drawing.Point(8, 128);
			this.LblHeaderOrder.Name = "LblHeaderOrder";
			this.LblHeaderOrder.Size = new System.Drawing.Size(320, 40);
			this.LblHeaderOrder.TabIndex = 41;
			this.LblHeaderOrder.Text = "Order Customer";
			this.LblHeaderOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MessagePad
			// 
			this.MessagePad.Font = new System.Drawing.Font("Tahoma", 12F);
			this.MessagePad.Image = ((System.Drawing.Bitmap)(resources.GetObject("MessagePad.Image")));
			this.MessagePad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("MessagePad.ImageClick")));
			this.MessagePad.ImageClickIndex = 1;
			this.MessagePad.ImageIndex = 0;
			this.MessagePad.ImageList = this.NumberImgList;
			this.MessagePad.Location = new System.Drawing.Point(40, 384);
			this.MessagePad.Name = "MessagePad";
			this.MessagePad.Size = new System.Drawing.Size(936, 340);
			this.MessagePad.TabIndex = 42;
			this.MessagePad.Title = null;
			this.MessagePad.Visible = false;
			this.MessagePad.PadClick += new smartRestaurant.Controls.KeyboardPadEventHandler(this.MessagePad_PadClick);
			// 
			// BtnEditOrder
			// 
			this.BtnEditOrder.BackColor = System.Drawing.Color.Transparent;
			this.BtnEditOrder.Blue = 1.75F;
			this.BtnEditOrder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnEditOrder.Green = 1F;
			this.BtnEditOrder.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnEditOrder.Image")));
			this.BtnEditOrder.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnEditOrder.ImageClick")));
			this.BtnEditOrder.ImageClickIndex = 1;
			this.BtnEditOrder.ImageIndex = 0;
			this.BtnEditOrder.ImageList = this.ButtonImgList;
			this.BtnEditOrder.Location = new System.Drawing.Point(120, 64);
			this.BtnEditOrder.Name = "BtnEditOrder";
			this.BtnEditOrder.ObjectValue = null;
			this.BtnEditOrder.Red = 1.75F;
			this.BtnEditOrder.Size = new System.Drawing.Size(110, 60);
			this.BtnEditOrder.TabIndex = 43;
			this.BtnEditOrder.Text = "Edit Order";
			this.BtnEditOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnEditOrder.Click += new System.EventHandler(this.BtnEditOrder_Click);
			// 
			// LblPageID
			// 
			this.LblPageID.BackColor = System.Drawing.Color.Transparent;
			this.LblPageID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblPageID.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblPageID.Location = new System.Drawing.Point(784, 752);
			this.LblPageID.Name = "LblPageID";
			this.LblPageID.Size = new System.Drawing.Size(224, 23);
			this.LblPageID.TabIndex = 44;
			this.LblPageID.Text = "STTO020";
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
			this.LblCopyright.TabIndex = 45;
			this.LblCopyright.Text = "Copyright (c) 2004. All rights reserved.";
			// 
			// TakeOutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.LblCopyright,
																		  this.LblPageID,
																		  this.BtnEditOrder,
																		  this.MessagePad,
																		  this.LblHeaderOrder,
																		  this.ListCustName,
																		  this.LblHeaderName,
																		  this.LblHeaderPhone,
																		  this.BtnCustList,
																		  this.BtnCustSearch,
																		  this.BtnCustDown,
																		  this.BtnCustUp,
																		  this.ListCustPhone,
																		  this.PanCustField,
																		  this.BtnDown,
																		  this.BtnUp,
																		  this.ListOrderQueue,
																		  this.BtnPay,
																		  this.BtnTakeOrder,
																		  this.BtnCancel,
																		  this.BtnMain});
			this.Name = "TakeOutForm";
			this.Text = "Take Out List";
			this.PanCustField.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public TableInformation Table
		{
			get
			{
				return tableInfo;
			}
			set
			{
				tableInfo = value;
			}
		}

		public bool TakeOrderMode
		{
			get
			{
				return takeOrderMode;
			}
			set
			{
				takeOrderMode = value;
			}
		}

		public string CustomerName
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(FieldFName.Text);
				if (FieldMName.Text != null && FieldMName.Text != "")
				{
					sb.Append(" ");
					sb.Append(FieldMName.Text);
				}
				if (FieldLName.Text != null && FieldLName.Text != "")
				{
					sb.Append(" ");
					sb.Append(FieldLName.Text);
				}
				return sb.ToString();
			}
			set
			{
				ClearCustomer();
				if (value == null)
					return;
				string[] names = value.Split(' ');
				if (names.Length >= 1)
					FieldFName.Text = names[0];
				if (names.Length == 2)
					FieldLName.Text = names[1];
				else if (names.Length >= 3)
				{
					FieldMName.Text = names[1];
					FieldLName.Text = names[2];
				}
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

		#region Customer Management
		private void ClearCustomer()
		{
			selectedCust = null;
			FieldPhone.Text = "";
			FieldFName.Text = "";
			FieldMName.Text = "";
			FieldLName.Text = "";
			FieldAddress.Text = "";
			FieldMemo.Text = "";
			ListCustPhone.SelectedIndex = -1;
			ListCustPhone.AutoRefresh = true;
			ListCustName.AutoRefresh = true;
		}
		#endregion

		#region User Interface
		public override void UpdateForm()
		{
			selectedTakeOut = null;
			// Update Screen
			LblPageID.Text = "Employee ID:" + ((MainForm)MdiParent).UserID + " | STTO020";
			UpdateTakeOutList();
			if (FieldFName.Text == "")
				BtnCustList_Click(null, null);
			else
				BtnCustSearch_Click(null, null);
		}

		private void UpdateTakeOutList()
		{
			StringBuilder sb = new StringBuilder();
			int takeOutCnt;
			DataItem data;

			ListOrderQueue.AutoRefresh = false;
			ListOrderQueue.Items.Clear();
			ListOrderQueue.SelectedIndex = -1;
			// Load Take Out List
			OrderService.OrderService service = new OrderService.OrderService();
			takeOutList = service.GetTakeOutList();
			if (takeOutList == null)
			{
				ListOrderQueue.AutoRefresh = true;
				return;
			}
			// Loop for all take out.
			for (takeOutCnt = 0;takeOutCnt < takeOutList.Length;takeOutCnt++)
			{
				// Add take out's customer name to grid.
				sb.Length = 0;
				sb.Append(takeOutList[takeOutCnt].CustInfo.FirstName);
				if (takeOutList[takeOutCnt].CustInfo.MiddleName != "")
				{
					sb.Append(" ");
					sb.Append(takeOutList[takeOutCnt].CustInfo.MiddleName);
				}
				if (takeOutList[takeOutCnt].CustInfo.LastName != "")
				{
					sb.Append(" ");
					sb.Append(takeOutList[takeOutCnt].CustInfo.LastName);
				}

				data = new DataItem(sb.ToString(), takeOutList[takeOutCnt], false);
				ListOrderQueue.Items.Add(data);
				// Selected Take Out
				if (selectedTakeOut == takeOutList[takeOutCnt])
				{
					ListOrderQueue.SelectedIndex = ListOrderQueue.Items.Count - 1;
				}
			}
			ListOrderQueue.AutoRefresh = true;
			UpdateOrderButton();
		}

		private void UpdateCustomerList()
		{
			StringBuilder sb = new StringBuilder();
			int custCnt;
			DataItem data;

			ListCustPhone.AutoRefresh = false;
			ListCustName.AutoRefresh = false;
			ListCustPhone.Items.Clear();
			ListCustName.Items.Clear();
			if (custList == null)
			{
				ListCustPhone.AutoRefresh = true;
				ListCustName.AutoRefresh = true;
				return;
			}
			// Loop for all customers.
			for (custCnt = 0;custCnt < custList.Length;custCnt++)
			{
				// Add customers to grid.
				sb.Length = 0;
				sb.Append(custList[custCnt].FirstName);
				sb.Append(" ");
				sb.Append(custList[custCnt].MiddleName);
				sb.Append(" ");
				sb.Append(custList[custCnt].LastName);

				data = new DataItem(custList[custCnt].Telephone, custList[custCnt], false);
				ListCustPhone.Items.Add(data);
				data = new DataItem(sb.ToString(), custList[custCnt], false);
				ListCustName.Items.Add(data);
				// Selected Customer
				if (selectedCust == custList[custCnt])
				{
					ListCustPhone.SelectedIndex = ListCustPhone.Items.Count - 1;
				}
			}
			ListCustPhone.AutoRefresh = true;
			ListCustName.AutoRefresh = true;
			UpdateCustomerButton();
		}

		private void UpdateCustomerField()
		{
			if (selectedCust != null)
			{
				FieldPhone.Text = selectedCust.Telephone;
				FieldFName.Text = selectedCust.FirstName;
				FieldMName.Text = selectedCust.MiddleName;
				FieldLName.Text = selectedCust.LastName;
				FieldAddress.Text = selectedCust.Address;
				FieldMemo.Text = selectedCust.Description;
			}
			UpdateCustomerButton();
		}

		private void UpdateOrderButton()
		{
			if (selectedTakeOut == null)
			{
				BtnPay.Enabled = false;
				BtnCancel.Enabled = false;
				BtnEditOrder.Enabled = false;
			}
			else
			{
				BtnPay.Enabled = true;
				BtnCancel.Enabled = true;
				BtnEditOrder.Enabled = true;
			}
			// Update enabled for up/down button
			BtnUp.Enabled = ListOrderQueue.CanUp;
			BtnDown.Enabled = ListOrderQueue.CanDown;
		}

		private void UpdateCustomerButton()
		{
			BtnTakeOrder.Enabled = (FieldFName.Text != "");
			BtnSave.Enabled = (FieldFName.Text != "");
			BtnDelete.Enabled = (selectedCust != null);
			BtnCustSearch.Enabled = (FieldPhone.Text != "" || FieldFName.Text != "" || 
				FieldMName.Text != "" || FieldLName.Text != "");
			// Update enabled for up/down button
			BtnCustUp.Enabled = ListCustPhone.CanUp;
			BtnCustDown.Enabled = ListCustPhone.CanDown;
		}

		private void StartInputMessage()
		{
			// Order
			BtnCancel.Enabled = false;
			BtnPay.Enabled = false;
			BtnUp.Enabled = false;
			BtnDown.Enabled = false;
			BtnTakeOrder.Enabled = false;
			ListOrderQueue.Enabled = false;
			// Query
			BtnCustSearch.Enabled = false;
			BtnCustList.Enabled = false;
			BtnCustUp.Enabled = false;
			BtnCustDown.Enabled = false;
			BtnClear.Enabled = false;
			BtnSave.Enabled = false;
			BtnDelete.Enabled = false;
			ListCustName.Enabled = false;
			ListCustPhone.Enabled = false;
			NumberKeyPad.Enabled = false;
			FieldPhone.Enabled = false;
			FieldFName.Enabled = false;
			FieldMName.Enabled = false;
			FieldLName.Enabled = false;
			FieldAddress.Enabled = false;
			FieldMemo.Enabled = false;
			// Other
			BtnMain.Enabled = false;
		}
		
		private void ExitInputMessage()
		{
			// Order
			BtnCancel.Enabled = true;
			BtnPay.Enabled = true;
			BtnUp.Enabled = true;
			BtnDown.Enabled = true;
			BtnTakeOrder.Enabled = true;
			ListOrderQueue.Enabled = true;
			// Query
			BtnCustSearch.Enabled = true;
			BtnCustList.Enabled = true;
			BtnCustUp.Enabled = true;
			BtnCustDown.Enabled = true;
			BtnClear.Enabled = true;
			BtnSave.Enabled = true;
			BtnDelete.Enabled = true;
			ListCustName.Enabled = true;
			ListCustPhone.Enabled = true;
			NumberKeyPad.Enabled = true;
			FieldPhone.Enabled = true;
			FieldFName.Enabled = true;
			FieldMName.Enabled = true;
			FieldLName.Enabled = true;
			FieldAddress.Enabled = true;
			FieldMemo.Enabled = true;
			// Other
			BtnMain.Enabled = true;
			UpdateOrderButton();
			UpdateCustomerButton();
		}
		#endregion

		private void BtnTakeOrder_Click(object sender, System.EventArgs e)
		{
			if (TakeOrderMode)
				((MainForm)MdiParent).ShowTakeOrderForm(CustomerName.Trim());
			else
				((MainForm)MdiParent).ShowTakeOrderForm(tableInfo, 0, CustomerName);
		}

		private void BtnMain_Click(object sender, System.EventArgs e)
		{
			if (TakeOrderMode)
				((MainForm)MdiParent).ShowTakeOrderForm((string)null);
			else
				((MainForm)MdiParent).ShowMainMenuForm();
		}

		private void BtnCustSearch_Click(object sender, System.EventArgs e)
		{
			if (FieldPhone.Text == "" && FieldFName.Text == "" &&
				FieldMName.Text == "" && FieldLName.Text == "")
			{
				MessageBox.Show("Please fill phone number, first name, middle name, or last name.",
					"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			CustomerService.CustomerService service = new CustomerService.CustomerService();
			custList = service.SearchCustomers(FieldPhone.Text, FieldFName.Text, FieldMName.Text, FieldLName.Text);
			if (custList != null && custList.Length == 1)
			{
				selectedCust = custList[0];
				UpdateCustomerField();
			}
			UpdateCustomerList();
		}

		private void BtnCustList_Click(object sender, System.EventArgs e)
		{
			CustomerService.CustomerService service = new CustomerService.CustomerService();
			custList = service.GetCustomers();
			if (selectedCust != null)
			{
				for (int i = 0;i < custList.Length;i++)
					if (custList[i].CustID == selectedCust.CustID)
					{
						selectedCust = custList[i];
						break;
					}
			}
			UpdateCustomerList();
		}

		private void BtnCustDown_Click(object sender, System.EventArgs e)
		{
			ListCustPhone.Down(5);
			UpdateCustomerButton();
		}

		private void BtnCustUp_Click(object sender, System.EventArgs e)
		{
			ListCustPhone.Up(5);
			UpdateCustomerButton();
		}

		private void BtnClear_Click(object sender, System.EventArgs e)
		{
			ClearCustomer();
			UpdateCustomerButton();
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if (FieldFName.Text == "")
			{
				MessageBox.Show("Please fill first name.", "Information",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			CustomerService.CustomerInformation custInfo;
			if (selectedCust != null)
				custInfo = selectedCust;
			else
			{
				custInfo = new CustomerService.CustomerInformation();
				custInfo.CustID = 0;
			}
			custInfo.Telephone = FieldPhone.Text;
			custInfo.FirstName = FieldFName.Text;
			custInfo.MiddleName = FieldMName.Text;
			custInfo.LastName = FieldLName.Text;
			custInfo.Address = FieldAddress.Text;
			custInfo.Description = FieldMemo.Text;

			CustomerService.CustomerService service = new CustomerService.CustomerService();
			string result = service.SetCustomer(custInfo);
			if (result != null)
			{
				MessageBox.Show(result);
				return;
			}
			BtnCustSearch_Click(null, null);
		}

		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			if (selectedCust == null)
			{
				MessageBox.Show("Please select from customer list first.", "Information",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			CustomerService.CustomerService service = new CustomerService.CustomerService();
			string result = service.DeleteCustomer(selectedCust.CustID);
			if (result != null)
			{
				MessageBox.Show(result);
				return;
			}
			ClearCustomer();
			BtnCustList_Click(null, null);
		}

		private void NumberKeyPad_PadClick(object sender, smartRestaurant.Controls.NumberPadEventArgs e)
		{
			if (e.IsNumeric)
			{
				FieldPhone.Text += e.Number.ToString();
			}
			else if (e.IsCancel)
			{
				if (FieldPhone.Text.Length > 1)
					FieldPhone.Text = FieldPhone.Text.Substring(0, FieldPhone.Text.Length - 1);
				else
					FieldPhone.Text = "";
			}
			UpdateCustomerButton();
		}

		private void FieldFName_Click(object sender, System.EventArgs e)
		{
			StartInputMessage();
			inputState = INPUT_FIRSTNAME;
			MessagePad.Top = PanCustField.Top + FieldFName.Top;
			MessagePad.Text = FieldFName.Text;
			MessagePad.Title = "First Name";
			MessagePad.ShowKeyboard();
		}

		private void FieldMName_Click(object sender, System.EventArgs e)
		{
			StartInputMessage();
			inputState = INPUT_MIDDLENAME;
			MessagePad.Top = PanCustField.Top + FieldMName.Top;
			MessagePad.Text = FieldMName.Text;
			MessagePad.Title = "Middle Name";
			MessagePad.ShowKeyboard();
		}

		private void FieldLName_Click(object sender, System.EventArgs e)
		{
			StartInputMessage();
			inputState = INPUT_LASTNAME;
			MessagePad.Top = PanCustField.Top + FieldLName.Top;
			MessagePad.Text = FieldLName.Text;
			MessagePad.Title = "Last Name";
			MessagePad.ShowKeyboard();
		}

		private void FieldAddress_Click(object sender, System.EventArgs e)
		{
			StartInputMessage();
			inputState = INPUT_ADDRESS;
			MessagePad.Top = PanCustField.Top + FieldAddress.Top;
			MessagePad.Text = FieldAddress.Text;
			MessagePad.Title = "Address";
			MessagePad.ShowKeyboard();
		}

		private void FieldMemo_Click(object sender, System.EventArgs e)
		{
			StartInputMessage();
			inputState = INPUT_MEMO;
			MessagePad.Top = PanCustField.Top + FieldMemo.Top;
			MessagePad.Text = FieldMemo.Text;
			MessagePad.Title = "Memo";
			MessagePad.ShowKeyboard();
		}

		private void MessagePad_PadClick(object sender, smartRestaurant.Controls.KeyboardPadEventArgs e)
		{
			if (e.KeyCode == KeyboardPad.BUTTON_OK)
			{
				switch (inputState)
				{
					case INPUT_FIRSTNAME:
						FieldFName.Text = e.Text;
						break;
					case INPUT_MIDDLENAME:
						FieldMName.Text = e.Text;
						break;
					case INPUT_LASTNAME:
						FieldLName.Text = e.Text;
						break;
					case INPUT_ADDRESS:
						FieldAddress.Text = e.Text;
						break;
					case INPUT_MEMO:
						FieldMemo.Text = e.Text;
						break;
				}
			}
			else if (e.KeyCode != KeyboardPad.BUTTON_CANCEL)
				return;
			MessagePad.Visible = false;
			ExitInputMessage();
		}

		private void ListCustPhone_ItemClick(object sender, smartRestaurant.Controls.ItemsListEventArgs e)
		{
			if (e.Item.Value is CustomerService.CustomerInformation)
			{
				selectedCust = (CustomerService.CustomerInformation)e.Item.Value;
				UpdateCustomerField();
			}
		}

		private void BtnUp_Click(object sender, System.EventArgs e)
		{
			ListOrderQueue.Up(5);
			UpdateOrderButton();
		}

		private void BtnDown_Click(object sender, System.EventArgs e)
		{
			ListOrderQueue.Down(5);
			UpdateOrderButton();
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			if (selectedTakeOut == null)
			{
				MessageBox.Show("Please select order first.");
				return;
			}
			// Get bill from database
			OrderService.OrderService service = new OrderService.OrderService();
			OrderInformation orderInfo = service.GetOrderByOrderID(selectedTakeOut.OrderID);
			if (orderInfo == null)
			{
				MessageBox.Show("Can't load order information for this order.");
				return;
			}
			if (orderInfo.Bills == null || orderInfo.Bills.Length <= 0)
			{
				MessageBox.Show("No order item in this order.");
				return;
			}
			// Cancel Order
			OrderManagement.CancelOrder(orderInfo, employeeID);
			service.SendOrder(orderInfo, null);
			selectedTakeOut = null;
			UpdateTakeOutList();
			UpdateOrderButton();
		}

		private void BtnPay_Click(object sender, System.EventArgs e)
		{
			if (selectedTakeOut == null)
			{
				MessageBox.Show("Please select order first.");
				return;
			}
			// Get bill from database
			OrderService.OrderService service = new OrderService.OrderService();
			OrderInformation orderInfo = service.GetOrderByOrderID(selectedTakeOut.OrderID);
			if (orderInfo == null)
			{
				MessageBox.Show("Can't load order information for this order.");
				return;
			}
			if (orderInfo.Bills == null || orderInfo.Bills.Length <= 0)
			{
				MessageBox.Show("No order item in this order.");
				return;
			}
			// Go to print receipt page
			((MainForm)MdiParent).ShowPrintReceiptForm(tableInfo, orderInfo, orderInfo.Bills[0]);
		}

		private void ListOrderQueue_ItemClick(object sender, smartRestaurant.Controls.ItemsListEventArgs e)
		{
			if (e.Item.Value is TakeOutInformation)
				selectedTakeOut = (TakeOutInformation)e.Item.Value;
			UpdateOrderButton();
		}

		private void BtnEditOrder_Click(object sender, System.EventArgs e)
		{
			if (selectedTakeOut != null)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(selectedTakeOut.CustInfo.FirstName);
				if (selectedTakeOut.CustInfo.MiddleName != null && selectedTakeOut.CustInfo.MiddleName != "")
				{
					sb.Append(" ");
					sb.Append(selectedTakeOut.CustInfo.MiddleName);
				}
				if (selectedTakeOut.CustInfo.LastName != null && selectedTakeOut.CustInfo.LastName != "")
				{
					sb.Append(" ");
					sb.Append(selectedTakeOut.CustInfo.LastName);
				}
				((MainForm)MdiParent).ShowTakeOrderForm(tableInfo, selectedTakeOut.OrderID, sb.ToString());
			}
		}
	}
}
