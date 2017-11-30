<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WebForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Login = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Sqlite = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel_Web = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件FToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件FToolStripMenuItem
        '
        Me.文件FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Login, Me.ToolStripMenuItem_Refresh, Me.ToolStripMenuItem_Exit, Me.TestToolStripMenuItem, Me.ToolStripMenuItem_Sqlite})
        Me.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem"
        Me.文件FToolStripMenuItem.Size = New System.Drawing.Size(58, 21)
        Me.文件FToolStripMenuItem.Text = "文件(&F)"
        '
        'ToolStripMenuItem_Login
        '
        Me.ToolStripMenuItem_Login.Name = "ToolStripMenuItem_Login"
        Me.ToolStripMenuItem_Login.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem_Login.Text = "登录(&L)"
        '
        'ToolStripMenuItem_Refresh
        '
        Me.ToolStripMenuItem_Refresh.Name = "ToolStripMenuItem_Refresh"
        Me.ToolStripMenuItem_Refresh.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem_Refresh.Text = "注销(&C)"
        '
        'ToolStripMenuItem_Exit
        '
        Me.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit"
        Me.ToolStripMenuItem_Exit.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem_Exit.Text = "退出(&E)"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TestToolStripMenuItem.Text = "test"
        Me.TestToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem_Sqlite
        '
        Me.ToolStripMenuItem_Sqlite.Name = "ToolStripMenuItem_Sqlite"
        Me.ToolStripMenuItem_Sqlite.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem_Sqlite.Text = "sqlite"
        Me.ToolStripMenuItem_Sqlite.Visible = False
        '
        'Panel_Web
        '
        Me.Panel_Web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Web.Location = New System.Drawing.Point(0, 25)
        Me.Panel_Web.Name = "Panel_Web"
        Me.Panel_Web.Size = New System.Drawing.Size(1042, 650)
        Me.Panel_Web.TabIndex = 2
        '
        'WebForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 675)
        Me.Controls.Add(Me.Panel_Web)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "WebForm"
        Me.Text = "航线任务系统"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件FToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Exit As ToolStripMenuItem
    Friend WithEvents Panel_Web As Panel
    Friend WithEvents ToolStripMenuItem_Login As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Refresh As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Sqlite As ToolStripMenuItem
End Class
