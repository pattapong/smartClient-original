using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Controls;
using smartRestaurant.Utils;

namespace smartRestaurant
{
	/// <summary>
	/// <b>SearchCustomerForm</b> use for select customer name or create new customer.
	/// </summary>
	public class SearchCustomerForm : System.Windows.Forms.Form
	{
		/* Input State Value */
		/// <summary>
		/// <i>Input stats for input First Name</i>
		/// </summary>
		private const int INPUT_FIRSTNAME	= 0;
		/// <summary>
		/// <i>Input stats for input Middle Name</i>
		/// </summary>
		private const int INPUT_MIDDLENAME	= 1;
		/// <summary>
		/// <i>Input stats for input Last Name</i>
		/// </summary>
		private const int INPUT_LASTNAME	= 2;
		/// <summary>
		/// <i>Input stats for input Address</i>
		/// </summary>
		private const int INPUT_ADDRESS		= 3;
		/// <summary>
		/// <i>Input stats for input Menu</i>
		/// </summary>
		private const int INPUT_MEMO		= 4;

		/// <summary>
		/// <i>Instance variable for this class. Use for one time create object.</i>
		/// </summary>
		private static SearchCustomerForm instance = null;

		/// <summary>
		/// <i>Input state variable</i>
		/// </summary>
		private int inputState;
		/// <summary>
		/// <i>Boolean status to tell that SearchCustomerForm dialog is click OK or Cancel</i>
		/// </summary>
		private bool dialogResult;

		/// <summary>
		/// <i>List for all customer name</i>
		/// </summary>
		private CustomerService.CustomerInformation[] custList;
		/// <summary>
		/// <i>Object for selected customer.</i>
		/// </summary>
		private CustomerService.CustomerInformation selectedCust;

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
		private System.Windows.Forms.ImageList ButtonLiteImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ItemsList ListCustName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ItemsList ListCustPhone;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblHeaderName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblHeaderPhone;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnCustList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnCustSearch;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnCustDown;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnCustUp;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel PanCustField;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnDelete;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnSave;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnClear;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldMemo;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldAddress;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldLName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldMName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldFName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldPhone;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblAddress;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblMemo;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblLName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblMName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblFName;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPhone;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.NumberPad NumberKeyPad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnOk;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnCancel;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Comstructure for SearchCustomerForm class.
		/// </summary>
		public SearchCustomerForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			selectedCust = null;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SearchCustomerForm));
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.ButtonLiteImgList = new System.Windows.Forms.ImageList(this.components);
			this.ListCustName = new smartRestaurant.Controls.ItemsList();
			this.ListCustPhone = new smartRestaurant.Controls.ItemsList();
			this.LblHeaderName = new System.Windows.Forms.Label();
			this.LblHeaderPhone = new System.Windows.Forms.Label();
			this.BtnCustList = new smartRestaurant.Controls.ImageButton();
			this.BtnCustSearch = new smartRestaurant.Controls.ImageButton();
			this.BtnCustDown = new smartRestaurant.Controls.ImageButton();
			this.BtnCustUp = new smartRestaurant.Controls.ImageButton();
			this.PanCustField = new smartRestaurant.Controls.GroupPanel();
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
			this.BtnSave = new smartRestaurant.Controls.ImageButton();
			this.BtnClear = new smartRestaurant.Controls.ImageButton();
			this.BtnDelete = new smartRestaurant.Controls.ImageButton();
			this.BtnOk = new smartRestaurant.Controls.ImageButton();
			this.BtnCancel = new smartRestaurant.Controls.ImageButton();
			this.PanCustField.SuspendLayout();
			this.SuspendLayout();
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ButtonLiteImgList
			// 
			this.ButtonLiteImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonLiteImgList.ImageSize = new System.Drawing.Size(110, 40);
			this.ButtonLiteImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonLiteImgList.ImageStream")));
			this.ButtonLiteImgList.TransparentColor = System.Drawing.Color.Transparent;
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
			this.ListCustName.Location = new System.Drawing.Point(496, 112);
			this.ListCustName.Name = "ListCustName";
			this.ListCustName.Row = 9;
			this.ListCustName.SelectedIndex = 0;
			this.ListCustName.Size = new System.Drawing.Size(196, 360);
			this.ListCustName.TabIndex = 51;
			this.ListCustName.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListCustPhone_ItemClick);
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
			this.ListCustPhone.Location = new System.Drawing.Point(352, 112);
			this.ListCustPhone.Name = "ListCustPhone";
			this.ListCustPhone.Row = 9;
			this.ListCustPhone.SelectedIndex = 0;
			this.ListCustPhone.Size = new System.Drawing.Size(144, 360);
			this.ListCustPhone.TabIndex = 44;
			this.ListCustPhone.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListCustPhone_ItemClick);
			// 
			// LblHeaderName
			// 
			this.LblHeaderName.BackColor = System.Drawing.Color.Black;
			this.LblHeaderName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderName.ForeColor = System.Drawing.Color.White;
			this.LblHeaderName.Location = new System.Drawing.Point(496, 72);
			this.LblHeaderName.Name = "LblHeaderName";
			this.LblHeaderName.Size = new System.Drawing.Size(196, 40);
			this.LblHeaderName.TabIndex = 50;
			this.LblHeaderName.Text = "Name";
			this.LblHeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblHeaderPhone
			// 
			this.LblHeaderPhone.BackColor = System.Drawing.Color.Black;
			this.LblHeaderPhone.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderPhone.ForeColor = System.Drawing.Color.White;
			this.LblHeaderPhone.Location = new System.Drawing.Point(352, 72);
			this.LblHeaderPhone.Name = "LblHeaderPhone";
			this.LblHeaderPhone.Size = new System.Drawing.Size(144, 40);
			this.LblHeaderPhone.TabIndex = 49;
			this.LblHeaderPhone.Text = "Phone#";
			this.LblHeaderPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BtnCustList
			// 
			this.BtnCustList.BackColor = System.Drawing.Color.Transparent;
			this.BtnCustList.Blue = 1F;
			this.BtnCustList.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCustList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnCustList.Green = 1F;
			this.BtnCustList.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustList.Image")));
			this.BtnCustList.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustList.ImageClick")));
			this.BtnCustList.ImageClickIndex = 1;
			this.BtnCustList.ImageIndex = 0;
			this.BtnCustList.ImageList = this.ButtonLiteImgList;
			this.BtnCustList.Location = new System.Drawing.Point(466, 32);
			this.BtnCustList.Name = "BtnCustList";
			this.BtnCustList.ObjectValue = null;
			this.BtnCustList.Red = 2F;
			this.BtnCustList.Size = new System.Drawing.Size(110, 40);
			this.BtnCustList.TabIndex = 48;
			this.BtnCustList.Text = "List All";
			this.BtnCustList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustList.Click += new System.EventHandler(this.BtnCustList_Click);
			// 
			// BtnCustSearch
			// 
			this.BtnCustSearch.BackColor = System.Drawing.Color.Transparent;
			this.BtnCustSearch.Blue = 1F;
			this.BtnCustSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCustSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnCustSearch.Green = 1F;
			this.BtnCustSearch.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustSearch.Image")));
			this.BtnCustSearch.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCustSearch.ImageClick")));
			this.BtnCustSearch.ImageClickIndex = 1;
			this.BtnCustSearch.ImageIndex = 0;
			this.BtnCustSearch.ImageList = this.ButtonLiteImgList;
			this.BtnCustSearch.Location = new System.Drawing.Point(354, 32);
			this.BtnCustSearch.Name = "BtnCustSearch";
			this.BtnCustSearch.ObjectValue = null;
			this.BtnCustSearch.Red = 2F;
			this.BtnCustSearch.Size = new System.Drawing.Size(110, 40);
			this.BtnCustSearch.TabIndex = 47;
			this.BtnCustSearch.Text = "Search";
			this.BtnCustSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustSearch.Click += new System.EventHandler(this.BtnCustSearch_Click);
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
			this.BtnCustDown.Location = new System.Drawing.Point(576, 480);
			this.BtnCustDown.Name = "BtnCustDown";
			this.BtnCustDown.ObjectValue = null;
			this.BtnCustDown.Red = 2F;
			this.BtnCustDown.Size = new System.Drawing.Size(110, 60);
			this.BtnCustDown.TabIndex = 46;
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
			this.BtnCustUp.Location = new System.Drawing.Point(360, 480);
			this.BtnCustUp.Name = "BtnCustUp";
			this.BtnCustUp.ObjectValue = null;
			this.BtnCustUp.Red = 2F;
			this.BtnCustUp.Size = new System.Drawing.Size(110, 60);
			this.BtnCustUp.TabIndex = 45;
			this.BtnCustUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCustUp.Click += new System.EventHandler(this.BtnCustUp_Click);
			// 
			// PanCustField
			// 
			this.PanCustField.BackColor = System.Drawing.Color.Transparent;
			this.PanCustField.Caption = null;
			this.PanCustField.Controls.AddRange(new System.Windows.Forms.Control[] {
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
																					   this.NumberKeyPad,
																					   this.BtnSave,
																					   this.BtnClear});
			this.PanCustField.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.PanCustField.Location = new System.Drawing.Point(8, 32);
			this.PanCustField.Name = "PanCustField";
			this.PanCustField.ShowHeader = false;
			this.PanCustField.Size = new System.Drawing.Size(344, 576);
			this.PanCustField.TabIndex = 43;
			// 
			// FieldMemo
			// 
			this.FieldMemo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldMemo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldMemo.Location = new System.Drawing.Point(96, 216);
			this.FieldMemo.Name = "FieldMemo";
			this.FieldMemo.Size = new System.Drawing.Size(232, 40);
			this.FieldMemo.TabIndex = 34;
			this.FieldMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldMemo.Click += new System.EventHandler(this.FieldMemo_Click);
			// 
			// FieldAddress
			// 
			this.FieldAddress.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldAddress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldAddress.Location = new System.Drawing.Point(96, 168);
			this.FieldAddress.Name = "FieldAddress";
			this.FieldAddress.Size = new System.Drawing.Size(232, 48);
			this.FieldAddress.TabIndex = 33;
			this.FieldAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldAddress.Click += new System.EventHandler(this.FieldAddress_Click);
			// 
			// FieldLName
			// 
			this.FieldLName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldLName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldLName.Location = new System.Drawing.Point(96, 128);
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
			this.FieldMName.Location = new System.Drawing.Point(96, 88);
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
			this.FieldFName.Location = new System.Drawing.Point(96, 48);
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
			this.FieldPhone.Location = new System.Drawing.Point(96, 8);
			this.FieldPhone.Name = "FieldPhone";
			this.FieldPhone.Size = new System.Drawing.Size(232, 40);
			this.FieldPhone.TabIndex = 29;
			this.FieldPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblAddress
			// 
			this.LblAddress.Location = new System.Drawing.Point(16, 168);
			this.LblAddress.Name = "LblAddress";
			this.LblAddress.Size = new System.Drawing.Size(80, 40);
			this.LblAddress.TabIndex = 24;
			this.LblAddress.Text = "Address";
			this.LblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblMemo
			// 
			this.LblMemo.Location = new System.Drawing.Point(16, 216);
			this.LblMemo.Name = "LblMemo";
			this.LblMemo.Size = new System.Drawing.Size(80, 40);
			this.LblMemo.TabIndex = 22;
			this.LblMemo.Text = "Memo";
			this.LblMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblLName
			// 
			this.LblLName.Location = new System.Drawing.Point(16, 128);
			this.LblLName.Name = "LblLName";
			this.LblLName.Size = new System.Drawing.Size(80, 40);
			this.LblLName.TabIndex = 20;
			this.LblLName.Text = "L.Name";
			this.LblLName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblMName
			// 
			this.LblMName.Location = new System.Drawing.Point(16, 88);
			this.LblMName.Name = "LblMName";
			this.LblMName.Size = new System.Drawing.Size(80, 40);
			this.LblMName.TabIndex = 19;
			this.LblMName.Text = "M.Name";
			this.LblMName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblFName
			// 
			this.LblFName.Location = new System.Drawing.Point(16, 48);
			this.LblFName.Name = "LblFName";
			this.LblFName.Size = new System.Drawing.Size(80, 40);
			this.LblFName.TabIndex = 18;
			this.LblFName.Text = "F.Name";
			this.LblFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblPhone
			// 
			this.LblPhone.Location = new System.Drawing.Point(16, 8);
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
			this.NumberKeyPad.Location = new System.Drawing.Point(64, 312);
			this.NumberKeyPad.Name = "NumberKeyPad";
			this.NumberKeyPad.Size = new System.Drawing.Size(226, 255);
			this.NumberKeyPad.TabIndex = 7;
			this.NumberKeyPad.Text = "numberPad1";
			this.NumberKeyPad.PadClick += new smartRestaurant.Controls.NumberPadEventHandler(this.NumberKeyPad_PadClick);
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
			this.BtnSave.Location = new System.Drawing.Point(216, 264);
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
			this.BtnClear.Location = new System.Drawing.Point(16, 264);
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.ObjectValue = null;
			this.BtnClear.Red = 1F;
			this.BtnClear.Size = new System.Drawing.Size(110, 40);
			this.BtnClear.TabIndex = 35;
			this.BtnClear.Text = "Clear";
			this.BtnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
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
			this.BtnDelete.Location = new System.Drawing.Point(578, 32);
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
			// BtnOk
			// 
			this.BtnOk.BackColor = System.Drawing.Color.Transparent;
			this.BtnOk.Blue = 1.75F;
			this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnOk.Green = 1F;
			this.BtnOk.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnOk.Image")));
			this.BtnOk.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnOk.ImageClick")));
			this.BtnOk.ImageClickIndex = 1;
			this.BtnOk.ImageIndex = 0;
			this.BtnOk.ImageList = this.ButtonImgList;
			this.BtnOk.Location = new System.Drawing.Point(464, 544);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.ObjectValue = null;
			this.BtnOk.Red = 1.75F;
			this.BtnOk.Size = new System.Drawing.Size(112, 60);
			this.BtnOk.TabIndex = 42;
			this.BtnOk.Text = "OK";
			this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
			this.BtnCancel.Blue = 2F;
			this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnCancel.Green = 2F;
			this.BtnCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.Image")));
			this.BtnCancel.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.ImageClick")));
			this.BtnCancel.ImageClickIndex = 1;
			this.BtnCancel.ImageIndex = 0;
			this.BtnCancel.ImageList = this.ButtonImgList;
			this.BtnCancel.Location = new System.Drawing.Point(576, 544);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.ObjectValue = null;
			this.BtnCancel.Red = 1F;
			this.BtnCancel.Size = new System.Drawing.Size(110, 60);
			this.BtnCancel.TabIndex = 41;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// SearchCustomerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 23);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(704, 616);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ListCustName,
																		  this.ListCustPhone,
																		  this.LblHeaderName,
																		  this.LblHeaderPhone,
																		  this.BtnCustList,
																		  this.BtnCustSearch,
																		  this.BtnCustDown,
																		  this.BtnCustUp,
																		  this.PanCustField,
																		  this.BtnOk,
																		  this.BtnCancel,
																		  this.BtnDelete});
			this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SearchCustomerForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search Customer";
			this.PanCustField.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		/// <summary>
		/// Property for set customer name to class or get customer name from dialog result.
		/// </summary>
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
		#endregion

		#region Customer Management
		/// <summary>
		/// This method use for clear all customer field.
		/// </summary>
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
		/// <summary>
		/// First method to process when show this form. If customer name's first name
		/// already define, this method will search that customer name from customer list
		/// via BtnCustSearch_Click() method. But if customer name's first name is not define,
		/// this method will show all customer list via BtnCustList_Click().
		/// </summary>
		public void UpdateForm()
		{
			if (FieldFName.Text == "")
				BtnCustList_Click(null, null);
			else
				BtnCustSearch_Click(null, null);
		}

		/// <summary>
		/// This method use for show customer list
		/// </summary>
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

		/// <summary>
		/// This method use for show customer information in field from selected customer.
		/// </summary>
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

		/// <summary>
		/// This method use for update button status. Depend on customer field.
		/// </summary>
		private void UpdateCustomerButton()
		{
			BtnOk.Enabled = (FieldFName.Text != "");
			BtnSave.Enabled = (FieldFName.Text != "");
			BtnDelete.Enabled = (selectedCust != null);
			BtnCustSearch.Enabled = (FieldPhone.Text != "" || FieldFName.Text != "" || 
				FieldMName.Text != "" || FieldLName.Text != "");
			// Update enabled for up/down button
			BtnCustUp.Enabled = ListCustPhone.CanUp;
			BtnCustDown.Enabled = ListCustPhone.CanDown;
		}

		/*private void StartInputMessage()
		{
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
			BtnCancel.Enabled = false;
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
		}*/
		#endregion

		/// <summary>
		/// (Override) This method use for draw border and title for this dialog.
		/// </summary>
		/// <param name="pe">Paint Event object</param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;

			Rectangle rect = new Rectangle(0, 0, this.Width, 29);
			LinearGradientBrush gBrush = new LinearGradientBrush(
				rect,
				Color.FromArgb(103, 138, 198),
				Color.White, 90f);
			g.FillRectangle(gBrush, rect);

			rect = new Rectangle(0, 30, this.Width, this.Height - 30);
			gBrush = new LinearGradientBrush(
				rect,
				Color.FromArgb(230, 230, 230),
				Color.White, 180f);
			g.FillRectangle(gBrush, rect);

			Pen grayPen = new Pen(Color.FromArgb(180, 180, 180));
			g.DrawLine(grayPen, 0, 29, this.Width - 1, 29);
			g.DrawRectangle(grayPen, 0, 0, this.Width - 1, this.Height - 1);

			g.DrawString(this.Text, this.Font, Brushes.Black, 15f, 4f);
			base.OnPaint(pe);
		}

		/// <summary>
		/// This method use for create SearchCustomerForm if never create, else use
		/// old instance. After that will call UpdateForm() and show this form as dialog
		/// (ShowDialog() method). When dialog is close, will return customer name.
		/// </summary>
		/// <param name="customer">Input customer name for search or edit.</param>
		/// <returns>Selected customer name.</returns>
		public static string Show(string customer)
		{
			if (instance == null)
			{
				instance = new SearchCustomerForm();
			}
			instance.CustomerName = customer;
			instance.UpdateForm();
			instance.ShowDialog();
			if (instance.dialogResult)
				return instance.CustomerName.Trim();
			return null;
		}

		/// <summary>
		/// Check input state and put result from keyboard to that field.
		/// </summary>
		/// <param name="result">Input result from keyboard.</param>
		private void CheckKeyboardOutput(string result)
		{
			if (result != null)
			{
				switch (inputState)
				{
					case INPUT_FIRSTNAME:
						FieldFName.Text = result;
						break;
					case INPUT_MIDDLENAME:
						FieldMName.Text = result;
						break;
					case INPUT_LASTNAME:
						FieldLName.Text = result;
						break;
					case INPUT_ADDRESS:
						FieldAddress.Text = result;
						break;
					case INPUT_MEMO:
						FieldMemo.Text = result;
						break;
				}
				UpdateCustomerButton();
			}
		}

		/// <summary>
		/// When user click OK button, this method will close dialog and set status for <i>dialogResult</i> to true.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			dialogResult = true;
			instance.Close();
		}

		/// <summary>
		/// When user click Cancel button, this method will close dialog and set status for <i>dialogResult</i> to false.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			dialogResult = false;
			instance.Close();
		}

		/// <summary>
		/// User click down button for change customer list page down.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnCustDown_Click(object sender, System.EventArgs e)
		{
			ListCustPhone.Down(5);
			UpdateCustomerButton();
		}

		/// <summary>
		/// User click up button for change customer list page up.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnCustUp_Click(object sender, System.EventArgs e)
		{
			ListCustPhone.Up(5);
			UpdateCustomerButton();
		}

		/// <summary>
		/// When user fill some information for customer field and click Search button, this method will work.
		/// And this method will search object from customer list and put information in customer field
		/// with UpdateCustomerField() method.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
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

		/// <summary>
		/// This method work when user select customer from customer list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
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

		/// <summary>
		/// This method work when user click on Clear button and this method will clear all
		/// field and show all customer in customer list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnClear_Click(object sender, System.EventArgs e)
		{
			ClearCustomer();
			UpdateCustomerButton();
		}

		/// <summary>
		/// When user edit customer information or create new customer and click save,
		/// this method will send information to database via CustomerService.SetCustomer().
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
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

		/// <summary>
		/// When user select customer from list and click delete button, this method will
		/// send delete command though CustomerService.DeleteCustomer().
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// This method work when user click on Number Key Pad and will send number to Phone field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
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

		/// <summary>
		/// This method will show keyboard and set input state to INPUT_FIRSTNAME
		/// when customer click on First Name field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldFName_Click(object sender, System.EventArgs e)
		{
			inputState = INPUT_FIRSTNAME;
			CheckKeyboardOutput(KeyboardForm.Show("First Name", FieldFName.Text));
		}

		/// <summary>
		/// This method will show keyboard and set input state to INPUT_MIDDLENAME
		/// when customer click on Middle Name field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldMName_Click(object sender, System.EventArgs e)
		{
			inputState = INPUT_MIDDLENAME;
			CheckKeyboardOutput(KeyboardForm.Show("Middle Name", FieldMName.Text));
		}

		/// <summary>
		/// This method will show keyboard and set input state to INPUT_LASTNAME
		/// when customer click on Last Name field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldLName_Click(object sender, System.EventArgs e)
		{
			inputState = INPUT_LASTNAME;
			CheckKeyboardOutput(KeyboardForm.Show("Last Name", FieldLName.Text));
		}

		/// <summary>
		/// This method will show keyboard and set input state to INPUT_ADDRESS
		/// when customer click on Address field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldAddress_Click(object sender, System.EventArgs e)
		{
			inputState = INPUT_ADDRESS;
			CheckKeyboardOutput(KeyboardForm.Show("Address", FieldAddress.Text));
		}

		/// <summary>
		/// This method will show keyboard and set input state to INPUT_MEMO
		/// when customer click on Memo field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldMemo_Click(object sender, System.EventArgs e)
		{
			inputState = INPUT_MEMO;
			CheckKeyboardOutput(KeyboardForm.Show("Memo", FieldMemo.Text));
		}

		/// <summary>
		/// This method work when user click at Customer Phone Field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void ListCustPhone_ItemClick(object sender, smartRestaurant.Controls.ItemsListEventArgs e)
		{
			if (e.Item.Value is CustomerService.CustomerInformation)
			{
				selectedCust = (CustomerService.CustomerInformation)e.Item.Value;
				UpdateCustomerField();
			}
		}
	}
}
