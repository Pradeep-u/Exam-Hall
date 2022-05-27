Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim frm As New frmLogin
        frm.ShowDialog()
    End Sub

    Private Sub STUDENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STUDENTToolStripMenuItem.Click
        Dim frm As New frmAddStudent
        frm.ShowDialog()
    End Sub

    Private Sub STAFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STAFFToolStripMenuItem.Click
        Dim frm As New frmAddStaff
        frm.ShowDialog()
    End Sub

    Private Sub SUBJECTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBJECTToolStripMenuItem.Click
        Dim frm As New frmAddSubject
        frm.ShowDialog()
    End Sub

    Private Sub HALLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HALLToolStripMenuItem.Click
        Dim frm As New frmAddHall
        frm.ShowDialog()
    End Sub

    Private Sub EXAMDETAILSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXAMDETAILSToolStripMenuItem.Click
        Dim frm As New frmAddExam
        frm.ShowDialog()
    End Sub

    Private Sub HALLALLOCATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HALLALLOCATIONToolStripMenuItem.Click
        Dim frm As New frmHallAllocation
        frm.ShowDialog()
    End Sub

    Private Sub STUDENTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STUDENTToolStripMenuItem1.Click
        Dim frm As New frmReport
        frm.type = 1
        frm.ShowDialog()
    End Sub

    Private Sub STAFFToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STAFFToolStripMenuItem1.Click
        Dim frm As New frmReport
        frm.type = 2
        frm.ShowDialog()
    End Sub

    Private Sub SUBJECTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBJECTToolStripMenuItem1.Click
        Dim frm As New frmReport
        frm.type = 3
        frm.ShowDialog()
    End Sub

    Private Sub HALLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HALLToolStripMenuItem1.Click
        Dim frm As New frmReport
        frm.type = 4
        frm.ShowDialog()
    End Sub

    Private Sub EXAMDETAILToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXAMDETAILToolStripMenuItem.Click
        Dim frm As New frmReport
        frm.type = 5
        frm.ShowDialog()
    End Sub

    Private Sub ALLOCATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ALLOCATIONToolStripMenuItem.Click
        Dim frm As New frmReport
        frm.type = 6
        frm.ShowDialog()
    End Sub

    Private Sub VIEWALLOCATEDHALLSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWALLOCATEDHALLSToolStripMenuItem.Click
        Dim frm As New frmViewExamHall
        frm.ShowDialog()
    End Sub

    Private Sub VIEWHALLALLOCATIONSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VIEWHALLALLOCATIONSToolStripMenuItem.Click
        Dim frm As New frmViewHallAllocation
        frm.ShowDialog()
    End Sub
End Class