Public Class frmStudentFromTo

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim from_id As Integer = Val(txtFrom.Text)
            Dim to_id As Integer = Val(txtTo.Text)


            For i As Integer = from_id To to_id
                Db.cmd.CommandText = "Insert Into StudentTable Values('" & "STD" & i & "','NONAME','" & cbDepartment.Text & "','" & cbYear.Text & "','','','')"
                Db.cmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class