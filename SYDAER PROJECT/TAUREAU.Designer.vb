<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TAUREAU
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.elveur = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnsupp = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.elveur.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(346, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(342, 31)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "LA GESTION DES TAUREAU"
        '
        'elveur
        '
        Me.elveur.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.elveur.Controls.Add(Me.TextBox3)
        Me.elveur.Controls.Add(Me.Button4)
        Me.elveur.Controls.Add(Me.btnsupp)
        Me.elveur.Controls.Add(Me.btnupdate)
        Me.elveur.Controls.Add(Me.btnadd)
        Me.elveur.Controls.Add(Me.ComboBox1)
        Me.elveur.Controls.Add(Me.Label6)
        Me.elveur.Controls.Add(Me.Label5)
        Me.elveur.Controls.Add(Me.Label4)
        Me.elveur.Controls.Add(Me.TextBox5)
        Me.elveur.Controls.Add(Me.TextBox4)
        Me.elveur.Controls.Add(Me.Label3)
        Me.elveur.Controls.Add(Me.Label2)
        Me.elveur.Controls.Add(Me.Label1)
        Me.elveur.Controls.Add(Me.TextBox2)
        Me.elveur.Controls.Add(Me.TextBox1)
        Me.elveur.Controls.Add(Me.dgv)
        Me.elveur.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elveur.ForeColor = System.Drawing.Color.Black
        Me.elveur.Location = New System.Drawing.Point(12, 41)
        Me.elveur.Name = "elveur"
        Me.elveur.Size = New System.Drawing.Size(968, 482)
        Me.elveur.TabIndex = 11
        Me.elveur.TabStop = False
        Me.elveur.Text = "INSERTION DES ELVEUR"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(168, 198)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(560, 25)
        Me.TextBox3.TabIndex = 30
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(745, 81)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(181, 41)
        Me.Button4.TabIndex = 29
        Me.Button4.Text = "Rechercher"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'btnsupp
        '
        Me.btnsupp.BackColor = System.Drawing.Color.Red
        Me.btnsupp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnsupp.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsupp.Location = New System.Drawing.Point(745, 182)
        Me.btnsupp.Name = "btnsupp"
        Me.btnsupp.Size = New System.Drawing.Size(181, 41)
        Me.btnsupp.TabIndex = 27
        Me.btnsupp.Text = "Supprimer"
        Me.btnsupp.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.Aqua
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnupdate.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.Location = New System.Drawing.Point(745, 132)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(181, 41)
        Me.btnupdate.TabIndex = 26
        Me.btnupdate.Text = "Modifier"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'btnadd
        '
        Me.btnadd.BackColor = System.Drawing.Color.Lime
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnadd.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.Location = New System.Drawing.Point(745, 29)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(181, 41)
        Me.btnadd.TabIndex = 25
        Me.btnadd.Text = "Ajouter"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(168, 95)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(560, 27)
        Me.ComboBox1.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 22)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Origine: *"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 22)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "type Pallaitte:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 22)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Categorie:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(168, 164)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(560, 25)
        Me.TextBox5.TabIndex = 17
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(168, 130)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(560, 25)
        Me.TextBox4.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 22)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Race: *"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 22)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nom Taureau: *"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 22)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Code Taureau: *"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(168, 61)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(560, 25)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(168, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(560, 25)
        Me.TextBox1.TabIndex = 6
        '
        'dgv
        '
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 229)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(954, 244)
        Me.dgv.TabIndex = 5
        '
        'TAUREAU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 528)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.elveur)
        Me.Name = "TAUREAU"
        Me.Text = "Form1"
        Me.elveur.ResumeLayout(False)
        Me.elveur.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents elveur As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnsupp As Button
    Friend WithEvents btnupdate As Button
    Friend WithEvents btnadd As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button4 As Button
End Class
