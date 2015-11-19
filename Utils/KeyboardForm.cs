using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using smartRestaurant.Controls;

namespace smartRestaurant.Utils
{
	/// <summary>
	/// Summary description for KeyboardForm.
	/// </summary>
	public class KeyboardForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList NumberImgList;
		private smartRestaurant.Controls.KeyboardPad MessagePad;
		private System.ComponentModel.IContainer components;

		private static KeyboardForm instance = null;

		private bool dialogResult;

		public KeyboardForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(KeyboardForm));
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.MessagePad = new smartRestaurant.Controls.KeyboardPad();
			this.SuspendLayout();
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MessagePad
			// 
			this.MessagePad.Font = new System.Drawing.Font("Tahoma", 12F);
			this.MessagePad.Image = ((System.Drawing.Bitmap)(resources.GetObject("MessagePad.Image")));
			this.MessagePad.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("MessagePad.ImageClick")));
			this.MessagePad.ImageClickIndex = 1;
			this.MessagePad.ImageIndex = 0;
			this.MessagePad.ImageList = this.NumberImgList;
			this.MessagePad.Name = "MessagePad";
			this.MessagePad.Size = new System.Drawing.Size(936, 340);
			this.MessagePad.TabIndex = 43;
			this.MessagePad.Title = null;
			this.MessagePad.PadClick += new smartRestaurant.Controls.KeyboardPadEventHandler(this.MessagePad_PadClick);
			// 
			// KeyboardForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(936, 340);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.MessagePad});
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "KeyboardForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);

		}
		#endregion

		public string Title
		{
			get
			{
				if (MessagePad == null)
					return null;
				return MessagePad.Title;
			}
			set
			{
				MessagePad.Title = value;
			}
		}

		public override string Text
		{
			get
			{
				if (MessagePad == null)
					return null;
				return MessagePad.Text;
			}
			set
			{
				MessagePad.Text = value;
			}
		}

		public static string Show(string title, string text)
		{
			if (instance == null)
				instance = new KeyboardForm();
			instance.Title = title;
			instance.Text = text;
			instance.MessagePad.Focus();
			instance.ShowDialog();
			if (instance.dialogResult)
				return instance.Text;
			return null;
		}

		private void MessagePad_PadClick(object sender, smartRestaurant.Controls.KeyboardPadEventArgs e)
		{
			if (e.KeyCode == KeyboardPad.BUTTON_OK)
			{
				dialogResult = true;
				this.Close();
			}
			else if (e.KeyCode == KeyboardPad.BUTTON_CANCEL)
			{
				dialogResult = false;
				this.Close();
			}
		}
	}
}
