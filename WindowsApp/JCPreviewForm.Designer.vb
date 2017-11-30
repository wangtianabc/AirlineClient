<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JCPreviewForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JCPreviewForm))
        Me.Panel_JcPreview = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Panel_JcPreview
        '
        Me.Panel_JcPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_JcPreview.Location = New System.Drawing.Point(0, 0)
        Me.Panel_JcPreview.Name = "Panel_JcPreview"
        Me.Panel_JcPreview.Size = New System.Drawing.Size(943, 791)
        Me.Panel_JcPreview.TabIndex = 0
        '
        'JCPreviewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 791)
        Me.Controls.Add(Me.Panel_JcPreview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "JCPreviewForm"
        Me.Text = "工卡预览"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel_JcPreview As Panel
End Class
