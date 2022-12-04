<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class masterKey
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.confBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(396, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INPUT MASTER KEY"
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(100, 121)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(257, 22)
        Me.txtInput.TabIndex = 1
        '
        'confBtn
        '
        Me.confBtn.Location = New System.Drawing.Point(115, 162)
        Me.confBtn.Name = "confBtn"
        Me.confBtn.Size = New System.Drawing.Size(95, 38)
        Me.confBtn.TabIndex = 2
        Me.confBtn.Text = "CONFIRM"
        Me.confBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(242, 162)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(93, 38)
        Me.cancelBtn.TabIndex = 3
        Me.cancelBtn.Text = "CANCEL"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'masterKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 248)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.confBtn)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "masterKey"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "masterKey"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents confBtn As Button
    Friend WithEvents cancelBtn As Button
End Class
