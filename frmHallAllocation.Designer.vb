<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHallAllocation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbExam = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnShow = New System.Windows.Forms.Button
        Me.lblTotalHall = New System.Windows.Forms.Label
        Me.lblHallAllocated = New System.Windows.Forms.Label
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbExam
        '
        Me.cbExam.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbExam.FormattingEnabled = True
        Me.cbExam.Location = New System.Drawing.Point(100, 87)
        Me.cbExam.Name = "cbExam"
        Me.cbExam.Size = New System.Drawing.Size(254, 27)
        Me.cbExam.TabIndex = 193
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(21, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 19)
        Me.Label15.TabIndex = 192
        Me.Label15.Text = "Exam Id:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(367, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 19)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "HALL ALLOCATION"
        '
        'btnShow
        '
        Me.btnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShow.Location = New System.Drawing.Point(360, 87)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(115, 27)
        Me.btnShow.TabIndex = 195
        Me.btnShow.TabStop = False
        Me.btnShow.Text = "Show Halls"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'lblTotalHall
        '
        Me.lblTotalHall.AutoSize = True
        Me.lblTotalHall.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHall.Location = New System.Drawing.Point(38, 484)
        Me.lblTotalHall.Name = "lblTotalHall"
        Me.lblTotalHall.Size = New System.Drawing.Size(14, 19)
        Me.lblTotalHall.TabIndex = 196
        Me.lblTotalHall.Text = "-"
        '
        'lblHallAllocated
        '
        Me.lblHallAllocated.AutoSize = True
        Me.lblHallAllocated.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHallAllocated.Location = New System.Drawing.Point(282, 484)
        Me.lblHallAllocated.Name = "lblHallAllocated"
        Me.lblHallAllocated.Size = New System.Drawing.Size(14, 19)
        Me.lblHallAllocated.TabIndex = 197
        Me.lblHallAllocated.Text = "-"
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(481, 85)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(206, 29)
        Me.btnGenerate.TabIndex = 198
        Me.btnGenerate.Text = "Generate Hall Allocation"
        Me.btnGenerate.UseVisualStyleBackColor = True
        Me.btnGenerate.Visible = False
        '
        'frmHallAllocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.ClientSize = New System.Drawing.Size(906, 528)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.lblHallAllocated)
        Me.Controls.Add(Me.lblTotalHall)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbExam)
        Me.Controls.Add(Me.Label15)
        Me.Name = "frmHallAllocation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbExam As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents lblTotalHall As System.Windows.Forms.Label
    Friend WithEvents lblHallAllocated As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
End Class
