Imports System.Data
Imports System.Data.SqlClient

Public Class frmAddStaff

    Private Sub frmAddStaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Db.cmd.CommandText = "Select StaffID, Name From StaffTable "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            ListBox1.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()

        btnAdd.Text = "Add"
        txtID.Enabled = True

        Db.cmd.CommandText = "Select COUNT(*)+1 From StaffTable"
        If Db.cmd.ExecuteScalar Is DBNull.Value Then
            txtID.Text = "STF001"
        Else
            txtID.Text = "STF" & Integer.Parse(Db.cmd.ExecuteScalar()).ToString("000")
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

            Db.cmd.CommandText = "Insert Into StaffTable Values('" & txtID.Text & "','" & txtName.Text & "','" & cbDepartment.Text & "','" & txtAddress.Text & "','" & txtContactNo.Text & "','" & txtEmailId.Text & "')"
            Db.cmd.ExecuteNonQuery()

            ClearAll()

        ElseIf btnAdd.Text = "Update" Then

            Db.cmd.CommandText = "Update StaffTable Set Name = '" & txtName.Text & "',Department = '" & cbDepartment.Text & "', Address = '" & txtAddress.Text & "', ContactNo = '" & txtContactNo.Text & "', EmailID = '" & txtEmailId.Text & "' Where StaffID = '" & txtID.Text & "' "
            Db.cmd.ExecuteNonQuery()

            ClearAll()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim adp As New SqlDataAdapter("Select * From StaffTable Where StaffID = '" & Split(ListBox1.SelectedItem.ToString(), ":")(0) & "'", Db.con)

        Dim dt As New DataTable
        adp.Fill(dt)
        txtID.Text = dt.Rows(0)("StaffID").ToString()
        txtName.Text = dt.Rows(0)("Name").ToString()
        cbDepartment.Text = dt.Rows(0)("Department").ToString()
        txtAddress.Text = dt.Rows(0)("Address").ToString()
        txtContactNo.Text = dt.Rows(0)("ContactNo").ToString()
        txtEmailId.Text = dt.Rows(0)("EmailID").ToString()

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
        Db.cmd.CommandText = "Select StaffID, Name From StaffTable Where StaffID Like '" & txtSearch.Text & "%" & "' "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            ListBox1.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If MsgBox("Sure To Delete?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            If txtID.Text = "" Then
                MsgBox("Please Select StaffID From List")
                Return
            End If

            Db.cmd.CommandText = "Delete From StaffTable Where StaffID = '" & txtID.Text & "' "
            Db.cmd.ExecuteNonQuery()

            ClearAll()
        End If

    End Sub
End Class