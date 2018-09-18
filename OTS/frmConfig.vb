Public Class frmConfig

    Public Property Response As OrdenesTrabajo.Config
    Sub New(Config As OrdenesTrabajo.Config)
        InitializeComponent()
        OrdenesTrabajo_ConfigBindingSource.Add(Config)
        OrdenesTrabajo_ConfigBindingSource.MoveFirst()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response = OrdenesTrabajo_ConfigBindingSource.Current
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
End Class