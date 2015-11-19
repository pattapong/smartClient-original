using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace smartRestaurant.Controls
{
	public class KeyboardPadEventArgs: EventArgs 
	{  
		private ImageButton button;
		private char keyChar;
		private int keyCode;
		private string text;

		public KeyboardPadEventArgs(ImageButton button, char keyChar, int keyCode)
		{
			this.button = button;
			this.keyChar = keyChar;
			this.keyCode = keyCode;
			this.text = null;
		}

		public ImageButton Button
		{     
			get
			{
				return button;
			}
		}

		public char KeyChar
		{
			get
			{
				return keyChar;
			}
		}

		public int KeyCode
		{
			get
			{
				return keyCode;
			}
		}

		public string Text
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

		public bool IsControlKey
		{
			get
			{
				return (keyCode == KeyboardPad.BUTTON_OK ||
					keyCode == KeyboardPad.BUTTON_CANCEL ||
					keyCode == KeyboardPad.BUTTON_CAPLOCK ||
					keyCode == KeyboardPad.BUTTON_SHIFT ||
					keyCode == KeyboardPad.BUTTON_BACKSPACE);
			}
		}
	}
   
	// Delegate declaration.
	//
	public delegate void KeyboardPadEventHandler(object sender, KeyboardPadEventArgs e);

	/// <summary>
	/// Summary description for KeyboardPad.
	/// </summary>
	public class KeyboardPad : System.Windows.Forms.Control
	{
		public static int BUTTON_OK			= 52;
		public static int BUTTON_CANCEL		= 53;
		public static int BUTTON_CAPLOCK	= 26;
		public static int BUTTON_ENTER		= 38;
		public static int BUTTON_SHIFT		= 39;
		public static int BUTTON_SPACE		= 50;
		public static int BUTTON_BACKSPACE	= 51;

		public event KeyboardPadEventHandler PadClick;

		private string[] keyboardNormalText = {
											"~\n`","!\n1","@\n2","#\n3","$\n4","%\n5","^\n6","&\n7","*\n8","(\n9",")\n0","_\n-","+\n=",
											"|\n\\","Q","W","E","R","T","Y","U","I","O","P","{\n[","}\n]",
											"Cap","A","S","D","F","G","H","J","K","L",":\n;","\"\n'","Enter",
											"Shift","Z","X","C","V","B","N","M","<\n,",">\n.","?\n/","Space","<-",
											"OK","Cancel"
										};

		private bool isCaplock, isShift;

		private Label textLabel;
		private TextBox messageBox;
		private ImageList imageList;
		private Image image, imageClick;
		private int imageIndex, imageClickIndex;
		private ImageButton[] buttons;

		private string title;

		public KeyboardPad()
		{
			this.Width = 936;
			this.Height = 340;
			this.isCaplock = this.isShift = false;

			BuildKeyboardPad();
		}

		private void BuildKeyboardPad()
		{
			int x, y;
			this.Controls.Clear();
			// Title Label (TextLabel)
			if (textLabel == null)
			{
				textLabel = new Label();
				textLabel.Top = 0;
				textLabel.Left = 0;
				textLabel.Width = this.Width;
				textLabel.Height = 40;
				textLabel.Text = this.title;
				textLabel.BackColor = Color.Black;
				textLabel.ForeColor = Color.White;
				textLabel.TextAlign = ContentAlignment.MiddleLeft;
			}
			// Button
			ImageButton[] oldButtons = buttons;
			buttons = new ImageButton[keyboardNormalText.Length];
			x = 0;
			y = 40;
			for (int i = 0;i < buttons.Length;i++)
			{
				if (oldButtons != null && i < oldButtons.Length)
					buttons[i] = oldButtons[i];
				else
					buttons[i] = new ImageButton();
				if (i < keyboardNormalText.Length)
				{
					buttons[i].Text = keyboardNormalText[i];
					if (i < 13)
					{
						x = i * 72;
						y = 100;
					}
					else if (i >= 13 && i < 26)
					{
						x = (i - 13) * 72;
						y = 160;
					}
					else if (i >= 26 && i < 39)
					{
						x = (i - 26) * 72;
						y = 220;
					}
					else if (i >= 39 && i < 52)
					{
						x = (i - 39) * 72;
						y = 280;
					}
					else if (i >= 52)
					{
						x = (i - 52 + 11) * 72;
						y = 40;
					}
				}

				buttons[i].Location = new Point(x, y);
				buttons[i].Width = 72;
				if (i == BUTTON_CAPLOCK || i == BUTTON_SHIFT ||
					i == BUTTON_BACKSPACE || i == BUTTON_ENTER || i == BUTTON_SPACE)
					buttons[i].Blue = .5f;
				else if (i == BUTTON_OK || i == BUTTON_CANCEL)
					buttons[i].Blue = 1.75f;
				else
					buttons[i].Blue = 2f;
				if (i == BUTTON_OK || i == BUTTON_CANCEL)
					buttons[i].Red = 1.75f;
				buttons[i].ObjectValue = i;
				buttons[i].Click += new System.EventHandler(this.Button_Click);
				buttons[i].DoubleClick += new System.EventHandler(this.Button_Click);
			}
			// Input Box
			if (messageBox == null)
			{
				messageBox = new TextBox();
				messageBox.BorderStyle = BorderStyle.FixedSingle;
				messageBox.Top = 40;
				messageBox.Left = 0;
				messageBox.Width = this.Width - (72 * 2);
				messageBox.Height = 60;
				messageBox.Multiline = true;
				messageBox.AcceptsReturn = true;
				messageBox.WordWrap = true;
			}
			this.Controls.Add(textLabel);
			this.Controls.Add(messageBox);
			this.Controls.AddRange(buttons);
		}

		private void SetKeyboardLock()
		{
			if (isShift)
				buttons[BUTTON_SHIFT].Green = .5f;
			else
				buttons[BUTTON_SHIFT].Green = 1f;
			if (isCaplock)
				buttons[BUTTON_CAPLOCK].Green = .5f;
			else
				buttons[BUTTON_CAPLOCK].Green = 1f;
			buttons[BUTTON_SHIFT].Refresh();
			buttons[BUTTON_CAPLOCK].Refresh();
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

		public override string Text
		{
			get
			{
				return String.Join("\n", messageBox.Lines);
			}
			set
			{
				if (value != null)
				{
					messageBox.Lines = value.Split('\n');
					if (messageBox.Lines.Length > 1)
						messageBox.SelectionStart = value.Length + messageBox.Lines.Length - 1;
					else
						messageBox.SelectionStart = value.Length;
				}
				else
				{
					messageBox.Text = null;
					messageBox.SelectionStart = 0;
				}
				messageBox.SelectionLength = 0;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
				textLabel.Text = title;
			}
		}

		public bool ShowKeyboard()
		{
			this.Visible = true;
			return messageBox.Focus();
		}

		protected virtual void OnPadClick(KeyboardPadEventArgs e)
		{
			StringBuilder sb = new StringBuilder(messageBox.Text);
			int selectionStart = messageBox.SelectionStart;
			int addPos = 1;
			if (!e.IsControlKey)
			{
				if (messageBox.SelectionLength > 0)
					sb.Remove(messageBox.SelectionStart, messageBox.SelectionLength);
				sb.Insert(messageBox.SelectionStart, e.KeyChar);
				messageBox.Lines = sb.Replace("\r","").ToString().Split('\n');
				for (int i = 0;i <= selectionStart && i < sb.Length; i++)
				{
					if (sb[i] == '\n')
						addPos++;
				}
				selectionStart = selectionStart + addPos;
			}
			else
			{
				if (e.KeyCode == BUTTON_BACKSPACE)
				{
					if (messageBox.SelectionLength > 0)
					{
						sb.Remove(messageBox.SelectionStart, messageBox.SelectionLength);
						messageBox.Text = sb.ToString();
					}
					else if (messageBox.SelectionStart > 0)
					{
						sb.Remove(messageBox.SelectionStart - 1, 1);
						messageBox.Text = sb.ToString();
						selectionStart--;
					}
				}
			}
			messageBox.SelectionStart = selectionStart;
			messageBox.ScrollToCaret();
			messageBox.Focus();
			if (PadClick != null)
			{
				if (e.KeyCode == BUTTON_OK)
					e.Text = String.Join("\n", messageBox.Lines);
				PadClick(this, e);
			}
		}

		private void Button_Click(object sender, System.EventArgs e)
		{
			if (buttons != null && buttons.Length > 0)
			{
				int index = (int)(((ImageButton)sender).ObjectValue);

				char keyChar;
				if (index == BUTTON_SHIFT)
				{
					isShift = !isShift;
					keyChar = ' ';
				}
				else if (index == BUTTON_CAPLOCK)
				{
					isCaplock = !isCaplock;
					keyChar = ' ';
				}
				else if (index == BUTTON_OK || index == BUTTON_CANCEL)
				{
					keyChar = ' ';
				}
				else 
				{
					if (index == BUTTON_BACKSPACE || index == BUTTON_SPACE)
					{
						keyChar = ' ';
					}
					else if (index == BUTTON_ENTER)
					{
						keyChar = '\n';
					}
					else
					{
						string keyTxt = buttons[index].Text;
						if (keyTxt.Length > 1)
						{
							if (isShift || isCaplock)
								keyChar = keyTxt[0];
							else
								keyChar = keyTxt[2];
						}
						else
						{
							if (isShift || isCaplock)
								keyChar = keyTxt[0];
							else
								keyChar = keyTxt.ToLower()[0];
						}
					}
					if (isShift)
						isShift = false;
				}
				SetKeyboardLock();
				OnPadClick(new KeyboardPadEventArgs(buttons[index], keyChar, index));
			}
		}	
	}
}
