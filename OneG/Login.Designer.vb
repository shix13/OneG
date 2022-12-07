<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtAccID = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.LoginBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SignUpLink = New System.Windows.Forms.LinkLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(210, 100)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(800, 600)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.PictureBox2.BackgroundImage = Global.OneG.My.Resources.Resources.logo_small_2
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(463, 119)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(302, 236)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'txtAccID
        '
        Me.txtAccID.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccID.Location = New System.Drawing.Point(463, 387)
        Me.txtAccID.Multiline = True
        Me.txtAccID.Name = "txtAccID"
        Me.txtAccID.Size = New System.Drawing.Size(302, 34)
        Me.txtAccID.TabIndex = 2
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(463, 452)
        Me.txtPass.Multiline = True
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPass.Size = New System.Drawing.Size(302, 34)
        Me.txtPass.TabIndex = 3
        '
        'LoginBtn
        '
        Me.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LoginBtn.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginBtn.Location = New System.Drawing.Point(569, 522)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(100, 44)
        Me.LoginBtn.TabIndex = 4
        Me.LoginBtn.Text = "Login"
        Me.LoginBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(514, 602)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Create new account?"
        '
        'SignUpLink
        '
        Me.SignUpLink.ActiveLinkColor = System.Drawing.Color.Pink
        Me.SignUpLink.AutoSize = True
        Me.SignUpLink.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.SignUpLink.Font = New System.Drawing.Font("Malgun Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SignUpLink.LinkColor = System.Drawing.Color.Yellow
        Me.SignUpLink.Location = New System.Drawing.Point(580, 631)
        Me.SignUpLink.Name = "SignUpLink"
        Me.SignUpLink.Size = New System.Drawing.Size(77, 25)
        Me.SignUpLink.TabIndex = 6
        Me.SignUpLink.TabStop = True
        Me.SignUpLink.Text = "Sign Up"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1070, 797)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 44)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.OneG.My.Resources.Resources.Background_1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1182, 853)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SignUpLink)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtAccID)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOGIN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtAccID As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents LoginBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents SignUpLink As LinkLabel
    Friend WithEvents Button1 As Button
End Class
