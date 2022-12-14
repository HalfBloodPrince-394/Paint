Public Class Form1

    Public grafik As Graphics
    Private resim_cizim As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height - 25)
    Private grafik_cizim As Graphics = Graphics.FromImage(resim_cizim)
    Private kalem As New System.Drawing.SolidBrush(System.Drawing.Color.Black)

    Dim SavedPic As Boolean
    Dim k As Integer
    Dim tx, ty As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        k = 10
        SavedPic = False
        grafik = PictureBox1.CreateGraphics()
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            grafik.FillEllipse(kalem, New Rectangle(e.X - 5, e.Y - 5, k, k))
            grafik_cizim.FillEllipse(kalem, New Rectangle(e.X - 5, e.Y - 5, k, k))
            SavedPic = False
        End If

        tx = e.X
        ty = e.Y
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        k = 5
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        k = 10
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        k = 15
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        k = 20
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        k = 25
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        k = 30
    End Sub

    Private Sub ChangeColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            kalem.Color = ColorDialog1.Color
        End If
    End Sub

    Private Sub XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XToolStripMenuItem.Click
        If SavedPic = True Then
            End
        Else
            Dim answer As Integer
            answer = MsgBox("Do you Want To Save Before Close", vbQuestion + vbYesNo + vbDefaultButton2, "Not Saved")
            If answer = vbYes Then
                SaveToolStripMenuItem.PerformClick()
            Else
                End
            End If

        End If
    End Sub

    Private Sub JToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim save As New SaveFileDialog

        save.Title = "Resim Kaydet"
        save.Filter = "Png File(*.png)|*.png"

        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            resim_cizim.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png)
        End If
        SavedPic = True
    End Sub
End Class
