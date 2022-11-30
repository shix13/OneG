<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccountUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.leftSideBar = New System.Windows.Forms.Panel()
        Me.dtpSideBar = New System.Windows.Forms.DateTimePicker()
        Me.lblWelcomeBar = New System.Windows.Forms.Label()
        Me.LogoutBtn = New System.Windows.Forms.Button()
        Me.IconPurcBtn = New System.Windows.Forms.Button()
        Me.PurcBtn = New System.Windows.Forms.Button()
        Me.IconAccBtn = New System.Windows.Forms.Button()
        Me.AccBtn = New System.Windows.Forms.Button()
        Me.IconMainBtn = New System.Windows.Forms.Button()
        Me.MainBtn = New System.Windows.Forms.Button()
        Me.IconPayBtn = New System.Windows.Forms.Button()
        Me.PayBtn = New System.Windows.Forms.Button()
        Me.IconOrderBtn = New System.Windows.Forms.Button()
        Me.OrderBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMenuBar = New System.Windows.Forms.Label()
        Me.MenuBarBtn = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.leftSideBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'leftSideBar
        '
        Me.leftSideBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.leftSideBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.leftSideBar.Controls.Add(Me.dtpSideBar)
        Me.leftSideBar.Controls.Add(Me.lblWelcomeBar)
        Me.leftSideBar.Controls.Add(Me.LogoutBtn)
        Me.leftSideBar.Controls.Add(Me.IconPurcBtn)
        Me.leftSideBar.Controls.Add(Me.PurcBtn)
        Me.leftSideBar.Controls.Add(Me.IconAccBtn)
        Me.leftSideBar.Controls.Add(Me.AccBtn)
        Me.leftSideBar.Controls.Add(Me.IconMainBtn)
        Me.leftSideBar.Controls.Add(Me.MainBtn)
        Me.leftSideBar.Controls.Add(Me.IconPayBtn)
        Me.leftSideBar.Controls.Add(Me.PayBtn)
        Me.leftSideBar.Controls.Add(Me.IconOrderBtn)
        Me.leftSideBar.Controls.Add(Me.OrderBtn)
        Me.leftSideBar.Controls.Add(Me.Panel1)
        Me.leftSideBar.Location = New System.Drawing.Point(-1, -1)
        Me.leftSideBar.Margin = New System.Windows.Forms.Padding(1)
        Me.leftSideBar.Name = "leftSideBar"
        Me.leftSideBar.Size = New System.Drawing.Size(75, 857)
        Me.leftSideBar.TabIndex = 0
        '
        'dtpSideBar
        '
        Me.dtpSideBar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSideBar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSideBar.Location = New System.Drawing.Point(92, 138)
        Me.dtpSideBar.Name = "dtpSideBar"
        Me.dtpSideBar.Size = New System.Drawing.Size(146, 32)
        Me.dtpSideBar.TabIndex = 13
        '
        'lblWelcomeBar
        '
        Me.lblWelcomeBar.AutoSize = True
        Me.lblWelcomeBar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcomeBar.ForeColor = System.Drawing.Color.White
        Me.lblWelcomeBar.Location = New System.Drawing.Point(77, 104)
        Me.lblWelcomeBar.Name = "lblWelcomeBar"
        Me.lblWelcomeBar.Size = New System.Drawing.Size(184, 23)
        Me.lblWelcomeBar.TabIndex = 2
        Me.lblWelcomeBar.Text = "WELCOME, Admin"
        '
        'LogoutBtn
        '
        Me.LogoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LogoutBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoutBtn.Location = New System.Drawing.Point(120, 726)
        Me.LogoutBtn.Name = "LogoutBtn"
        Me.LogoutBtn.Size = New System.Drawing.Size(119, 48)
        Me.LogoutBtn.TabIndex = 12
        Me.LogoutBtn.Text = "Logout"
        Me.LogoutBtn.UseVisualStyleBackColor = True
        '
        'IconPurcBtn
        '
        Me.IconPurcBtn.BackgroundImage = Global.OneG.My.Resources.Resources.kart
        Me.IconPurcBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IconPurcBtn.FlatAppearance.BorderSize = 0
        Me.IconPurcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconPurcBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconPurcBtn.ForeColor = System.Drawing.Color.White
        Me.IconPurcBtn.Location = New System.Drawing.Point(10, 602)
        Me.IconPurcBtn.Name = "IconPurcBtn"
        Me.IconPurcBtn.Size = New System.Drawing.Size(60, 68)
        Me.IconPurcBtn.TabIndex = 11
        Me.IconPurcBtn.UseVisualStyleBackColor = True
        '
        'PurcBtn
        '
        Me.PurcBtn.AutoSize = True
        Me.PurcBtn.FlatAppearance.BorderSize = 0
        Me.PurcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PurcBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurcBtn.ForeColor = System.Drawing.Color.White
        Me.PurcBtn.Location = New System.Drawing.Point(73, 602)
        Me.PurcBtn.Name = "PurcBtn"
        Me.PurcBtn.Size = New System.Drawing.Size(216, 68)
        Me.PurcBtn.TabIndex = 10
        Me.PurcBtn.Text = "  PURCHASE ORDER"
        Me.PurcBtn.UseVisualStyleBackColor = True
        '
        'IconAccBtn
        '
        Me.IconAccBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.IconAccBtn.BackgroundImage = Global.OneG.My.Resources.Resources.profile_acc
        Me.IconAccBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IconAccBtn.FlatAppearance.BorderSize = 0
        Me.IconAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconAccBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconAccBtn.ForeColor = System.Drawing.Color.White
        Me.IconAccBtn.Location = New System.Drawing.Point(10, 502)
        Me.IconAccBtn.Name = "IconAccBtn"
        Me.IconAccBtn.Size = New System.Drawing.Size(60, 68)
        Me.IconAccBtn.TabIndex = 9
        Me.IconAccBtn.UseVisualStyleBackColor = False
        '
        'AccBtn
        '
        Me.AccBtn.AutoSize = True
        Me.AccBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.AccBtn.FlatAppearance.BorderSize = 0
        Me.AccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AccBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccBtn.ForeColor = System.Drawing.Color.White
        Me.AccBtn.Location = New System.Drawing.Point(73, 502)
        Me.AccBtn.Name = "AccBtn"
        Me.AccBtn.Size = New System.Drawing.Size(216, 68)
        Me.AccBtn.TabIndex = 8
        Me.AccBtn.Text = "  ACCOUNT"
        Me.AccBtn.UseVisualStyleBackColor = False
        '
        'IconMainBtn
        '
        Me.IconMainBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.IconMainBtn.BackgroundImage = Global.OneG.My.Resources.Resources.Daco_4626465
        Me.IconMainBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IconMainBtn.FlatAppearance.BorderSize = 0
        Me.IconMainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconMainBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconMainBtn.ForeColor = System.Drawing.Color.White
        Me.IconMainBtn.Location = New System.Drawing.Point(10, 404)
        Me.IconMainBtn.Name = "IconMainBtn"
        Me.IconMainBtn.Size = New System.Drawing.Size(60, 68)
        Me.IconMainBtn.TabIndex = 7
        Me.IconMainBtn.UseVisualStyleBackColor = False
        '
        'MainBtn
        '
        Me.MainBtn.AutoSize = True
        Me.MainBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.MainBtn.FlatAppearance.BorderSize = 0
        Me.MainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MainBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainBtn.ForeColor = System.Drawing.Color.White
        Me.MainBtn.Location = New System.Drawing.Point(73, 404)
        Me.MainBtn.Name = "MainBtn"
        Me.MainBtn.Size = New System.Drawing.Size(216, 68)
        Me.MainBtn.TabIndex = 6
        Me.MainBtn.Text = "  MAINTENANCE"
        Me.MainBtn.UseVisualStyleBackColor = False
        '
        'IconPayBtn
        '
        Me.IconPayBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.IconPayBtn.BackgroundImage = Global.OneG.My.Resources.Resources.PngItem_877239
        Me.IconPayBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IconPayBtn.FlatAppearance.BorderSize = 0
        Me.IconPayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconPayBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconPayBtn.ForeColor = System.Drawing.Color.White
        Me.IconPayBtn.Location = New System.Drawing.Point(10, 309)
        Me.IconPayBtn.Name = "IconPayBtn"
        Me.IconPayBtn.Size = New System.Drawing.Size(60, 68)
        Me.IconPayBtn.TabIndex = 5
        Me.IconPayBtn.UseVisualStyleBackColor = False
        '
        'PayBtn
        '
        Me.PayBtn.AutoSize = True
        Me.PayBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.PayBtn.FlatAppearance.BorderSize = 0
        Me.PayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PayBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayBtn.ForeColor = System.Drawing.Color.White
        Me.PayBtn.Location = New System.Drawing.Point(73, 309)
        Me.PayBtn.Name = "PayBtn"
        Me.PayBtn.Size = New System.Drawing.Size(216, 68)
        Me.PayBtn.TabIndex = 4
        Me.PayBtn.Text = "  PAYMENT"
        Me.PayBtn.UseVisualStyleBackColor = False
        '
        'IconOrderBtn
        '
        Me.IconOrderBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.IconOrderBtn.BackgroundImage = Global.OneG.My.Resources.Resources.pinpng_com_checklist_icon_png_2009984
        Me.IconOrderBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IconOrderBtn.FlatAppearance.BorderSize = 0
        Me.IconOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconOrderBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconOrderBtn.ForeColor = System.Drawing.Color.White
        Me.IconOrderBtn.Location = New System.Drawing.Point(9, 221)
        Me.IconOrderBtn.Name = "IconOrderBtn"
        Me.IconOrderBtn.Size = New System.Drawing.Size(60, 68)
        Me.IconOrderBtn.TabIndex = 3
        Me.IconOrderBtn.UseVisualStyleBackColor = False
        '
        'OrderBtn
        '
        Me.OrderBtn.AutoSize = True
        Me.OrderBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.OrderBtn.FlatAppearance.BorderSize = 0
        Me.OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OrderBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderBtn.ForeColor = System.Drawing.Color.White
        Me.OrderBtn.Location = New System.Drawing.Point(72, 221)
        Me.OrderBtn.Name = "OrderBtn"
        Me.OrderBtn.Size = New System.Drawing.Size(216, 68)
        Me.OrderBtn.TabIndex = 2
        Me.OrderBtn.Text = "  ORDER"
        Me.OrderBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblMenuBar)
        Me.Panel1.Controls.Add(Me.MenuBarBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(75, 76)
        Me.Panel1.TabIndex = 1
        '
        'lblMenuBar
        '
        Me.lblMenuBar.AutoSize = True
        Me.lblMenuBar.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenuBar.ForeColor = System.Drawing.Color.White
        Me.lblMenuBar.Location = New System.Drawing.Point(90, 26)
        Me.lblMenuBar.Name = "lblMenuBar"
        Me.lblMenuBar.Size = New System.Drawing.Size(105, 25)
        Me.lblMenuBar.TabIndex = 1
        Me.lblMenuBar.Text = "MENU BAR"
        '
        'MenuBarBtn
        '
        Me.MenuBarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.MenuBarBtn.BackgroundImage = Global.OneG.My.Resources.Resources.clipart365828
        Me.MenuBarBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MenuBarBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuBarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MenuBarBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.MenuBarBtn.Location = New System.Drawing.Point(15, 0)
        Me.MenuBarBtn.Name = "MenuBarBtn"
        Me.MenuBarBtn.Size = New System.Drawing.Size(60, 76)
        Me.MenuBarBtn.TabIndex = 0
        Me.MenuBarBtn.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Panel2.BackgroundImage = Global.OneG.My.Resources.Resources.Background_1
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(-34, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1502, 129)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(624, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(325, 70)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ACCOUNT"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(893, 222)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(330, 30)
        Me.TextBox2.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(889, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 23)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Account ID"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(894, 573)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(330, 30)
        Me.TextBox1.TabIndex = 46
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(894, 666)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(330, 30)
        Me.txtPass.TabIndex = 45
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(889, 635)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 23)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(889, 542)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 23)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Position"
        '
        'txtMName
        '
        Me.txtMName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMName.Location = New System.Drawing.Point(894, 481)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(330, 30)
        Me.txtMName.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(889, 450)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 23)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Middle name"
        '
        'txtFName
        '
        Me.txtFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFName.Location = New System.Drawing.Point(894, 393)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(330, 30)
        Me.txtFName.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(889, 362)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 23)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "First name"
        '
        'txtLName
        '
        Me.txtLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLName.Location = New System.Drawing.Point(894, 306)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(330, 30)
        Me.txtLName.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(889, 275)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Last name"
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button5.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(943, 739)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(166, 41)
        Me.Button5.TabIndex = 36
        Me.Button5.Text = "SAVE CHANGES"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1115, 739)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(109, 41)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "CLOSE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.OneG.My.Resources.Resources.logo_small_2
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(156, 216)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(591, 530)
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'AccountUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1382, 853)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.leftSideBar)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "AccountUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  ACCOUNT"
        Me.leftSideBar.ResumeLayout(False)
        Me.leftSideBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents leftSideBar As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MenuBarBtn As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents IconOrderBtn As Button
    Friend WithEvents OrderBtn As Button
    Friend WithEvents IconPurcBtn As Button
    Friend WithEvents PurcBtn As Button
    Friend WithEvents IconAccBtn As Button
    Friend WithEvents AccBtn As Button
    Friend WithEvents IconMainBtn As Button
    Friend WithEvents MainBtn As Button
    Friend WithEvents IconPayBtn As Button
    Friend WithEvents PayBtn As Button
    Friend WithEvents dtpSideBar As DateTimePicker
    Friend WithEvents lblWelcomeBar As Label
    Friend WithEvents LogoutBtn As Button
    Friend WithEvents lblMenuBar As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
