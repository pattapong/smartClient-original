using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace smartRestaurant
{
	/// <summary>
	/// Summary description for SmartForm.
	/// </summary>
	public class SmartForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList ImgLogo;

		private static System.Drawing.Font titleFont, smallFont;
		private static System.Drawing.Font titleBoldFont, smallBoldFont;

		private const int HEADER_HEIGHT = 60;
		private const int FORM_WIDTH = 1020;
		private const int FORM_HEIGHT = 764;

		public SmartForm()
		{
			//
			// TODO: Add constructor logic here
			//
			//InitializeComponent();
			if (titleFont == null)
			{
				titleFont = new Font("Tahoma", 30, FontStyle.Italic, GraphicsUnit.Pixel);
				smallFont = new Font("Tahoma", 12, FontStyle.Italic, GraphicsUnit.Pixel);
				titleBoldFont = new Font("Tahoma", 30, FontStyle.Bold , GraphicsUnit.Pixel);
				smallBoldFont = new Font("Tahoma", 12, FontStyle.Bold , GraphicsUnit.Pixel);
			}
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SmartForm));
			this.ImgLogo = new System.Windows.Forms.ImageList();
			this.ImgLogo.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ImgLogo.ImageSize = new System.Drawing.Size(55, 59);
			this.ImgLogo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLogo.ImageStream")));
			this.ImgLogo.TransparentColor = System.Drawing.Color.Transparent;

			this.BackColor = Color.White;
			this.AutoScroll = false;
			this.Size = new System.Drawing.Size(FORM_WIDTH, FORM_HEIGHT);
			this.StartPosition = FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Font = new Font("Tahoma", 12f, GraphicsUnit.Pixel);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SmartForm_Paint);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void SmartForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, FORM_WIDTH, HEADER_HEIGHT - 1);
			LinearGradientBrush gBrush = new LinearGradientBrush(
					rect,
					Color.FromArgb(103, 138, 198),
					Color.White, 0f);
			e.Graphics.FillRectangle(gBrush, rect);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(180, 180, 180)), 0, HEADER_HEIGHT - 1, FORM_WIDTH - 1, HEADER_HEIGHT - 1);

			rect = new Rectangle(0, HEADER_HEIGHT, FORM_WIDTH, FORM_HEIGHT - HEADER_HEIGHT);
			gBrush = new LinearGradientBrush(
				rect,
				Color.FromArgb(230, 230, 230),
				Color.White, 180f);
			e.Graphics.FillRectangle(gBrush, rect);

			if (ImgLogo != null && ImgLogo.Images != null && ImgLogo.Images.Count > 0)
				e.Graphics.DrawImage(ImgLogo.Images[0], 0, 0);
			/*e.Graphics.DrawString(this.Text, titleFont, Brushes.White, 55f, 5f);
			e.Graphics.DrawString("smartRestaurant", smallFont, Brushes.White, 54f, 36f);*/
			e.Graphics.DrawString("smart", titleFont, Brushes.White, 55f, 5f);
			e.Graphics.DrawString("Touch", titleBoldFont, Brushes.White, 135f, 5f);
			e.Graphics.DrawString("for smart", smallFont, Brushes.White, 124f, 36f);
			e.Graphics.DrawString("Restaurant", smallBoldFont, Brushes.White, 175f, 36f);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SmartForm));
			this.ImgLogo = new System.Windows.Forms.ImageList(this.components);
			// 
			// ImgLogo
			// 
			this.ImgLogo.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ImgLogo.ImageSize = new System.Drawing.Size(55, 59);
			this.ImgLogo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLogo.ImageStream")));
			this.ImgLogo.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// SmartForm
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "SmartForm";

		}

		public virtual void UpdateForm()
		{
		}
	}
}
