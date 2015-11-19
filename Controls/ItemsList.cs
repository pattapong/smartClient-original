using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace smartRestaurant.Controls
{
	public class DataItem
	{
		public string Text;
		public object Value;
		public bool IsHeader;
		public bool Strike;

		public DataItem(string text, object value, bool isHeader)
		{
			this.Text = text;
			this.Value = value;
			this.IsHeader = isHeader;
			this.Strike = false;
		}
	}

	public class ItemsListEventArgs: EventArgs 
	{  
		private DataItem item;

		public ItemsListEventArgs(DataItem item) 
		{
			this.item = item;
		}

		public DataItem Item
		{     
			get
			{
				return item;
			}
		}
	}
   
	// Delegate declaration.
	//
	public delegate void ItemsListEventHandler(object sender, ItemsListEventArgs e);

	/// <summary>
	/// Summary description for ItemsList.
	/// </summary>
	public class ItemsList : System.Windows.Forms.Control
	{
		public event ItemsListEventHandler ItemClick;

		private Color backHeaderColor;
		private Color backHeaderSelectedColor;
		private Color backNormalColor;
		private Color backAlterColor;
		private Color backSelectedColor;
		private Color foreHeaderColor;
		private Color foreHeaderSelectedColor;
		private Color foreNormalColor;
		private Color foreAlterColor;
		private Color foreSelectedColor;
		private Font strikeFont;
		private ItemsList bindList1;
		private ItemsList bindList2;

		private int itemWidth, itemHeight;
		private int border;
		private int row;
		private Label[] labels;
		private ArrayList items;
		private int selectedIndex;
		private int itemStart;
		private bool pageEnable;
		private bool autoRefresh;
		private ContentAlignment alignment;

		public ItemsList()
		{
			items = new ArrayList();
			border = 0;
			itemStart = 0;
			itemWidth = 320;
			itemHeight = 20;
			pageEnable = false;
			autoRefresh = true;
			bindList1 = bindList2 = null;
			alignment = ContentAlignment.MiddleLeft;
			BuildItemList();
		}

		public void Reset()
		{
			itemStart = 0;
			pageEnable = false;
			autoRefresh = true;
		}

		private void BuildItemList()
		{
			int y, i;
			if (row == 0)
			{
				labels = null;
				return;
			}
			this.Controls.Clear();
			Label[] oldLabels = labels;
			labels = new Label[row];
			EventHandler evt =  new System.EventHandler(this.Item_Click);
			for (i = 0;i < row;i++)
			{
				if (oldLabels != null && i < oldLabels.Length)
					labels[i] = oldLabels[i];
				else
				{
					labels[i] = new Label();
					labels[i].Click += evt;
				}
				y = border + (i * itemHeight);
				labels[i].Left = border;
				labels[i].Top = y;
				labels[i].Width = itemWidth;
				labels[i].Height = itemHeight;
				labels[i].TextAlign = alignment;
				if ((i % 2) == 0)
				{
					labels[i].ForeColor = foreNormalColor;
					labels[i].BackColor = backNormalColor;
				}
				else
				{
					labels[i].ForeColor = foreAlterColor;
					labels[i].BackColor = backAlterColor;
				}
			}
			this.Controls.AddRange(labels);
			this.Width = itemWidth + (border * 2);
			this.Height = itemHeight * row + (border * 2);
		}

		private void SetItemValue()
		{
			int i;
			int labelPos;
			int cnt;

			if (labels == null) return;
			labelPos = -1;
			if (items.Count > labels.Length)
				pageEnable = true;
			else
				pageEnable = false;
			cnt = 0;
			for (i = 0;i < items.Count;i++)
			{
				if ((i == itemStart || itemStart < 0) && labelPos < 0)
				{
					itemStart = i;
					labelPos = 0;
				}
				if (labelPos >= labels.Length)
					break;
				if (items != null && i < items.Count && items[i] is DataItem)
				{
					DataItem b = (DataItem)items[i];
					if (labelPos >= 0)
					{
						labels[labelPos].Text = b.Text;
						labels[labelPos].Cursor = Cursors.Hand;
						if (b.Strike)
						{
							if (strikeFont == null || strikeFont.Size != this.Font.Size)
								strikeFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Strikeout, this.Font.Unit);
							labels[labelPos].Font = strikeFont;
						}
						else
							labels[labelPos].Font = this.Font;
					}
					if (b.IsHeader)
					{
						if (labelPos >= 0)
						{
							if (selectedIndex == i)
							{
								labels[labelPos].ForeColor = foreHeaderSelectedColor;
								labels[labelPos].BackColor = backHeaderSelectedColor;
							}
							else
							{
								labels[labelPos].ForeColor = foreHeaderColor;
								labels[labelPos].BackColor = backHeaderColor;
							}
						}
						cnt = 0;
					}
					else
					{
						if (labelPos >= 0)
						{
							if (selectedIndex == i)
							{
								labels[labelPos].ForeColor = foreSelectedColor;
								labels[labelPos].BackColor = backSelectedColor;
							}
							else if ((cnt % 2) == 0)
							{
								labels[labelPos].ForeColor = foreNormalColor;
								labels[labelPos].BackColor = backNormalColor;
							}
							else
							{
								labels[labelPos].ForeColor = foreAlterColor;
								labels[labelPos].BackColor = backAlterColor;
							}
						}
						cnt++;
					}
				}
				else
				{
					if (labelPos >= 0)
						labels[labelPos].Text = null;
				}
				if (labelPos >= 0)
					labelPos++;
			}
			if (labelPos < 0)
			{
				if (items.Count > 0)
					return;
				else
					labelPos = 0;
			}
			for (;labelPos < labels.Length;labelPos++)
			{
				labels[labelPos].Text = null;
				labels[labelPos].Cursor = Cursors.Default;
				if ((cnt % 2) == 0)
				{
					labels[labelPos].ForeColor = foreNormalColor;
					labels[labelPos].BackColor = backNormalColor;
				}
				else
				{
					labels[labelPos].ForeColor = foreAlterColor;
					labels[labelPos].BackColor = backAlterColor;
				}
				cnt++;
			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			SetItemValue();
			Graphics g = pe.Graphics;
			g.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
			//base.OnPaint(pe);
		}

		protected virtual void OnItemClick(ItemsListEventArgs e)
		{
			if (ItemClick != null)
			{
				ItemClick(this, e);
			}
		}

		private void Item_Click(object sender, System.EventArgs e)
		{
			if (items.Count <= 0) return;
			if (!(sender is Label)) return;
			Label item = (Label)sender;
			int pos = -1;
			for (int i = 0;i < labels.Length;i++)
				if (item == labels[i])
				{
					pos = i;
					break;
				}
			if (pos < 0 || itemStart + pos >= items.Count)
				return;
			this.selectedIndex = itemStart + pos;
			SetItemValue();
			OnItemClick(new ItemsListEventArgs((DataItem)items[itemStart + pos]));
			ChangePosition(itemStart, selectedIndex);
		}

		private void ChangePosition(int itemStart, int selectedIndex)
		{
			if (bindList1 != null && bindList1.selectedIndex != selectedIndex)
			{
				bindList1.itemStart = itemStart;
				bindList1.selectedIndex = selectedIndex;
				bindList1.SetItemValue();
				bindList1.ChangePosition(itemStart, selectedIndex);
			}
			if (bindList2 != null && bindList2.selectedIndex != selectedIndex)
			{
				bindList2.itemStart = itemStart;
				bindList2.selectedIndex = selectedIndex;
				bindList2.SetItemValue();
				bindList2.ChangePosition(itemStart, selectedIndex);
			}
		}

		public void Down(int cnt)
		{
			if (!pageEnable)
				return;
			if (itemStart + cnt + row < items.Count)
				itemStart += cnt;
			else
				itemStart = items.Count - row;
			SetItemValue();
			if (bindList1 != null && bindList1.itemStart != itemStart)
				bindList1.Down(cnt);
			if (bindList2 != null && bindList2.itemStart != itemStart)
				bindList2.Down(cnt);
		}

		public void Up(int cnt)
		{
			if (!pageEnable)
				return;
			if (itemStart - cnt >= 0)
				itemStart -= cnt;
			else
				itemStart = 0;
			SetItemValue();
			if (bindList1 != null && bindList1.itemStart != itemStart)
				bindList1.Up(cnt);
			if (bindList2 != null && bindList2.itemStart != itemStart)
				bindList2.Up(cnt);
		}

		public bool CanDown
		{
			get
			{
				return pageEnable && (itemStart + row < items.Count);
			}
		}

		public bool CanUp
		{
			get
			{
				return pageEnable && (itemStart > 0);
			}
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
				BuildItemList();
			}
		}

		public ArrayList Items
		{
			get
			{
				return items;
			}
		}

		public int ItemWidth
		{
			get
			{
				return itemWidth;
			}
			set
			{
				itemWidth = value;
				if (autoRefresh)
				{
					BuildItemList();
					SetItemValue();
				}
			}
		}

		public int ItemHeight
		{
			get
			{
				return itemHeight;
			}
			set
			{
				itemHeight = value;
				if (autoRefresh)
				{
					BuildItemList();
					SetItemValue();
				}
			}
		}

		public int Border
		{
			get
			{
				return border;
			}
			set
			{
				border = value;
				if (autoRefresh)
				{
					BuildItemList();
					SetItemValue();
				}
			}
		}

		public Color BackHeaderColor
		{
			get
			{
				return backHeaderColor;
			}
			set
			{
				backHeaderColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color BackHeaderSelectedColor
		{
			get
			{
				return backHeaderSelectedColor;
			}
			set
			{
				backHeaderSelectedColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color BackNormalColor
		{
			get
			{
				return backNormalColor;
			}
			set
			{
				backNormalColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color BackAlterColor
		{
			get
			{
				return backAlterColor;
			}
			set
			{
				backAlterColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color BackSelectedColor
		{
			get
			{
				return backSelectedColor;
			}
			set
			{
				backSelectedColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color ForeHeaderColor
		{
			get
			{
				return foreHeaderColor;
			}
			set
			{
				foreHeaderColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color ForeHeaderSelectedColor
		{
			get
			{
				return foreHeaderSelectedColor;
			}
			set
			{
				foreHeaderSelectedColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color ForeNormalColor
		{
			get
			{
				return foreNormalColor;
			}
			set
			{
				foreNormalColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color ForeAlterColor
		{
			get
			{
				return foreAlterColor;
			}
			set
			{
				foreAlterColor = value;
				if (autoRefresh)
					SetItemValue();
			}
		}

		public Color ForeSelectedColor
		{
			get
			{
				return foreSelectedColor;
			}
			set
			{
				foreSelectedColor = value;
				if (autoRefresh)
					SetItemValue();
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
				{
					SetItemValue();
					Refresh();
				}
			}
		}

		public int SelectedIndex
		{
			get
			{
				return selectedIndex;
			}
			set
			{
				selectedIndex = value;
				if (selectedIndex >= itemStart + row)
					itemStart = selectedIndex - row + 1;
				else if (selectedIndex < itemStart)
					itemStart = selectedIndex;
				ChangePosition(itemStart, selectedIndex);
				/*if (bindList1 != null && bindList1.selectedIndex != selectedIndex)
				{
					bindList1.selectedIndex = selectedIndex;
					bindList1.SetItemValue();
				}
				if (bindList2 != null && bindList2.selectedIndex != selectedIndex)
				{
					bindList2.selectedIndex = selectedIndex;
					bindList2.SetItemValue();
				}*/
			}
		}

		public ItemsList BindList1
		{
			get
			{
				return bindList1;
			}
			set
			{
				bindList1 = value;
			}
		}

		public ItemsList BindList2
		{
			get
			{
				return bindList2;
			}
			set
			{
				bindList2 = value;
			}
		}

		public ContentAlignment Alignment
		{
			get
			{
				return alignment;
			}
			set
			{
				alignment = value;
			}
		}
	}
}
