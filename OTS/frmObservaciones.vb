Public Class frmObservaciones
    Private Sub FillToolStripButton_Click(sender As Object, e As EventArgs) Handles FillToolStripButton.Click
        Try
            Me.SP_ORDENTRABAJOTableAdapter.Fill(Me.DataSet1.SP_ORDENTRABAJO, OTToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class