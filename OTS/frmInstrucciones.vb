Imports System.Data.Entity
Public Class frmInstrucciones

    Private DB As libProduccionDataBase.Contexto.DataBaseContexto
    Private CurrentOT As String = ""
    Private Sub frmInstrucciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DB = New libProduccionDataBase.Contexto.DataBaseContexto()
        OTTextBox.Select()
    End Sub
    Private Sub FillToolStripButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Try
            If Not DB.TEMPCAPT.Any(Function(o) o.OT = OTTextBox.Text) Then
                Throw New Exception("No existe ninguna OT con los datos indicados")
            Else
                DB.TEMPCAPT.Where(Function(o) o.OT = OTTextBox.Text).LoadAsync()
                Me.TEMPCAPTBindingSource.DataSource = DB.TEMPCAPT.Local.ToBindingList()
                Dim y = DB.TEMPCAPT.Local.FirstOrDefault(Function(o) o.OT = OTTextBox.Text)
                Me.TEMPCAPTBindingSource.Position = Me.TEMPCAPTBindingSource.IndexOf(y)
                CurrentOT = OTTextBox.Text
                Me.Text = "Instrucciones - [" & CurrentOT & "]"
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
            OTTextBox.Text = CurrentOT
        Finally
            OTTextBox.Select()
            OTTextBox.SelectAll()
        End Try

    End Sub

    Private Sub HideOnTextChanged(sender As Object, e As EventArgs) Handles INSTCORTETextBox.TextChanged, INSTDOBLADOTextBox.TextChanged, INSTEMBOBINADOTextBox.TextChanged, INSTEXTRUSIONTextBox.TextChanged, INSTIMPRESIONTextBox.TextChanged, INSTLAMINACIONTextBox.TextChanged, INSTMANGASTextBox.TextChanged, INSTREFINADOTextBox.TextChanged, INSTSELLADOTextBox.TextChanged
        sender.visible = If(sender.text.trim = String.Empty, False, True)
        For Each ctl As Windows.Forms.Control In Panel2.Controls
            If TypeOf (ctl) Is Windows.Forms.Label Then
                If ctl.Name = sender.name.replace("TextBox", "") & "Label" Then
                    ctl.Visible = sender.visible
                End If
            End If
        Next
    End Sub

    Private Sub OTToolStripTextBox_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles OTTextBox.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            FillToolStripButton_Click(SearchButton, Nothing)
        End If
    End Sub

    Private Sub ENABLEDCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        'If sender.checked Then
        '    ENABLEDCheckBox.Image = My.Resources.accept_button
        '    ENABLEDCheckBox.Text = "Disponible"
        'Else
        '    ENABLEDCheckBox.Image = My.Resources.prohibition_button
        '    ENABLEDCheckBox.Text = "No Disponible"
        'End If
    End Sub
End Class