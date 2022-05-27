Imports System.Data
Imports System.Data.SqlClient

Public Class frmAddHall

    Private Sub frmAddHall_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        ClearAll()
    End Sub


    Private Sub ClearAll()

        Dim c As Control
        For Each c In Me.Controls
            If TypeOf (c) Is TextBox Or TypeOf (c) Is ComboBox Then
                c.Text = ""
            End If
        Next

        ListBox1.Items.Clear()
        Db.cmd.CommandText = "Select HallID, Name From HallTable "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            ListBox1.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()

        btnAdd.Text = "Add"
        txtID.Enabled = True

        Db.cmd.CommandText = "Select COUNT(*)+1 From HallTable"
        If Db.cmd.ExecuteScalar Is DBNull.Value Then
            txtID.Text = "HL001"
        Else
            txtID.Text = "HL" & Integer.Parse(Db.cmd.ExecuteScalar()).ToString("000")
        End If

        txtName.Focus()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        For Each c As Control In Me.Controls
            If (TypeOf (c) Is TextBox Or TypeOf (c) Is ComboBox) And c.Name <> txtSearch.Name Then
                If c.Text = "" Then
                    MsgBox("Please Fill All Details")
                    c.Focus()
                    Return
                End If
            End If
        Next


        If btnAdd.Text = "Add" Then

            Db.cmd.CommandText = "Insert Into HallTable Values('" & txtID.Text & "','" & txtName.Text & "','" & txtLocation.Text & "','" & txtCapacity.Text & "')"
            Db.cmd.ExecuteNonQuery()

            ClearAll()

        ElseIf btnAdd.Text = "Update" Then

            Db.cmd.CommandText = "Update HallTable Set Name = '" & txtName.Text & "',Location = '" & txtLocation.Text & "', Capacity = '" & txtCapacity.Text & "' Where HallID = '" & txtID.Text & "' "
            Db.cmd.ExecuteNonQuery()

            ClearAll()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim adp As New SqlDataAdapter("Select * From HallTable Where HallID = '" & Split(ListBox1.SelectedItem.ToString(), ":")(0) & "'", Db.con)

        Dim dt As New DataTable
        adp.Fill(dt)
        txtID.Text = dt.Rows(0)("HallID").ToString()
        txtName.Text = dt.Rows(0)("Name").ToString()
        txtLocation.Text = dt.Rows(0)("Location").ToString()
        txtCapacity.Text = dt.Rows(0)("Capacity").ToString()

        btnAdd.Text = "Update"
        txtID.Enabled = False
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        ListBox1.Items.Clear()
        Db.cmd.CommandText = "Select HallID, Name From HallTable Where HallID Like '" & txtSearch.Text & "%" & "' "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            ListBox1.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If MsgBox("Sure To Delete?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            If txtID.Text = "" Then
                MsgBox("Please Select ID From List")
                Return
            End If

            Db.cmd.CommandText = "Delete From HallTable Where HallID = '" & txtID.Text & "' "
            Db.cmd.ExecuteNonQuery()

            ClearAll()
        End If

    End Sub
End Class