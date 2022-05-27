Imports System.Data
Imports System.Data.SqlClient

Public Class frmViewHallAllocation

    Private Sub frmViewHallAllocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Db.cmd.CommandText = "Select ExamID, Name, Department, Year, EDate From ExamTable "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            cbExam.Items.Add(r(0) & ":" & r(1) & ":" & r(2) & ":" & r(3) & ":" & r(4))
        End While
        r.Close()
    End Sub

    Private Sub cbExam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExam.SelectedIndexChanged
        Db.cmd.CommandText = "Select HallID, AllocationID From AllocateMaster Where ExamId = '" & cbExam.Text.Split(":")(0) & "' "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            cbHall.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        If cbExam.Text = "" Or cbHall.Text = "" Then
            MsgBox("Please Select Exam and Hall Id")
            Return
        End If

        pnl.Controls.Clear()

        Dim x As Integer = 25
        Dim y As Integer = 25

        Db.cmd.CommandText = "Select * From AllocateTrans Where AllocationID = '" & cbHall.Text.Split(":")(1) & "' and HallID = '" & cbHall.Text.Split(":")(0) & "' "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader
        While r.Read
            Dim lblStudent As New Label
            lblStudent.Location = New Point(x, y)
            lblStudent.Text = r(3)
            lblStudent.BackColor = Color.LightGreen
            pnl.Controls.Add(lblStudent)
            x += 120

            If x > 700 Then
                x = 25
                y += 35
            End If

        End While
        r.Close()

    End Sub

End Class