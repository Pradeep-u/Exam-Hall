Imports System.Data
Imports System.Data.SqlClient

Public Class frmHallAllocation

    Private Sub frmHallAllocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        Db.cmd.CommandText = "Select ExamID, Name, Department, Year, EDate From ExamTable "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader()
        While r.Read()
            cbExam.Items.Add(r(0) & ":" & r(1) & ":" & r(2) & ":" & r(3) & ":" & r(4))
        End While
        r.Close()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        If cbExam.Text = "" Then
            MsgBox("Please select Exam")
            Return
        End If

        Dim x As Integer = 50
        Dim y As Integer = 200
        Dim i As Integer = 0
        Dim count As Integer

        Db.cmd.CommandText = "Select COunt(*) From StudentTable Where Department = '" & cbExam.Text.Split(":")(2) & "' and Year = '" & cbExam.Text.Split(":")(3) & "' "
        count = Db.cmd.ExecuteScalar()

        Db.cmd.CommandText = "Select * From HallTable"
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt_Hall As New DataTable
        adp.Fill(dt_Hall)

        Dim staff_list As New List(Of String)
        Db.cmd.CommandText = "Select StaffID From StaffTable Where Department = '" & cbExam.Text.Split(":")(2) & "' ORDER BY StaffID"
        Dim r As SqlDataReader = Db.cmd.ExecuteReader
        While r.Read()
            staff_list.Add(r(0))
        End While
        r.Close()

        While count > 0

            Dim pnl As New Panel
            pnl.BackColor = Color.Aqua
            pnl.Height = 200
            pnl.Width = 100
            pnl.Location = New Point(x + 20, y)
            Me.Controls.Add(pnl)

            Dim lblName As New Label
            lblName.Text = dt_Hall.Rows(i)(0).ToString
            lblName.Location = New Point(x + 30, y + 50)
            lblName.BackColor = Color.Aqua
            Me.Controls.Add(lblName)
            lblName.BringToFront()

            Dim lblCapacity As New Label
            If count > dt_Hall.Rows(i)("capacity") Then
                lblCapacity.Text = dt_Hall.Rows(i)(3)
                pnl.Name = dt_Hall.Rows(i)("HallID") & ":" & dt_Hall.Rows(i)("capacity")
            Else
                lblCapacity.Text = count.ToString
                pnl.Name = dt_Hall.Rows(i)("HallID") & ":" & count.ToString()
            End If
            lblCapacity.Location = New Point(x + 30, y + 90)
            lblCapacity.BackColor = Color.Aqua
            lblCapacity.Font = New Font("Calibri", 16)
            Me.Controls.Add(lblCapacity)
            lblCapacity.BringToFront()

            Dim cbStaff As New ComboBox
            If i < staff_list.Count Then
                Dim rnd As New Random()
                Dim index As Integer = rnd.Next(0, staff_list.Count - 1)
                cbStaff.Items.Add(staff_list(index))
                staff_list.RemoveAt(index)
            Else
                cbStaff.Items.Add("")
            End If
            cbStaff.SelectedIndex = 0
            cbStaff.Location = New Point(cbStaff.Location.X + 10, cbStaff.Location.Y + 130)
            cbStaff.Width = 80
            pnl.Controls.Add(cbStaff)

            count = count - dt_Hall.Rows(i)("capacity")

            x += 150
            i = i + 1

        End While

        lblTotalHall.Text = "Total Hall Available: " & dt_Hall.Rows.Count
        lblHallAllocated.Text = "Total Allocated Hall: " & i.ToString()

        btnGenerate.Visible = True

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click


        For Each c As Control In Me.Controls
            If TypeOf (c) Is Panel Then
                For Each cPnl As Control In c.Controls
                    If TypeOf (cPnl) Is ComboBox Then
                        If cPnl.Text = "" Then
                            MsgBox("Please Select Staff From Each Hall")
                            Return
                        End If
                    End If
                Next
            End If
        Next

        Db.cmd.CommandText = "Delete From AllocateMaster Where ExamID = '" & cbExam.Text.Split(":")(0) & "' "
        Db.cmd.ExecuteNonQuery()

        Dim current_count As Integer = 0

        Dim student_list As New List(Of String)
        Db.cmd.CommandText = "Select * From StudentTable Where Department = '" & cbExam.Text.Split(":")(2) & "' and Year = '" & cbExam.Text.Split(":")(3) & "' "
        Dim r As SqlDataReader = Db.cmd.ExecuteReader
        While r.Read
            student_list.Add(r(0) + ":" + r(1))
        End While
        r.Close()

        For Each c As Control In Me.Controls
            If TypeOf (c) Is Panel Then
                For Each cPnl As Control In c.Controls
                    If TypeOf (cPnl) Is ComboBox Then

                        Dim hall_id As String = c.Name.Split(":")(0)
                        Dim capacity As Integer = c.Name.Split(":")(1)

                        Dim allocation_id As Integer
                        Db.cmd.CommandText = "Select MAX(AllocationID)+1 From AllocateMaster"
                        If Db.cmd.ExecuteScalar Is DBNull.Value Then
                            allocation_id = 1
                        Else
                            allocation_id = Db.cmd.ExecuteScalar
                        End If

                        For j As Integer = 0 To capacity - 1
                            Dim sno As Integer
                            Db.cmd.CommandText = "Select MAX(Sno)+1 From AllocateTrans"
                            If Db.cmd.ExecuteScalar Is DBNull.Value Then
                                sno = 1
                            Else
                                sno = Db.cmd.ExecuteScalar
                            End If

                            Db.cmd.CommandText = "Insert Into AllocateTrans Values('" & sno & "','" & allocation_id & "','" & hall_id & "','" & student_list(current_count).Split(":")(0) & "','" & student_list(current_count).Split(":")(1) & "')"
                            Db.cmd.ExecuteNonQuery()

                            current_count = current_count + 1
                        Next


                        Db.cmd.CommandText = "Select Name From StaffTable Where StaffID = '" & cPnl.Text & "' "
                        Dim staff_name As String = Db.cmd.ExecuteScalar()
                        Db.cmd.CommandText = "Select EDate From ExamTable Where ExamID = '" & cbExam.Text.Split(":")(0) & "' "
                        Dim exam_date As String = Db.cmd.ExecuteScalar()

                        Db.cmd.CommandText = "Insert Into AllocateMaster Values('" & allocation_id & "','" & hall_id & "','" & capacity & "','" & cPnl.Text & "','" & staff_name & "','" & cbExam.Text.Split(":")(0) & "','" & cbExam.Text.Split(":")(1) & "','" & exam_date & "','" & cbExam.Text.Split(":")(2) & "')"

                        Db.cmd.ExecuteNonQuery()

                    End If
                Next
            End If
        Next

        MsgBox("Hall Allocated Successfully")

    End Sub
End Class