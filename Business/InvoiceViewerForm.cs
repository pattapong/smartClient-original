using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using smartRestaurant.Data;
using smartRestaurant.Utils;

namespace smartRestaurant.Business
{
	/// <summary>
	/// Summary description for InvoiceViewerForm.
	/// </summary>
	public class InvoiceViewerForm : System.Windows.Forms.Form
	{
		private static InvoiceViewerForm instance = null;

		private System.Windows.Forms.ImageList ButtonImgList;
		private smartRestaurant.Controls.ImageButton BtnOk;
		private smartRestaurant.Controls.GroupPanel groupPanel1;
		private System.Windows.Forms.Label FieldChange;
		private System.Windows.Forms.Label FieldTotalReceive;
		private System.Windows.Forms.Label FieldTotalDue;
		private System.Windows.Forms.Label FieldTotalDiscount;
		private System.Windows.Forms.Label FieldTax2;
		private System.Windows.Forms.Label FieldTax1;
		private System.Windows.Forms.Label FieldAmountDue;
		private System.Windows.Forms.Label LblTotalChange;
		private System.Windows.Forms.Label LblTotalReceive;
		private System.Windows.Forms.Label LblTotalDue;
		private System.Windows.Forms.Label LblTotalDiscount;
		private System.Windows.Forms.Label LblTax2;
		private System.Windows.Forms.Label LblTax1;
		private System.Windows.Forms.Label LblAmountDue;
		private System.ComponentModel.IContainer components;
		private smartRestaurant.Controls.ImageButton BtnReprint;

		private Receipt		receipt;

		public InvoiceViewerForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(InvoiceViewerForm));
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnOk = new smartRestaurant.Controls.ImageButton();
			this.groupPanel1 = new smartRestaurant.Controls.GroupPanel();
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
			this.BtnReprint = new smartRestaurant.Controls.ImageButton();
			this.groupPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnOk
			// 
			this.BtnOk.BackColor = System.Drawing.Color.Transparent;
			this.BtnOk.Blue = 1F;
			this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnOk.Green = 1F;
			this.BtnOk.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnOk.Image")));
			this.BtnOk.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnOk.ImageClick")));
			this.BtnOk.ImageClickIndex = 0;
			this.BtnOk.Location = new System.Drawing.Point(216, 344);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.ObjectValue = null;
			this.BtnOk.Red = 1F;
			this.BtnOk.Size = new System.Drawing.Size(110, 60);
			this.BtnOk.TabIndex = 5;
			this.BtnOk.Text = "Ok";
			this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// groupPanel1
			// 
			this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel1.Caption = null;
			this.groupPanel1.Controls.AddRange(new System.Windows.Forms.Control[] {
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
																					  this.LblAmountDue});
			this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.groupPanel1.Location = new System.Drawing.Point(8, 40);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.ShowHeader = false;
			this.groupPanel1.Size = new System.Drawing.Size(320, 296);
			this.groupPanel1.TabIndex = 38;
			// 
			// FieldChange
			// 
			this.FieldChange.Location = new System.Drawing.Point(156, 248);
			this.FieldChange.Name = "FieldChange";
			this.FieldChange.Size = new System.Drawing.Size(160, 40);
			this.FieldChange.TabIndex = 51;
			this.FieldChange.Text = "0.00";
			this.FieldChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTotalReceive
			// 
			this.FieldTotalReceive.Location = new System.Drawing.Point(156, 208);
			this.FieldTotalReceive.Name = "FieldTotalReceive";
			this.FieldTotalReceive.Size = new System.Drawing.Size(160, 40);
			this.FieldTotalReceive.TabIndex = 50;
			this.FieldTotalReceive.Text = "0.00";
			this.FieldTotalReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTotalDue
			// 
			this.FieldTotalDue.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FieldTotalDue.ForeColor = System.Drawing.Color.Green;
			this.FieldTotalDue.Location = new System.Drawing.Point(156, 168);
			this.FieldTotalDue.Name = "FieldTotalDue";
			this.FieldTotalDue.Size = new System.Drawing.Size(160, 40);
			this.FieldTotalDue.TabIndex = 49;
			this.FieldTotalDue.Text = "0.00";
			this.FieldTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTotalDiscount
			// 
			this.FieldTotalDiscount.Location = new System.Drawing.Point(156, 48);
			this.FieldTotalDiscount.Name = "FieldTotalDiscount";
			this.FieldTotalDiscount.Size = new System.Drawing.Size(160, 40);
			this.FieldTotalDiscount.TabIndex = 48;
			this.FieldTotalDiscount.Text = "0.00";
			this.FieldTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTax2
			// 
			this.FieldTax2.Location = new System.Drawing.Point(156, 128);
			this.FieldTax2.Name = "FieldTax2";
			this.FieldTax2.Size = new System.Drawing.Size(160, 40);
			this.FieldTax2.TabIndex = 47;
			this.FieldTax2.Text = "0.00";
			this.FieldTax2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldTax1
			// 
			this.FieldTax1.Location = new System.Drawing.Point(156, 88);
			this.FieldTax1.Name = "FieldTax1";
			this.FieldTax1.Size = new System.Drawing.Size(160, 40);
			this.FieldTax1.TabIndex = 46;
			this.FieldTax1.Text = "0.00";
			this.FieldTax1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FieldAmountDue
			// 
			this.FieldAmountDue.Location = new System.Drawing.Point(156, 8);
			this.FieldAmountDue.Name = "FieldAmountDue";
			this.FieldAmountDue.Size = new System.Drawing.Size(160, 40);
			this.FieldAmountDue.TabIndex = 45;
			this.FieldAmountDue.Text = "0.00";
			this.FieldAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LblTotalChange
			// 
			this.LblTotalChange.Location = new System.Drawing.Point(4, 248);
			this.LblTotalChange.Name = "LblTotalChange";
			this.LblTotalChange.Size = new System.Drawing.Size(144, 40);
			this.LblTotalChange.TabIndex = 44;
			this.LblTotalChange.Text = "Change";
			this.LblTotalChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTotalReceive
			// 
			this.LblTotalReceive.Location = new System.Drawing.Point(4, 208);
			this.LblTotalReceive.Name = "LblTotalReceive";
			this.LblTotalReceive.Size = new System.Drawing.Size(144, 40);
			this.LblTotalReceive.TabIndex = 43;
			this.LblTotalReceive.Text = "Total Receive";
			this.LblTotalReceive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTotalDue
			// 
			this.LblTotalDue.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblTotalDue.ForeColor = System.Drawing.Color.Green;
			this.LblTotalDue.Location = new System.Drawing.Point(4, 168);
			this.LblTotalDue.Name = "LblTotalDue";
			this.LblTotalDue.Size = new System.Drawing.Size(144, 40);
			this.LblTotalDue.TabIndex = 42;
			this.LblTotalDue.Text = "Total Due";
			this.LblTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTotalDiscount
			// 
			this.LblTotalDiscount.Location = new System.Drawing.Point(4, 48);
			this.LblTotalDiscount.Name = "LblTotalDiscount";
			this.LblTotalDiscount.Size = new System.Drawing.Size(144, 40);
			this.LblTotalDiscount.TabIndex = 41;
			this.LblTotalDiscount.Text = "Total Discount";
			this.LblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTax2
			// 
			this.LblTax2.Location = new System.Drawing.Point(4, 128);
			this.LblTax2.Name = "LblTax2";
			this.LblTax2.Size = new System.Drawing.Size(144, 40);
			this.LblTax2.TabIndex = 40;
			this.LblTax2.Text = "Tax2";
			this.LblTax2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblTax1
			// 
			this.LblTax1.Location = new System.Drawing.Point(4, 88);
			this.LblTax1.Name = "LblTax1";
			this.LblTax1.Size = new System.Drawing.Size(144, 40);
			this.LblTax1.TabIndex = 39;
			this.LblTax1.Text = "Tax1";
			this.LblTax1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblAmountDue
			// 
			this.LblAmountDue.Location = new System.Drawing.Point(4, 8);
			this.LblAmountDue.Name = "LblAmountDue";
			this.LblAmountDue.Size = new System.Drawing.Size(144, 40);
			this.LblAmountDue.TabIndex = 38;
			this.LblAmountDue.Text = "Amount Due";
			this.LblAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BtnReprint
			// 
			this.BtnReprint.BackColor = System.Drawing.Color.Transparent;
			this.BtnReprint.Blue = 2F;
			this.BtnReprint.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnReprint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnReprint.Green = 1F;
			this.BtnReprint.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnReprint.Image")));
			this.BtnReprint.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnReprint.ImageClick")));
			this.BtnReprint.ImageClickIndex = 0;
			this.BtnReprint.Location = new System.Drawing.Point(8, 344);
			this.BtnReprint.Name = "BtnReprint";
			this.BtnReprint.ObjectValue = null;
			this.BtnReprint.Red = 2F;
			this.BtnReprint.Size = new System.Drawing.Size(110, 60);
			this.BtnReprint.TabIndex = 39;
			this.BtnReprint.Text = "Reprint";
			this.BtnReprint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnReprint.Click += new System.EventHandler(this.BtnReprint_Click);
			// 
			// InvoiceViewerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 20);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(336, 408);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnReprint,
																		  this.groupPanel1,
																		  this.BtnOk});
			this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "InvoiceViewerForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Invoice Viewer";
			this.groupPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

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
		}

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

		public static void Show(int invoiceID)
		{
			if (instance == null)
				instance = new InvoiceViewerForm();
			if (AppParameter.IsDemo())
				instance.LblTotalChange.Text = "Change";
			else
				instance.LblTotalChange.Text = "Tip";
			instance.receipt = new Receipt(invoiceID);
			instance.UpdateSummary();
			instance.ShowDialog();
		}

		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void BtnReprint_Click(object sender, System.EventArgs e)
		{
			WaitingForm.Show("Print Receipt");
			this.Enabled = false;
			receipt.PrintInvoice();
			this.Enabled = true;
			WaitingForm.HideForm();
		}
	}
}
