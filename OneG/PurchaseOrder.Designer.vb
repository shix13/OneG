<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PurchaseOrder
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SEARCHPO = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.ingbtn = New System.Windows.Forms.Button()
        Me.supbtn = New System.Windows.Forms.Button()
        Me.dgvSelect = New System.Windows.Forms.DataGridView()
        Me.closebtn = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.dgvPO = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.leftSideBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.IconPurcBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
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
        Me.IconPurcBtn.UseVisualStyleBackColor = False
        '
        'PurcBtn
        '
        Me.PurcBtn.AutoSize = True
        Me.PurcBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.PurcBtn.FlatAppearance.BorderSize = 0
        Me.PurcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PurcBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurcBtn.ForeColor = System.Drawing.Color.White
        Me.PurcBtn.Location = New System.Drawing.Point(73, 602)
        Me.PurcBtn.Name = "PurcBtn"
        Me.PurcBtn.Size = New System.Drawing.Size(216, 68)
        Me.PurcBtn.TabIndex = 10
        Me.PurcBtn.Text = "  PURCHASE ORDER"
        Me.PurcBtn.UseVisualStyleBackColor = False
        '
        'IconAccBtn
        '
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
        Me.IconAccBtn.UseVisualStyleBackColor = True
        '
        'AccBtn
        '
        Me.AccBtn.AutoSize = True
        Me.AccBtn.FlatAppearance.BorderSize = 0
        Me.AccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AccBtn.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccBtn.ForeColor = System.Drawing.Color.White
        Me.AccBtn.Location = New System.Drawing.Point(73, 502)
        Me.AccBtn.Name = "AccBtn"
        Me.AccBtn.Size = New System.Drawing.Size(216, 68)
        Me.AccBtn.TabIndex = 8
        Me.AccBtn.Text = "  ACCOUNT"
        Me.AccBtn.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.SEARCHPO)
        Me.GroupBox1.Controls.Add(Me.txtsearch)
        Me.GroupBox1.Controls.Add(Me.ingbtn)
        Me.GroupBox1.Controls.Add(Me.supbtn)
        Me.GroupBox1.Controls.Add(Me.dgvSelect)
        Me.GroupBox1.Controls.Add(Me.closebtn)
        Me.GroupBox1.Controls.Add(Me.SaveBtn)
        Me.GroupBox1.Controls.Add(Me.dgvPO)
        Me.GroupBox1.Controls.Add(Me.MenuStrip1)
        Me.GroupBox1.Location = New System.Drawing.Point(71, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1313, 744)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1144, 395)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 56)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "REMOVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SEARCHPO
        '
        Me.SEARCHPO.AutoSize = True
        Me.SEARCHPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.SEARCHPO.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SEARCHPO.ForeColor = System.Drawing.Color.Transparent
        Me.SEARCHPO.Location = New System.Drawing.Point(462, 436)
        Me.SEARCHPO.Name = "SEARCHPO"
        Me.SEARCHPO.Size = New System.Drawing.Size(164, 21)
        Me.SEARCHPO.TabIndex = 38
        Me.SEARCHPO.Text = "Search Ingredients"
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(632, 434)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(224, 27)
        Me.txtsearch.TabIndex = 37
        '
        'ingbtn
        '
        Me.ingbtn.BackColor = System.Drawing.Color.Gray
        Me.ingbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ingbtn.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ingbtn.ForeColor = System.Drawing.Color.White
        Me.ingbtn.Location = New System.Drawing.Point(48, 424)
        Me.ingbtn.Name = "ingbtn"
        Me.ingbtn.Size = New System.Drawing.Size(120, 41)
        Me.ingbtn.TabIndex = 25
        Me.ingbtn.Text = "Ingredients"
        Me.ingbtn.UseVisualStyleBackColor = False
        '
        'supbtn
        '
        Me.supbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.supbtn.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supbtn.ForeColor = System.Drawing.Color.White
        Me.supbtn.Location = New System.Drawing.Point(174, 424)
        Me.supbtn.Name = "supbtn"
        Me.supbtn.Size = New System.Drawing.Size(120, 41)
        Me.supbtn.TabIndex = 24
        Me.supbtn.Text = "Suppliers"
        Me.supbtn.UseVisualStyleBackColor = True
        '
        'dgvSelect
        '
        Me.dgvSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelect.Location = New System.Drawing.Point(48, 471)
        Me.dgvSelect.Name = "dgvSelect"
        Me.dgvSelect.RowHeadersWidth = 51
        Me.dgvSelect.RowTemplate.Height = 24
        Me.dgvSelect.Size = New System.Drawing.Size(808, 240)
        Me.dgvSelect.TabIndex = 23
        '
        'closebtn
        '
        Me.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.closebtn.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closebtn.ForeColor = System.Drawing.Color.White
        Me.closebtn.Location = New System.Drawing.Point(1159, 670)
        Me.closebtn.Name = "closebtn"
        Me.closebtn.Size = New System.Drawing.Size(109, 41)
        Me.closebtn.TabIndex = 22
        Me.closebtn.Text = "CLOSE"
        Me.closebtn.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SaveBtn.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBtn.ForeColor = System.Drawing.Color.White
        Me.SaveBtn.Location = New System.Drawing.Point(1006, 395)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(132, 56)
        Me.SaveBtn.TabIndex = 21
        Me.SaveBtn.Text = "SAVE"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'dgvPO
        '
        Me.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPO.Location = New System.Drawing.Point(48, 88)
        Me.dgvPO.Name = "dgvPO"
        Me.dgvPO.RowHeadersWidth = 51
        Me.dgvPO.RowTemplate.Height = 24
        Me.dgvPO.Size = New System.Drawing.Size(1220, 295)
        Me.dgvPO.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TableToolStripMenuItem, Me.EmployeeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 18)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1307, 33)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TableToolStripMenuItem
        '
        Me.TableToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue
        Me.TableToolStripMenuItem.Name = "TableToolStripMenuItem"
        Me.TableToolStripMenuItem.Size = New System.Drawing.Size(213, 29)
        Me.TableToolStripMenuItem.Text = "Create Purchase Order"
        '
        'EmployeeToolStripMenuItem
        '
        Me.EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem"
        Me.EmployeeToolStripMenuItem.Size = New System.Drawing.Size(135, 29)
        Me.EmployeeToolStripMenuItem.Text = "All Purchases"
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
        Me.Label1.Location = New System.Drawing.Point(489, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(455, 70)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "MAINTENANCE"
        '
        'PurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1382, 853)
        Me.Controls.Add(Me.leftSideBar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PurchaseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Maintenance (TABLE)"
        Me.leftSideBar.ResumeLayout(False)
        Me.leftSideBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgvPO As DataGridView
    Friend WithEvents closebtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents dgvSelect As DataGridView
    Friend WithEvents ingbtn As Button
    Friend WithEvents supbtn As Button
    Friend WithEvents SEARCHPO As Label
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents Button1 As Button
End Class
