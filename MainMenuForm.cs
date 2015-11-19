using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Controls;
using smartRestaurant.Data;
using smartRestaurant.TableService;
using smartRestaurant.OrderService;
using smartRestaurant.Utils;

namespace smartRestaurant
{
	/// <summary>
	/// <b>MainMenuForm</b> is main form for user to select thing to do.
	/// </summary>
	public class MainMenuForm : SmartForm
	{
		//private ImageButton[] tableButtons;
		/// <summary>
		/// <i>Table Information array list</i>
		/// </summary>
		private TableInformation[] tableInfo;
		/// <summary>
		/// <i>Table status array list</i>
		/// </summary>
		private TableStatus[] tableStatus;
		/// <summary>
		/// <i>Take out table object</i>
		/// </summary>
		private TableInformation takeOutTable;
		/// <summary>
		/// <i>Array of waiting list</i>
		/// </summary>
		private OrderWaiting[] orderWaiting;
		/// <summary>
		/// <i>Current top cursor for waiting list </i>
		/// </summary>
		private int waitingTop;
		/// <summary>
		/// <i>Current left cursor for waiting list </i>
		/// </summary>
		private int waitingLeft;
		/// <summary>
		/// <i>Current row count for waiting list </i>
		/// </summary>
		private int waitingRow;
		/// <summary>
		/// <i>Current column count for waiting list </i>
		/// </summary>
		private int waitingColumn;

		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnExit;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel TablePanel;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnTakeOut;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnReserve;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnTakeOutList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.ComponentModel.IContainer components;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList ButtonImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPageID;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblCopyRight;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ButtonListPad TablePad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList ButtonLiteImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList NumberImgList;
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
		private smartRestaurant.Controls.ImageButton BtnRight;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnLeft;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ButtonListPad BillItemPad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnManager;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Timers.Timer TimerClock;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblClock;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel WaitingListPanel;

		/// <summary>
		/// Constructure for class
		/// </summary>
		public MainMenuForm() : base()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			LoadTableInformation();
			InitWaitingList();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainMenuForm));
			this.BtnExit = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.TablePanel = new smartRestaurant.Controls.GroupPanel();
			this.TablePad = new smartRestaurant.Controls.ButtonListPad();
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnTakeOut = new smartRestaurant.Controls.ImageButton();
			this.BtnReserve = new smartRestaurant.Controls.ImageButton();
			this.BtnTakeOutList = new smartRestaurant.Controls.ImageButton();
			this.BtnManager = new smartRestaurant.Controls.ImageButton();
			this.LblPageID = new System.Windows.Forms.Label();
			this.LblCopyRight = new System.Windows.Forms.Label();
			this.WaitingListPanel = new smartRestaurant.Controls.GroupPanel();
			this.BtnDown = new smartRestaurant.Controls.ImageButton();
			this.BtnUp = new smartRestaurant.Controls.ImageButton();
			this.BtnRight = new smartRestaurant.Controls.ImageButton();
			this.ButtonLiteImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnLeft = new smartRestaurant.Controls.ImageButton();
			this.BillItemPad = new smartRestaurant.Controls.ButtonListPad();
			this.TimerClock = new System.Timers.Timer();
			this.LblClock = new System.Windows.Forms.Label();
			this.TablePanel.SuspendLayout();
			this.WaitingListPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TimerClock)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnExit
			// 
			this.BtnExit.BackColor = System.Drawing.Color.Transparent;
			this.BtnExit.Blue = 2F;
			this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnExit.Green = 2F;
			this.BtnExit.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnExit.ImageClick")));
			this.BtnExit.ImageClickIndex = 1;
			this.BtnExit.ImageIndex = 0;
			this.BtnExit.ImageList = this.ButtonImgList;
			this.BtnExit.Location = new System.Drawing.Point(880, 692);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.ObjectValue = null;
			this.BtnExit.Red = 1F;
			this.BtnExit.Size = new System.Drawing.Size(110, 60);
			this.BtnExit.TabIndex = 0;
			this.BtnExit.Text = "Logout";
			this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// TablePanel
			// 
			this.TablePanel.BackColor = System.Drawing.Color.Transparent;
			this.TablePanel.Caption = "Select Table";
			this.TablePanel.Controls.Add(this.TablePad);
			this.TablePanel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.TablePanel.Location = new System.Drawing.Point(24, 144);
			this.TablePanel.Name = "TablePanel";
			this.TablePanel.ShowHeader = true;
			this.TablePanel.Size = new System.Drawing.Size(976, 264);
			this.TablePanel.TabIndex = 1;
			// 
			// TablePad
			// 
			this.TablePad.AutoRefresh = true;
			this.TablePad.BackColor = System.Drawing.Color.White;
			this.TablePad.Blue = 1F;
			this.TablePad.Column = 8;
			this.TablePad.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.TablePad.Green = 1F;
			this.TablePad.Image = ((System.Drawing.Image)(resources.GetObject("TablePad.Image")));
			this.TablePad.ImageClick = ((System.Drawing.Image)(resources.GetObject("TablePad.ImageClick")));
			this.TablePad.ImageClickIndex = 1;
			this.TablePad.ImageIndex = 0;
			this.TablePad.ImageList = this.ButtonImgList;
			this.TablePad.ItemStart = 0;
			this.TablePad.Location = new System.Drawing.Point(13, 48);
			this.TablePad.Name = "TablePad";
			this.TablePad.Padding = 10;
			this.TablePad.Red = 1F;
			this.TablePad.Row = 3;
			this.TablePad.Size = new System.Drawing.Size(950, 200);
			this.TablePad.TabIndex = 7;
			this.TablePad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.TablePad_PadClick);
			this.TablePad.PageChange += new smartRestaurant.Controls.ButtonListPadEventHandler(this.TablePad_PageChange);
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnTakeOut
			// 
			this.BtnTakeOut.BackColor = System.Drawing.Color.Transparent;
			this.BtnTakeOut.Blue = 2F;
			this.BtnTakeOut.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnTakeOut.Green = 1F;
			this.BtnTakeOut.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnTakeOut.ImageClick")));
			this.BtnTakeOut.ImageClickIndex = 1;
			this.BtnTakeOut.ImageIndex = 0;
			this.BtnTakeOut.ImageList = this.ButtonImgList;
			this.BtnTakeOut.Location = new System.Drawing.Point(608, 72);
			this.BtnTakeOut.Name = "BtnTakeOut";
			this.BtnTakeOut.ObjectValue = null;
			this.BtnTakeOut.Red = 1F;
			this.BtnTakeOut.Size = new System.Drawing.Size(110, 60);
			this.BtnTakeOut.TabIndex = 3;
			this.BtnTakeOut.Text = "Take Out";
			this.BtnTakeOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnTakeOut.Click += new System.EventHandler(this.BtnTakeOut_Click);
			// 
			// BtnReserve
			// 
			this.BtnReserve.BackColor = System.Drawing.Color.Transparent;
			this.BtnReserve.Blue = 1F;
			this.BtnReserve.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnReserve.Green = 1F;
			this.BtnReserve.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnReserve.ImageClick")));
			this.BtnReserve.ImageClickIndex = 1;
			this.BtnReserve.ImageIndex = 0;
			this.BtnReserve.ImageList = this.ButtonImgList;
			this.BtnReserve.Location = new System.Drawing.Point(880, 72);
			this.BtnReserve.Name = "BtnReserve";
			this.BtnReserve.ObjectValue = null;
			this.BtnReserve.Red = 2F;
			this.BtnReserve.Size = new System.Drawing.Size(110, 60);
			this.BtnReserve.TabIndex = 4;
			this.BtnReserve.Text = "Reserve";
			this.BtnReserve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnReserve.Click += new System.EventHandler(this.BtnReserve_Click);
			// 
			// BtnTakeOutList
			// 
			this.BtnTakeOutList.BackColor = System.Drawing.Color.Transparent;
			this.BtnTakeOutList.Blue = 2F;
			this.BtnTakeOutList.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnTakeOutList.Green = 1F;
			this.BtnTakeOutList.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnTakeOutList.ImageClick")));
			this.BtnTakeOutList.ImageClickIndex = 1;
			this.BtnTakeOutList.ImageIndex = 0;
			this.BtnTakeOutList.ImageList = this.ButtonImgList;
			this.BtnTakeOutList.Location = new System.Drawing.Point(744, 72);
			this.BtnTakeOutList.Name = "BtnTakeOutList";
			this.BtnTakeOutList.ObjectValue = null;
			this.BtnTakeOutList.Red = 2F;
			this.BtnTakeOutList.Size = new System.Drawing.Size(110, 60);
			this.BtnTakeOutList.TabIndex = 5;
			this.BtnTakeOutList.Text = "Take Out List";
			this.BtnTakeOutList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnTakeOutList.Click += new System.EventHandler(this.BtnTakeOutList_Click);
			// 
			// BtnManager
			// 
			this.BtnManager.BackColor = System.Drawing.Color.Transparent;
			this.BtnManager.Blue = 1F;
			this.BtnManager.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnManager.Green = 2F;
			this.BtnManager.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnManager.ImageClick")));
			this.BtnManager.ImageClickIndex = 1;
			this.BtnManager.ImageIndex = 0;
			this.BtnManager.ImageList = this.ButtonImgList;
			this.BtnManager.Location = new System.Drawing.Point(32, 692);
			this.BtnManager.Name = "BtnManager";
			this.BtnManager.ObjectValue = null;
			this.BtnManager.Red = 1F;
			this.BtnManager.Size = new System.Drawing.Size(110, 60);
			this.BtnManager.TabIndex = 6;
			this.BtnManager.Text = "Manager";
			this.BtnManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnManager.Click += new System.EventHandler(this.BtnManager_Click);
			// 
			// LblPageID
			// 
			this.LblPageID.BackColor = System.Drawing.Color.Transparent;
			this.LblPageID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblPageID.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblPageID.Location = new System.Drawing.Point(784, 752);
			this.LblPageID.Name = "LblPageID";
			this.LblPageID.Size = new System.Drawing.Size(224, 23);
			this.LblPageID.TabIndex = 33;
			this.LblPageID.Text = "STST010";
			this.LblPageID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LblCopyRight
			// 
			this.LblCopyRight.BackColor = System.Drawing.Color.Transparent;
			this.LblCopyRight.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblCopyRight.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblCopyRight.Location = new System.Drawing.Point(8, 752);
			this.LblCopyRight.Name = "LblCopyRight";
			this.LblCopyRight.Size = new System.Drawing.Size(280, 16);
			this.LblCopyRight.TabIndex = 36;
			this.LblCopyRight.Text = "Copyright (c) 2004. All rights reserved.";
			// 
			// WaitingListPanel
			// 
			this.WaitingListPanel.BackColor = System.Drawing.Color.Transparent;
			this.WaitingListPanel.Caption = null;
			this.WaitingListPanel.Controls.Add(this.BtnDown);
			this.WaitingListPanel.Controls.Add(this.BtnUp);
			this.WaitingListPanel.Controls.Add(this.BtnRight);
			this.WaitingListPanel.Controls.Add(this.BtnLeft);
			this.WaitingListPanel.Controls.Add(this.BillItemPad);
			this.WaitingListPanel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.WaitingListPanel.Location = new System.Drawing.Point(24, 408);
			this.WaitingListPanel.Name = "WaitingListPanel";
			this.WaitingListPanel.ShowHeader = false;
			this.WaitingListPanel.Size = new System.Drawing.Size(976, 280);
			this.WaitingListPanel.TabIndex = 37;
			// 
			// BtnDown
			// 
			this.BtnDown.BackColor = System.Drawing.Color.Transparent;
			this.BtnDown.Blue = 1F;
			this.BtnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDown.Green = 2F;
			this.BtnDown.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnDown.ImageClick")));
			this.BtnDown.ImageClickIndex = 1;
			this.BtnDown.ImageIndex = 0;
			this.BtnDown.ImageList = this.NumberImgList;
			this.BtnDown.Location = new System.Drawing.Point(896, 176);
			this.BtnDown.Name = "BtnDown";
			this.BtnDown.ObjectValue = null;
			this.BtnDown.Red = 2F;
			this.BtnDown.Size = new System.Drawing.Size(72, 60);
			this.BtnDown.TabIndex = 11;
			this.BtnDown.Text = "Down";
			this.BtnDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
			this.BtnDown.DoubleClick += new System.EventHandler(this.BtnDown_Click);
			// 
			// BtnUp
			// 
			this.BtnUp.BackColor = System.Drawing.Color.Transparent;
			this.BtnUp.Blue = 1F;
			this.BtnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnUp.Green = 2F;
			this.BtnUp.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnUp.ImageClick")));
			this.BtnUp.ImageClickIndex = 1;
			this.BtnUp.ImageIndex = 0;
			this.BtnUp.ImageList = this.NumberImgList;
			this.BtnUp.Location = new System.Drawing.Point(896, 8);
			this.BtnUp.Name = "BtnUp";
			this.BtnUp.ObjectValue = null;
			this.BtnUp.Red = 2F;
			this.BtnUp.Size = new System.Drawing.Size(72, 60);
			this.BtnUp.TabIndex = 10;
			this.BtnUp.Text = "Up";
			this.BtnUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
			this.BtnUp.DoubleClick += new System.EventHandler(this.BtnUp_Click);
			// 
			// BtnRight
			// 
			this.BtnRight.BackColor = System.Drawing.Color.Transparent;
			this.BtnRight.Blue = 1F;
			this.BtnRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnRight.Green = 2F;
			this.BtnRight.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnRight.ImageClick")));
			this.BtnRight.ImageClickIndex = 1;
			this.BtnRight.ImageIndex = 0;
			this.BtnRight.ImageList = this.ButtonLiteImgList;
			this.BtnRight.Location = new System.Drawing.Point(778, 240);
			this.BtnRight.Name = "BtnRight";
			this.BtnRight.ObjectValue = null;
			this.BtnRight.Red = 2F;
			this.BtnRight.Size = new System.Drawing.Size(110, 40);
			this.BtnRight.TabIndex = 9;
			this.BtnRight.Text = ">>";
			this.BtnRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
			this.BtnRight.DoubleClick += new System.EventHandler(this.BtnRight_Click);
			// 
			// ButtonLiteImgList
			// 
			this.ButtonLiteImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonLiteImgList.ImageSize = new System.Drawing.Size(110, 40);
			this.ButtonLiteImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonLiteImgList.ImageStream")));
			this.ButtonLiteImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnLeft
			// 
			this.BtnLeft.BackColor = System.Drawing.Color.Transparent;
			this.BtnLeft.Blue = 1F;
			this.BtnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnLeft.Green = 2F;
			this.BtnLeft.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnLeft.ImageClick")));
			this.BtnLeft.ImageClickIndex = 1;
			this.BtnLeft.ImageIndex = 0;
			this.BtnLeft.ImageList = this.ButtonLiteImgList;
			this.BtnLeft.Location = new System.Drawing.Point(8, 240);
			this.BtnLeft.Name = "BtnLeft";
			this.BtnLeft.ObjectValue = null;
			this.BtnLeft.Red = 2F;
			this.BtnLeft.Size = new System.Drawing.Size(110, 40);
			this.BtnLeft.TabIndex = 8;
			this.BtnLeft.Text = "<<";
			this.BtnLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
			this.BtnLeft.DoubleClick += new System.EventHandler(this.BtnLeft_Click);
			// 
			// BillItemPad
			// 
			this.BillItemPad.AutoRefresh = true;
			this.BillItemPad.BackColor = System.Drawing.Color.White;
			this.BillItemPad.Blue = 1F;
			this.BillItemPad.Column = 8;
			this.BillItemPad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.BillItemPad.Green = 1F;
			this.BillItemPad.Image = ((System.Drawing.Image)(resources.GetObject("BillItemPad.Image")));
			this.BillItemPad.ImageClick = ((System.Drawing.Image)(resources.GetObject("BillItemPad.ImageClick")));
			this.BillItemPad.ImageClickIndex = 1;
			this.BillItemPad.ImageIndex = 0;
			this.BillItemPad.ImageList = this.ButtonLiteImgList;
			this.BillItemPad.ItemStart = 0;
			this.BillItemPad.Location = new System.Drawing.Point(8, 1);
			this.BillItemPad.Name = "BillItemPad";
			this.BillItemPad.Padding = 0;
			this.BillItemPad.Red = 1F;
			this.BillItemPad.Row = 6;
			this.BillItemPad.Size = new System.Drawing.Size(880, 240);
			this.BillItemPad.TabIndex = 7;
			this.BillItemPad.Text = "BillItemPad";
			this.BillItemPad.PadClick += new smartRestaurant.Controls.ButtonListPadEventHandler(this.BillItemPad_PadClick);
			// 
			// TimerClock
			// 
			this.TimerClock.Enabled = true;
			this.TimerClock.Interval = 1000;
			this.TimerClock.SynchronizingObject = this;
			this.TimerClock.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerClock_Elapsed);
			// 
			// LblClock
			// 
			this.LblClock.BackColor = System.Drawing.Color.Transparent;
			this.LblClock.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblClock.Location = new System.Drawing.Point(872, 8);
			this.LblClock.Name = "LblClock";
			this.LblClock.Size = new System.Drawing.Size(144, 40);
			this.LblClock.TabIndex = 38;
			this.LblClock.Text = "99:99:99";
			this.LblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MainMenuForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.Add(this.LblClock);
			this.Controls.Add(this.WaitingListPanel);
			this.Controls.Add(this.LblCopyRight);
			this.Controls.Add(this.LblPageID);
			this.Controls.Add(this.BtnManager);
			this.Controls.Add(this.BtnTakeOutList);
			this.Controls.Add(this.BtnReserve);
			this.Controls.Add(this.BtnTakeOut);
			this.Controls.Add(this.TablePanel);
			this.Controls.Add(this.BtnExit);
			this.Name = "MainMenuForm";
			this.Text = "Select Table";
			this.TablePanel.ResumeLayout(false);
			this.WaitingListPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TimerClock)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// This method use for user click Logout button. This method will call
		/// UserProfile.CheckLogout() to update user status and return user to LoginForm
		/// (via MainForm.ShowLoginForm()).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnExit_Click(object sender, System.EventArgs e)
		{
			UserProfile.CheckLogout(((MainForm)this.MdiParent).User.UserID);
			((MainForm)this.MdiParent).User = null;
			((MainForm)this.MdiParent).ShowLoginForm();
		}

		/// <summary>
		/// This method uses for read table style variable from App.Config file.<br/>
		/// Style 1 is big size button table list. It's easy to click but there are less tables
		/// show per page.<br/>
		/// Style 2 is middle size button table list. Its size same as number pad button.<br/>
		/// Style 3 is small size button table list. This style show more tables per page.
		/// </summary>
		private void LoadTableListStyle()
		{
			string style;
			try
			{
				style = ConfigurationSettings.AppSettings["TableListStyle"];
			}
			catch (Exception)
			{
				style = "1";
			}
			if (style == "1")
			{
				TablePad.ImageList = ButtonImgList;
				TablePad.ImageIndex = 0;
				TablePad.ImageClickIndex = 1;
				TablePad.Padding = 10;
				TablePad.Top = 48;
				TablePad.Left = 13;
				TablePad.Column = 8;
				TablePad.Row = 3;
			}
			else if (style == "2")
			{
				TablePad.ImageList = NumberImgList;
				TablePad.ImageIndex = 0;
				TablePad.ImageClickIndex = 1;
				TablePad.Padding = 8;
				TablePad.Top = 48;
				TablePad.Left = 13;
				TablePad.Column = 12;
				TablePad.Row = 3;
			}
			else if (style == "3")
			{
				TablePad.ImageList = ButtonLiteImgList;
				TablePad.ImageIndex = 0;
				TablePad.ImageClickIndex = 1;
				TablePad.Padding = 5;
				TablePad.Top = 36;
				TablePad.Left = 31;
				TablePad.Row = 5;
				TablePad.Column = 8;
			}
		}

		/// <summary>
		/// This method call TableService.GetTableList() for get all tables' information
		/// and create objects in TableInfo array list.
		/// </summary>
		private void LoadTableInformation()
		{
			TableService.TableService service = new TableService.TableService();
			tableInfo = service.GetTableList();
			while (tableInfo == null)
			{
				DialogResult result = MessageBox.Show("Can't load table information.", "Error",
					MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (result == DialogResult.Cancel)
					((MainForm)this.MdiParent).Exit();
				else
					tableInfo = service.GetTableList();
			}
			// Search table object by table id = 0 (Take Out Table)
			for (int i = 0;i < tableInfo.Length;i++)
			{
				if (tableInfo[i].TableID == 0)
				{
					takeOutTable = tableInfo[i];
					break;
				}
			}
		}

		/*private void AddTableButton()
		{
			try
			{
				// Get table status from web service
				TableService.TableService service = new TableService.TableService();
				TableStatus[] tableStatus = service.GetTableStatus();
				// Create button to screen
				ImageButton button;
				Image img = ButtonImgList.Images[0];
				Image imgClick = ButtonImgList.Images[1];
				int x, y;
				bool newButton = false;
				x = 13; y = 48;
				if (tableStatus != null && tableStatus.Length > 1)
				{
					// Table not include ID = 0
					if (tableButtons == null || tableButtons.Length != tableStatus.Length - 1)
					{
						TablePanel.Controls.Clear();
						tableButtons = new ImageButton[tableStatus.Length - 1];
						newButton = true;
					}
					for (int cnt = 0;cnt < tableStatus.Length - 1;cnt++)
					{
						if (newButton)
						{
							button = new ImageButton();
							button.Image = img;
							button.ImageClick = imgClick;
							button.Left = x;
							button.Top = y;
							button.Text = tableStatus[cnt + 1].TableName;
						}
						else
							button = tableButtons[cnt];
						// Check Table Status
						if (tableStatus[cnt + 1].InUse)
						{
							button.ObjectValue = -tableStatus[cnt + 1].TableID;
							button.Red = 1;
							button.Green = 2;
							button.Blue = 2;
						}
						else
						{
							button.ObjectValue = tableStatus[cnt + 1].TableID;
							button.Red = 1;
							button.Green = 1;
							button.Blue = 1;
						}
						// Add event and control
						if (newButton)
						{
							button.Click += new EventHandler(this.Table_Click);
							TablePanel.Controls.Add(button);
							tableButtons[cnt] = button;
						}
						x += button.Width + 10;
						if (((cnt + 1) % 8) == 0)
						{
							x = 13; y += button.Height + 10;
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}*/

		/// <summary>
		/// This method use for check all table information and create button item on
		/// table list button.
		/// </summary>
		private void AddTableButton()
		{
			try
			{
				TablePad.AutoRefresh = false;
				TablePad.Red = 1;
				TablePad.Green = 1;
				TablePad.Blue = 1;
				TablePad.Items.Clear();
				// Get table status from web service
				TableService.TableService service = new TableService.TableService();
				tableStatus = service.GetTableStatus();
				// Create button to screen
				if (tableStatus != null && tableStatus.Length > 1)
				{
					// Table not include ID = 0
					for (int cnt = 0;cnt < tableStatus.Length - 1;cnt++)
					{
						ButtonItem item = new ButtonItem(tableStatus[cnt + 1].TableName, null);
						TablePad.Items.Add(item);
						// Check Table Status
						if (tableStatus[cnt + 1].InUse)
							item.Value = ((int)(-tableStatus[cnt + 1].TableID)).ToString();
						else
							item.Value = tableStatus[cnt + 1].TableID.ToString();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				TablePad.AutoRefresh = true;
			}
		}

		/// <summary>
		/// This method checks status for all tables and update color on table button list.
		/// </summary>
		private void UpdateTableStatus()
		{
			try
			{
				TablePad.AutoRefresh = true;
				TablePad.AutoRefresh = false;
				TablePad.Red = 1;
				TablePad.Green = 1;
				TablePad.Blue = 1;
				// Create button to screen
				if (tableStatus != null && tableStatus.Length > 1)
				{
					// Table not include ID = 0
					for (int cnt = 0;cnt < tableStatus.Length - 1;cnt++)
					{
						string val1 = tableStatus[cnt + 1].TableID.ToString();
						string val2 = "-" + val1;
						bool found = false;
						int pos;
						for (pos = 0;pos < TablePad.Buttons.Length;pos++)
						{
							if (TablePad.Buttons[pos].ObjectValue == null)
								continue;
							string val = TablePad.Buttons[pos].ObjectValue.ToString();
							if (val == val1 || val == val2)
							{
								found = true;
								break;
							}
						}
						if (!found)
							continue;
						// Check Table Status
						if (tableStatus[cnt + 1].InUse)
							TablePad.SetMatrix(pos, 1, 2, 2);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				TablePad.AutoRefresh = true;
			}
		}

		/// <summary>
		/// Clear waiting list button.
		/// </summary>
		private void InitWaitingList()
		{
			try
			{
				BillItemPad.AutoRefresh = false;
				ButtonItem item;
				for (int row = 0;row < BillItemPad.Row;row++)
					for (int col = 0;col < BillItemPad.Column;col++)
					{
						item = new ButtonItem(null, null);
						BillItemPad.Items.Add(item);
						if (row == 0)
							BillItemPad.SetMatrix(col, 1, 1, 2);
					}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				BillItemPad.AutoRefresh = true;
			}
		}

		/// <summary>
		/// This method updates all waiting list to button list.
		/// </summary>
		private void UpdateWaitingList()
		{
			try
			{
				OrderWaiting[] orders = orderWaiting;
				ButtonItem item;
				StringBuilder sb = new StringBuilder();
				BillItemPad.AutoRefresh = false;
				// Not found
				if (orders == null)
				{
					for (int i = 0;i < BillItemPad.Items.Count;i++)
					{
						item = (ButtonItem)BillItemPad.Items[i];
						item.Text = item.Value = null;
					}
					return;
				}
				// Loop fetch waiting list to button pad
				waitingColumn = orders.Length;
				waitingRow = 0;
				int oPos = waitingLeft;
				for (int col = 0;col < BillItemPad.Column;col++)
				{
					item = (ButtonItem)BillItemPad.Items[col];
					// Set order to pad
					if (orders.Length <= oPos)
					{
						item.Text = null;
						item.Value = null;
						for (int row = 1;row < BillItemPad.Row;row++)
						{
							item = (ButtonItem)BillItemPad.Items[col + (row * BillItemPad.Column)];
							item.Text = null;
							item.Value = null;
						}
						continue;
					}
					else
					{
						if (waitingRow < orders[oPos].Items.Length)
							waitingRow = orders[oPos].Items.Length;
						sb.Length = 0;
						sb.Append("Serve all\n");
						sb.Append(orders[oPos].TableName);
						item.Text = sb.ToString();
						item.Value = ((int)(-orders[oPos].OrderID)).ToString();
						// Set item to pad
						int iPos = waitingTop;
						for (int row = 1;row < BillItemPad.Row;row++)
						{
							item = (ButtonItem)BillItemPad.Items[col + (row * BillItemPad.Column)];
							if (orders[oPos].Items.Length <= iPos)
							{
								item.Text = null;
								item.Value = null;
							}
							else
							{
								OrderBillItemWaiting bItem = orders[oPos].Items[iPos];
								sb.Length = 0;
								sb.Append(bItem.MenuKeyID);
								if (bItem.Unit > 1)
								{
									sb.Append(" (");
									sb.Append(bItem.Unit);
									sb.Append(")");
								}
								if (bItem.Choice != null && bItem.Choice != "")
								{
									sb.Append("\n");
									if (bItem.Choice.Length > 12)
									{
										sb.Append(bItem.Choice.Substring(0, 12));
										sb.Append("...");
									}
									else
										sb.Append(bItem.Choice);
								}
								item.Text = sb.ToString();
								item.Value = orders[oPos].Items[iPos].BillDetailID.ToString();
							}
							iPos++;
						}
					}
					oPos++;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			finally
			{
				BillItemPad.AutoRefresh = true;
			}
		}

		/*private void Table_Click(object sender, System.EventArgs e)
		{
			ImageButton btn = (ImageButton)sender;
			int tableValue = (int)btn.ObjectValue;

			if (tableValue < 0)
				tableValue = -tableValue;
			// Search table object by table id
			for (int i = 0;i < tableInfo.Length;i++)
			{
				if (tableInfo[i].TableID == tableValue)
				{
					((MainForm)MdiParent).ShowTakeOrderForm(tableInfo[i]);
					return;
				}
			}
			// If not found in loop
			MessageForm.Show("Select Table", "Can't find table information.");
		}*/

		/// <summary>
		/// This method uses for initial status for MainMenuForm before use can use.<br/>
		/// In this method checks user group is manager/auditor or not to show manager button.
		/// And call OrderService.GetBillDetailWaitingList() to get all waiting list for show
		/// on waiting list button.
		/// </summary>
		public override void UpdateForm()
		{
			// Update Screen
			LblPageID.Text = "Employee ID:" + ((MainForm)MdiParent).UserID + " | STST010";
			if (AppParameter.IsDemo())
			{
				BtnManager.Visible = false;
				BtnReserve.Visible = true;
				TablePanel.Height = 544;
				TablePad.Row = 7;
			}
			else
			{
				BtnManager.Visible = ((MainForm)MdiParent).User.IsManager() || ((MainForm)MdiParent).User.IsAuditor();
				BtnReserve.Visible = false;
				TablePanel.Height = 264;
				LoadTableListStyle();
				waitingTop = waitingLeft = 0;
				// Get Order Waiting List from Service
				OrderService.OrderService service = new OrderService.OrderService();
				orderWaiting = service.GetBillDetailWaitingList();
				UpdateWaitingList();
			}
			AddTableButton();
			UpdateTableStatus();
		}

		/// <summary>
		/// This event works when user click on Take Out button and this method will
		/// call MainForm.ShowTakeOrderForm() in new take out case.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">event object</param>
		private void BtnTakeOut_Click(object sender, System.EventArgs e)
		{
			((MainForm)MdiParent).ShowTakeOrderForm(takeOutTable, 0, "");
		}

		/// <summary>
		/// This event works when users click on Take Out List button. This method will
		/// call MainForm.ShowTakeOutForm() to show take out list form.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnTakeOutList_Click(object sender, System.EventArgs e)
		{
			((MainForm)MdiParent).ShowTakeOutForm(takeOutTable, null, false);
		}

		/// <summary>
		/// This event works when users click on manager button. This method will
		/// call MainForm.ShowSalesForm().
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnManager_Click(object sender, System.EventArgs e)
		{
			/*CheckBillService.CheckBillService service = new CheckBillService.CheckBillService();
			double tip = service.GetTodayTip();
			MessageForm.Show("Tip", "Today tip summary is " + tip.ToString("f"));*/
			((MainForm)MdiParent).ShowSalesForm();
		}

		/// <summary>
		/// This method will call MainForm.ShowReserveForm() when user click on Reserve button.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnReserve_Click(object sender, System.EventArgs e)
		{
			((MainForm)MdiParent).ShowReserveForm();
		}

		/// <summary>
		/// This method works when user select table from table list button.
		/// After user select, this method will find table information object and pass it to
		/// MainForm.ShowTakeOrderForm() to show take order form in new or resume order case.
		/// If this method can't find table information, will show error screen.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void TablePad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			if (e.Value == null)
				return;
			int tableValue = int.Parse(e.Value);

			if (tableValue < 0)
				tableValue = -tableValue;
			// Search table object by table id
			for (int i = 0;i < tableInfo.Length;i++)
			{
				if (tableInfo[i].TableID == tableValue)
				{
					((MainForm)MdiParent).ShowTakeOrderForm(tableInfo[i]);
					return;
				}
			}
			// If not found in loop
			MessageForm.Show("Select Table", "Can't find table information.");
		}

		/// <summary>
		/// This method works when user change page for table list button.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void TablePad_PageChange(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			UpdateTableStatus();
		}

		/// <summary>
		/// This method works when user click down button for waiting list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnDown_Click(object sender, System.EventArgs e)
		{
			if (waitingTop + BillItemPad.Row - 1 >= waitingRow)
				return;
			waitingTop += BillItemPad.Row - 1;
			UpdateWaitingList();
		}

		/// <summary>
		/// This method works when user click up button for waiting list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnUp_Click(object sender, System.EventArgs e)
		{
			if (waitingTop == 0)
				return;
			waitingTop -= BillItemPad.Row - 1;
			if (waitingTop < 0)
				waitingTop = 0;
			UpdateWaitingList();
		}

		/// <summary>
		/// This method works when user click left button for waiting list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnLeft_Click(object sender, System.EventArgs e)
		{
			if (waitingLeft == 0)
				return;
			waitingLeft -= BillItemPad.Column;
			if (waitingLeft < 0)
				waitingLeft = 0;
			UpdateWaitingList();
		}

		/// <summary>
		/// This method works when user click right button for waiting list.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnRight_Click(object sender, System.EventArgs e)
		{
			if (waitingLeft + BillItemPad.Column >= waitingColumn)
				return;
			waitingLeft += BillItemPad.Column;
			UpdateWaitingList();
		}

		/// <summary>
		/// This method works when user click at waiting list button. Will call
		/// OrderService.ServeWaitingOrder() to mark bill item to served status.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BillItemPad_PadClick(object sender, smartRestaurant.Controls.ButtonListPadEventArgs e)
		{
			if (e.Value == null)
				return;
			int id = int.Parse(e.Value);
			OrderService.OrderService service = new OrderService.OrderService();
			if (id < 0)
			{
				// Order ID
				id = -id;
				orderWaiting = service.ServeWaitingOrder(id, 0);
			}
			else
			{
				// Bill Detail ID
				orderWaiting = service.ServeWaitingOrder(0, id);
			}
			UpdateWaitingList();
		}

		/// <summary>
		/// This method works 1 time/second for update clock on screen.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void TimerClock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			LblClock.Text = DateTime.Now.ToString("HH:mm:ss");
		}
	}
}
