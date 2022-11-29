<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbDirectory = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPrefix = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbNumber = New System.Windows.Forms.TextBox()
        Me.cbReverse = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbRate = New System.Windows.Forms.TextBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.lvPictures = New System.Windows.Forms.ListView()
        Me.ofdAnimDir = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "动画图片目录："
        '
        'tbDirectory
        '
        Me.tbDirectory.Location = New System.Drawing.Point(110, 18)
        Me.tbDirectory.Name = "tbDirectory"
        Me.tbDirectory.Size = New System.Drawing.Size(533, 23)
        Me.tbDirectory.TabIndex = 1
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(649, 18)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "选择···"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "动画文件名："
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(110, 58)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(533, 23)
        Me.tbName.TabIndex = 4
        Me.tbName.Text = "bootanimation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "图片文件名前缀："
        '
        'tbPrefix
        '
        Me.tbPrefix.Location = New System.Drawing.Point(109, 140)
        Me.tbPrefix.Name = "tbPrefix"
        Me.tbPrefix.Size = New System.Drawing.Size(132, 23)
        Me.tbPrefix.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(258, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "起始编号："
        '
        'tbNumber
        '
        Me.tbNumber.Location = New System.Drawing.Point(323, 140)
        Me.tbNumber.Name = "tbNumber"
        Me.tbNumber.Size = New System.Drawing.Size(100, 23)
        Me.tbNumber.TabIndex = 8
        '
        'cbReverse
        '
        Me.cbReverse.AutoSize = True
        Me.cbReverse.Location = New System.Drawing.Point(445, 142)
        Me.cbReverse.Name = "cbReverse"
        Me.cbReverse.Size = New System.Drawing.Size(75, 21)
        Me.cbReverse.TabIndex = 9
        Me.cbReverse.Text = "反向排序"
        Me.cbReverse.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 17)
        Me.Label5.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "动画帧率："
        '
        'tbRate
        '
        Me.tbRate.Location = New System.Drawing.Point(110, 98)
        Me.tbRate.Name = "tbRate"
        Me.tbRate.Size = New System.Drawing.Size(107, 23)
        Me.tbRate.TabIndex = 12
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(239, 98)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 13
        Me.btnPreview.Text = "预览动画"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.Location = New System.Drawing.Point(535, 140)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(85, 23)
        Me.btnRename.TabIndex = 14
        Me.btnRename.Text = "重命名图片"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'lvPictures
        '
        Me.lvPictures.Location = New System.Drawing.Point(12, 183)
        Me.lvPictures.Name = "lvPictures"
        Me.lvPictures.Size = New System.Drawing.Size(712, 275)
        Me.lvPictures.TabIndex = 15
        Me.lvPictures.UseCompatibleStateImageBehavior = False
        '
        'ofdAnimDir
        '
        Me.ofdAnimDir.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 470)
        Me.Controls.Add(Me.lvPictures)
        Me.Controls.Add(Me.btnRename)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.tbRate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbReverse)
        Me.Controls.Add(Me.tbNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbPrefix)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.tbDirectory)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AnimationMaker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbDirectory As TextBox
    Friend WithEvents btnSelect As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tbName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbPrefix As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbNumber As TextBox
    Friend WithEvents cbReverse As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbRate As TextBox
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnRename As Button
    Friend WithEvents lvPictures As ListView
    Friend WithEvents ofdAnimDir As OpenFileDialog
End Class
