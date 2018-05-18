Module Module1

    Sub Main()
        T.intente()
    End Sub

    Public Class T
        Shared Sub intente()

            Dim myString As String = "1-|@$@|-TEST1-|@$@|-Yes|||2-|@$@|-TEST2-|@$@|-No|||3-|@$@|-TEST3-|@$@|-Yes|||"


            Dim objects = Text.RegularExpressions.Regex.Split(myString, "\|\|\|", Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim lst As List(Of Employee) = New List(Of Employee)

            For Each k In objects
                If k.Trim <> "" Then
                    Dim props = Text.RegularExpressions.Regex.Split(k, "-\|\@\$\@\|-", Text.RegularExpressions.RegexOptions.IgnoreCase)
                    lst.Add(New Employee() With {.EmpId = props(0), .Name = props(1), .Value = If(props(2) = "Yes", True, False)})
                End If
            Next

            Console.WriteLine("{0,10} {1,10} {2,10}", "Id", "Value", "Name")

            lst.ForEach(New Action(Of Employee)(Sub(t)
                                                    Console.WriteLine("{0,10} {1,10} {2,10}", t.EmpId, t.Value, t.Name)
                                                End Sub))

            Console.ReadLine()


            ' Dim delimiter As String = "|||"
            ' Dim delimiter1 As Char() = "-|@$@|-"

            'Dim subStrings() As String = myString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)

            'For index = 0 To subStrings.Length Step 3
            '    Dim Emp = New Employee With {
            '        .EmpId = .Name = subStrings(index),
            '        .Name = subStrings(index + 1),
            '        .Value = subStrings(index + 2)
            '    }


            '    Console.WriteLine("{0,10} {1,10} {2,10}", Emp.EmpId, Emp.Value, Emp.Name)
            'Next



        End Sub

    End Class
    Public Class Employee
        Public Property EmpId As Integer
        Public Property Name As String
        Public Property Value As Boolean
    End Class

End Module
