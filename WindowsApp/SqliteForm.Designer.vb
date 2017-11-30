<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqliteForm
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
        Me.Button_CreateTable = New System.Windows.Forms.Button()
        Me.Button_InsertTable = New System.Windows.Forms.Button()
        Me.Button_Update = New System.Windows.Forms.Button()
        Me.Button_Select = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button_Delete = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_CreateTable
        '
        Me.Button_CreateTable.Location = New System.Drawing.Point(78, 37)
        Me.Button_CreateTable.Name = "Button_CreateTable"
        Me.Button_CreateTable.Size = New System.Drawing.Size(183, 23)
        Me.Button_CreateTable.TabIndex = 0
        Me.Button_CreateTable.Text = "create table"
        Me.Button_CreateTable.UseVisualStyleBackColor = True
        '
        'Button_InsertTable
        '
        Me.Button_InsertTable.Location = New System.Drawing.Point(78, 82)
        Me.Button_InsertTable.Name = "Button_InsertTable"
        Me.Button_InsertTable.Size = New System.Drawing.Size(183, 23)
        Me.Button_InsertTable.TabIndex = 0
        Me.Button_InsertTable.Text = "insert"
        Me.Button_InsertTable.UseVisualStyleBackColor = True
        '
        'Button_Update
        '
        Me.Button_Update.Location = New System.Drawing.Point(78, 129)
        Me.Button_Update.Name = "Button_Update"
        Me.Button_Update.Size = New System.Drawing.Size(183, 23)
        Me.Button_Update.TabIndex = 0
        Me.Button_Update.Text = "update"
        Me.Button_Update.UseVisualStyleBackColor = True
        '
        'Button_Select
        '
        Me.Button_Select.Location = New System.Drawing.Point(78, 174)
        Me.Button_Select.Name = "Button_Select"
        Me.Button_Select.Size = New System.Drawing.Size(183, 23)
        Me.Button_Select.TabIndex = 0
        Me.Button_Select.Text = "select"
        Me.Button_Select.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(425, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(407, 259)
        Me.DataGridView1.TabIndex = 1
        '
        'Button_Delete
        '
        Me.Button_Delete.Location = New System.Drawing.Point(78, 218)
        Me.Button_Delete.Name = "Button_Delete"
        Me.Button_Delete.Size = New System.Drawing.Size(183, 23)
        Me.Button_Delete.TabIndex = 0
        Me.Button_Delete.Text = "delete"
        Me.Button_Delete.UseVisualStyleBackColor = True
        '
        'SqliteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 312)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button_Delete)
        Me.Controls.Add(Me.Button_Select)
        Me.Controls.Add(Me.Button_Update)
        Me.Controls.Add(Me.Button_InsertTable)
        Me.Controls.Add(Me.Button_CreateTable)
        Me.Name = "SqliteForm"
        Me.Text = "SqliteForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_CreateTable As Button
    Friend WithEvents Button_InsertTable As Button
    Friend WithEvents Button_Update As Button
    Friend WithEvents Button_Select As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button_Delete As Button
End Class
