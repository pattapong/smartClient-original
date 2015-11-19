using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using smartRestaurant.Data;
using smartRestaurant.Utils;

namespace smartRestaurant
{
	/// <summary>
	/// <b>LoginForm</b> is form for users to login. This is first form that users should use.
	/// </summary>
	public class LoginForm : SmartForm
	{
		/// <summary>
		/// Constanct value for form to know that focus on User ID Text Box.
		/// </summary>
		private const int FIELD_USERID		= 0;
		/// <summary>
		/// Constanct value for form to know that focus on Password Text Box.
		/// </summary>
		private const int FIELD_PASSWORD	= 1;

		/// <summary>
		/// Old background color for focused field.
		/// </summary>
		private Color backColor;
		/// <summary>
		/// Focus Field variable. Value for this variable should be FIELD_USERID or FIELD_PASSWORD.
		/// </summary>
		private int focusField;
		/// <summary>
		/// Password string that users type but show on screen as star (*).
		/// </summary>
		private string hiddenPassword;

		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.NumberPad NumberKeyPad;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList NumberImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.ImageList ButtonImgList;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnExit;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.ImageButton BtnLogin;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblUserID;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPassword;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private smartRestaurant.Controls.GroupPanel LoginPanel;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldUserID;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label FieldPassword;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.ComponentModel.IContainer components;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblPageID;
		/// <summary>
		/// <i>User Interface object</i>
		/// </summary>
		private System.Windows.Forms.Label LblCopyright;

		/// <summary>
		/// Constructure for LoginForm class.
		/// </summary>
		public LoginForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			backColor = FieldUserID.BackColor;
			UpdateForm();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LoginForm));
			this.NumberKeyPad = new smartRestaurant.Controls.NumberPad();
			this.NumberImgList = new System.Windows.Forms.ImageList(this.components);
			this.ButtonImgList = new System.Windows.Forms.ImageList(this.components);
			this.BtnLogin = new smartRestaurant.Controls.ImageButton();
			this.BtnExit = new smartRestaurant.Controls.ImageButton();
			this.LoginPanel = new smartRestaurant.Controls.GroupPanel();
			this.FieldPassword = new System.Windows.Forms.Label();
			this.LblPassword = new System.Windows.Forms.Label();
			this.FieldUserID = new System.Windows.Forms.Label();
			this.LblUserID = new System.Windows.Forms.Label();
			this.LblPageID = new System.Windows.Forms.Label();
			this.LblCopyright = new System.Windows.Forms.Label();
			this.LoginPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// NumberKeyPad
			// 
			this.NumberKeyPad.BackColor = System.Drawing.Color.White;
			this.NumberKeyPad.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.NumberKeyPad.Image = ((System.Drawing.Image)(resources.GetObject("NumberKeyPad.Image")));
			this.NumberKeyPad.ImageClick = ((System.Drawing.Image)(resources.GetObject("NumberKeyPad.ImageClick")));
			this.NumberKeyPad.ImageClickIndex = 1;
			this.NumberKeyPad.ImageIndex = 0;
			this.NumberKeyPad.ImageList = this.NumberImgList;
			this.NumberKeyPad.Location = new System.Drawing.Point(392, 368);
			this.NumberKeyPad.Name = "NumberKeyPad";
			this.NumberKeyPad.Size = new System.Drawing.Size(226, 255);
			this.NumberKeyPad.TabIndex = 8;
			this.NumberKeyPad.Text = "NumberPadKey";
			this.NumberKeyPad.PadClick += new smartRestaurant.Controls.NumberPadEventHandler(this.NumberKeyPad_PadClick);
			// 
			// NumberImgList
			// 
			this.NumberImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.NumberImgList.ImageSize = new System.Drawing.Size(72, 60);
			this.NumberImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NumberImgList.ImageStream")));
			this.NumberImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ButtonImgList
			// 
			this.ButtonImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ButtonImgList.ImageSize = new System.Drawing.Size(110, 60);
			this.ButtonImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonImgList.ImageStream")));
			this.ButtonImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnLogin
			// 
			this.BtnLogin.BackColor = System.Drawing.Color.Transparent;
			this.BtnLogin.Blue = 2F;
			this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnLogin.Green = 1F;
			this.BtnLogin.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnLogin.ImageClick")));
			this.BtnLogin.ImageClickIndex = 1;
			this.BtnLogin.ImageIndex = 0;
			this.BtnLogin.ImageList = this.ButtonImgList;
			this.BtnLogin.Location = new System.Drawing.Point(392, 632);
			this.BtnLogin.Name = "BtnLogin";
			this.BtnLogin.ObjectValue = null;
			this.BtnLogin.Red = 2F;
			this.BtnLogin.Size = new System.Drawing.Size(110, 60);
			this.BtnLogin.TabIndex = 9;
			this.BtnLogin.Text = "Login";
			this.BtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
			// 
			// BtnExit
			// 
			this.BtnExit.BackColor = System.Drawing.Color.Transparent;
			this.BtnExit.Blue = 2F;
			this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnExit.Green = 2F;
			this.BtnExit.ImageClick = ((System.Drawing.Image)(resources.GetObject("BtnExit.ImageClick")));
			this.BtnExit.ImageClickIndex = 1;
			this.BtnExit.ImageIndex = 0;
			this.BtnExit.ImageList = this.ButtonImgList;
			this.BtnExit.Location = new System.Drawing.Point(509, 632);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.ObjectValue = null;
			this.BtnExit.Red = 1F;
			this.BtnExit.Size = new System.Drawing.Size(110, 60);
			this.BtnExit.TabIndex = 10;
			this.BtnExit.Text = "Exit";
			this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// LoginPanel
			// 
			this.LoginPanel.BackColor = System.Drawing.Color.Transparent;
			this.LoginPanel.Caption = "Login";
			this.LoginPanel.Controls.Add(this.FieldPassword);
			this.LoginPanel.Controls.Add(this.LblPassword);
			this.LoginPanel.Controls.Add(this.FieldUserID);
			this.LoginPanel.Controls.Add(this.LblUserID);
			this.LoginPanel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.LoginPanel.Location = new System.Drawing.Point(392, 128);
			this.LoginPanel.Name = "LoginPanel";
			this.LoginPanel.ShowHeader = true;
			this.LoginPanel.Size = new System.Drawing.Size(225, 224);
			this.LoginPanel.TabIndex = 11;
			// 
			// FieldPassword
			// 
			this.FieldPassword.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldPassword.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldPassword.Location = new System.Drawing.Point(8, 168);
			this.FieldPassword.Name = "FieldPassword";
			this.FieldPassword.Size = new System.Drawing.Size(208, 40);
			this.FieldPassword.TabIndex = 42;
			this.FieldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldPassword.Click += new System.EventHandler(this.FieldPassword_Click);
			// 
			// LblPassword
			// 
			this.LblPassword.Location = new System.Drawing.Point(8, 128);
			this.LblPassword.Name = "LblPassword";
			this.LblPassword.Size = new System.Drawing.Size(88, 40);
			this.LblPassword.TabIndex = 41;
			this.LblPassword.Text = "Password";
			this.LblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FieldUserID
			// 
			this.FieldUserID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FieldUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FieldUserID.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FieldUserID.Location = new System.Drawing.Point(8, 80);
			this.FieldUserID.Name = "FieldUserID";
			this.FieldUserID.Size = new System.Drawing.Size(208, 40);
			this.FieldUserID.TabIndex = 40;
			this.FieldUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FieldUserID.Click += new System.EventHandler(this.FieldUserID_Click);
			// 
			// LblUserID
			// 
			this.LblUserID.Location = new System.Drawing.Point(8, 40);
			this.LblUserID.Name = "LblUserID";
			this.LblUserID.Size = new System.Drawing.Size(72, 40);
			this.LblUserID.TabIndex = 39;
			this.LblUserID.Text = "User ID";
			this.LblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblPageID
			// 
			this.LblPageID.BackColor = System.Drawing.Color.Transparent;
			this.LblPageID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblPageID.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblPageID.Location = new System.Drawing.Point(912, 752);
			this.LblPageID.Name = "LblPageID";
			this.LblPageID.TabIndex = 33;
			this.LblPageID.Text = "STLI011";
			this.LblPageID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LblCopyright
			// 
			this.LblCopyright.BackColor = System.Drawing.Color.Transparent;
			this.LblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LblCopyright.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(103)), ((System.Byte)(138)), ((System.Byte)(198)));
			this.LblCopyright.Location = new System.Drawing.Point(8, 752);
			this.LblCopyright.Name = "LblCopyright";
			this.LblCopyright.Size = new System.Drawing.Size(280, 16);
			this.LblCopyright.TabIndex = 36;
			this.LblCopyright.Text = "Copyright (c) 2004. All rights reserved.";
			// 
			// LoginForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1020, 764);
			this.Controls.Add(this.LblCopyright);
			this.Controls.Add(this.LblPageID);
			this.Controls.Add(this.LoginPanel);
			this.Controls.Add(this.BtnExit);
			this.Controls.Add(this.BtnLogin);
			this.Controls.Add(this.NumberKeyPad);
			this.Name = "LoginForm";
			this.Text = "Login";
			this.LoginPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// This method checks current focus field. And change background color for
		/// UserID field and Password field.
		/// </summary>
		private void CheckFocusField()
		{
			switch (focusField)
			{
				case FIELD_USERID:
					FieldUserID.BackColor = backColor;
					FieldPassword.BackColor = Color.White;
					break;
				case FIELD_PASSWORD:
					FieldUserID.BackColor = Color.White;
					FieldPassword.BackColor = backColor;
					break;
			}
		}

		/// <summary>
		/// This method clear all texts in UserID field, Password field, and hidden password variable.
		/// After that, focus on UserID field.
		/// </summary>
		private void ClearField()
		{
			focusField = FIELD_USERID;
			FieldUserID.Text = "";
			FieldPassword.Text = "";
			hiddenPassword = "";
		}

		/// <summary>
		/// This method call ClearField() to clear all texts and call CheckFocusField() for change
		/// background color for all fields.<br/>
		/// Called from MainForm.ShowLoginForm().
		/// </summary>
		public override void UpdateForm()
		{
			ClearField();
			CheckFocusField();
		}

		/// <summary>
		/// Method for UserID field is clicked from users. LoginForm will change focus to
		/// UserID field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldUserID_Click(object sender, System.EventArgs e)
		{
			focusField = FIELD_USERID;
			CheckFocusField();
		}

		/// <summary>
		/// Method for Password field is clicked from users. LoginForm will change focus to
		/// Password field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void FieldPassword_Click(object sender, System.EventArgs e)
		{
			focusField = FIELD_PASSWORD;
			CheckFocusField();
		}

		/// <summary>
		/// Event method for users click pad on number key pad.<br/>
		/// This method has 2 main cases. First case is focus on UserID field.
		/// The other case is focus on Password field.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void NumberKeyPad_PadClick(object sender, smartRestaurant.Controls.NumberPadEventArgs e)
		{
			if (e.IsNumeric)
			{
				switch (focusField)
				{
					case FIELD_USERID:
						FieldUserID.Text += e.Number;
						break;
					case FIELD_PASSWORD:
						FieldPassword.Text += "*";
						hiddenPassword += e.Number;
						break;
				}
			}
			else if (e.IsCancel)
			{
				switch (focusField)
				{
					case FIELD_USERID:
						if (FieldUserID.Text.Length > 0)
							FieldUserID.Text = FieldUserID.Text.Substring(0, FieldUserID.Text.Length - 1);
						break;
					case FIELD_PASSWORD:
						if (FieldPassword.Text.Length > 0)
						{
							FieldPassword.Text = FieldPassword.Text.Substring(0, FieldPassword.Text.Length - 1);
							hiddenPassword = hiddenPassword.Substring(0, hiddenPassword.Length - 1);
						}
						break;
				}
			}
			else if (e.IsEnter)
			{
				switch (focusField)
				{
					case FIELD_USERID:
						focusField = FIELD_PASSWORD;
						CheckFocusField();
						break;
					case FIELD_PASSWORD:
						BtnLogin_Click(null, null);
						break;
				}
			}
		}

		/// <summary>
		/// This method works when users click on Login Button. After users fill all fields
		/// and click on this button, this method will send user ID and password to
		/// UserProfile.CheckLogin() method to continue check user/password is corrent.
		/// If not corrent, this method will show error and prepare form for users to input again.
		/// If corrent, this method will call MainForm and order to show MainMenuForm (select table form).
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnLogin_Click(object sender, System.EventArgs e)
		{
			int userID;
			if (FieldUserID.Text == "" || FieldPassword.Text == "")
			{
				MessageForm.Show("Login Fail", "Please fill form.");
				return;
			}
			try
			{
				userID = Int32.Parse(FieldUserID.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return;
			}
			UserProfile user = UserProfile.CheckLogin(userID, hiddenPassword);
			if (user == null)
			{
				MessageForm.Show("Login Fail", "Your user ID or password wrong.");
				FieldPassword.Text = "";
				hiddenPassword = "";
				focusField = FIELD_USERID;
				CheckFocusField();
				return;
			}
			((MainForm)this.MdiParent).User = user;
			((MainForm)this.MdiParent).ShowMainMenuForm();
		}

		/// <summary>
		/// This method works when user click on Exit button. This method will call
		/// MainForm.Exit() for exit from <i>smartTouch</i>.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event object</param>
		private void BtnExit_Click(object sender, System.EventArgs e)
		{
			((MainForm)this.MdiParent).Exit();
		}
	}
}
