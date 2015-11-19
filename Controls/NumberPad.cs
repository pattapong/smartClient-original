using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace smartRestaurant.Controls
{
	public class NumberPadEventArgs: EventArgs 
	{  
		private ImageButton button;
		private int number;

		public NumberPadEventArgs(ImageButton button, int number) 
		{
			this.button = button;
			this.number = number;
		}

		public ImageButton Button
		{     
			get
			{
				return button;
			}
		}

		public int Number
		{
			get
			{
				return number;
			}
		}

		public bool IsNumeric
		{
			get
			{
				return number < 10;
			}
		}

		public bool IsCancel
		{
			get
			{
				return number == NumberPad.BUTTON_CANCEL;
			}
		}

		public bool IsEnter
		{
			get
			{
				return number == NumberPad.BUTTON_ENTER;
			}
		}
	}
   
	// Delegate declaration.
	//
	public delegate void NumberPadEventHandler(object sender, NumberPadEventArgs e);

	/// <summary>
	/// Summary description for NumberPad.
	/// </summary>
	public class NumberPad : System.Windows.Forms.Control
	{
		public static int BUTTON_CANCEL = 10;
		public static int BUTTON_ENTER = 11;

		public event NumberPadEventHandler PadClick;

		private ImageList imageList;
		private Image image, imageClick;
		private int imageIndex, imageClickIndex;
		private ImageButton[] buttons;

		public NumberPad()
		{
			this.Width = 226;
			this.Height = 255;
			int x, y;
			buttons = new ImageButton[12];
			x = y = 0;
			for (int i = 0;i < 12;i++)
			{
				buttons[i] = new ImageButton();
				if (i < 10)
					buttons[i].Text = i.ToString();
				else if (i == BUTTON_CANCEL)
					buttons[i].Text = "Cor.";
				else if (i == BUTTON_ENTER)
					buttons[i].Text = "Enter";
				if (i == 0)
				{
					x = 77; y = 195;
				}
				else if (i >= 1 && i <= 3)
				{
					x = (i - 1) * 77;
					y = 130;
				}
				else if (i >= 4 && i <= 6)
				{
					x = (i - 4) * 77;
					y = 65;
				}
				else if (i >= 7 && i <= 9)
				{
					x = (i - 7) * 77;
					y = 0;
				}
				else if (i == BUTTON_CANCEL)
				{
					x = 0; y = 195;
				}
				else if (i == BUTTON_ENTER)
				{
					x = 154; y = 195;
				}
				buttons[i].Location = new Point(x, y);
				buttons[i].Width = 72;
				buttons[i].Blue = .5f;
				buttons[i].ObjectValue = i;
				buttons[i].Click += new System.EventHandler(this.Button_Click);
				buttons[i].DoubleClick += new System.EventHandler(this.Button_Click);
			}
			this.Controls.AddRange(buttons);
		}

		public Image Image
		{
			get
			{
				return image;
			}
			set
			{
				image = value;
				for (int i = 0;i < buttons.Length;i++)
					buttons[i].Image = image;
			}
		}

		public Image ImageClick
		{
			get
			{
				return imageClick;
			}
			set
			{
				imageClick = value;
				for (int i = 0;i < buttons.Length;i++)
					buttons[i].ImageClick = imageClick;
			}
		}

		public ImageList ImageList
		{
			get
			{
				return imageList;
			}
			set
			{
				imageList = value;
			}
		}

		public int ImageIndex
		{
			get
			{
				return imageIndex;
			}
			set
			{
				imageIndex = value;
				if (imageList != null)
					this.Image = imageList.Images[imageIndex];
			}
		}

		public int ImageClickIndex
		{
			get
			{
				return imageClickIndex;
			}
			set
			{
				imageClickIndex = value;
				if (imageList != null)
					ImageClick = imageList.Images[imageClickIndex];
			}
		}

		protected virtual void OnPadClick(NumberPadEventArgs e)
		{
			if (PadClick != null)
			{
				PadClick(this, e);
			}
		}

		private void Button_Click(object sender, System.EventArgs e)
		{
			if (buttons != null && buttons.Length > 0)
			{
				int index = (int)(((ImageButton)sender).ObjectValue);
				OnPadClick(new NumberPadEventArgs(buttons[index], index));
			}
		}
	}
}
