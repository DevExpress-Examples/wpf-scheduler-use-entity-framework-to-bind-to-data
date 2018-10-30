Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations

Namespace EntityFrameworkCodeFirstBindingExample

    Partial Public Class Car
        Public Property ID() As Integer

        <StringLength(50)> _
        Public Property Trademark() As String

        <StringLength(50)> _
        Public Property Model() As String

        Public Property HP() As Short?

        Public Property Liter() As Double?

        Public Property Cyl() As Byte?

        Public Property TransmissSpeedCount() As Byte?

        <StringLength(3)> _
        Public Property TransmissAutomatic() As String

        Public Property MPG_City() As Byte?

        Public Property MPG_Highway() As Byte?

        <StringLength(7)> _
        Public Property Category() As String

        Public Property Description() As String

        <StringLength(50)> _
        Public Property Hyperlink() As String

        <Column(TypeName := "image")> _
        Public Property Picture() As Byte()

        <Column(TypeName := "money")> _
        Public Property Price() As Decimal?

        Public Property RtfContent() As String
    End Class
End Namespace
