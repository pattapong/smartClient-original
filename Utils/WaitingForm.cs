using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace smartRestaurant.Utils
{
	/// <summary>
	/// Summary description for WaitingForm.
	/// </summary>
	public class WaitingForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList PrintImgList;
		private System.Windows.Forms.PictureBox ImgPrinter;
		private System.Windows.Forms.Timer IconChangeTimer;
		private System.ComponentModel.IContainer components;

		private static WaitingForm instance = null;
		private static int iconCount;

		public WaitingForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WaitingForm));
			this.label1 = new System.Windows.Forms.Label();
			this.PrintImgList = new System.Windows.Forms.ImageList(this.components);
			this.IconChangeTimer = new System.Windows.Forms.Timer(this.components);
			this.ImgPrinter = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(96, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please wait . . .";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PrintImgList
			// 
			this.PrintImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.PrintImgList.ImageSize = new System.Drawing.Size(44, 49);
			this.PrintImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PrintImgList.ImageStream")));
			this.PrintImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// IconChangeTimer
			// 
			this.IconChangeTimer.Interval = 25;
			this.IconChangeTimer.Tick += new System.EventHandler(this.IconChangeTimer_Tick);
			// 
			// ImgPrinter
			// 
			this.ImgPrinter.BackColor = System.Drawing.Color.Transparent;
			this.ImgPrinter.Location = new System.Drawing.Point(32, 64);
			this.ImgPrinter.Name = "ImgPrinter";
			this.ImgPrinter.Size = new System.Drawing.Size(44, 49);
			this.ImgPrinter.TabIndex = 1;
			this.ImgPrinter.TabStop = false;
			// 
			// WaitingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 23);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(344, 144);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ImgPrinter,
																		  this.label1});
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "WaitingForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Waiting";
			this.TopMost = true;
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

		public static void Show(string caption)
		{
			if (instance == null)
			{
				instance = new WaitingForm();
			}
			iconCount = 0;
			instance.ImgPrinter.Image = instance.PrintImgList.Images[iconCount++];
			instance.Text = caption;
			instance.Show();
			instance.Refresh();
			instance.IconChangeTimer.Start();
		}

		public static void HideForm()
		{
			if (instance == null)
				return;
			instance.Hide();
			instance.IconChangeTimer.Stop();
		}

		private void IconChangeTimer_Tick(object sender, System.EventArgs e)
		{
			ImgPrinter.Image = PrintImgList.Images[iconCount++];
			if (iconCount >= PrintImgList.Images.Count)
				iconCount = 0;
		}
	}
}
