using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;

namespace smartRestaurant.Controls
{
	/// <summary>
	/// Summary description for CustomControl1.
	/// </summary>
	public class ImageButton : System.Windows.Forms.Label
	{
		private static StringFormat stringFormat = null;

		private object objectValue;
		private Image imageNormal;
		private Image imageClick;
		private int imageClickIndex;
		private string tmpText;
		private float redTone, greenTone, blueTone;

		public ImageButton()
		{
			this.redTone = this.greenTone = this.blueTone = 1.0f;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Size = new System.Drawing.Size(110, 60);
			this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.MouseDown += new MouseEventHandler(this.Button_MouseDown);
			this.MouseUp += new MouseEventHandler(this.Button_MouseUp);
		}

		private void Button_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (imageClick != null)
			{
				imageNormal = this.Image;
				this.Image = imageClick;
			}
		}

		private void Button_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (imageNormal != null)
			{
				this.Image = imageNormal;
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
				if (ImageList != null)
					imageClick = ImageList.Images[ImageClickIndex];
			}
		}

		public float Red
		{
			get
			{
				return redTone;
			}
			set
			{
				redTone = value;
				Repaint();
			}
		}

		public float Green
		{
			get
			{
				return greenTone;
			}
			set
			{
				greenTone = value;
				Repaint();
			}
		}

		public float Blue
		{
			get
			{
				return blueTone;
			}
			set
			{
				blueTone = value;
				Repaint();
			}
		}

		public object ObjectValue
		{
			get
			{
				return objectValue;
			}
			set
			{
				objectValue = value;
			}
		}

		private void Repaint()
		{
			tmpText = this.Text;
			this.Text = "";
			this.Text = tmpText;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;

			if (base.Image != null)
			{
				ColorMatrix myColorMatrix = new ColorMatrix();
				if (this.Enabled)
				{
					myColorMatrix.Matrix00 = redTone; // Red
					myColorMatrix.Matrix11 = greenTone; // Green
					myColorMatrix.Matrix22 = blueTone; // Blue
				}
				else
				{
					myColorMatrix.Matrix00 = 1.0f; // Red
					myColorMatrix.Matrix11 = 1.0f; // Green
					myColorMatrix.Matrix22 = 1.0f; // Blue
				}
				myColorMatrix.Matrix33 = 1.00f; // alpha
				myColorMatrix.Matrix44 = 1.00f; // w
				// Create an ImageAttributes object and set the color matrix.
				ImageAttributes imageAttr = new ImageAttributes();
				imageAttr.SetColorMatrix(myColorMatrix);
				// Draw the image using the color matrix.
				Rectangle rect = new Rectangle(0, 0, Width, Height);
				g.DrawImage(base.Image,         // Image
					rect,            // Dest. rect.
					0,               // srcX
					0,               // srcY
					Width,             // srcWidth
					Height,             // srcHeight
					GraphicsUnit.Pixel, // srcUnit
					imageAttr);      // ImageAttributes
			}

			if (stringFormat == null)
			{
				stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
			}

			g.DrawString(this.Text, this.Font,
				(new System.Drawing.Pen(this.Enabled?this.ForeColor:Color.Gray)).Brush,
				new RectangleF(0, 0, Width, Height), stringFormat);
		}
	}
}
