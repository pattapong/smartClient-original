using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using smartRestaurant.Data;
using smartRestaurant.Utils;

namespace smartRestaurant.Business
{
	/// <summary>
	/// Summary description for SalesForm.
	/// </summary>
	public class SalesForm : SmartForm
	{
		private System.Windows.Forms.ImageList ButtonImgList;
		private smartRestaurant.Controls.ImageButton BtnMain;
		private smartRestaurant.Controls.ImageButton BtnSaleReport;
		private smartRestaurant.Controls.ImageButton BtnInvoiceReport;
		private System.Windows.Forms.Panel PanelSalesReport;
		private System.Windows.Forms.DataGrid TotalGrid;
		private System.Windows.Forms.DataGrid ReportGrid;
		private System.Windows.Forms.Panel PanelInvoiceReport;
		private System.Windows.Forms.DataGrid InvoiceReportGrid;
		private System.Windows.Forms.ImageList ButtonLiteImgList;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid InvoiceSummaryGrid;
		private smartRestaurant.Controls.ImageButton BtnMaintenance;
		private System.Windows.Forms.Panel PanelMaintenance;
		private smartRestaurant.Controls.GroupPanel groupPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private smartRestaurant.Controls.ImageButton BtnSumMenuType;
		private smartRestaurant.Controls.ImageButton BtnSumPayment;
		private System.Windows.Forms.DateTimePicker SummaryDate;
		private System.Windows.Forms.DateTimePicker DateInvoiceReport;
		private System.Windows.Forms.DateTimePicker DateSalesReport;
		private smartRestaurant.Controls.GroupPanel groupPanel2;
		private System.Windows.Forms.Label label6;
		private smartRestaurant.Controls.ImageButton BtnExport;
		private System.Windows.Forms.DateTimePicker DateExportFrom;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker DateExportTo;
		private smartRestaurant.Controls.GroupPanel groupPanel4;
		private smartRestaurant.Controls.ImageButton BtnDelete;
		private System.Windows.Forms.Panel PanelManagerMaintenance;
		private smartRestaurant.Controls.ImageButton BtnManagerMaintenance;
		private smartRestaurant.Controls.GroupPanel groupPanel3;
		private smartRestaurant.Controls.ImageButton BtnBackup;
		private System.Windows.Forms.Label label5;

		private DataTable Table;
		private smartRestaurant.Controls.ImageButton BtnPrintInvoiceReport;
		private bool Changed;

		public SalesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SalesForm));
			this.BtnMain = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnSaleReport = new smartRestaurant.Controls.ImageButton();
			this.BtnInvoiceReport = new smartRestaurant.Controls.ImageButton();
			this.PanelSalesReport = new System.Windows.Forms.Panel();
			this.DateSalesReport = new System.Windows.Forms.DateTimePicker();
			this.TotalGrid = new System.Windows.Forms.DataGrid();
			this.ReportGrid = new System.Windows.Forms.DataGrid();
			this.PanelInvoiceReport = new System.Windows.Forms.Panel();
			this.DateInvoiceReport = new System.Windows.Forms.DateTimePicker();
			this.InvoiceSummaryGrid = new System.Windows.Forms.DataGrid();
			this.InvoiceReportGrid = new System.Windows.Forms.DataGrid();
			this.ButtonLiteImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnMaintenance = new smartRestaurant.Controls.ImageButton();
			this.PanelMaintenance = new System.Windows.Forms.Panel();
			this.groupPanel3 = new smartRestaurant.Controls.GroupPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.BtnBackup = new smartRestaurant.Controls.ImageButton();
			this.groupPanel2 = new smartRestaurant.Controls.GroupPanel();
			this.DateExportTo = new System.Windows.Forms.DateTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.BtnExport = new smartRestaurant.Controls.ImageButton();
			this.DateExportFrom = new System.Windows.Forms.DateTimePicker();
			this.groupPanel1 = new smartRestaurant.Controls.GroupPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.BtnSumMenuType = new smartRestaurant.Controls.ImageButton();
			this.BtnSumPayment = new smartRestaurant.Controls.ImageButton();
			this.SummaryDate = new System.Windows.Forms.DateTimePicker();
			this.BtnManagerMaintenance = new smartRestaurant.Controls.ImageButton();
			this.PanelManagerMaintenance = new System.Windows.Forms.Panel();
			this.groupPanel4 = new smartRestaurant.Controls.GroupPanel();
			this.BtnDelete = new smartRestaurant.Controls.ImageButton();
			this.BtnPrintInvoiceReport = new smartRestaurant.Controls.ImageButton();
			this.PanelSalesReport.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TotalGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ReportGrid)).BeginInit();
			this.PanelInvoiceReport.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceSummaryGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceReportGrid)).BeginInit();
			this.PanelMaintenance.SuspendLayout();
			this.groupPanel3.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			this.groupPanel1.SuspendLayout();
			this.PanelManagerMaintenance.SuspendLayout();
			this.groupPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnMain
			// 
			this.BtnMain.BackColor = System.Drawing.Color.Transparent;
			this.BtnMain.Blue = 2F;
			this.BtnMain.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnMain.Green = 2F;
			this.BtnMain.ImageClick = null;
			this.BtnMain.ImageClickIndex = 0;
			this.BtnMain.ImageIndex = 0;
			this.BtnMain.ImageList = this.ButtonImgList;
			this.BtnMain.Location = new System.Drawing.Point(880, 688);
			this.BtnMain.Name = "BtnMain";
			this.BtnMain.ObjectValue = null;
			this.BtnMain.Red = 1F;
			this.BtnMain.Size = new System.Drawing.Size(110, 60);
			this.BtnMain.TabIndex = 1;
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
			// BtnSaleReport
			// 
			this.BtnSaleReport.BackColor = System.Drawing.Color.Transparent;
			this.BtnSaleReport.Blue = 2F;
			this.BtnSaleReport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSaleReport.Green = 1F;
			this.BtnSaleReport.ImageClick = null;
			this.BtnSaleReport.ImageClickIndex = 0;
			this.BtnSaleReport.ImageIndex = 0;
			this.BtnSaleReport.ImageList = this.ButtonImgList;
			this.BtnSaleReport.Location = new System.Drawing.Point(24, 688);
			this.BtnSaleReport.Name = "BtnSaleReport";
			this.BtnSaleReport.ObjectValue = null;
			this.BtnSaleReport.Red = 1F;
			this.BtnSaleReport.Size = new System.Drawing.Size(110, 60);
			this.BtnSaleReport.TabIndex = 3;
			this.BtnSaleReport.Text = "Sales";
			this.BtnSaleReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnSaleReport.Click += new System.EventHandler(this.BtnSaleReport_Click);
			// 
			// BtnInvoiceReport
			// 
			this.BtnInvoiceReport.BackColor = System.Drawing.Color.Transparent;
			this.BtnInvoiceReport.Blue = 2F;
			this.BtnInvoiceReport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnInvoiceReport.Green = 1F;
			this.BtnInvoiceReport.ImageClick = null;
			this.BtnInvoiceReport.ImageClickIndex = 0;
			this.BtnInvoiceReport.ImageIndex = 0;
			this.BtnInvoiceReport.ImageList = this.ButtonImgList;
			this.BtnInvoiceReport.Location = new System.Drawing.Point(144, 688);
			this.BtnInvoiceReport.Name = "BtnInvoiceReport";
			this.BtnInvoiceReport.ObjectValue = null;
			this.BtnInvoiceReport.Red = 2F;
			this.BtnInvoiceReport.Size = new System.Drawing.Size(110, 60);
			this.BtnInvoiceReport.TabIndex = 4;
			this.BtnInvoiceReport.Text = "Receipt";
			this.BtnInvoiceReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnInvoiceReport.Click += new System.EventHandler(this.BtnInvoiceReport_Click);
			// 
			// PanelSalesReport
			// 
			this.PanelSalesReport.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.PanelSalesReport.Controls.Add(this.DateSalesReport);
			this.PanelSalesReport.Controls.Add(this.TotalGrid);
			this.PanelSalesReport.Controls.Add(this.ReportGrid);
			this.PanelSalesReport.Location = new System.Drawing.Point(16, 80);
			this.PanelSalesReport.Name = "PanelSalesReport";
			this.PanelSalesReport.Size = new System.Drawing.Size(992, 608);
			this.PanelSalesReport.TabIndex = 5;
			// 
			// DateSalesReport
			// 
			this.DateSalesReport.CalendarFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateSalesReport.CustomFormat = "";
			this.DateSalesReport.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateSalesReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DateSalesReport.Location = new System.Drawing.Point(824, 8);
			this.DateSalesReport.Name = "DateSalesReport";
			this.DateSalesReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DateSalesReport.Size = new System.Drawing.Size(152, 30);
			this.DateSalesReport.TabIndex = 8;
			this.DateSalesReport.ValueChanged += new System.EventHandler(this.DateSalesReport_ValueChanged);
			// 
			// TotalGrid
			// 
			this.TotalGrid.AllowSorting = false;
			this.TotalGrid.AlternatingBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.TotalGrid.BackColor = System.Drawing.Color.White;
			this.TotalGrid.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.TotalGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TotalGrid.CaptionBackColor = System.Drawing.Color.Black;
			this.TotalGrid.CaptionForeColor = System.Drawing.Color.White;
			this.TotalGrid.CaptionVisible = false;
			this.TotalGrid.ColumnHeadersVisible = false;
			this.TotalGrid.DataMember = "";
			this.TotalGrid.FlatMode = true;
			this.TotalGrid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TotalGrid.ForeColor = System.Drawing.Color.Black;
			this.TotalGrid.GridLineColor = System.Drawing.Color.Silver;
			this.TotalGrid.HeaderBackColor = System.Drawing.Color.Black;
			this.TotalGrid.HeaderForeColor = System.Drawing.Color.White;
			this.TotalGrid.Location = new System.Drawing.Point(8, 568);
			this.TotalGrid.Name = "TotalGrid";
			this.TotalGrid.PreferredRowHeight = 32;
			this.TotalGrid.ReadOnly = true;
			this.TotalGrid.RowHeadersVisible = false;
			this.TotalGrid.SelectionBackColor = System.Drawing.Color.Navy;
			this.TotalGrid.Size = new System.Drawing.Size(976, 32);
			this.TotalGrid.TabIndex = 4;
			// 
			// ReportGrid
			// 
			this.ReportGrid.AllowSorting = false;
			this.ReportGrid.AlternatingBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.ReportGrid.BackColor = System.Drawing.Color.White;
			this.ReportGrid.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.ReportGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ReportGrid.CaptionBackColor = System.Drawing.Color.Black;
			this.ReportGrid.CaptionForeColor = System.Drawing.Color.White;
			this.ReportGrid.CaptionVisible = false;
			this.ReportGrid.DataMember = "";
			this.ReportGrid.FlatMode = true;
			this.ReportGrid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ReportGrid.ForeColor = System.Drawing.Color.Black;
			this.ReportGrid.GridLineColor = System.Drawing.Color.Silver;
			this.ReportGrid.HeaderBackColor = System.Drawing.Color.Black;
			this.ReportGrid.HeaderForeColor = System.Drawing.Color.White;
			this.ReportGrid.Location = new System.Drawing.Point(8, 48);
			this.ReportGrid.Name = "ReportGrid";
			this.ReportGrid.PreferredRowHeight = 32;
			this.ReportGrid.ReadOnly = true;
			this.ReportGrid.RowHeadersVisible = false;
			this.ReportGrid.SelectionBackColor = System.Drawing.Color.Navy;
			this.ReportGrid.Size = new System.Drawing.Size(976, 520);
			this.ReportGrid.TabIndex = 3;
			// 
			// PanelInvoiceReport
			// 
			this.PanelInvoiceReport.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.PanelInvoiceReport.Controls.Add(this.BtnPrintInvoiceReport);
			this.PanelInvoiceReport.Controls.Add(this.DateInvoiceReport);
			this.PanelInvoiceReport.Controls.Add(this.InvoiceSummaryGrid);
			this.PanelInvoiceReport.Controls.Add(this.InvoiceReportGrid);
			this.PanelInvoiceReport.Location = new System.Drawing.Point(16, 80);
			this.PanelInvoiceReport.Name = "PanelInvoiceReport";
			this.PanelInvoiceReport.Size = new System.Drawing.Size(992, 608);
			this.PanelInvoiceReport.TabIndex = 6;
			// 
			// DateInvoiceReport
			// 
			this.DateInvoiceReport.CalendarFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateInvoiceReport.CustomFormat = "";
			this.DateInvoiceReport.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateInvoiceReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DateInvoiceReport.Location = new System.Drawing.Point(824, 8);
			this.DateInvoiceReport.Name = "DateInvoiceReport";
			this.DateInvoiceReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DateInvoiceReport.Size = new System.Drawing.Size(152, 30);
			this.DateInvoiceReport.TabIndex = 7;
			this.DateInvoiceReport.ValueChanged += new System.EventHandler(this.DateInvoiceReport_ValueChanged);
			// 
			// InvoiceSummaryGrid
			// 
			this.InvoiceSummaryGrid.AllowSorting = false;
			this.InvoiceSummaryGrid.AlternatingBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.InvoiceSummaryGrid.BackColor = System.Drawing.Color.White;
			this.InvoiceSummaryGrid.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.InvoiceSummaryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.InvoiceSummaryGrid.CaptionBackColor = System.Drawing.Color.Black;
			this.InvoiceSummaryGrid.CaptionForeColor = System.Drawing.Color.White;
			this.InvoiceSummaryGrid.CaptionVisible = false;
			this.InvoiceSummaryGrid.DataMember = "";
			this.InvoiceSummaryGrid.FlatMode = true;
			this.InvoiceSummaryGrid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.InvoiceSummaryGrid.ForeColor = System.Drawing.Color.Black;
			this.InvoiceSummaryGrid.GridLineColor = System.Drawing.Color.Silver;
			this.InvoiceSummaryGrid.HeaderBackColor = System.Drawing.Color.Black;
			this.InvoiceSummaryGrid.HeaderForeColor = System.Drawing.Color.White;
			this.InvoiceSummaryGrid.Location = new System.Drawing.Point(8, 512);
			this.InvoiceSummaryGrid.Name = "InvoiceSummaryGrid";
			this.InvoiceSummaryGrid.PreferredRowHeight = 32;
			this.InvoiceSummaryGrid.ReadOnly = true;
			this.InvoiceSummaryGrid.RowHeadersVisible = false;
			this.InvoiceSummaryGrid.SelectionBackColor = System.Drawing.Color.Navy;
			this.InvoiceSummaryGrid.Size = new System.Drawing.Size(976, 90);
			this.InvoiceSummaryGrid.TabIndex = 4;
			// 
			// InvoiceReportGrid
			// 
			this.InvoiceReportGrid.AllowSorting = false;
			this.InvoiceReportGrid.AlternatingBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.InvoiceReportGrid.BackColor = System.Drawing.Color.White;
			this.InvoiceReportGrid.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.InvoiceReportGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.InvoiceReportGrid.CaptionBackColor = System.Drawing.Color.Black;
			this.InvoiceReportGrid.CaptionForeColor = System.Drawing.Color.White;
			this.InvoiceReportGrid.CaptionVisible = false;
			this.InvoiceReportGrid.DataMember = "";
			this.InvoiceReportGrid.FlatMode = true;
			this.InvoiceReportGrid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.InvoiceReportGrid.ForeColor = System.Drawing.Color.Black;
			this.InvoiceReportGrid.GridLineColor = System.Drawing.Color.Silver;
			this.InvoiceReportGrid.HeaderBackColor = System.Drawing.Color.Black;
			this.InvoiceReportGrid.HeaderForeColor = System.Drawing.Color.White;
			this.InvoiceReportGrid.Location = new System.Drawing.Point(8, 48);
			this.InvoiceReportGrid.Name = "InvoiceReportGrid";
			this.InvoiceReportGrid.PreferredRowHeight = 32;
			this.InvoiceReportGrid.ReadOnly = true;
			this.InvoiceReportGrid.RowHeadersVisible = false;
			this.InvoiceReportGrid.SelectionBackColor = System.Drawing.Color.Navy;
			this.InvoiceReportGrid.Size = new System.Drawing.Size(976, 464);
			this.InvoiceReportGrid.TabIndex = 3;
			this.InvoiceReportGrid.Click += new System.EventHandler(this.InvoiceReportGrid_Click);
			this.InvoiceReportGrid.DoubleClick += new System.EventHandler(this.InvoiceReportGrid_Click);
			// 
			// ButtonLiteImgList
			// 
			this.ButtonLiteImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonLiteImgList.ImageSize = new System.Drawing.Size(110, 40);
			this.ButtonLiteImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonLiteImgList.ImageStream")));
			this.ButtonLiteImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnMaintenance
			// 
			this.BtnMaintenance.BackColor = System.Drawing.Color.Transparent;
			this.BtnMaintenance.Blue = 1F;
			this.BtnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnMaintenance.Green = 2F;
			this.BtnMaintenance.ImageClick = null;
			this.BtnMaintenance.ImageClickIndex = 0;
			this.BtnMaintenance.ImageIndex = 0;
			this.BtnMaintenance.ImageList = this.ButtonImgList;
			this.BtnMaintenance.Location = new System.Drawing.Point(264, 688);
			this.BtnMaintenance.Name = "BtnMaintenance";
			this.BtnMaintenance.ObjectValue = null;
			this.BtnMaintenance.Red = 1F;
			this.BtnMaintenance.Size = new System.Drawing.Size(110, 60);
			this.BtnMaintenance.TabIndex = 7;
			this.BtnMaintenance.Text = "Maintenance";
			this.BtnMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnMaintenance.Click += new System.EventHandler(this.BtnMaintenance_Click);
			// 
			// PanelMaintenance
			// 
			this.PanelMaintenance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.PanelMaintenance.Controls.Add(this.groupPanel3);
			this.PanelMaintenance.Controls.Add(this.groupPanel2);
			this.PanelMaintenance.Controls.Add(this.groupPanel1);
			this.PanelMaintenance.Location = new System.Drawing.Point(16, 80);
			this.PanelMaintenance.Name = "PanelMaintenance";
			this.PanelMaintenance.Size = new System.Drawing.Size(992, 608);
			this.PanelMaintenance.TabIndex = 8;
			// 
			// groupPanel3
			// 
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.Caption = "Backup Database";
			this.groupPanel3.Controls.Add(this.label5);
			this.groupPanel3.Controls.Add(this.BtnBackup);
			this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel3.Location = new System.Drawing.Point(720, 16);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.ShowHeader = true;
			this.groupPanel3.Size = new System.Drawing.Size(256, 248);
			this.groupPanel3.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(24, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(216, 40);
			this.label5.TabIndex = 7;
			this.label5.Text = "Click \"Backup\" button for start backup database to disk.";
			// 
			// BtnBackup
			// 
			this.BtnBackup.BackColor = System.Drawing.Color.Transparent;
			this.BtnBackup.Blue = 2F;
			this.BtnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnBackup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnBackup.Green = 1F;
			this.BtnBackup.ImageClick = null;
			this.BtnBackup.ImageClickIndex = 0;
			this.BtnBackup.ImageIndex = 0;
			this.BtnBackup.ImageList = this.ButtonImgList;
			this.BtnBackup.Location = new System.Drawing.Point(80, 176);
			this.BtnBackup.Name = "BtnBackup";
			this.BtnBackup.ObjectValue = null;
			this.BtnBackup.Red = 1F;
			this.BtnBackup.Size = new System.Drawing.Size(110, 60);
			this.BtnBackup.TabIndex = 6;
			this.BtnBackup.Text = "Backup";
			this.BtnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
			// 
			// groupPanel2
			// 
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.Caption = "Export Invoice";
			this.groupPanel2.Controls.Add(this.DateExportTo);
			this.groupPanel2.Controls.Add(this.label9);
			this.groupPanel2.Controls.Add(this.label6);
			this.groupPanel2.Controls.Add(this.BtnExport);
			this.groupPanel2.Controls.Add(this.DateExportFrom);
			this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel2.Location = new System.Drawing.Point(368, 16);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.ShowHeader = true;
			this.groupPanel2.Size = new System.Drawing.Size(336, 248);
			this.groupPanel2.TabIndex = 11;
			// 
			// DateExportTo
			// 
			this.DateExportTo.CalendarFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateExportTo.CustomFormat = "";
			this.DateExportTo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateExportTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DateExportTo.Location = new System.Drawing.Point(136, 112);
			this.DateExportTo.Name = "DateExportTo";
			this.DateExportTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DateExportTo.Size = new System.Drawing.Size(152, 30);
			this.DateExportTo.TabIndex = 12;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(88, 120);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 16);
			this.label9.TabIndex = 11;
			this.label9.Text = "to";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(32, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "Export from";
			// 
			// BtnExport
			// 
			this.BtnExport.BackColor = System.Drawing.Color.Transparent;
			this.BtnExport.Blue = 2F;
			this.BtnExport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnExport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnExport.Green = 1F;
			this.BtnExport.ImageClick = null;
			this.BtnExport.ImageClickIndex = 0;
			this.BtnExport.ImageIndex = 0;
			this.BtnExport.ImageList = this.ButtonImgList;
			this.BtnExport.Location = new System.Drawing.Point(192, 176);
			this.BtnExport.Name = "BtnExport";
			this.BtnExport.ObjectValue = null;
			this.BtnExport.Red = 1F;
			this.BtnExport.Size = new System.Drawing.Size(110, 60);
			this.BtnExport.TabIndex = 5;
			this.BtnExport.Text = "Export";
			this.BtnExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
			// 
			// DateExportFrom
			// 
			this.DateExportFrom.CalendarFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateExportFrom.CustomFormat = "";
			this.DateExportFrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DateExportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DateExportFrom.Location = new System.Drawing.Point(136, 64);
			this.DateExportFrom.Name = "DateExportFrom";
			this.DateExportFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DateExportFrom.Size = new System.Drawing.Size(152, 30);
			this.DateExportFrom.TabIndex = 6;
			// 
			// groupPanel1
			// 
			this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel1.Caption = "Print Summary";
			this.groupPanel1.Controls.Add(this.label1);
			this.groupPanel1.Controls.Add(this.label2);
			this.groupPanel1.Controls.Add(this.label3);
			this.groupPanel1.Controls.Add(this.label4);
			this.groupPanel1.Controls.Add(this.BtnSumMenuType);
			this.groupPanel1.Controls.Add(this.BtnSumPayment);
			this.groupPanel1.Controls.Add(this.SummaryDate);
			this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel1.Location = new System.Drawing.Point(16, 16);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.ShowHeader = true;
			this.groupPanel1.Size = new System.Drawing.Size(336, 248);
			this.groupPanel1.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 7;
			this.label1.Text = "Step 1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(32, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Select date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 120);
			this.label3.Name = "label3";
			this.label3.TabIndex = 9;
			this.label3.Text = "Step 2";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(32, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(216, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Select print summary type";
			// 
			// BtnSumMenuType
			// 
			this.BtnSumMenuType.BackColor = System.Drawing.Color.Transparent;
			this.BtnSumMenuType.Blue = 2F;
			this.BtnSumMenuType.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSumMenuType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnSumMenuType.Green = 1F;
			this.BtnSumMenuType.ImageClick = null;
			this.BtnSumMenuType.ImageClickIndex = 0;
			this.BtnSumMenuType.ImageIndex = 0;
			this.BtnSumMenuType.ImageList = this.ButtonImgList;
			this.BtnSumMenuType.Location = new System.Drawing.Point(56, 176);
			this.BtnSumMenuType.Name = "BtnSumMenuType";
			this.BtnSumMenuType.ObjectValue = null;
			this.BtnSumMenuType.Red = 1F;
			this.BtnSumMenuType.Size = new System.Drawing.Size(110, 60);
			this.BtnSumMenuType.TabIndex = 4;
			this.BtnSumMenuType.Text = "Print Summary by Menu Type";
			this.BtnSumMenuType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnSumMenuType.Click += new System.EventHandler(this.BtnSumMenuType_Click);
			// 
			// BtnSumPayment
			// 
			this.BtnSumPayment.BackColor = System.Drawing.Color.Transparent;
			this.BtnSumPayment.Blue = 2F;
			this.BtnSumPayment.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSumPayment.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnSumPayment.Green = 1F;
			this.BtnSumPayment.ImageClick = null;
			this.BtnSumPayment.ImageClickIndex = 0;
			this.BtnSumPayment.ImageIndex = 0;
			this.BtnSumPayment.ImageList = this.ButtonImgList;
			this.BtnSumPayment.Location = new System.Drawing.Point(184, 176);
			this.BtnSumPayment.Name = "BtnSumPayment";
			this.BtnSumPayment.ObjectValue = null;
			this.BtnSumPayment.Red = 1F;
			this.BtnSumPayment.Size = new System.Drawing.Size(110, 60);
			this.BtnSumPayment.TabIndex = 5;
			this.BtnSumPayment.Text = "Print Summary by Payment Method";
			this.BtnSumPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnSumPayment.Click += new System.EventHandler(this.BtnSumPayment_Click);
			// 
			// SummaryDate
			// 
			this.SummaryDate.CalendarFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SummaryDate.CustomFormat = "";
			this.SummaryDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SummaryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.SummaryDate.Location = new System.Drawing.Point(136, 64);
			this.SummaryDate.Name = "SummaryDate";
			this.SummaryDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.SummaryDate.Size = new System.Drawing.Size(152, 30);
			this.SummaryDate.TabIndex = 6;
			this.SummaryDate.ValueChanged += new System.EventHandler(this.SummaryDate_ValueChanged);
			// 
			// BtnManagerMaintenance
			// 
			this.BtnManagerMaintenance.BackColor = System.Drawing.Color.Transparent;
			this.BtnManagerMaintenance.Blue = 0.5F;
			this.BtnManagerMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnManagerMaintenance.ForeColor = System.Drawing.Color.White;
			this.BtnManagerMaintenance.Green = 0.5F;
			this.BtnManagerMaintenance.ImageClick = null;
			this.BtnManagerMaintenance.ImageClickIndex = 0;
			this.BtnManagerMaintenance.ImageIndex = 0;
			this.BtnManagerMaintenance.ImageList = this.ButtonImgList;
			this.BtnManagerMaintenance.Location = new System.Drawing.Point(760, 688);
			this.BtnManagerMaintenance.Name = "BtnManagerMaintenance";
			this.BtnManagerMaintenance.ObjectValue = null;
			this.BtnManagerMaintenance.Red = 0.5F;
			this.BtnManagerMaintenance.Size = new System.Drawing.Size(110, 60);
			this.BtnManagerMaintenance.TabIndex = 9;
			this.BtnManagerMaintenance.Text = "Manager Maintenance";
			this.BtnManagerMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnManagerMaintenance.Click += new System.EventHandler(this.BtnManagerMaintenance_Click);
			// 
			// PanelManagerMaintenance
			// 
			this.PanelManagerMaintenance.BackColor = System.Drawing.Color.Gray;
			this.PanelManagerMaintenance.Controls.Add(this.groupPanel4);
			this.PanelManagerMaintenance.Location = new System.Drawing.Point(16, 80);
			this.PanelManagerMaintenance.Name = "PanelManagerMaintenance";
			this.PanelManagerMaintenance.Size = new System.Drawing.Size(992, 608);
			this.PanelManagerMaintenance.TabIndex = 10;
			// 
			// groupPanel4
			// 
			this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel4.Caption = "Void Selected";
			this.groupPanel4.Controls.Add(this.BtnDelete);
			this.groupPanel4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel4.Location = new System.Drawing.Point(16, 16);
			this.groupPanel4.Name = "groupPanel4";
			this.groupPanel4.ShowHeader = true;
			this.groupPanel4.Size = new System.Drawing.Size(336, 128);
			this.groupPanel4.TabIndex = 10;
			// 
			// BtnDelete
			// 
			this.BtnDelete.BackColor = System.Drawing.Color.Transparent;
			this.BtnDelete.Blue = 2F;
			this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BtnDelete.Green = 2F;
			this.BtnDelete.ImageClick = null;
			this.BtnDelete.ImageClickIndex = 0;
			this.BtnDelete.ImageIndex = 0;
			this.BtnDelete.ImageList = this.ButtonImgList;
			this.BtnDelete.Location = new System.Drawing.Point(208, 48);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.ObjectValue = null;
			this.BtnDelete.Red = 1F;
			this.BtnDelete.Size = new System.Drawing.Size(110, 60);
			this.BtnDelete.TabIndex = 5;
			this.BtnDelete.Text = "Void";
			this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// BtnPrintInvoiceReport
			// 
			this.BtnPrintInvoiceReport.BackColor = System.Drawing.Color.Transparent;
			this.BtnPrintInvoiceReport.Blue = 2F;
			this.BtnPrintInvoiceReport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnPrintInvoiceReport.Green = 1F;
			this.BtnPrintInvoiceReport.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnPrintInvoiceReport.ImageClick")));
			this.BtnPrintInvoiceReport.ImageClickIndex = 1;
			this.BtnPrintInvoiceReport.ImageIndex = 0;
			this.BtnPrintInvoiceReport.ImageList = this.ButtonLiteImgList;
			this.BtnPrintInvoiceReport.Location = new System.Drawing.Point(8, 5);
			this.BtnPrintInvoiceReport.Name = "BtnPrintInvoiceReport";
			this.BtnPrintInvoiceReport.ObjectValue = null;
			this.BtnPrintInvoiceReport.Red = 1F;
			this.BtnPrintInvoiceReport.Size = new System.Drawing.Size(110, 40);
			this.BtnPrintInvoiceReport.TabIndex = 8;
			this.BtnPrintInvoiceReport.Text = "Print List";
			this.BtnPrintInvoiceReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnPrintInvoiceReport.Click += new System.EventHandler(this.BtnPrintInvoiceReport_Click);
			// 
			// SalesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.Add(this.BtnManagerMaintenance);
			this.Controls.Add(this.BtnMaintenance);
			this.Controls.Add(this.BtnInvoiceReport);
			this.Controls.Add(this.BtnSaleReport);
			this.Controls.Add(this.BtnMain);
			this.Controls.Add(this.PanelInvoiceReport);
			this.Controls.Add(this.PanelSalesReport);
			this.Controls.Add(this.PanelManagerMaintenance);
			this.Controls.Add(this.PanelMaintenance);
			this.Name = "SalesForm";
			this.Text = "SalesForm";
			this.PanelSalesReport.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TotalGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ReportGrid)).EndInit();
			this.PanelInvoiceReport.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.InvoiceSummaryGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceReportGrid)).EndInit();
			this.PanelMaintenance.ResumeLayout(false);
			this.groupPanel3.ResumeLayout(false);
			this.groupPanel2.ResumeLayout(false);
			this.groupPanel1.ResumeLayout(false);
			this.PanelManagerMaintenance.ResumeLayout(false);
			this.groupPanel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void UpdateForm()
		{
			if (((MainForm)MdiParent).User.IsManager())
			{
				BtnManagerMaintenance.Visible = true;
			}
			else
			{
				BtnManagerMaintenance.Visible = false;
			}
			Changed = true;
			DateSalesReport.Value = DateTime.Today;
			DateInvoiceReport.Value = DateTime.Today;
			SummaryDate.Value = DateTime.Today;
			Changed = false;
			UpdateSalesReport();
		}

		private void UpdateSalesReport()
		{
			PanelSalesReport.BringToFront();
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			DataTable dTable = ReportConverter.Convert(service.GetSalesReport(DateSalesReport.Value, ((MainForm)MdiParent).User.EmployeeTypeID));
			if (dTable == null)
				return;
			// Compute total
			double[] sum = new double[dTable.Columns.Count - 1];
			for (int i = 0;i < dTable.Rows.Count;i++)
			{
				for (int j = 1;j < dTable.Columns.Count;j++)
				{
					double p = double.Parse(dTable.Rows[i][j].ToString());
					dTable.Rows[i][j] = p.ToString("N");
					sum[j - 1] += p;
				}
			}
			// Create total table
			DataTable tTable = new DataTable();
			for (int i = 0;i < dTable.Columns.Count;i++)
				tTable.Columns.Add(new DataColumn(dTable.Columns[i].ColumnName));
			DataRow row = tTable.NewRow();
			row[0] = "Total";
			for (int i = 1;i < dTable.Columns.Count;i++)
				row[i] = sum[i - 1].ToString("N");
			tTable.Rows.Add(row);
			// Bind data to data grid
			ReportGrid.DataSource = dTable;
			DataGridTableStyle tStyle = new DataGridTableStyle();
			tStyle.RowHeadersVisible = false;
			tStyle.PreferredRowHeight = 32;
			tStyle.PreferredColumnWidth = (ReportGrid.Width - 16) / dTable.Columns.Count;
			tStyle.HeaderBackColor = Color.Black;
			tStyle.HeaderForeColor = Color.White;
			for (int i = 0;i < dTable.Columns.Count;i++)
			{
				DataGridColumnStyle cStyle = new DataGridTextBoxColumn();
				if (i == 0)
					cStyle.HeaderText = "";
				else
					cStyle.HeaderText = dTable.Columns[i].ColumnName;
				cStyle.MappingName = dTable.Columns[i].ColumnName;
				cStyle.Alignment = HorizontalAlignment.Center;
				tStyle.GridColumnStyles.Add(cStyle);
			}
			ReportGrid.TableStyles.Clear();
			ReportGrid.TableStyles.Add(tStyle);
			// Bind total to total grid
			TotalGrid.DataSource = tTable;
			tStyle = new DataGridTableStyle();
			tStyle.RowHeadersVisible = false;
			tStyle.ColumnHeadersVisible = false;
			tStyle.PreferredRowHeight = 32;
			tStyle.PreferredColumnWidth = (TotalGrid.Width - 16) / tTable.Columns.Count;
			tStyle.BackColor = Color.DarkRed;
			tStyle.ForeColor = Color.White;
			for (int i = 0;i < tTable.Columns.Count;i++)
			{
				DataGridColumnStyle cStyle = new DataGridTextBoxColumn();
				cStyle.HeaderText = "";
				cStyle.MappingName = tTable.Columns[i].ColumnName;
				cStyle.Alignment = HorizontalAlignment.Center;
				tStyle.GridColumnStyles.Add(cStyle);
			}
			TotalGrid.TableStyles.Clear();
			TotalGrid.TableStyles.Add(tStyle);
		}

		private void UpdateInvoiceReport()
		{
			PanelInvoiceReport.BringToFront();
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			DataTable dTable = ReportConverter.Convert(service.GetInvoiceReport(DateInvoiceReport.Value, ((MainForm)MdiParent).User.EmployeeTypeID));
			if (dTable == null)
				return;
			// Add order column
			if (((MainForm)MdiParent).User.IsManager())
				dTable.Columns.Add("Selected", typeof(bool));
			dTable.Columns.Add("View", typeof(bool));
			dTable.Columns.Add("No.", typeof(string));
			string oldInvoiceID = "";
			int cnt = 1;
			for (int i = 0;i < dTable.Rows.Count;i++)
			{
				bool selected = (dTable.Rows[i]["hidden"].ToString() == "True");
				if (((MainForm)MdiParent).User.IsManager())
					dTable.Rows[i]["Selected"] = (dTable.Rows[i]["hidden"].ToString() == "True");
				dTable.Rows[i]["View"] = false;
				if (oldInvoiceID == dTable.Rows[i]["invoiceid"].ToString())
				{
					dTable.Rows[i]["No."] = "";
					continue;
				}
				dTable.Rows[i]["No."] = (cnt++).ToString();
				oldInvoiceID = dTable.Rows[i]["invoiceid"].ToString();
			}
			dTable.Columns.Remove("hidden");
			// Bind data to data grid
			InvoiceReportGrid.DataSource = dTable;
			DataGridTableStyle tStyle = new DataGridTableStyle();
			tStyle.RowHeadersVisible = false;
			tStyle.PreferredRowHeight = 32;
			tStyle.PreferredColumnWidth = (InvoiceReportGrid.Width - 66) / (dTable.Columns.Count - 3);
			tStyle.HeaderBackColor = Color.Black;
			tStyle.HeaderForeColor = Color.White;
			tStyle.AllowSorting = false;
			// Manage Column
			DataGridColumnStyle cStyle = new DataGridTextBoxColumn();
			cStyle.HeaderText = "No.";
			cStyle.MappingName = "No.";
			cStyle.Alignment = HorizontalAlignment.Center;
			cStyle.Width = 50;
			tStyle.GridColumnStyles.Add(cStyle);
			for (int i = 2;i < dTable.Columns.Count - 1;i++)
			{
				if (i >= 5)
					cStyle = new DataGridBoolColumn();
				else
					cStyle = new DataGridTextBoxColumn();
				cStyle.HeaderText = dTable.Columns[i].ColumnName;
				cStyle.MappingName = dTable.Columns[i].ColumnName;
				cStyle.Alignment = HorizontalAlignment.Center;
				cStyle.ReadOnly = false;
				tStyle.GridColumnStyles.Add(cStyle);
			}
			InvoiceReportGrid.TableStyles.Clear();
			InvoiceReportGrid.TableStyles.Add(tStyle);
			Table = dTable;
			UpdateInvoiceSummaryReport();
		}

		private void UpdateMaintenance()
		{
			PanelMaintenance.BringToFront();
		}

		private void UpdateManagerMaintenance()
		{
			PanelManagerMaintenance.BringToFront();
		}

		private void UpdateInvoiceSummaryReport()
		{
			// Invoice Summary
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			DataTable dTable = ReportConverter.Convert(service.GetInvoiceSummaryReport(DateInvoiceReport.Value, ((MainForm)MdiParent).User.EmployeeTypeID));
			if (dTable == null)
				return;
			// Change text format
			for (int i = 0;i < dTable.Rows.Count;i++)
			{
				for (int j = 1;j < dTable.Columns.Count;j++)
				{
					double p = double.Parse(dTable.Rows[i][j].ToString());
					dTable.Rows[i][j] = p.ToString("N");
				}
			}
			// Bind data to data grid
			InvoiceSummaryGrid.DataSource = dTable;
			DataGridTableStyle tStyle = new DataGridTableStyle();
			tStyle.RowHeadersVisible = false;
			tStyle.PreferredRowHeight = 32;
			tStyle.PreferredColumnWidth = (InvoiceSummaryGrid.Width - 16) / dTable.Columns.Count;
			tStyle.HeaderBackColor = Color.Black;
			tStyle.HeaderForeColor = Color.White;
			for (int i = 0;i < dTable.Columns.Count;i++)
			{
				DataGridColumnStyle cStyle = new DataGridTextBoxColumn();
				if (i == 0)
					cStyle.HeaderText = "";
				else
					cStyle.HeaderText = dTable.Columns[i].ColumnName;
				cStyle.MappingName = dTable.Columns[i].ColumnName;
				cStyle.Alignment = HorizontalAlignment.Center;
				tStyle.GridColumnStyles.Add(cStyle);
			}
			InvoiceSummaryGrid.TableStyles.Clear();
			InvoiceSummaryGrid.TableStyles.Add(tStyle);
		}

		private void BtnMain_Click(object sender, System.EventArgs e)
		{
			((MainForm)MdiParent).ShowMainMenuForm();
		}

		private void BtnSaleReport_Click(object sender, System.EventArgs e)
		{
			UpdateSalesReport();
		}

		private void BtnInvoiceReport_Click(object sender, System.EventArgs e)
		{
			UpdateInvoiceReport();
		}

		private void BtnMaintenance_Click(object sender, System.EventArgs e)
		{
			UpdateMaintenance();
		}

		private void BtnManagerMaintenance_Click(object sender, System.EventArgs e)
		{
			UpdateManagerMaintenance();
		}

		private void InvoiceReportGrid_Click(object sender, System.EventArgs e)
		{
			int invoiceID;
			if (InvoiceReportGrid.CurrentCell.ColumnNumber == 4 && ((MainForm)MdiParent).User.IsManager())
			{
				invoiceID = int.Parse(Table.Rows[InvoiceReportGrid.CurrentCell.RowNumber]["invoiceid"].ToString());
				bool selected = !(bool)(Table.Rows[InvoiceReportGrid.CurrentCell.RowNumber]["Selected"]);
				for (int i = 0;i < Table.Rows.Count;i++)
					if (Table.Rows[i]["invoiceid"].ToString() == invoiceID.ToString())
						Table.Rows[i]["Selected"] = selected;
				BusinessService.BusinessService service = new BusinessService.BusinessService();
				service.UpdateInvoiceHidden(invoiceID, selected);
				UpdateInvoiceSummaryReport();
			}
			else if (InvoiceReportGrid.CurrentCell.ColumnNumber == 5 ||
				InvoiceReportGrid.CurrentCell.ColumnNumber == 4 && ((MainForm)MdiParent).User.IsAuditor())
			{
				invoiceID = int.Parse(Table.Rows[InvoiceReportGrid.CurrentCell.RowNumber]["invoiceid"].ToString());
				InvoiceViewerForm.Show(invoiceID);
			}
		}

		private void BtnSumMenuType_Click(object sender, System.EventArgs e)
		{
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			WaitingForm.Show("Print Summary");
			service.PrintSummaryMenuType(SummaryDate.Value);
			WaitingForm.HideForm();
		}

		private void BtnSumPayment_Click(object sender, System.EventArgs e)
		{
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			WaitingForm.Show("Print Summary");
			service.PrintSummaryReceive(SummaryDate.Value);
			WaitingForm.HideForm();
		}

		private void DateSalesReport_ValueChanged(object sender, System.EventArgs e)
		{
			if (Changed)
				return;
			Changed = true;
			DateInvoiceReport.Value = DateSalesReport.Value;
			SummaryDate.Value = DateSalesReport.Value;
			Changed = false;
			UpdateSalesReport();
		}

		private void DateInvoiceReport_ValueChanged(object sender, System.EventArgs e)
		{
			if (Changed)
				return;
			Changed = true;
			DateSalesReport.Value = DateInvoiceReport.Value;
			SummaryDate.Value = DateInvoiceReport.Value;
			Changed = false;
			UpdateInvoiceReport();
		}

		private void SummaryDate_ValueChanged(object sender, System.EventArgs e)
		{
			if (Changed)
				return;
			Changed = true;
			DateSalesReport.Value = SummaryDate.Value;
			DateInvoiceReport.Value = SummaryDate.Value;
			Changed = false;
		}

		private void BtnExport_Click(object sender, System.EventArgs e)
		{
			if (DateExportFrom.Value > DateExportTo.Value)
			{
				MessageForm.Show("Export Invoice", "Please select from date less or equal to date.");
				return;
			}
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			DataTable dTable = ReportConverter.Convert(service.ExportInvoice(DateExportFrom.Value, DateExportTo.Value));
			if (dTable == null)
			{
				MessageForm.Show("Export Invoice", "No invoice in range to export.");
				return;
			}
			// Create output file
			DateTime now = DateTime.Now;
			StringBuilder sb = new StringBuilder();
			CheckBillService.CheckBillService bService = new CheckBillService.CheckBillService();
			string path = bService.GetDescription("EXPORT_PATH");
			sb.Append(path);
			sb.Append("invoice_");
			sb.Append(now.ToString("yyyyMMddhhmmss"));
			sb.Append(".csv");
			StreamWriter sw = File.CreateText(sb.ToString());
			// Write Header
			sb.Length = 0;
			sb.Append("Export Invoice when ");
			sb.Append(now.ToString("dd/MM/yyyy hh:mm:ss"));
			sw.WriteLine(sb.ToString());
			sb.Length = 0;
			for (int i = 0;i < dTable.Columns.Count;i++)
			{
				if (i > 0)
					sb.Append(",\"");
				else
					sb.Append("\"");
				sb.Append(dTable.Columns[i].ColumnName);
				sb.Append("\"");
			}
			sw.WriteLine(sb.ToString());
			// Write Data
			for (int i = 0;i < dTable.Rows.Count;i++)
			{
				DataRow row = dTable.Rows[i];
				sb.Length = 0;
				for (int j = 0;j < row.ItemArray.Length;j++)
				{
					if (j > 0)
						sb.Append(",");
					sb.Append(row[j].ToString());
				}
				sw.WriteLine(sb.ToString());
			}
			sw.Close();
			MessageForm.Show("Export Invoice", "Export Invoice Completed...");
		}

		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			service.DeleteSelected();
			MessageForm.Show("Void Selected", "Void Selected Completed...");
		}

		private void BtnBackup_Click(object sender, System.EventArgs e)
		{
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			service.BackupDatabase();
			MessageForm.Show("Backup Database", "Backup Database Completed...");
		}

		private void BtnPrintInvoiceReport_Click(object sender, System.EventArgs e)
		{
			WaitingForm.Show("Print Invoice Report");
			this.Enabled = false;
			BusinessService.BusinessService service = new BusinessService.BusinessService();
			service.PrintInvoiceReport(DateInvoiceReport.Value, ((MainForm)MdiParent).User.EmployeeTypeID);
			this.Enabled = true;
			WaitingForm.HideForm();
		}
	}
}
