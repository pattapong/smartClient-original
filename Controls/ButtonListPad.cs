using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace smartRestaurant.Controls
{
	public class ButtonItem
	{
		public string Text;
		public string Value;
		public Color ForeColor;

		public ButtonItem(string text, string value)
		{
			this.Text = text;
			this.Value = value;
			this.ForeColor = Color.Black;
		}
	}

	public class ButtonListPadEventArgs: EventArgs 
	{  
		private ImageButton button;
		private string buttonValue;
		private int index;

		public ButtonListPadEventArgs(ImageButton button, int index) 
		{
			this.button = button;
			if (button.ObjectValue != null)
				this.buttonValue = (string)button.ObjectValue;
			else
				this.buttonValue = null;
			this.index = index;
		}

		public ImageButton Button
		{     
			get
			{
				return button;
			}
		}

		public string Value
		{
			get
			{
				return buttonValue;
			}
		}

		public int Index
		{
			get
			{
				return index;
			}
		}
	}
   
	// Delegate declaration.
	//
	public delegate void ButtonListPadEventHandler(object sender, ButtonListPadEventArgs e);

	/// <summary>
	/// Summary description for ButtonListPad.
	/// </summary>
	public class ButtonListPad : System.Windows.Forms.Control
	{
		public event ButtonListPadEventHandler PadClick;
		public event ButtonListPadEventHandler PageChange;

		private int row, column;
		private int padding;
		private ImageList imageList;
		private Image image, imageClick;
		private int imageIndex, imageClickIndex;
		private ImageButton[] buttons;
		private float red, green, blue;
		private ArrayList items;
		private int itemStart;
		private bool pageEnable;
		private bool autoRefresh;

		public ButtonListPad()
		{
			red = green = blue = 1;
			items = new ArrayList();
			itemStart = 0;
			pageEnable = false;
			autoRefresh = true;
			BuildButtonList();
		}

		private void BuildButtonList()
		{
			int x, y;
			int count = row * column;
			int i;
			if (count == 0)
			{
				buttons = null;
				return;
			}
			this.Controls.Clear();
			ImageButton[] oldButtons = buttons;
			buttons = new ImageButton[count];
			EventHandler evt =  new System.EventHandler(this.Button_Click);
			for (i = 0;i < count;i++)
			{
				if (oldButtons != null && i < oldButtons.Length)
				{
					buttons[i] = oldButtons[i];
				}
				else
				{
					buttons[i] = new ImageButton();
					buttons[i].Click += evt;
					buttons[i].DoubleClick += evt;
				}
				buttons[i].Image = image;
				buttons[i].ImageClick = imageClick;
				buttons[i].Width = imageClick.Width;
				buttons[i].Height = imageClick.Height;
				x = ((i % column) * (buttons[i].Width + padding));
				y = ((i / column) * (buttons[i].Height + padding));
				buttons[i].Left = x;
				buttons[i].Top = y;
			}
			this.Controls.AddRange(buttons);
			this.Width = ((buttons[0].Width + padding) * column) - padding;
			this.Height = ((buttons[0].Height + padding) * row) - padding;
		}

		public void SetButtonValue()
		{
			int i, pos;
			int start, end;

			pos = itemStart;
			if (items == null)
				return;
			if (items.Count > buttons.Length)
			{
				start = 1;
				end = buttons.Length - 1;
				buttons[0].Text = "<<";
				buttons[0].ObjectValue = null;
				buttons[buttons.Length - 1].Text = ">>";
				buttons[buttons.Length - 1].ObjectValue = null;
				pageEnable = true;
			}
			else
			{
				start = 0;
				end = buttons.Length;
				pageEnable = false;
			}
			for (i = start;i < end;i++)
			{
				if (items != null && pos < items.Count && items[pos] is ButtonItem)
				{
					ButtonItem b = (ButtonItem)items[pos];
					buttons[i].Text = b.Text;
					buttons[i].ObjectValue = b.Value;
					buttons[i].ForeColor = b.ForeColor;
				}
				else
				{
					buttons[i].Text = null;
					buttons[i].ObjectValue = null;
				}
				pos++;
			}
		}

		protected virtual void OnPadClick(ButtonListPadEventArgs e)
		{
			if (PadClick != null)
			{
				PadClick(this, e);
			}
		}

		protected virtual void OnPageChange(ButtonListPadEventArgs e)
		{
			if (PageChange != null)
			{
				PageChange(this, e);
			}
		}

		private void Button_Click(object sender, System.EventArgs e)
		{
			if (!(sender is ImageButton)) return;
			ImageButton btn = (ImageButton)sender;
			int index = -1;
			for (int i = 0;i < buttons.Length;i++)
			{
				if (btn == buttons[i])
				{
					index = i;
					break;
				}
			}
			if (index < 0)
				return;
			if (pageEnable)
			{
				if (index == 0)
				{
					itemStart -= (buttons.Length - 2);
					if (itemStart < 0)
						itemStart = (items.Count / (buttons.Length - 2)) * (buttons.Length - 2);
					OnPageChange(new ButtonListPadEventArgs(btn, index));
					return;
				}
				else if (index == buttons.Length - 1)
				{
					itemStart += (buttons.Length - 2);
					if (itemStart >= items.Count)
						itemStart = 0;
					OnPageChange(new ButtonListPadEventArgs(btn, index));
					return;
				}
				index += itemStart - 1;
			}
			OnPadClick(new ButtonListPadEventArgs(btn, index));
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			SetButtonValue();
		}

		public int Row
		{
			get
			{
				return row;
			}
			set
			{
				row = value;
				BuildButtonList();
			}
		}

		public int Column
		{
			get
			{
				return column;
			}
			set
			{
				column = value;
				BuildButtonList();
			}
		}

		public int Padding
		{
			get
			{
				return padding;
			}
			set
			{
				padding = value;
				BuildButtonList();
			}
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
				if (buttons != null)
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
				if (buttons != null)
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

		public float Red
		{
			get
			{
				return red;
			}
			set
			{
				red = value;
				if (buttons != null)
				{
					for (int i = 0;i < buttons.Length;i++)
						buttons[i].Red = red;
					if (autoRefresh)
						Refresh();
				}
			}
		}

		public float Green
		{
			get
			{
				return green;
			}
			set
			{
				green = value;
				if (buttons != null)
				{
					for (int i = 0;i < buttons.Length;i++)
						buttons[i].Green = green;
					if (autoRefresh)
						Refresh();
				}
			}
		}

		public float Blue
		{
			get
			{
				return blue;
			}
			set
			{
				blue = value;
				if (buttons != null)
				{
					for (int i = 0;i < buttons.Length;i++)
						buttons[i].Blue = blue;
					if (autoRefresh)
						Refresh();
				}
			}
		}

		public ImageButton[] Buttons
		{
			get
			{
				return buttons;
			}
		}

		public ArrayList Items
		{
			get
			{
				return items;
			}
		}

		public int ItemStart
		{
			get
			{
				return itemStart;
			}
			set
			{
				itemStart = value;
				if (autoRefresh)
					Refresh();
			}
		}

		public bool AutoRefresh
		{
			get
			{
				return autoRefresh;
			}
			set
			{
				autoRefresh = value;
				if (autoRefresh)
					Refresh();
			}
		}

		public void SetMatrix(int pos, float red, float green, float blue)
		{
			if (buttons != null && pos < buttons.Length)
			{
				buttons[pos].Red = red;
				buttons[pos].Green = green;
				buttons[pos].Blue = blue;
				if (autoRefresh)
					buttons[pos].Refresh();
			}
		}

		public int GetPosition(int index)
		{
			if (!pageEnable)
				return index;
			else
			{
				if (index < itemStart)
					return -1;
				if (index >= itemStart + (buttons.Length - 2))
					return -1;
				return (index - itemStart) + 1;
			}
		}
	}
}
