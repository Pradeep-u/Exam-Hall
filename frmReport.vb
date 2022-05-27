Imports System.Text
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data.SqlClient

Public Class frmReport
    Public type As Integer

    Private Sub frmView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        If type = 1 Then
            Db.cmd.CommandText = "Select * From StudentTable"
            lblHeading.Text = "Student List"
        ElseIf type = 2 Then
            Db.cmd.CommandText = "Select * From StaffTable"
            lblHeading.Text = "Staff List"
        ElseIf type = 3 Then
            Db.cmd.CommandText = "Select * From SubjectTable"
            lblHeading.Text = "Subject List"
        ElseIf type = 4 Then
            Db.cmd.CommandText = "Select * From HallTable"
            lblHeading.Text = "Hall List"
        ElseIf type = 5 Then
            Db.cmd.CommandText = "Select * From ExamTable"
            lblHeading.Text = "Exam List"
        ElseIf type = 6 Then
            Db.cmd.CommandText = "Select * From AllocateMaster"
            lblHeading.Text = "Hall Allocation List"
        End If

        Dim adp As New SqlDataAdapter(Db.cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        dgv.DataSource = dt
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = CType(xlWorkBook.Worksheets.Item(1), Microsoft.Office.Interop.Excel.Worksheet)
        Dim i As Integer = 0
        Dim j As Integer = 0
        i = 0
        Do While (i <= (dgv.RowCount - 1))
            j = 0
            Do While (j <= (dgv.ColumnCount - 1))
                Dim cell As DataGridViewCell = dgv(j, i)
                xlWorkSheet.Cells((i + 1), (j + 1)) = cell.Value
                j = (j + 1)
            Loop
            i = (i + 1)
        Loop

        Dim sfd As SaveFileDialog = New SaveFileDialog
        sfd.Filter = "Excel|*.xls"
        If sfd.ShowDialog() = DialogResult.OK Then
            xlWorkBook.SaveAs(sfd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            MessageBox.Show("Report Generated Successfully")
        End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show(("Exception Occured while releasing object " + ex.ToString))
        Finally
            GC.Collect()
        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim printDoc As New PrintDocument
        AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
        Dim printDialog As New PrintDialog
        printDialog.Document = printDoc
        printDialog.ShowDialog()
    End Sub

    Private Sub printDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim bm As New Bitmap(Me.dgv.Width, Me.dgv.Height)
        dgv.DrawToBitmap(bm, New System.Drawing.Rectangle(0, 0, Me.dgv.Width, Me.dgv.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

End Class