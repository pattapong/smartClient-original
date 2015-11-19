using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using smartRestaurant.Controls;
using smartRestaurant.Data;
using smartRestaurant.TableService;
using smartRestaurant.Utils;

namespace smartRestaurant.Utils
{
	/// <summary>
	/// Summary description for CancelForm.
	/// </summary>
	public class TableForm : System.Windows.Forms.Form
	{
		private static int MODE_SINGLE	= 0;
		private static int MODE_MULTI	= 1;

		private static TableForm instance = null;

		private smartRestaurant.Controls.GroupPanel TablePanel;
		private System.ComponentModel.IContainer components;
		private smartRestaurant.Controls.ImageButton BtnCancel;
		private System.Windows.Forms.ImageList ButtonImgList;

		private ImageButton[] tableButtons;
		private TableInformation[] tableInfo;
		private TableInformation tableSelect = null;
		private TableStatus[] tableStatus;
		private int[] multiSelectID = null;
		private ArrayList multiTemp = null;
		private smartRestaurant.Controls.ImageButton BtnOk;
		private int mode;

		public TableForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			multiTemp = new ArrayList();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TableForm));
			this.TablePanel = new smartRestaurant.Controls.GroupPanel();
			this.BtnCancel = new smartRestaurant.Controls.ImageButton();
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnOk = new smartRestaurant.Controls.ImageButton();
			this.SuspendLayout();
			// 
			// TablePanel
			// 
			this.TablePanel.BackColor = System.Drawing.Color.Transparent;
			this.TablePanel.Caption = "Select Table";
			this.TablePanel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.TablePanel.Name = "TablePanel";
			this.TablePanel.ShowHeader = true;
			this.TablePanel.Size = new System.Drawing.Size(866, 352);
			this.TablePanel.TabIndex = 3;
			// 
			// BtnCancel
			// 
			this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
			this.BtnCancel.Blue = 1F;
			this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.BtnCancel.Green = 1F;
			this.BtnCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.Image")));
			this.BtnCancel.ImageClick = ((System.Drawing.Bitmap)(resources.GetObject("BtnCancel.ImageClick")));
			this.BtnCancel.ImageClickIndex = 0;
			this.BtnCancel.Location = new System.Drawing.Point(736, 360);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.ObjectValue = null;
			this.BtnCancel.Red = 1F;
			this.BtnCancel.Size = new System.Drawing.Size(110, 60);
			this.BtnCancel.TabIndex = 3;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
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
			this.BtnOk.Location = new System.Drawing.Point(600, 360);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.ObjectValue = null;
			this.BtnOk.Red = 1F;
			this.BtnOk.Size = new System.Drawing.Size(110, 60);
			this.BtnOk.TabIndex = 4;
			this.BtnOk.Text = "Ok";
			this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// TableForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 23);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(866, 424);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.BtnOk,
																		  this.TablePanel,
																		  this.BtnCancel});
			this.Font = new System.Drawing.Font("Tahoma", 14.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "TableForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TableForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void LoadTableInformation()
		{
			TableService.TableService service = new TableService.TableService();
			tableInfo = service.GetTableList();
			while (tableInfo == null)
			{
				DialogResult result = MessageBox.Show("Can't load table information.", "Error",
					MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (result == DialogResult.Cancel)
					((MainForm)this.MdiParent).Exit();
				else
					tableInfo = service.GetTableList();
			}
		}

		private void AddTableButton()
		{
			try
			{
				// Get table status from web service
				TableService.TableService service = new TableService.TableService();
				tableStatus = service.GetTableStatus();
				// Create button to screen
				ImageButton button;
				Image img = ButtonImgList.Images[0];
				Image imgClick = ButtonImgList.Images[1];
				int x, y;
				bool newButton = false;
				x = 13; y = 48;
				if (tableStatus != null && tableStatus.Length > 1)
				{
					// Table not include ID = 0
					if (tableButtons == null || tableButtons.Length != tableStatus.Length - 1)
					{
						TablePanel.Controls.Clear();
						tableButtons = new ImageButton[tableStatus.Length - 1];
						newButton = true;
					}
					for (int cnt = 0;cnt < tableStatus.Length - 1;cnt++)
					{
						if (newButton)
						{
							button = new ImageButton();
							button.Image = img;
							button.ImageClick = imgClick;
							button.Left = x;
							button.Top = y;
							button.Text = tableStatus[cnt + 1].TableName;
						}
						else
							button = tableButtons[cnt];
						// Check Table Status
						if (tableSelect != null && tableStatus[cnt + 1].TableID == tableSelect.TableID)
						{
							// Selected Table
							button.ObjectValue = tableStatus[cnt + 1].TableID;
							button.Red = 1.75f;
							button.Green = 1.75f;
							button.Blue = 1;
						}
						else if (multiTemp != null && multiTemp.Contains(tableInfo[cnt + 1]))
						{
							// Multi Selected Table
							button.ObjectValue = tableStatus[cnt + 1].TableID;
							tableStatus[cnt + 1].InUse = false;
							button.Red = 2;
							button.Green = 2;
							button.Blue = 1;
						}
						else if (tableStatus[cnt + 1].InUse)
						{
							// Use table
							button.ObjectValue = -tableStatus[cnt + 1].TableID;
							button.Red = 1;
							button.Green = 2;
							button.Blue = 2;
						}
						else
						{
							// No select
							button.ObjectValue = tableStatus[cnt + 1].TableID;
							button.Red = 1;
							button.Green = 1;
							button.Blue = 1;
						}
						// Add event and control
						if (newButton)
						{
							button.Click += new EventHandler(this.Table_Click);
							TablePanel.Controls.Add(button);
							tableButtons[cnt] = button;
						}
						x += button.Width + 10;
						if (((cnt + 1) % 7) == 0)
						{
							x = 13; y += button.Height + 10;
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		private void CreateMultiTemp(int[] tableList)
		{
			if (tableList == null || tableList.Length == 0)
				return;
			for (int i = 0;i < tableList.Length;i++)
			{
				for (int j = 0;j < tableInfo.Length;j++)
				{
					if (tableList[i] == tableInfo[j].TableID)
					{
						multiTemp.Add(tableInfo[j]);
						break;
					}
				}
			}
		}

		private void Table_Click(object sender, System.EventArgs e)
		{
			ImageButton btn = (ImageButton)sender;
			int tableValue = (int)btn.ObjectValue;
			if (tableValue < 0)
				tableValue = -tableValue;
			// Search table object by table id
			for (int i = 0;i < tableInfo.Length;i++)
			{
				if (tableInfo[i].TableID == tableValue)
				{
					if (tableStatus[i].InUse)
					{
						MessageForm.Show("Select Table", "Can't select used table.");
						return;
					}
					if (mode == MODE_SINGLE)
					{
						tableSelect  = tableInfo[i];
						this.Close();
					}
					else if (mode == MODE_MULTI)
					{
						if (tableInfo[i].TableID == tableSelect.TableID)
							return;
						// Change select table
						if (multiTemp.Contains(tableInfo[i]))
						{
							multiTemp.Remove(tableInfo[i]);
							btn.Red = 1;
							btn.Green = 1;
							btn.Blue = 1;
						}
						else
						{
							multiTemp.Add(tableInfo[i]);
							btn.Red = 2;
							btn.Green = 2;
							btn.Blue = 1;
						}
						break;
					}
				}
			}
			// If not found in loop
		}

		public static TableInformation Show(string PageShow)
		{
			if (instance == null)
				instance = new TableForm();
			if (PageShow != null)
				instance.TablePanel.Caption = PageShow;
			instance.BtnOk.Visible = false;
			instance.mode = MODE_SINGLE;
			instance.tableSelect = null;
			instance.LoadTableInformation();
			instance.AddTableButton();
			instance.ShowDialog();
			return instance.tableSelect;
		}

		public static int[] ShowMulti(string PageShow, TableInformation mainTable, int[] mergeTable)
		{
			if (instance == null)
				instance = new TableForm();
			if (PageShow != null)
				instance.TablePanel.Caption = PageShow;
			instance.BtnOk.Visible = true;
			instance.mode = MODE_MULTI;
			instance.tableSelect = mainTable;
			instance.multiTemp.Clear();
			instance.LoadTableInformation();
			instance.CreateMultiTemp(mergeTable);
			instance.AddTableButton();
			instance.ShowDialog();
			return instance.multiSelectID;
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			tableSelect = null;
			multiSelectID = null;
			this.Close();
		}

		private void BtnOk_Click(object sender, System.EventArgs e)
		{
			if (multiTemp.Count == 0)
			{
				multiSelectID = new int[1];
				multiSelectID[0] = -1;
			}
			else
			{
				multiSelectID = new int[multiTemp.Count];
				for (int i = 0;i < multiTemp.Count;i++)
					multiSelectID[i] = ((TableInformation)multiTemp[i]).TableID;
			}
			this.Close();
		}
	}
}
