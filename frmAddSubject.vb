Imports System.Data
Imports System.Data.SqlClient

Public Class frmAddSubject

    Private Sub frmAddSubject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Db.cmd.CommandText = "Select Code, Name From SubjectTable "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            ListBox1.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()

        cbStaff.Items.Clear()
        Db.cmd.CommandText = "Select ID, Name From StaffTable "
        r = Db.cmd.ExecuteReader()
        While r.Read()
            cbStaff.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()

        btnAdd.Text = "Add"
        txtCode.Enabled = True

        Db.cmd.CommandText = "Select COUNT(*)+1 From SubjectTable"
        If Db.cmd.ExecuteScalar Is DBNull.Value Then
            txtCode.Text = "S001"
        Else
            txtCode.Text = "S" & Integer.Parse(Db.cmd.ExecuteScalar()).ToString("000")
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

            Db.cmd.CommandText = "Insert Into SubjectTable Values('" & txtCode.Text & "','" & txtName.Text & "','" & cbDepartment.Text & "','" & cbYear.Text & "','" & cbType.Text & "','" & cbStaff.Text.Split(":")(0) & "','" & cbStaff.Text.Split(":")(1) & "')"
            Db.cmd.ExecuteNonQuery()

            ClearAll()

        ElseIf btnAdd.Text = "Update" Then

            Db.cmd.CommandText = "Update SubjectTable Set Name = '" & txtName.Text & "',Department = '" & cbDepartment.Text & "',Year = '" & cbYear.Text & "', Type = '" & cbType.Text & "', StaffId = '" & cbStaff.Text.Split(":")(0) & "', StaffName = '" & cbStaff.Text.Split(":")(1) & "' Where Code = '" & txtCode.Text & "' "
            Db.cmd.ExecuteNonQuery()

            ClearAll()
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim adp As New SqlDataAdapter("Select * From SubjectTable Where Code = '" & Split(ListBox1.SelectedItem.ToString(), ":")(0) & "'", Db.con)
        Dim dt As New DataTable
        adp.Fill(dt)
        txtCode.Text = dt.Rows(0)("Code").ToString()
        txtName.Text = dt.Rows(0)("Name").ToString()
        cbDepartment.Text = dt.Rows(0)("Department").ToString()
        cbYear.Text = dt.Rows(0)("Year").ToString()
        cbType.Text = dt.Rows(0)("Type").ToString()
        cbStaff.Text = dt.Rows(0)("StaffId") & ":" & dt.Rows(0)("StaffName")

        btnAdd.Text = "Update"
        txtCode.Enabled = False
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        ListBox1.Items.Clear()
        Db.cmd.CommandText = "Select Code, Name From SubjectTable Where Code Like '" & txtSearch.Text & "%" & "' "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            ListBox1.Items.Add(r(0) & ":" & r(1))
        End While
        r.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Sure To Delete?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            If txtCode.Text = "" Then
                MsgBox("Please Select ID From List")
                Return
            End If

            Db.cmd.CommandText = "Delete From SubjectTable Where Code = '" & txtCode.Text & "' "
            Db.cmd.ExecuteNonQuery()

            ClearAll()
        End If
    End Sub
End Class