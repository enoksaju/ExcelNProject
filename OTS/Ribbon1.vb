Imports System.Configuration
Imports Microsoft.Office.Tools.Ribbon
Imports System.IO
Public Class Ribbon1
    ' <summary>
    ' CARGA DEL RIBBON DEL ADDIN
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    'Private Sub Ribbon1_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load
    '    BD.DataBaseConn.InitialiceStringConnection(ConfigurationManager.AppSettings.Item("PathBD"),
    '                                               ConfigurationManager.AppSettings.Item("BDNombre"),
    '                                               ConfigurationManager.AppSettings.Item("Port"),
    '                                               ConfigurationManager.AppSettings.Item("USER"),
    '                                               ConfigurationManager.AppSettings.Item("Pass"))
    '    AddHandler BD.DatosOt.ErrorDatosOT, AddressOf OrdenesTrabajo.OnBDError
    'End Sub
    ' <summary>
    ' INSERTA O ACTUALIZA UNA ORDEN DE TRABAJO
    ' <para>REQUIERE ACCESO DE ADMINISTRADOR</para>
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    'Private Sub btnCrear_Click(sender As Object, e As RibbonControlEventArgs) Handles btnCrear.Click
    '    OrdenesTrabajo.InsertUpdate()
    'End Sub
    ''' <summary>
    ''' OBTIENE UNA ORDEN DE TRABAJO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CallReport_Click(sender As Object, e As RibbonControlEventArgs) Handles _
        btnImpresion.Click
        Dim frm As New frmReportViewer
        frm.Show()
    End Sub
    '' <summary>
    '' ACTUALIZA LA CONFIGURACION 
    '' </summary>
    '' <param name="sender"></param>
    '' <param name="e"></param>
    'Private Sub btnConfig_Click(sender As Object, e As RibbonControlEventArgs) Handles btnConfig.Click
    '    If OrdenesTrabajo.ModificarConfiguracion() Then
    '        System.Windows.Forms.MessageBox.Show("Se actualizó la configuracion", "Correcto...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
    '    Else
    '        System.Windows.Forms.MessageBox.Show("No se pudo actualizar la configuracion", "Algo Salió mal...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
    '    End If
    'End Sub
    'Private Sub btnInstrucciones_Click(sender As Object, e As RibbonControlEventArgs) Handles btnInstrucciones.Click
    '    OrdenesTrabajo.ShowAllInstruccions(InputBox("INGRESE EL NUMERO DE OT", "BUSCAR OT..."))
    'End Sub
    'Private Sub btnBorrar_Click(sender As Object, e As RibbonControlEventArgs) Handles btnBorrar.Click
    '    OrdenesTrabajo.Borrar()
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs) Handles Button1.Click
    '    Using C As New frmAyuda
    '        C.ShowDialog()
    '    End Using
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As RibbonControlEventArgs) Handles Button2.Click
    '    OrdenesTrabajo.ShowObservaciones(InputBox("INGRESE EL NUMERO DE OT", "BUSCAR OT..."))
    'End Sub
    Private Sub Button3_Click(sender As Object, e As RibbonControlEventArgs) Handles Button3.Click
        Dim ot = InputBox("INGRESE EL NUMERO DE OT", "BUSCAR OT...", "")
        Try
            If ot.Trim = String.Empty Then Throw New Exception("Error en los datos indicados")

            Dim fls = Directory.GetFiles("\\192.168.1.253\sgc\9 PFT'S", "PFT*")
            Dim filename = ""

            For Each x In fls
                If x.Contains(ot) Then
                    filename = x
                    Exit For
                End If
            Next


            If filename.Trim <> "" Then

                System.Diagnostics.Process.Start(filename)

                'Dim APP As New Excel.Application
                'APP.Visible = True
                'APP.Workbooks.Open(filename)

            Else
                Throw New Exception("NO SE ENCONTRÓ LA PFT PARA LA OT " & ot & " NINGUN ARCHIVO")
            End If
            'Diagnostics.Process.Start("EXCEL.EXE", filename)
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Error:" & ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As RibbonControlEventArgs) Handles Button4.Click
        Dim frm As New frmHist
        frm.Show()
    End Sub

    Private Sub btnInstrucciones_Click(sender As Object, e As RibbonControlEventArgs) Handles btnInstrucciones.Click
        Dim frm As New frmInstrucciones
        frm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As RibbonControlEventArgs)
        Dim frm As New frmObservaciones
        frm.Show()
    End Sub

    Private Sub btnCierreOt_Click(sender As Object, e As RibbonControlEventArgs) Handles btnCierreOt.Click
        Dim frm As New frmCierreOts
        frm.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As RibbonControlEventArgs) Handles Button5.Click
        Dim frm As New frmTransferenciasLinea
        frm.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As RibbonControlEventArgs) Handles Button6.Click
        Dim frm As New frmExistencias
        frm.Show()
    End Sub
End Class
