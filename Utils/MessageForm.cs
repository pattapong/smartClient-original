using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace smartRestaurant.Utils
{
	/// <summary>
	/// Summary description for MessageForm.
	/// </summary>
	public class MessageForm : System.Windows.Forms.Form
	{
		private static MessageForm instance = null;
		private System.Windows.Forms.Label LblText;
		private smartRestaurant.Controls.ImageButton BtnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MessageForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MessageForm));
			this.LblText = new System.Windows.Forms.Label();
			this.BtnOk = new smartRestaurant.Controls.ImageButton();
			this.SuspendLayout();
			// 
			// LblText
			// 
			this.LblText.BackColor = System.Drawing.Color.Transparent;
			this.LblText.Location = new System.Drawing.Point(8, 40);
			this.LblText.Name = "LblText";
			this.LblText.Size = new System.Drawing.Size(288, 56);
			this.LblText.TabIndex = 0;
			this.LblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.BtnOk.Location = new System.Drawing.Point(184, 96);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.ObjectValue = null;
			this.BtnOk.Red = 1F;
			this.BtnOk.Size = new System.Drawing.Size(110, 60);
			this.BtnOk.TabIndex = 1;
			this.BtnOk.Text = "Ok";
			this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// MessageForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 23);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(304, 160);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnOk,
																		  this.LblText});
			this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MessageForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MessageForm";
			this.ResumeLayout(false);

		}
		#endregion

		public string MessageText
		{
			get
			{
				return LblText.Text;
			}
			set
			{
				LblText.Text = value;
			}
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

		public static void Show(string caption, string text)
		{
			if (instance == null)
				instance = new MessageForm();
			instance.Text = caption;
			instance.MessageText = text;
			instance.ShowDialog();
		}

		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
