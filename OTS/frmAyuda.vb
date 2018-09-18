Imports System.Drawing.Printing

Public Class frmAyuda
    'Private checkPrint As Integer

    'Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
    '    checkPrint = 0
    'End Sub
    'Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    '    ' Print the content of the RichTextBox. Store the last character printed.
    '    checkPrint = RichTextBoxPrintCtrl1.Print(checkPrint, RichTextBoxPrintCtrl1.TextLength, e)
    '    ' Look for more pages
    '    If checkPrint < RichTextBoxPrintCtrl1.TextLength Then
    '        e.HasMorePages = True
    '    Else
    '        e.HasMorePages = False
    '    End If
    'End Sub
    'Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
    '    PageSetupDialog1.ShowDialog()
    '    PrintPreviewControl1.InvalidatePreview()
    'End Sub
    'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Dim X = PrintDialog1.ShowDialog()
    '    If X = System.Windows.Forms.DialogResult.OK Then
    '        PrintDocument1.Print()
    '    End If
    'End Sub
    'Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
    '    'PrintPreviewDialog1.ShowDialog()
    '    PrintPreviewControl1.InvalidatePreview()
    'End Sub
    Private Sub frmAyuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Rtf = My.Resources.Henoc_Salinas
    End Sub
End Class