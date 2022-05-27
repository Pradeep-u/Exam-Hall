Public Class frmLogin

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Db.con.State <> ConnectionState.Open Then
                Db.con.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.CenterToScreen()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try

            For Each cntrl As Control In Me.Controls
                If TypeOf (cntrl) Is TextBox Or TypeOf (cntrl) Is ComboBox Then
                    If cntrl.Text = "" Then
                        MsgBox("Please Fill All Details!")
                        Return
                    End If
                End If
            Next

            Db.cmd.CommandText = "Select Count(*) From LoginTable Where Username = '" & txtUsername.Text & "' and Password = '" & txtPassword.Text & "'  "
            If Db.cmd.ExecuteScalar > 0 Then
                Db.user_name = txtUsername.Text
                Me.Close()
            Else
                MsgBox("Invalid Credientials!")
                txtPassword.Text = ""
                txtPassword.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If Db.con.State = ConnectionState.Open Then
            Db.con.Close()
        End If

        Environment.Exit(0)
    End Sub
End Class