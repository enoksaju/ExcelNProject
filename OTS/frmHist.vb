Imports System.Data.Entity

Public Class frmHist

    Private Property db As libProduccionDataBase.Contexto.DataBaseContexto
    Private Async Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Await FillDataBinding(ToolStripTextBox1.Text, IIf(IsNumeric(ToolStripTextBox1.Text.Trim), True, False))
    End Sub

    Private Async Function FillDataBinding(ToSearch As String, Optional asOT As Boolean = False) As Threading.Tasks.Task
        Try
            If ToSearch.Trim() <> String.Empty Then

                If asOT Then
                    Dim localOT = Await db.TEMPCAPT.Include(Function(o) o.OrdenTrabajo).Where(Function(o) o.OT = ToSearch).FirstOrDefaultAsync()
                    Await db.TEMPCAPT.Where(Function(o) o.OrdenTrabajo.PRODUCTO.Contains(localOT.OrdenTrabajo.PRODUCTO)).OrderBy(Function(O) O.DISENIOAUT).LoadAsync()
                Else
                    Await db.TEMPCAPT.Where(Function(o) o.OrdenTrabajo.PRODUCTO.Contains(ToSearch)).OrderBy(Function(O) O.DISENIOAUT).LoadAsync()
                End If

                TEMPCAPTBindingSource.DataSource = db.TEMPCAPT.Local.ToBindingList()

            Else
                Throw New Exception("No se encontro ninguna OT que coincidiera")
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(Me, ex.Message, "Algo va mal...", Windows.Forms.MessageBoxIcon.Error, Windows.Forms.MessageBoxButtons.OK)

        End Try
    End Function

    Private Sub frmHist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.db = New libProduccionDataBase.Contexto.DataBaseContexto()
    End Sub

    ' '''
    ' If (AsOT) {
    '	Try {
    '		var localOT = await DB.TEMPCAPT.Include ( o => o.OrdenTrabajo ).Where ( o => o.OT == ToSearch ).FirstOrDefaultAsync ( );

    '		await DB.TEMPCAPT
    '			.Where(o >= o.OrdenTrabajo.PRODUCTO.Contains(localOT.OrdenTrabajo.PRODUCTO))
    ' .OrderBy(O >= O.DISENIOAUT)
    ' .LoadAsync();
    '	}
    '	Catch (Exception ex) {
    '		KryptonTaskDialog.Show ( "Algo va mal...", "Error", "No se encontro el historico: \n" + ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
    '	}

    '} else {

    '	await DB.TEMPCAPT
    '		.Where(o >= o.OrdenTrabajo.PRODUCTO.Contains(ToSearch))
    ' .OrderBy(O >= O.DISENIOAUT)
    ' .LoadAsync();

    '}
    ' '''

End Class