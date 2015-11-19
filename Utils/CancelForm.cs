using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace smartRestaurant.Utils
{
	/// <summary>
	/// Summary description for CancelForm.
	/// </summary>
	public class CancelForm : System.Windows.Forms.Form
	{
		private static CancelForm instance = null;
		private static OrderService.CancelReason[] reasons = null;

		private smartRestaurant.Controls.ImageButton BtnOk;
		private System.Windows.Forms.ComboBox LstCancelReason;
		private System.Windows.Forms.Label LblCancalReason;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CancelForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (reasons == null)
			{
				OrderService.OrderService service = new OrderService.OrderService();
				reasons = service.GetCancelReason();
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CancelForm));
			this.LstCancelReason = new System.Windows.Forms.ComboBox();
			this.LblCancalReason = new System.Windows.Forms.Label();
			this.BtnOk = new smartRestaurant.Controls.ImageButton();
			this.SuspendLayout();
			// 
			// LstCancelReason
			// 
			this.LstCancelReason.Location = new System.Drawing.Point(160, 48);
			this.LstCancelReason.Name = "LstCancelReason";
			this.LstCancelReason.Size = new System.Drawing.Size(256, 31);
			this.LstCancelReason.TabIndex = 0;
			// 
			// LblCancalReason
			// 
			this.LblCancalReason.Location = new System.Drawing.Point(16, 51);
			this.LblCancalReason.Name = "LblCancalReason";
			this.LblCancalReason.Size = new System.Drawing.Size(136, 23);
			this.LblCancalReason.TabIndex = 1;
			this.LblCancalReason.Text = "Cancel Reason";
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
			this.BtnOk.Location = new System.Drawing.Point(304, 96);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.ObjectValue = null;
			this.BtnOk.Red = 1F;
			this.BtnOk.Size = new System.Drawing.Size(110, 60);
			this.BtnOk.TabIndex = 2;
			this.BtnOk.Text = "Ok";
			this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// CancelForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 23);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(432, 168);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnOk,
																		  this.LblCancalReason,
																		  this.LstCancelReason});
			this.Font = new System.Drawing.Font("Tahoma", 14.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CancelForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CancelForm";
			this.ResumeLayout(false);

		}
		#endregion

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

		public static int Show(string caption)
		{
			if (instance == null)
			{
				instance = new CancelForm();
				if (reasons != null)
				{
					instance.LstCancelReason.Items.Add("Other");
					for (int i = 0;i < reasons.Length;i++)
						instance.LstCancelReason.Items.Add(reasons[i].Reason);
				}
			}
			if (reasons == null)
				return 0;
			instance.Text = caption;
			instance.LstCancelReason.SelectedIndex = 0;
			instance.LstCancelReason.Text = instance.LstCancelReason.Items[0].ToString();
			instance.ShowDialog();
			if (instance.LstCancelReason.SelectedIndex == 0)
				return 0;
			return reasons[instance.LstCancelReason.SelectedIndex - 1].CancelReasonID;
		}

		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
