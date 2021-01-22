Module Module1

    Sub Main()

        Console.WriteLine(GetTratado("PET_TRANSPARENTE"))
        Console.WriteLine(GetTratado("PEBD_T-2000 60.0/200"))

        Console.ReadLine()

    End Sub

    Public Function GetTolColor(deck As Object(), Optional func As Integer = 2) As String

        If IsNothing(deck) Then Return ""

        Select Case func
            Case 1
                Return If(deck(0) = "Pantone", "0", If(deck(0) = "Blanco", "", (CDbl(deck(7)) - 0.1).ToString("0.00")))
            Case 2
                Return If(deck(0) = "Pantone", "0", If(deck(0) = "Blanco", "", (CDbl(deck(7))).ToString("0.00")))
            Case 3
                Return If(deck(0) = "Pantone", "1.5", If(deck(0) = "Blanco", "", (CDbl(deck(7)) + 0.1).ToString("0.00")))
            Case Else
                Return ""
        End Select

    End Function

    Public Function GetTratado(material As String) As String

        If material.Trim() = "" Then Return ""

        Return If(material.ToUpper().Contains("PET"), "42", "38")
    End Function


End Module
