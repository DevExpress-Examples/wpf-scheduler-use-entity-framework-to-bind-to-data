Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace EntityFrameworkCodeFirstBindingExample

    <Table("CarScheduling")>
    Public Partial Class CarScheduling

        Public Property ID As Integer

        Public Property CarId As Integer?

        Public Property UserId As Integer?

        Public Property Status As Integer?

        <StringLength(50)>
        Public Property Subject As String

        Public Property Description As String

        Public Property Label As Integer?

        Public Property StartTime As Date?

        Public Property EndTime As Date?

        <StringLength(50)>
        Public Property Location As String

        Public Property AllDay As Boolean

        Public Property EventType As Integer?

        Public Property RecurrenceInfo As String

        Public Property ReminderInfo As String

        <Column(TypeName:="smallmoney")>
        Public Property Price As Decimal?

        Public Property ContactInfo As String
    End Class
End Namespace
