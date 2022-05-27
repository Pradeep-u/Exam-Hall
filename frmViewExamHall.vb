Imports System.Data
Imports System.Data.SqlClient

Public Class frmViewExamHall

    Private Sub frmViewHallAllocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Db.cmd.CommandText = "Select ExamID, Name, Department, Year, EDate From ExamTable "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            cbExam.Items.Add(r(0) & ":" & r(1) & ":" & r(2) & ":" & r(3) & ":" & r(4))
        End While
        r.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Db.cmd.CommandText = "Select * From AllocateMaster Where ExamID = '" & cbExam.Text.Split(":")(0) & "' "
        Dim adp As New SqlDataAdapter(Db.cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        DataGridView1.DataSource = dt

        lblTotal.Text = "Total Allocated Halls: " & dt.Rows.Count

    End Sub
End Class