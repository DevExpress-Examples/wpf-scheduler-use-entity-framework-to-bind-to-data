Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace EntityFrameworkCodeFirstBindingExample

    Public Partial Class Car

        Public Property ID As Integer

        <StringLength(50)>
        Public Property Trademark As String

        <StringLength(50)>
        Public Property Model As String

        Public Property HP As Short?

        Public Property Liter As Double?

        Public Property Cyl As Byte?

        Public Property TransmissSpeedCount As Byte?

        <StringLength(3)>
        Public Property TransmissAutomatic As String

        Public Property MPG_City As Byte?

        Public Property MPG_Highway As Byte?

        <StringLength(7)>
        Public Property Category As String

        Public Property Description As String

        <StringLength(50)>
        Public Property Hyperlink As String

        <Column(TypeName:="image")>
        Public Property Picture As Byte()

        <Column(TypeName:="money")>
        Public Property Price As Decimal?

        Public Property RtfContent As String
    End Class
End Namespace
