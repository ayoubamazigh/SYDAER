<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formzone
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
        Me.zone = New System.Windows.Forms.GroupBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnsupp = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.zone.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'zone
        '
        Me.zone.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.zone.Controls.Add(Me.dgv)
        Me.zone.Controls.Add(Me.btnsupp)
        Me.zone.Controls.Add(Me.btnupdate)
        Me.zone.Controls.Add(Me.btnadd)
        Me.zone.Controls.Add(Me.Label2)
        Me.zone.Controls.Add(Me.Label1)
        Me.zone.Controls.Add(Me.TextBox2)
        Me.zone.Controls.Add(Me.TextBox1)
        Me.zone.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zone.ForeColor = System.Drawing.Color.Black
        Me.zone.Location = New System.Drawing.Point(12, 46)
        Me.zone.Name = "zone"
        Me.zone.Size = New System.Drawing.Size(669, 264)
        Me.zone.TabIndex = 5
        Me.zone.TabStop = False
        Me.zone.Text = "INSERTION ZONE"
        '
        'dgv
        '
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 80)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(456, 176)
        Me.dgv.TabIndex = 16
        '
        'btnsupp
        '
        Me.btnsupp.BackColor = System.Drawing.Color.Red
        Me.btnsupp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnsupp.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsupp.Location = New System.Drawing.Point(477, 184)
        Me.btnsupp.Name = "btnsupp"
        Me.btnsupp.Size = New System.Drawing.Size(181, 72)
        Me.btnsupp.TabIndex = 15
        Me.btnsupp.Text = "Supprimer"
        Me.btnsupp.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.Aqua
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnupdate.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.Location = New System.Drawing.Point(477, 103)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(181, 72)
        Me.btnupdate.TabIndex = 13
        Me.btnupdate.Text = "Modifier"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'btnadd
        '
        Me.btnadd.BackColor = System.Drawing.Color.Lime
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnadd.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.Location = New System.Drawing.Point(477, 21)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(181, 72)
        Me.btnadd.TabIndex = 12
        Me.btnadd.Text = "Ajouter"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 22)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nom de Zone: *"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 22)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Code de Zone: *"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(189, 49)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(273, 25)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(189, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(273, 25)
        Me.TextBox1.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(195, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(259, 31)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "La Gestion des Zone"
        '
        'Formzone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 315)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.zone)
        Me.Name = "Formzone"
        Me.zone.ResumeLayout(False)
        Me.zone.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents zone As GroupBox
    Friend WithEvents btnsupp As Button
    Friend WithEvents btnupdate As Button
    Friend WithEvents btnadd As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dgv As DataGridView
End Class
