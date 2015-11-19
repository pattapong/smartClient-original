using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace smartRestaurant.Controls
{
	/// <summary>
	/// Summary description for GroupPanel.
	/// </summary>
	public class GroupPanel : System.Windows.Forms.Panel
	{
		private bool showHeader;
		private string text;

		public GroupPanel()
		{
			this.Font = new Font("Tahoma", 16f, FontStyle.Bold, GraphicsUnit.Pixel);
			this.BackColor = Color.Transparent;
			this.showHeader = true;
		}

		public string Caption
		{
			get
			{
				return text;
			}
			set
			{
				text = value;
			}
		}

		public bool ShowHeader
		{
			get
			{
				return showHeader;
			}
			set
			{
				showHeader = value;
			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			// TODO: Add custom paint code here
			Rectangle rect;
			Pen grayPen = new Pen(Color.FromArgb(180, 180, 180));
			if (showHeader)
			{
				rect = new Rectangle(0, 0, this.Width, 29);
				LinearGradientBrush gBrush = new LinearGradientBrush(
					rect,
					Color.FromArgb(200, 200, 200),
					Color.White, 90f);
				g.FillRectangle(gBrush, rect);

				rect = new Rectangle(0, 30, this.Width, this.Height - 30);
				g.FillRectangle(Brushes.White, rect);
				g.DrawLine(grayPen, 0, 29, this.Width - 1, 29);
				g.DrawString(text, this.Font, Brushes.Black, 15f, 5f);
			}
			else
			{
				rect = new Rectangle(0, 0, this.Width, this.Height);
				g.FillRectangle(Brushes.White, rect);
			}
			g.DrawRectangle(grayPen, 0, 0, this.Width - 1, this.Height - 1);
			// Calling the base class OnPaint
			base.OnPaint(pe);
		}
	}
}
