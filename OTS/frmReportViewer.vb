Imports System.IO
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms

Public Class frmReportViewer
    'Private PathReporte As String
    'Private LAOT As BD.DatosOt

    'Sub New(DirReporte As String, OT As BD.DatosOt)
    '    InitializeComponent()
    '    Try
    '        'Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
    '        'Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    '        PathReporte = DirReporte
    '        'Me.ReportViewer1.LocalReport.ReportPath = PathReporte
    '        LAOT = OT
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Sub REPORTVIEWER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'With ReportViewer1
        '    Try
        '        .SetDisplayMode(DisplayMode.Normal)
        '        .ZoomMode = ZoomMode.PageWidth
        '        Dim c = ReportesRDLC.Init.Path
        '        Dim Assembly As Assembly = Assembly.LoadFrom(c) '.LoadFrom(Assembly.GetAssembly(Me.GetType).FullNam) '"ReportesRDLC.dll")
        '        Dim Stream As Stream = Assembly.GetManifestResourceStream("ReportesRDLC." & PathReporte)
        '        .LocalReport.LoadReportDefinition(Stream)
        '        .LocalReport.DataSources.Clear()
        '        Dim listpedido As New List(Of BD.DatosOt)
        '        listpedido.Add(LAOT)
        '        Dim parameters As ReportParameter() = New ReportParameter(1) {}
        '        parameters(0) = New ReportParameter("ORDENTRABAJO", LAOT.OT)
        '        parameters(1) = New ReportParameter("ENCABEZADO", LAOT.OT)
        '        .LocalReport.DataSources.Add(New ReportDataSource("DataSet1", listpedido))
        '        .LocalReport.SetParameters(parameters)
        '    Catch ex As Exception
        '        MessageBox.Show("NO SE PUDO ABRIR LA VENTANA PORQUE:" & vbCrLf & ex.Message, "Algo salió mal...", Forms.MessageBoxButtons.OK, Forms.MessageBoxIcon.Error)
        '        ' Me.Close()
        '    Finally
        '        .RefreshReport()
        '    End Try
        'End With
    End Sub

    'Private Sub ReportViewer1_ViewButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs)
    '    MsgBox("try")
    'End Sub

    'Private Sub ReportViewer1_StatusChanged(sender As Object, e As EventArgs)
    '    With ReportViewer1
    '        If .DisplayMode = DisplayMode.PrintLayout Then
    '            .SetDisplayMode(DisplayMode.Normal)
    '            .ZoomMode = ZoomMode.PageWidth
    '        End If
    '    End With
    'End Sub
End Class