Partial Class Ribbon1
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'El Diseñador de componentes requiere esta llamada.
        InitializeComponent()

    End Sub

    'Component reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de componentes
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de componentes requiere el siguiente procedimiento
    'Se puede modificar usando el Diseñador de componentes.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OTS = Me.Factory.CreateRibbonTab
        Me.grpCaptura = Me.Factory.CreateRibbonGroup
        Me.btnCrear = Me.Factory.CreateRibbonButton
        Me.Separator1 = Me.Factory.CreateRibbonSeparator
        Me.btnBorrar = Me.Factory.CreateRibbonButton
        Me.grpOTS = Me.Factory.CreateRibbonGroup
        Me.btnImpresion = Me.Factory.CreateRibbonButton
        Me.btnCierreOt = Me.Factory.CreateRibbonButton
        Me.Button5 = Me.Factory.CreateRibbonButton
        Me.Button6 = Me.Factory.CreateRibbonButton
        Me.btnInstrucciones = Me.Factory.CreateRibbonButton
        Me.Button3 = Me.Factory.CreateRibbonButton
        Me.Button4 = Me.Factory.CreateRibbonButton
        Me.grpInfo = Me.Factory.CreateRibbonGroup
        Me.Button1 = Me.Factory.CreateRibbonButton
        Me.btnConfig = Me.Factory.CreateRibbonButton
        Me.OTS.SuspendLayout()
        Me.grpCaptura.SuspendLayout()
        Me.grpOTS.SuspendLayout()
        Me.grpInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'OTS
        '
        Me.OTS.Groups.Add(Me.grpCaptura)
        Me.OTS.Groups.Add(Me.grpOTS)
        Me.OTS.Groups.Add(Me.grpInfo)
        Me.OTS.Label = "ORDENES DE TRABAJO"
        Me.OTS.Name = "OTS"
        '
        'grpCaptura
        '
        Me.grpCaptura.Items.Add(Me.btnCrear)
        Me.grpCaptura.Items.Add(Me.Separator1)
        Me.grpCaptura.Items.Add(Me.btnBorrar)
        Me.grpCaptura.Label = "GENERAR"
        Me.grpCaptura.Name = "grpCaptura"
        Me.grpCaptura.Visible = False
        '
        'btnCrear
        '
        Me.btnCrear.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnCrear.Image = Global.OTS.My.Resources.Resources.AÑADIR
        Me.btnCrear.Label = "CREAR / ACTUALIZAR"
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.ScreenTip = "Crear/actiualizar"
        Me.btnCrear.ShowImage = True
        Me.btnCrear.SuperTip = "crea o actualiza la informacion de la orden de trabajo selaccionada"
        Me.btnCrear.Visible = False
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        '
        'btnBorrar
        '
        Me.btnBorrar.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnBorrar.Image = Global.OTS.My.Resources.Resources.BORRAR
        Me.btnBorrar.Label = "BORRAR"
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.ScreenTip = "Borrar"
        Me.btnBorrar.ShowImage = True
        Me.btnBorrar.SuperTip = "Borrar de la base de datos la orden de trabajo seleccionada"
        Me.btnBorrar.Visible = False
        '
        'grpOTS
        '
        Me.grpOTS.Items.Add(Me.btnImpresion)
        Me.grpOTS.Items.Add(Me.btnCierreOt)
        Me.grpOTS.Items.Add(Me.Button5)
        Me.grpOTS.Items.Add(Me.Button6)
        Me.grpOTS.Items.Add(Me.btnInstrucciones)
        Me.grpOTS.Items.Add(Me.Button3)
        Me.grpOTS.Items.Add(Me.Button4)
        Me.grpOTS.Label = "ORDENES DE TRABAJO"
        Me.grpOTS.Name = "grpOTS"
        '
        'btnImpresion
        '
        Me.btnImpresion.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnImpresion.Image = Global.OTS.My.Resources.Resources.OTICON
        Me.btnImpresion.Label = "Ver Orden Trabajo"
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.ScreenTip = "Impresion"
        Me.btnImpresion.ShowImage = True
        Me.btnImpresion.SuperTip = "Ordenes de trabajo"
        '
        'btnCierreOt
        '
        Me.btnCierreOt.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnCierreOt.Image = Global.OTS.My.Resources.Resources.box_closed
        Me.btnCierreOt.Label = "Cierre de Ordenes"
        Me.btnCierreOt.Name = "btnCierreOt"
        Me.btnCierreOt.ShowImage = True
        Me.btnCierreOt.SuperTip = "Reporte de Transferencias en una OT"
        '
        'Button5
        '
        Me.Button5.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.Button5.Image = Global.OTS.My.Resources.Resources.document_move
        Me.Button5.Label = "Transferencias Linea"
        Me.Button5.Name = "Button5"
        Me.Button5.ShowImage = True
        Me.Button5.SuperTip = "Transferencias desde y hacia una linea en un Periodo de Tiempo."
        '
        'Button6
        '
        Me.Button6.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.Button6.Image = Global.OTS.My.Resources.Resources.page_numbers_in_margins_insert
        Me.Button6.Label = "Existencias Linea/Almacen"
        Me.Button6.Name = "Button6"
        Me.Button6.ShowImage = True
        '
        'btnInstrucciones
        '
        Me.btnInstrucciones.Image = Global.OTS.My.Resources.Resources.INFORMACION
        Me.btnInstrucciones.Label = "VER INSTRUCCIONES"
        Me.btnInstrucciones.Name = "btnInstrucciones"
        Me.btnInstrucciones.ShowImage = True
        '
        'Button3
        '
        Me.Button3.Image = Global.OTS.My.Resources.Resources.INFORMACION
        Me.Button3.Label = "VER PFT"
        Me.Button3.Name = "Button3"
        Me.Button3.ShowImage = True
        '
        'Button4
        '
        Me.Button4.Image = Global.OTS.My.Resources.Resources.Back
        Me.Button4.Label = "HISTORICO"
        Me.Button4.Name = "Button4"
        Me.Button4.ShowImage = True
        '
        'grpInfo
        '
        Me.grpInfo.Items.Add(Me.Button1)
        Me.grpInfo.Items.Add(Me.btnConfig)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.OTS.My.Resources.Resources.AYUDA
        Me.Button1.Label = "AYUDA"
        Me.Button1.Name = "Button1"
        Me.Button1.ShowImage = True
        '
        'btnConfig
        '
        Me.btnConfig.Image = Global.OTS.My.Resources.Resources.CONFIG
        Me.btnConfig.Label = "CONFIGURAR"
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.ShowImage = True
        '
        'Ribbon1
        '
        Me.Name = "Ribbon1"
        Me.RibbonType = "Microsoft.Excel.Workbook"
        Me.Tabs.Add(Me.OTS)
        Me.OTS.ResumeLayout(False)
        Me.OTS.PerformLayout()
        Me.grpCaptura.ResumeLayout(False)
        Me.grpCaptura.PerformLayout()
        Me.grpOTS.ResumeLayout(False)
        Me.grpOTS.PerformLayout()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OTS As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents grpCaptura As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnCrear As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnImpresion As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpOTS As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnConfig As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpInfo As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnInstrucciones As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Separator1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents btnBorrar As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button1 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button3 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button4 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnCierreOt As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button5 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Button6 As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As Ribbon1
        Get
            Return Me.GetRibbon(Of Ribbon1)()
        End Get
    End Property
End Class
