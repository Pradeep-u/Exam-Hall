<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewHallAllocation
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
        Me.cbHall = New System.Windows.Forms.ComboBox
        Me.btnShow = New System.Windows.Forms.Button
        Me.pnl = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'cbExam
        '
        Me.cbExam.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbExam.FormattingEnabled = True
        Me.cbExam.Location = New System.Drawing.Point(175, 41)
        Me.cbExam.Name = "cbExam"
        Me.cbExam.Size = New System.Drawing.Size(315, 27)
        Me.cbExam.TabIndex = 197
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(39, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(130, 19)
        Me.Label15.TabIndex = 196
        Me.Label15.Text = "ExamID/Hall ID:"
        '
        'cbHall
        '
        Me.cbHall.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHall.FormattingEnabled = True
        Me.cbHall.Location = New System.Drawing.Point(496, 41)
        Me.cbHall.Name = "cbHall"
        Me.cbHall.Size = New System.Drawing.Size(140, 27)
        Me.cbHall.TabIndex = 198
        '
        'btnShow
        '
        Me.btnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShow.Location = New System.Drawing.Point(654, 41)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(177, 27)
        Me.btnShow.TabIndex = 199
        Me.btnShow.TabStop = False
        Me.btnShow.Text = "Show Hall Allocation"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'pnl
        '
        Me.pnl.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl.Location = New System.Drawing.Point(43, 94)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(788, 338)
        Me.pnl.TabIndex = 200
        '
        'frmViewHallAllocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(875, 471)
        Me.Controls.Add(Me.pnl)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.cbHall)
        Me.Controls.Add(Me.cbExam)
        Me.Controls.Add(Me.Label15)
        Me.Name = "frmViewHallAllocation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbExam As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbHall As System.Windows.Forms.ComboBox
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents pnl As System.Windows.Forms.Panel
End Class
