Imports System.Diagnostics
Imports System.Reflection
Imports System.Windows.Forms
Imports FirebirdSql.Data.FirebirdClient
Imports System.Configuration
Imports System.Drawing
Public Class OrdenesTrabajo
#Region "PROPIEDADES"
    ''' <summary>
    ''' APLICACION DE EXCEL QUE CONTIENE EL ADDIN
    ''' </summary>
    ''' <returns></returns>
    Shared Property EXApp As Excel.Application = Globals.ThisAddIn.Application
#End Region
#Region "ENUMERACIONES"
    ''' <summary>
    ''' TIPO DE ORDEN DE TRABAJO
    ''' </summary>
    Enum TipoOT
        CORTE
        DOBLADO
        EMBOBINADO
        EXTRUSION
        IMPRESION
        LAMINACION
        MANGAS
        REFINADO
        SELLADO
    End Enum
#End Region
#Region "FUNCIONES COMPARTIDAS"
    ' <summary>
    ' INSERTA O ACTUALIZA UN ELEMENTO EN LA BASE DE DATOS
    ' </summary>
    'Shared Sub InsertUpdate()
    '    Try
    '        If RevisaUsuario(LoadConfig("AdminUser", ""), LoadConfig("AdminPass", "")) Then
    '            Using obj As BD.DatosOt = BD.DatosOt.FromRow(EXApp.ActiveCell)
    '                Try
    '                    If MessageBox.Show("REALMENTE DESEA INSERTAR LA OT SELECCIONADA", "CONFIRME...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
    '                    obj.InsertIntoDb()
    '                    MessageBox.Show("CORRECTO, SE INSERTÓ LA OT " & obj.OT, "INFO...", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Catch ex As BD.DatosOt.DatosOTException
    '                    If MessageBox.Show("LA OT " & ex.OT & " NO SE PUEDE INSERTAR POR QUE " & ex.Message & vbCrLf & "¿DESEA ACTUALIZAR LA INFORMACION EXISTENTE?", "Algo salió mal...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Throw New Exception("no se realizo ningun cambio")
    '                    obj.UpdateDb()
    '                    MessageBox.Show("CORRECTO, SE ACTUALIZÓ LA OT " & obj.OT, "INFO...", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Catch ex As Exception
    '                    Throw New Exception("NO SE PUDO ALMACENAR:" & vbCrLf & ex.Message)
    '                End Try
    '            End Using
    '        Else
    '            Throw New Exception("Necesita permisos de administrador para esta acción")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "ERROR...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    ' <summary>
    ' BORRA EL ELEMENTO SELECCIONADO DE LA BASE DE DATOS
    ' </summary>
    'Shared Sub Borrar()
    '    Try
    '        If RevisaUsuario(LoadConfig("AdminUser", ""), LoadConfig("AdminPass", "")) Then
    '            Using obj As BD.DatosOt = BD.DatosOt.FromRow(EXApp.ActiveCell)
    '                If obj.OT <> "" Then
    '                    If MessageBox.Show("REALMENTE DESEA BORRAR LA OT SELECCIONADA", "CONFIRME...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '                        If obj.DeleteDb() Then
    '                            MessageBox.Show("CORRECTO, SE BORRÓ LA OT " & obj.OT, "INFO...", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        End If
    '                    End If
    '                Else
    '                    Throw New Exception("EL CAMPO OT NO ES VALIDO")
    '                End If
    '            End Using
    '        Else
    '            Throw New Exception("Necesita permisos de administrador para esta acción")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "ERROR...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Shared Sub ShowOt(Tipo As TipoOT, Ot As String)
    '    Dim type As String = [Enum].GetName(GetType(TipoOT), Tipo)
    '    Try
    '        ' If System.IO.File.Exists(ConfigurationManager.AppSettings.Item("PathReports") & "OT" & type & ".rdlc") = False Then
    '        '    Throw New ApplicationException("No se encontro el archivo de la OT especificada en la ubicacion: " & vbCrLf & ConfigurationManager.AppSettings.Item("PathReports") & "OT" & type & ".rdlc" & vbCrLf & "Contacte al Administrador del sistema para resolver el conflicto")
    '        ' End If

    '        If Ot.Trim = "" Then Throw New BD.DatosOt.DatosOTException("No se Indico la OT", BD.DatosOt.DatosOTException.tipo_Error.onReader)
    '        Using y = BD.DatosOt.FromDataBase(Ot)
    '            If Not IsNothing(y) Then
    '                If Not y.HaveInstruccions(Tipo) Then Throw New Exception("La OT no cuenta con Instrucciones para generar el formato para " & type)
    '                Dim dialog As New frmReportViewer("OT" & type & ".rdlc", y)
    '                dialog.Text = "ORDEN DE TRABAJO DE " & type
    '                dialog.Show()
    '            Else
    '                Throw New Exception("NO SE ENCONTRO INFORMACION REFERENTE A LA OT " & Ot)
    '            End If
    '        End Using
    '    Catch ex As BD.DatosOt.DatosOTException
    '        Debug.WriteLine([Enum].GetName(GetType(BD.DatosOt.DatosOTException.tipo_Error), ex.tipoError) & " : " & ex.Message)
    '    Catch ex As Exception
    '        MessageBox.Show("Error:  " & ex.Message, "Algo salió mal...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Shared Sub ShowAllInstruccions(Ot As String)
    '    Try
    '        If Ot.Trim = "" Then Throw New BD.DatosOt.DatosOTException("No se Indico la OT", BD.DatosOt.DatosOTException.tipo_Error.onReader)
    '        Using y = BD.DatosOt.FromDataBase(Ot)
    '            If Not IsNothing(y) Then
    '                Dim frmInfo As New frmInstrucciones(y)
    '                frmInfo.Show()
    '            Else
    '                Throw New Exception("NO SE ENCONTRO INFORMACION REFERENTE A LA OT " & Ot)
    '            End If
    '        End Using
    '    Catch ex As BD.DatosOt.DatosOTException
    '        Debug.WriteLine([Enum].GetName(GetType(BD.DatosOt.DatosOTException.tipo_Error), ex.tipoError) & " : " & ex.Message)
    '    Catch ex As Exception
    '        MessageBox.Show("Error:  " & ex.Message, "Algo salió mal...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Shared Sub ShowObservaciones(ot As String)
    '    Try
    '        If ot.Trim = "" Then Throw New BD.DatosOt.DatosOTException("No se Indico la OT", BD.DatosOt.DatosOTException.tipo_Error.onReader)
    '        Using y = BD.DatosOt.FromDataBase(ot)
    '            If Not IsNothing(y) Then
    '                Dim frmInfo As New frmObservaciones(y)
    '                frmInfo.Show()
    '            Else
    '                Throw New Exception("NO SE ENCONTRO INFORMACION REFERENTE A LA OT " & ot)
    '            End If
    '        End Using
    '    Catch ex As BD.DatosOt.DatosOTException
    '        Debug.WriteLine([Enum].GetName(GetType(BD.DatosOt.DatosOTException.tipo_Error), ex.tipoError) & " : " & ex.Message)
    '    Catch ex As Exception
    '        MessageBox.Show("Error:  " & ex.Message, "Algo salió mal...", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Shared Sub ViewQR()
    '    Using obj As BD.DatosOt = BD.DatosOt.FromRow(EXApp.ActiveCell)
    '        Using frm As New imageform(obj.QRShow)
    '            frm.Show()
    '        End Using
    '    End Using
    'End Sub
    ' <summary>
    ' <para>FUNCION QUE SE DISPARA CUANDO SUCEDE UN ERROR EN EL OBJETO DatosOT</para>
    ' <para>SE DEBE HACER UN AddHandler BD.DatosOt.ErrorDatosOT, AddressOf OrdenesTrabajo.OnBDError</para>
    ' </summary>
    ' <param name="e"></param>
    'Shared Sub OnBDError(e As BD.DatosOt.ErrorDatosOTEventArg)
    '    MessageBox.Show(e.message)
    'End Sub
    ' <summary>
    ' FUNCION QUE SE ENCARGA DE VERIFICAR SI UN USUARIO ES DE TIPO ADMIN
    ' </summary>
    ' <param name="USER">NOMBRE DEL USUARIO</param>
    ' <param name="PASS">CONTRASEÑA DEL USUARIO</param>
    ' <returns></returns>
    'Shared Function RevisaUsuario(USER As String, PASS As String) As Boolean
    '    Try
    '        Using cnn As New FbConnection(BD.DataBaseConn.StringConnection)
    '            cnn.Open()
    '            Using cmd As New FbCommand("select COUNT(USER) FROM USERS WHERE UserName= '" & USER & "' AND PASS= '" & PASS & "'", cnn)
    '                Dim DR As FbDataReader = cmd.ExecuteReader
    '                While DR.Read
    '                    Return If(DR(0) > 0, True, False)
    '                End While
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Debug.WriteLine(ex.Message)
    '    End Try
    '    Return False
    'End Function
    ''' <summary>
    ''' SE ENCARGA DE OBTENER EL VALOR DE UN PARAMETRO DE CONFIGURACION
    ''' </summary>
    ''' <param name="Param">IDENTIFICADOR DEL ITEM DE CONFIGURACION</param>
    ''' <param name="DefaultValue">VALOR DEVUELTO SI NO ENCUENTRA</param>
    ''' <returns></returns>
    Shared Function LoadConfig(Param As String, DefaultValue As String) As String
        Dim resultado As Object = ""
        Try
            resultado = IIf(ConfigurationManager.AppSettings.Item(Param).Trim <> "", ConfigurationManager.AppSettings.Item(Param), DefaultValue)
        Catch ex As Exception
        End Try
        Return resultado
    End Function
    ''' <summary>
    ''' SE ENCARGA DE GUARDAR UN NUEVO VALOR A UN PARAMETRO DE CONFIGURACION
    ''' </summary>
    ''' <param name="Param">IDENTIFICADOR DEL ITEM DE CONFIGURACION</param>
    ''' <param name="Value">VALOR QUE SE ASIGNARA AL ITEM</param>
    Shared Sub WriteConfig(Param As String, Value As String)
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        config.AppSettings.Settings.Remove(Param)
        config.AppSettings.Settings.Add(Param, Value)
        config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
    End Sub
    ' <summary>
    ' MODIFICA COMPLETAMENTE EL ARCHIVO DE CONFIGURACION MEDIANTE LA VENTANA DE CONFIGURACION frmConfig
    ' </summary>
    ' <returns></returns>
    'Shared Function ModificarConfiguracion() As Boolean
    '    Dim Conf As New Config(LoadConfig("PathReports", ""), LoadConfig("PathBD", ""), LoadConfig("BDNombre", ""), LoadConfig("User", ""), LoadConfig("Pass", ""), LoadConfig("Port", ""), LoadConfig("AdminUser", ""), LoadConfig("AdminPass", ""))
    '    Using frmConf As New frmConfig(Conf)
    '        If frmConf.ShowDialog = DialogResult.Cancel Then Return False
    '        For Each p As PropertyInfo In frmConf.Response.GetType().GetProperties()
    '            Try
    '                WriteConfig(p.Name, p.GetValue(frmConf.Response))
    '            Catch ex As Exception
    '                Throw New Exception("VALOR NO ASIGANDO EN " & p.Name.ToUpper)
    '            End Try
    '        Next
    '    End Using
    '    BD.DataBaseConn.InitialiceStringConnection(ConfigurationManager.AppSettings.Item("PathBD"),
    '                                               ConfigurationManager.AppSettings.Item("BDNombre"),
    '                                               ConfigurationManager.AppSettings.Item("Port"),
    '                                               ConfigurationManager.AppSettings.Item("USER"),
    '                                               ConfigurationManager.AppSettings.Item("Pass"))
    '    Return True
    'End Function
#End Region
#Region "CLASES ANIDADAS"
    ''' <summary>
    ''' VENTANA QUE MUESTRA EL CODIGO QR DE LA ORDEN DE TRABAJO
    ''' </summary>
    Class imageform
        Inherits Form
        Dim WithEvents imagebox As New PictureBox
        Sub New(img As Image)
            Me.Controls.Add(imagebox)
            imagebox.Image = img
            imagebox.Dock = DockStyle.Fill
            imagebox.SizeMode = PictureBoxSizeMode.StretchImage
        End Sub
    End Class
    ''' <summary>
    ''' OBJETO CONTENEDOR DE LA INFORMACION DE CONFIGURACION
    ''' </summary>
    Class Config
        Public Property PathReports = ""
        Public Property PathBD = ""
        Public Property BDNombre = ""
        Public Property User = ""
        Public Property Pass = ""
        Public Property Port = ""
        Public Property AdminUser = ""
        Public Property AdminPass = ""
        Sub New(pathReports As String, PathBD As String, BDNombre As String, User As String, Pass As String, Port As String, AdminUser As String, AdminPass As String)
            Me.PathReports = pathReports
            Me.PathBD = PathBD
            Me.BDNombre = BDNombre
            Me.User = User
            Me.Pass = Pass
            Me.Port = Port
            Me.AdminUser = AdminUser
            Me.AdminPass = AdminPass
        End Sub
    End Class
#End Region
End Class
