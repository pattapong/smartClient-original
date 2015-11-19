using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Controls;
using smartRestaurant.ReserveService;
using smartRestaurant.Utils;

namespace smartRestaurant
{
	/// <summary>
	/// Summary description for ReserveForm.
	/// </summary>
	public class ReserveForm : SmartForm
	{
		private static string FIELD_CUST_TEXT = "- Please input name -";

		private smartRestaurant.Controls.ImageButton BtnSearch;
		private smartRestaurant.Controls.GroupPanel PanCustName;
		private System.Windows.Forms.Label FieldCustName;
		private System.Windows.Forms.ImageList ButtonImgList;
		private System.Windows.Forms.ImageList NumberImgList;
		private System.Windows.Forms.Label LblCopyright;
		private smartRestaurant.Controls.ImageButton BtnDown;
		private smartRestaurant.Controls.ImageButton BtnUp;
		private smartRestaurant.Controls.ImageButton BtnMain;
		private System.Windows.Forms.Label LblHeaderCustomer;
		private smartRestaurant.Controls.ItemsList ListReserveQueue;
		private smartRestaurant.Controls.ImageButton BtnDinIn;
		private smartRestaurant.Controls.ImageButton BtnReserve;
		private smartRestaurant.Controls.ImageButton BtnCancel;
		private System.Windows.Forms.Label LblHeaderSeat;
		private smartRestaurant.Controls.ItemsList ListReserveSeat;
		private System.Windows.Forms.Label LblHeaderTime;
		private smartRestaurant.Controls.ItemsList ListReserveTime;
		private System.Windows.Forms.Label LblPageID;
		private smartRestaurant.Controls.GroupPanel groupPanel2;
		private System.Windows.Forms.Label FieldInputType;
		private smartRestaurant.Controls.NumberPad NumberKeyPad;
		private smartRestaurant.Controls.ButtonListPad HourPad;
		private smartRestaurant.Controls.GroupPanel PanSelectTime;
		private smartRestaurant.Controls.ButtonListPad MinutePad;
		private System.Windows.Forms.Label LblHeaderHour;
		private System.Windows.Forms.Label LblMinute;
		private smartRestaurant.Controls.ImageButton BtnDayDown;
		private smartRestaurant.Controls.ImageButton BtnDayUp;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label LblCustName;
		private System.Windows.Forms.Label LblReserveInfo;
		private System.Windows.Forms.Label LblSelectedDate;
		private smartRestaurant.Controls.ButtonListPad DatePad;
		private smartRestaurant.Controls.GroupPanel GroupDate;
		private System.Windows.Forms.ImageList ButtonLiteImgList;
		private smartRestaurant.Controls.ImageButton BtnGotoToday;
		private System.Windows.Forms.Label FieldSeat;

		private static CultureInfo culture = new CultureInfo("en-US");

		private int		employeeID;

		private DateTime		startDate;
		private DateTime		selectedDate;
		private TableReserve[]	reserveList;
		private smartRestaurant.Controls.ItemsList ListReserveID;
		private System.Windows.Forms.Label LblHeaderNumber;
		private TableReserve	selectedReserve;

		public ReserveForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			UpdateTimeButton();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReserveForm));
			this.BtnSearch = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.PanCustName = new smartRestaurant.Controls.GroupPanel();
			this.FieldCustName = new System.Windows.Forms.Label();
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.LblCopyright = new System.Windows.Forms.Label();
			this.LblHeaderCustomer = new System.Windows.Forms.Label();
			this.BtnDown = new smartRestaurant.Controls.ImageButton();
			this.BtnUp = new smartRestaurant.Controls.ImageButton();
			this.ListReserveQueue = new smartRestaurant.Controls.ItemsList();
			this.ListReserveTime = new smartRestaurant.Controls.ItemsList();
			this.ListReserveID = new smartRestaurant.Controls.ItemsList();
			this.ListReserveSeat = new smartRestaurant.Controls.ItemsList();
			this.BtnDinIn = new smartRestaurant.Controls.ImageButton();
			this.BtnMain = new smartRestaurant.Controls.ImageButton();
			this.BtnReserve = new smartRestaurant.Controls.ImageButton();
			this.BtnCancel = new smartRestaurant.Controls.ImageButton();
			this.LblHeaderSeat = new System.Windows.Forms.Label();
			this.LblHeaderTime = new System.Windows.Forms.Label();
			this.LblPageID = new System.Windows.Forms.Label();
			this.PanSelectTime = new smartRestaurant.Controls.GroupPanel();
			this.LblMinute = new System.Windows.Forms.Label();
			this.LblHeaderHour = new System.Windows.Forms.Label();
			this.MinutePad = new smartRestaurant.Controls.ButtonListPad();
			this.HourPad = new smartRestaurant.Controls.ButtonListPad();
			this.groupPanel2 = new smartRestaurant.Controls.GroupPanel();
			this.BtnGotoToday = new smartRestaurant.Controls.ImageButton();
			this.ButtonLiteImgList = new System.Windows.Forms.ImageList(this.components);
			this.LblSelectedDate = new System.Windows.Forms.Label();
			this.LblCustName = new System.Windows.Forms.Label();
			this.FieldSeat = new System.Windows.Forms.Label();
			this.FieldInputType = new System.Windows.Forms.Label();
			this.NumberKeyPad = new smartRestaurant.Controls.NumberPad();
			this.LblReserveInfo = new System.Windows.Forms.Label();
			this.DatePad = new smartRestaurant.Controls.ButtonListPad();
			this.BtnDayDown = new smartRestaurant.Controls.ImageButton();
			this.BtnDayUp = new smartRestaurant.Controls.ImageButton();
			this.GroupDate = new smartRestaurant.Controls.GroupPanel();
			this.LblHeaderNumber = new System.Windows.Forms.Label();
			this.PanCustName.SuspendLayout();
			this.PanSelectTime.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			this.GroupDate.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnSearch
			// 
			this.BtnSearch.BackColor = System.Drawing.Color.Transparent;
			this.BtnSearch.Blue = 0.5F;
			this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnSearch.Green = 1F;
			this.BtnSearch.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnSearch.Image")));
			this.BtnSearch.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnSearch.ImageClick")));
			this.BtnSearch.ImageClickIndex = 1;
			this.BtnSearch.ImageIndex = 0;
			this.BtnSearch.ImageList = this.ButtonImgList;
			this.BtnSearch.Location = new System.Drawing.Point(216, 176);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.ObjectValue = null;
			this.BtnSearch.Red = 1F;
			this.BtnSearch.Size = new System.Drawing.Size(110, 60);
			this.BtnSearch.TabIndex = 26;
			this.BtnSearch.Text = "Search";
			this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// PanCustName
			// 
			this.PanCustName.BackColor = System.Drawing.Color.Transparent;
			this.PanCustName.Caption = null;
			this.PanCustName.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.FieldCustName});
			this.PanCustName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.PanCustName.Location = new System.Drawing.Point(16, 112);
			this.PanCustName.Name = "PanCustName";
			this.PanCustName.ShowHeader = false;
			this.PanCustName.Size = new System.Drawing.Size(312, 58);
			this.PanCustName.TabIndex = 25;
			// 
			// FieldCustName
			// 
			this.FieldCustName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldCustName.Location = new System.Drawing.Point(1, 1);
			this.FieldCustName.Name = "FieldCustName";
			this.FieldCustName.Size = new System.Drawing.Size(311, 56);
			this.FieldCustName.TabIndex = 0;
			this.FieldCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldCustName.Click += new System.EventHandler(this.FieldCustName_Click);
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// LblCopyright
			// 
			this.LblCopyright.BackColor = System.Drawing.Color.Transparent;
			this.LblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblCopyright.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblCopyright.Location = new System.Drawing.Point(8, 752);
			this.LblCopyright.Name = "LblCopyright";
			this.LblCopyright.Size = new System.Drawing.Size(280, 16);
			this.LblCopyright.TabIndex = 51;
			this.LblCopyright.Text = "Copyright (c) 2004. All rights reserved.";
			// 
			// LblHeaderCustomer
			// 
			this.LblHeaderCustomer.BackColor = System.Drawing.Color.Black;
			this.LblHeaderCustomer.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderCustomer.ForeColor = System.Drawing.Color.White;
			this.LblHeaderCustomer.Location = new System.Drawing.Point(64, 192);
			this.LblHeaderCustomer.Name = "LblHeaderCustomer";
			this.LblHeaderCustomer.Size = new System.Drawing.Size(168, 40);
			this.LblHeaderCustomer.TabIndex = 50;
			this.LblHeaderCustomer.Text = "Customer";
			this.LblHeaderCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.BtnDown.TabIndex = 49;
			this.BtnDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.BtnUp.TabIndex = 48;
			this.BtnUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ListReserveQueue
			// 
			this.ListReserveQueue.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.ListReserveQueue.AutoRefresh = true;
			this.ListReserveQueue.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListReserveQueue.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListReserveQueue.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListReserveQueue.BackNormalColor = System.Drawing.Color.White;
			this.ListReserveQueue.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListReserveQueue.BindList1 = this.ListReserveTime;
			this.ListReserveQueue.BindList2 = this.ListReserveID;
			this.ListReserveQueue.Border = 0;
			this.ListReserveQueue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListReserveQueue.ForeAlterColor = System.Drawing.Color.Black;
			this.ListReserveQueue.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListReserveQueue.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListReserveQueue.ForeNormalColor = System.Drawing.Color.Black;
			this.ListReserveQueue.ForeSelectedColor = System.Drawing.Color.White;
			this.ListReserveQueue.ItemHeight = 40;
			this.ListReserveQueue.ItemWidth = 168;
			this.ListReserveQueue.Location = new System.Drawing.Point(64, 232);
			this.ListReserveQueue.Name = "ListReserveQueue";
			this.ListReserveQueue.Row = 11;
			this.ListReserveQueue.SelectedIndex = 0;
			this.ListReserveQueue.Size = new System.Drawing.Size(168, 440);
			this.ListReserveQueue.TabIndex = 47;
			this.ListReserveQueue.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListReserveTime_ItemClick);
			// 
			// ListReserveTime
			// 
			this.ListReserveTime.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.ListReserveTime.AutoRefresh = true;
			this.ListReserveTime.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListReserveTime.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListReserveTime.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListReserveTime.BackNormalColor = System.Drawing.Color.White;
			this.ListReserveTime.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListReserveTime.BindList1 = null;
			this.ListReserveTime.BindList2 = this.ListReserveQueue;
			this.ListReserveTime.Border = 0;
			this.ListReserveTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListReserveTime.ForeAlterColor = System.Drawing.Color.Black;
			this.ListReserveTime.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListReserveTime.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListReserveTime.ForeNormalColor = System.Drawing.Color.Black;
			this.ListReserveTime.ForeSelectedColor = System.Drawing.Color.White;
			this.ListReserveTime.ItemHeight = 40;
			this.ListReserveTime.ItemWidth = 56;
			this.ListReserveTime.Location = new System.Drawing.Point(8, 232);
			this.ListReserveTime.Name = "ListReserveTime";
			this.ListReserveTime.Row = 11;
			this.ListReserveTime.SelectedIndex = 0;
			this.ListReserveTime.Size = new System.Drawing.Size(56, 440);
			this.ListReserveTime.TabIndex = 57;
			this.ListReserveTime.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListReserveTime_ItemClick);
			// 
			// ListReserveID
			// 
			this.ListReserveID.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.ListReserveID.AutoRefresh = true;
			this.ListReserveID.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListReserveID.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListReserveID.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListReserveID.BackNormalColor = System.Drawing.Color.White;
			this.ListReserveID.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListReserveID.BindList1 = this.ListReserveQueue;
			this.ListReserveID.BindList2 = this.ListReserveSeat;
			this.ListReserveID.Border = 0;
			this.ListReserveID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListReserveID.ForeAlterColor = System.Drawing.Color.Black;
			this.ListReserveID.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListReserveID.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListReserveID.ForeNormalColor = System.Drawing.Color.Black;
			this.ListReserveID.ForeSelectedColor = System.Drawing.Color.White;
			this.ListReserveID.ItemHeight = 40;
			this.ListReserveID.ItemWidth = 48;
			this.ListReserveID.Location = new System.Drawing.Point(232, 232);
			this.ListReserveID.Name = "ListReserveID";
			this.ListReserveID.Row = 11;
			this.ListReserveID.SelectedIndex = 0;
			this.ListReserveID.Size = new System.Drawing.Size(48, 440);
			this.ListReserveID.TabIndex = 63;
			this.ListReserveID.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListReserveTime_ItemClick);
			// 
			// ListReserveSeat
			// 
			this.ListReserveSeat.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.ListReserveSeat.AutoRefresh = true;
			this.ListReserveSeat.BackAlterColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ListReserveSeat.BackHeaderColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.ListReserveSeat.BackHeaderSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ListReserveSeat.BackNormalColor = System.Drawing.Color.White;
			this.ListReserveSeat.BackSelectedColor = System.Drawing.Color.Blue;
			this.ListReserveSeat.BindList1 = this.ListReserveID;
			this.ListReserveSeat.BindList2 = null;
			this.ListReserveSeat.Border = 0;
			this.ListReserveSeat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ListReserveSeat.ForeAlterColor = System.Drawing.Color.Black;
			this.ListReserveSeat.ForeHeaderColor = System.Drawing.Color.Black;
			this.ListReserveSeat.ForeHeaderSelectedColor = System.Drawing.Color.White;
			this.ListReserveSeat.ForeNormalColor = System.Drawing.Color.Black;
			this.ListReserveSeat.ForeSelectedColor = System.Drawing.Color.White;
			this.ListReserveSeat.ItemHeight = 40;
			this.ListReserveSeat.ItemWidth = 48;
			this.ListReserveSeat.Location = new System.Drawing.Point(280, 232);
			this.ListReserveSeat.Name = "ListReserveSeat";
			this.ListReserveSeat.Row = 11;
			this.ListReserveSeat.SelectedIndex = 0;
			this.ListReserveSeat.Size = new System.Drawing.Size(48, 440);
			this.ListReserveSeat.TabIndex = 55;
			this.ListReserveSeat.ItemClick += new smartRestaurant.Controls.ItemsListEventHandler(this.ListReserveTime_ItemClick);
			// 
			// BtnDinIn
			// 
			this.BtnDinIn.BackColor = System.Drawing.Color.Transparent;
			this.BtnDinIn.Blue = 2F;
			this.BtnDinIn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDinIn.Green = 1F;
			this.BtnDinIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnDinIn.Image")));
			this.BtnDinIn.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnDinIn.ImageClick")));
			this.BtnDinIn.ImageClickIndex = 1;
			this.BtnDinIn.ImageIndex = 0;
			this.BtnDinIn.ImageList = this.ButtonImgList;
			this.BtnDinIn.Location = new System.Drawing.Point(8, 64);
			this.BtnDinIn.Name = "BtnDinIn";
			this.BtnDinIn.ObjectValue = null;
			this.BtnDinIn.Red = 2F;
			this.BtnDinIn.Size = new System.Drawing.Size(110, 60);
			this.BtnDinIn.TabIndex = 46;
			this.BtnDinIn.Text = "Din-in";
			this.BtnDinIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDinIn.Click += new System.EventHandler(this.BtnDinIn_Click);
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
			this.BtnMain.TabIndex = 52;
			this.BtnMain.Text = "Main";
			this.BtnMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnMain.Click += new System.EventHandler(this.BtnMain_Click);
			// 
			// BtnReserve
			// 
			this.BtnReserve.BackColor = System.Drawing.Color.Transparent;
			this.BtnReserve.Blue = 1F;
			this.BtnReserve.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnReserve.Green = 1F;
			this.BtnReserve.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnReserve.Image")));
			this.BtnReserve.ImageClick = null;
			this.BtnReserve.ImageClickIndex = 0;
			this.BtnReserve.ImageIndex = 0;
			this.BtnReserve.ImageList = this.ButtonImgList;
			this.BtnReserve.Location = new System.Drawing.Point(904, 64);
			this.BtnReserve.Name = "BtnReserve";
			this.BtnReserve.ObjectValue = null;
			this.BtnReserve.Red = 0.75F;
			this.BtnReserve.Size = new System.Drawing.Size(110, 60);
			this.BtnReserve.TabIndex = 53;
			this.BtnReserve.Text = "Reserve";
			this.BtnReserve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnReserve.Click += new System.EventHandler(this.BtnReserve_Click);
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
			this.BtnCancel.Location = new System.Drawing.Point(120, 64);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.ObjectValue = null;
			this.BtnCancel.Red = 2F;
			this.BtnCancel.Size = new System.Drawing.Size(110, 60);
			this.BtnCancel.TabIndex = 54;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// LblHeaderSeat
			// 
			this.LblHeaderSeat.BackColor = System.Drawing.Color.Black;
			this.LblHeaderSeat.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderSeat.ForeColor = System.Drawing.Color.White;
			this.LblHeaderSeat.Location = new System.Drawing.Point(280, 192);
			this.LblHeaderSeat.Name = "LblHeaderSeat";
			this.LblHeaderSeat.Size = new System.Drawing.Size(48, 40);
			this.LblHeaderSeat.TabIndex = 56;
			this.LblHeaderSeat.Text = "Seat";
			this.LblHeaderSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblHeaderTime
			// 
			this.LblHeaderTime.BackColor = System.Drawing.Color.Black;
			this.LblHeaderTime.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderTime.ForeColor = System.Drawing.Color.White;
			this.LblHeaderTime.Location = new System.Drawing.Point(8, 192);
			this.LblHeaderTime.Name = "LblHeaderTime";
			this.LblHeaderTime.Size = new System.Drawing.Size(56, 40);
			this.LblHeaderTime.TabIndex = 58;
			this.LblHeaderTime.Text = "Time";
			this.LblHeaderTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblPageID
			// 
			this.LblPageID.BackColor = System.Drawing.Color.Transparent;
			this.LblPageID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblPageID.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblPageID.Location = new System.Drawing.Point(760, 752);
			this.LblPageID.Name = "LblPageID";
			this.LblPageID.Size = new System.Drawing.Size(248, 23);
			this.LblPageID.TabIndex = 61;
			this.LblPageID.Text = "STRT010";
			this.LblPageID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// PanSelectTime
			// 
			this.PanSelectTime.BackColor = System.Drawing.Color.Transparent;
			this.PanSelectTime.Caption = null;
			this.PanSelectTime.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.LblMinute,
																						this.LblHeaderHour,
																						this.MinutePad,
																						this.HourPad});
			this.PanSelectTime.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.PanSelectTime.Location = new System.Drawing.Point(672, 192);
			this.PanSelectTime.Name = "PanSelectTime";
			this.PanSelectTime.ShowHeader = false;
			this.PanSelectTime.Size = new System.Drawing.Size(344, 560);
			this.PanSelectTime.TabIndex = 60;
			// 
			// LblMinute
			// 
			this.LblMinute.BackColor = System.Drawing.Color.Black;
			this.LblMinute.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblMinute.ForeColor = System.Drawing.Color.White;
			this.LblMinute.Location = new System.Drawing.Point(0, 424);
			this.LblMinute.Name = "LblMinute";
			this.LblMinute.Size = new System.Drawing.Size(344, 40);
			this.LblMinute.TabIndex = 52;
			this.LblMinute.Text = "Minute";
			this.LblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblHeaderHour
			// 
			this.LblHeaderHour.BackColor = System.Drawing.Color.Black;
			this.LblHeaderHour.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderHour.ForeColor = System.Drawing.Color.White;
			this.LblHeaderHour.Name = "LblHeaderHour";
			this.LblHeaderHour.Size = new System.Drawing.Size(344, 40);
			this.LblHeaderHour.TabIndex = 51;
			this.LblHeaderHour.Text = "Hour";
			this.LblHeaderHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MinutePad
			// 
			this.MinutePad.AutoRefresh = true;
			this.MinutePad.BackColor = System.Drawing.Color.White;
			this.MinutePad.Blue = 1F;
			this.MinutePad.Column = 4;
			this.MinutePad.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.MinutePad.Green = 1F;
			this.MinutePad.Image = ((System.Drawing.Bitmap)(resources.GetObject("MinutePad.Image")));
			this.MinutePad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("MinutePad.ImageClick")));
			this.MinutePad.ImageClickIndex = 1;
			this.MinutePad.ImageIndex = 0;
			this.MinutePad.ImageList = this.NumberImgList;
			this.MinutePad.Location = new System.Drawing.Point(28, 472);
			this.MinutePad.Name = "MinutePad";
			this.MinutePad.Padding = 1;
			this.MinutePad.Red = 1F;
			this.MinutePad.Row = 1;
			this.MinutePad.Size = new System.Drawing.Size(291, 60);
			this.MinutePad.TabIndex = 6;
			this.MinutePad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.MinutePad_PadClick);
			// 
			// HourPad
			// 
			this.HourPad.AutoRefresh = true;
			this.HourPad.BackColor = System.Drawing.Color.White;
			this.HourPad.Blue = 1F;
			this.HourPad.Column = 4;
			this.HourPad.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.HourPad.Green = 1F;
			this.HourPad.Image = ((System.Drawing.Bitmap)(resources.GetObject("HourPad.Image")));
			this.HourPad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("HourPad.ImageClick")));
			this.HourPad.ImageClickIndex = 1;
			this.HourPad.ImageIndex = 0;
			this.HourPad.ImageList = this.NumberImgList;
			this.HourPad.Location = new System.Drawing.Point(28, 48);
			this.HourPad.Name = "HourPad";
			this.HourPad.Padding = 1;
			this.HourPad.Red = 1F;
			this.HourPad.Row = 6;
			this.HourPad.Size = new System.Drawing.Size(291, 365);
			this.HourPad.TabIndex = 5;
			this.HourPad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.HourPad_PadClick);
			// 
			// groupPanel2
			// 
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.Caption = null;
			this.groupPanel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.BtnGotoToday,
																					  this.LblSelectedDate,
																					  this.LblCustName,
																					  this.FieldSeat,
																					  this.FieldInputType,
																					  this.NumberKeyPad,
																					  this.BtnSearch,
																					  this.PanCustName,
																					  this.LblReserveInfo});
			this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel2.Location = new System.Drawing.Point(328, 192);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.ShowHeader = false;
			this.groupPanel2.Size = new System.Drawing.Size(344, 560);
			this.groupPanel2.TabIndex = 59;
			// 
			// BtnGotoToday
			// 
			this.BtnGotoToday.BackColor = System.Drawing.Color.Transparent;
			this.BtnGotoToday.Blue = 2F;
			this.BtnGotoToday.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnGotoToday.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.BtnGotoToday.Green = 1F;
			this.BtnGotoToday.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnGotoToday.Image")));
			this.BtnGotoToday.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnGotoToday.ImageClick")));
			this.BtnGotoToday.ImageClickIndex = 1;
			this.BtnGotoToday.ImageIndex = 0;
			this.BtnGotoToday.ImageList = this.ButtonLiteImgList;
			this.BtnGotoToday.Location = new System.Drawing.Point(224, 48);
			this.BtnGotoToday.Name = "BtnGotoToday";
			this.BtnGotoToday.ObjectValue = null;
			this.BtnGotoToday.Red = 1F;
			this.BtnGotoToday.Size = new System.Drawing.Size(110, 40);
			this.BtnGotoToday.TabIndex = 54;
			this.BtnGotoToday.Text = "Today";
			this.BtnGotoToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnGotoToday.Click += new System.EventHandler(this.BtnGotoToday_Click);
			// 
			// ButtonLiteImgList
			// 
			this.ButtonLiteImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonLiteImgList.ImageSize = new System.Drawing.Size(110, 40);
			this.ButtonLiteImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonLiteImgList.ImageStream")));
			this.ButtonLiteImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// LblSelectedDate
			// 
			this.LblSelectedDate.BackColor = System.Drawing.Color.Transparent;
			this.LblSelectedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LblSelectedDate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LblSelectedDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblSelectedDate.ForeColor = System.Drawing.Color.Black;
			this.LblSelectedDate.Location = new System.Drawing.Point(8, 48);
			this.LblSelectedDate.Name = "LblSelectedDate";
			this.LblSelectedDate.Size = new System.Drawing.Size(208, 40);
			this.LblSelectedDate.TabIndex = 53;
			this.LblSelectedDate.Text = "dd MMMM yyyy HH:mm";
			this.LblSelectedDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LblSelectedDate.Click += new System.EventHandler(this.LblSelectedDate_Click);
			// 
			// LblCustName
			// 
			this.LblCustName.BackColor = System.Drawing.Color.Transparent;
			this.LblCustName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblCustName.ForeColor = System.Drawing.Color.Black;
			this.LblCustName.Location = new System.Drawing.Point(16, 88);
			this.LblCustName.Name = "LblCustName";
			this.LblCustName.Size = new System.Drawing.Size(144, 24);
			this.LblCustName.TabIndex = 51;
			this.LblCustName.Text = "Customer Name";
			this.LblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FieldSeat
			// 
			this.FieldSeat.BackColor = System.Drawing.Color.Black;
			this.FieldSeat.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FieldSeat.ForeColor = System.Drawing.Color.Cyan;
			this.FieldSeat.Location = new System.Drawing.Point(136, 248);
			this.FieldSeat.Name = "FieldSeat";
			this.FieldSeat.Size = new System.Drawing.Size(200, 40);
			this.FieldSeat.TabIndex = 9;
			this.FieldSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FieldInputType
			// 
			this.FieldInputType.BackColor = System.Drawing.Color.Black;
			this.FieldInputType.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FieldInputType.ForeColor = System.Drawing.Color.Cyan;
			this.FieldInputType.Location = new System.Drawing.Point(8, 248);
			this.FieldInputType.Name = "FieldInputType";
			this.FieldInputType.Size = new System.Drawing.Size(128, 40);
			this.FieldInputType.TabIndex = 8;
			this.FieldInputType.Text = "Seat";
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
			this.NumberKeyPad.Location = new System.Drawing.Point(64, 296);
			this.NumberKeyPad.Name = "NumberKeyPad";
			this.NumberKeyPad.Size = new System.Drawing.Size(226, 255);
			this.NumberKeyPad.TabIndex = 7;
			this.NumberKeyPad.Text = "numberPad1";
			this.NumberKeyPad.PadClick += new smartRestaurant.Controls.NumberPadEventHandler(this.NumberKeyPad_PadClick);
			// 
			// LblReserveInfo
			// 
			this.LblReserveInfo.BackColor = System.Drawing.Color.Black;
			this.LblReserveInfo.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblReserveInfo.ForeColor = System.Drawing.Color.White;
			this.LblReserveInfo.Name = "LblReserveInfo";
			this.LblReserveInfo.Size = new System.Drawing.Size(344, 40);
			this.LblReserveInfo.TabIndex = 52;
			this.LblReserveInfo.Text = "Reserve Information";
			this.LblReserveInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DatePad
			// 
			this.DatePad.AutoRefresh = true;
			this.DatePad.BackColor = System.Drawing.Color.White;
			this.DatePad.Blue = 1F;
			this.DatePad.Column = 7;
			this.DatePad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.DatePad.Green = 1F;
			this.DatePad.Image = ((System.Drawing.Bitmap)(resources.GetObject("DatePad.Image")));
			this.DatePad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("DatePad.ImageClick")));
			this.DatePad.ImageClickIndex = 1;
			this.DatePad.ImageIndex = 0;
			this.DatePad.ImageList = this.ButtonImgList;
			this.DatePad.Location = new System.Drawing.Point(116, 2);
			this.DatePad.Name = "DatePad";
			this.DatePad.Padding = 1;
			this.DatePad.Red = 1F;
			this.DatePad.Row = 1;
			this.DatePad.Size = new System.Drawing.Size(776, 60);
			this.DatePad.TabIndex = 6;
			this.DatePad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.DatePad_PadClick);
			// 
			// BtnDayDown
			// 
			this.BtnDayDown.BackColor = System.Drawing.Color.Transparent;
			this.BtnDayDown.Blue = 2F;
			this.BtnDayDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDayDown.Green = 1F;
			this.BtnDayDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnDayDown.Image")));
			this.BtnDayDown.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnDayDown.ImageClick")));
			this.BtnDayDown.ImageClickIndex = 5;
			this.BtnDayDown.ImageIndex = 4;
			this.BtnDayDown.ImageList = this.ButtonImgList;
			this.BtnDayDown.Location = new System.Drawing.Point(893, 2);
			this.BtnDayDown.Name = "BtnDayDown";
			this.BtnDayDown.ObjectValue = null;
			this.BtnDayDown.Red = 1F;
			this.BtnDayDown.Size = new System.Drawing.Size(110, 60);
			this.BtnDayDown.TabIndex = 51;
			this.BtnDayDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDayDown.Click += new System.EventHandler(this.BtnDayDown_Click);
			// 
			// BtnDayUp
			// 
			this.BtnDayUp.BackColor = System.Drawing.Color.Transparent;
			this.BtnDayUp.Blue = 2F;
			this.BtnDayUp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDayUp.Green = 1F;
			this.BtnDayUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnDayUp.Image")));
			this.BtnDayUp.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnDayUp.ImageClick")));
			this.BtnDayUp.ImageClickIndex = 3;
			this.BtnDayUp.ImageIndex = 2;
			this.BtnDayUp.ImageList = this.ButtonImgList;
			this.BtnDayUp.Location = new System.Drawing.Point(5, 2);
			this.BtnDayUp.Name = "BtnDayUp";
			this.BtnDayUp.ObjectValue = null;
			this.BtnDayUp.Red = 1F;
			this.BtnDayUp.Size = new System.Drawing.Size(110, 60);
			this.BtnDayUp.TabIndex = 50;
			this.BtnDayUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDayUp.Click += new System.EventHandler(this.BtnDayUp_Click);
			// 
			// GroupDate
			// 
			this.GroupDate.BackColor = System.Drawing.Color.Transparent;
			this.GroupDate.Caption = null;
			this.GroupDate.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.BtnDayUp,
																					this.DatePad,
																					this.BtnDayDown});
			this.GroupDate.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.GroupDate.Location = new System.Drawing.Point(8, 128);
			this.GroupDate.Name = "GroupDate";
			this.GroupDate.ShowHeader = false;
			this.GroupDate.Size = new System.Drawing.Size(1008, 64);
			this.GroupDate.TabIndex = 62;
			// 
			// LblHeaderNumber
			// 
			this.LblHeaderNumber.BackColor = System.Drawing.Color.Black;
			this.LblHeaderNumber.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LblHeaderNumber.ForeColor = System.Drawing.Color.White;
			this.LblHeaderNumber.Location = new System.Drawing.Point(232, 192);
			this.LblHeaderNumber.Name = "LblHeaderNumber";
			this.LblHeaderNumber.Size = new System.Drawing.Size(48, 40);
			this.LblHeaderNumber.TabIndex = 64;
			this.LblHeaderNumber.Text = "#";
			this.LblHeaderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ReserveForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.LblHeaderNumber,
																		  this.ListReserveID,
																		  this.GroupDate,
																		  this.LblPageID,
																		  this.PanSelectTime,
																		  this.groupPanel2,
																		  this.LblHeaderTime,
																		  this.ListReserveTime,
																		  this.LblHeaderSeat,
																		  this.ListReserveSeat,
																		  this.BtnCancel,
																		  this.BtnReserve,
																		  this.BtnMain,
																		  this.LblCopyright,
																		  this.LblHeaderCustomer,
																		  this.BtnDown,
																		  this.BtnUp,
																		  this.ListReserveQueue,
																		  this.BtnDinIn});
			this.Name = "ReserveForm";
			this.Text = "Reserve Table";
			this.PanCustName.ResumeLayout(false);
			this.PanSelectTime.ResumeLayout(false);
			this.groupPanel2.ResumeLayout(false);
			this.GroupDate.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnMain_Click(object sender, System.EventArgs e)
		{
			((MainForm)MdiParent).ShowMainMenuForm();
		}

		private DateTime SearchStartOfWeek(DateTime date)
		{
			if (date.DayOfWeek > 0)
				return date.AddDays(0-date.DayOfWeek).Add(new TimeSpan(0-date.Hour, 0-date.Minute, 0));
			return date.Add(new TimeSpan(0-date.Hour, 0-date.Minute, 0));
		}

		#region Properties
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
		/// Initial form when start take order.
		/// (Call this method from outside)
		/// </summary>
		public override void UpdateForm()
		{
			selectedDate = DateTime.Today.Add(new TimeSpan(8, 0, 0));
			startDate = SearchStartOfWeek(selectedDate);
			selectedReserve = null;
			// Clear Reserve Form
			FieldCustName.Text = FIELD_CUST_TEXT;
			FieldSeat.Text = "";
			// Update Screen
			if (AppParameter.IsDemo())
				FieldInputType.Text = "Guest";
			else
				FieldInputType.Text = "Seat";
			LblPageID.Text = "Employee ID:" + ((MainForm)MdiParent).UserID.ToString() + " | STRT010";
			UpdateDateButton();
			UpdateSelectedTime();
		}

		private void UpdateReserveQueue()
		{
			ReserveService.ReserveService service = new ReserveService.ReserveService();
			reserveList = service.GetTableReserve(selectedDate);

			StringBuilder sb = new StringBuilder();
			int reserveCnt;
			DataItem data;

			ListReserveTime.AutoRefresh = false;
			ListReserveQueue.AutoRefresh = false;
			ListReserveID.AutoRefresh = false;
			ListReserveSeat.AutoRefresh = false;
			ListReserveTime.Items.Clear();
			ListReserveQueue.Items.Clear();
			ListReserveID.Items.Clear();
			ListReserveSeat.Items.Clear();
			if (reserveList == null)
			{
				ListReserveTime.AutoRefresh = true;
				ListReserveQueue.AutoRefresh = true;
				ListReserveID.AutoRefresh = true;
				ListReserveSeat.AutoRefresh = true;
				return;
			}
			// Loop for all reserve.
			ListReserveTime.SelectedIndex = -1;
			for (reserveCnt = 0;reserveCnt < reserveList.Length;reserveCnt++)
			{
				// Add reserve customer to grid.
				sb.Length = 0;
				sb.Append(reserveList[reserveCnt].custFirstName);
				sb.Append(" ");
				sb.Append(reserveList[reserveCnt].custMiddleName);
				sb.Append(" ");
				sb.Append(reserveList[reserveCnt].custLastName);

				data = new DataItem(reserveList[reserveCnt].reserveDate.ToString("HH:mm"), reserveList[reserveCnt], false);
				ListReserveTime.Items.Add(data);
				data = new DataItem(sb.ToString(), reserveList[reserveCnt], false);
				ListReserveQueue.Items.Add(data);
				data = new DataItem(reserveList[reserveCnt].reserveTableID.ToString(), reserveList[reserveCnt], false);
				ListReserveID.Items.Add(data);
				data = new DataItem(reserveList[reserveCnt].seat.ToString(), reserveList[reserveCnt], false);
				ListReserveSeat.Items.Add(data);
				// Selected Reserve
				if (selectedReserve == reserveList[reserveCnt])
				{
					ListReserveTime.SelectedIndex = ListReserveTime.Items.Count - 1;
				}
			}
			ListReserveTime.AutoRefresh = true;
			ListReserveQueue.AutoRefresh = true;
			ListReserveID.AutoRefresh = true;
			ListReserveSeat.AutoRefresh = true;
			UpdateReserveButton();
		}

		private void UpdateTimeButton()
		{
			int i;
			for (i = 0;i < 24;i++)
				HourPad.Items.Add(new ButtonItem(i.ToString("D2"), i.ToString()));
			MinutePad.Items.Add(new ButtonItem("00", "0"));
			MinutePad.Items.Add(new ButtonItem("15", "15"));
			MinutePad.Items.Add(new ButtonItem("30", "30"));
			MinutePad.Items.Add(new ButtonItem("45", "45"));
		}

		private void UpdateDateButton()
		{
			DateTime posDate = startDate;
			ButtonItem item;

			DatePad.AutoRefresh = false;
			DatePad.Items.Clear();
			DatePad.Red = 1;
			DatePad.Green = 1;
			DatePad.Blue = 1;
			for (int i = 0;i < 7;i++)
			{
				item = new ButtonItem(posDate.ToString("dd MMM yyyy", culture), i.ToString());
				DatePad.Items.Add(item);
				posDate = posDate.AddDays(1);
			}
			DatePad.AutoRefresh = true;
			UpdateReserveQueue();
		}

		private void UpdateSelectedTime()
		{
			int minIndex = (selectedDate.Minute / 15);
			if (minIndex > 3)
			{
				selectedDate = selectedDate.Add(new TimeSpan(-1, 0-selectedDate.Minute, 0));
				minIndex = 0;
			}

			DatePad.AutoRefresh = false;
			HourPad.AutoRefresh = false;
			MinutePad.AutoRefresh = false;

			HourPad.Red = HourPad.Green = HourPad.Blue = 1;
			HourPad.SetMatrix(selectedDate.Hour, 1f, 2f, 1f);
			MinutePad.Red = MinutePad.Green = MinutePad.Blue = 1;
			MinutePad.SetMatrix(minIndex, 1f, 2f, 1f);

			DateTime posDate = startDate;
			DatePad.Red = DatePad.Green = DatePad.Blue = 1;
			for (int i = 0;i < 7;i++)
			{
				if (posDate.Date == selectedDate.Date)
					DatePad.SetMatrix(i, 0.5f, 1f, 1f);
				posDate = posDate.AddDays(1);
			}

			DatePad.AutoRefresh = true;
			HourPad.AutoRefresh = true;
			MinutePad.AutoRefresh = true;

			// Update Selected Date Label
			LblSelectedDate.Text = selectedDate.ToString("dd MMMM yyyy HH:mm", culture);

			UpdateReserveButton();
		}

		private void UpdateReserveButton()
		{
			BtnReserve.Enabled = (FieldCustName.Text != "" && FieldCustName.Text != FIELD_CUST_TEXT && FieldSeat.Text != "");
			BtnUp.Enabled = ListReserveTime.CanUp;
			BtnDown.Enabled = ListReserveTime.CanDown;
			if (selectedReserve == null)
			{
				BtnDinIn.Enabled = false;
				BtnCancel.Enabled = false;
			}
			else
			{
				BtnDinIn.Enabled = true;
				BtnCancel.Enabled = true;
			}
		}
		#endregion

		private void BtnGotoToday_Click(object sender, System.EventArgs e)
		{
			selectedDate = DateTime.Today.Add(new TimeSpan(selectedDate.Hour, selectedDate.Minute, 0));
			startDate = SearchStartOfWeek(selectedDate);
			UpdateDateButton();
			UpdateSelectedTime();
		}

		private void DatePad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			int days = int.Parse(e.Value);
			selectedDate = startDate.AddDays(days).Add(new TimeSpan(selectedDate.Hour, selectedDate.Minute, 0));
			UpdateDateButton();
			UpdateSelectedTime();
			UpdateReserveButton();
		}

		private void BtnDayUp_Click(object sender, System.EventArgs e)
		{
			startDate = startDate.AddDays(-7);
			UpdateDateButton();
			UpdateSelectedTime();
		}

		private void BtnDayDown_Click(object sender, System.EventArgs e)
		{
			startDate = startDate.AddDays(7);
			UpdateDateButton();
			UpdateSelectedTime();
		}

		private void LblSelectedDate_Click(object sender, System.EventArgs e)
		{
			startDate = SearchStartOfWeek(selectedDate);
			UpdateDateButton();
			UpdateSelectedTime();
		}

		private void HourPad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			int val = int.Parse(e.Value);
			selectedDate = selectedDate.AddHours(val - selectedDate.Hour);
			UpdateSelectedTime();
		}

		private void MinutePad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			int val = int.Parse(e.Value);
			selectedDate = selectedDate.AddMinutes(val - selectedDate.Minute);
			UpdateSelectedTime();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			string oldCustName;
			if (FieldCustName.Text == FIELD_CUST_TEXT)
				oldCustName = "";
			else
				oldCustName = FieldCustName.Text;
			string result = SearchCustomerForm.Show(oldCustName);
			if (result != null)
			{
				FieldCustName.Text = result;
				UpdateReserveButton();
			}
		}

		private void NumberKeyPad_PadClick(object sender, smartRestaurant.Controls.NumberPadEventArgs e)
		{
			if (e.IsNumeric)
			{
				FieldSeat.Text += e.Number.ToString();
			}
			else if (e.IsCancel)
			{
				if (FieldSeat.Text.Length > 1)
					FieldSeat.Text = FieldSeat.Text.Substring(0, FieldSeat.Text.Length - 1);
				else
					FieldSeat.Text = "";
			}
			UpdateReserveButton();
		}

		private void FieldCustName_Click(object sender, System.EventArgs e)
		{
			string oldCustName;
			if (FieldCustName.Text == FIELD_CUST_TEXT)
				oldCustName = "";
			else
				oldCustName = FieldCustName.Text;
			string result = KeyboardForm.Show("Customer Name", oldCustName);
			if (result != null)
			{
				FieldCustName.Text = result;
				UpdateReserveButton();
			}
		}

		private void BtnReserve_Click(object sender, System.EventArgs e)
		{
			TableReserve reserve = new TableReserve();
			reserve.reserveTableID = 0;
			reserve.tableID = 0;
			reserve.customerID = 0;
			reserve.seat = int.Parse(FieldSeat.Text);
			reserve.reserveDate = selectedDate;

			ReserveService.ReserveService service = new ReserveService.ReserveService();
			string result = service.SetTableReserve(reserve, FieldCustName.Text);
			if (result != null)
			{
				MessageBox.Show(result);
				return;
			}
			// Clear Reserve Form
			FieldCustName.Text = FIELD_CUST_TEXT;
			FieldSeat.Text = "";
			UpdateReserveQueue();
			UpdateReserveButton();
			//((MainForm)MdiParent).ShowMainMenuForm();
		}

		private void ListReserveTime_ItemClick(object sender, smartRestaurant.Controls.ItemsListEventArgs e)
		{
			selectedReserve = (TableReserve)e.Item.Value;
			UpdateReserveButton();
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			//update status
			ReserveService.ReserveService service = new ReserveService.ReserveService();
			int result = service.SetReserveCancel(selectedReserve.reserveTableID.ToString());
			UpdateReserveQueue();
		}

		private void BtnDinIn_Click(object sender, System.EventArgs e)
		{
			if (selectedReserve!=null)
			{
				//PopUp Table List//
				TableService.TableInformation tableinfo = TableForm.Show("Reserve");
				if (tableinfo == null)
					return;
				//Update ReserveInfo//
				ReserveService.ReserveService service = new ReserveService.ReserveService();
				int result= service.SetReserveDinIn(selectedReserve.reserveTableID.ToString(),tableinfo.TableID.ToString());
				//Insert DinIn Info//
				tableinfo.NumberOfSeat = selectedReserve.seat;
				((MainForm)MdiParent).ShowTakeOrderForm(tableinfo);
				
			}
		}

	}
}
