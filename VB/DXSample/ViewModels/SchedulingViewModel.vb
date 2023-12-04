Imports System.Collections.ObjectModel
Imports System.Data.Entity
Imports System.Windows.Input
Imports DevExpress.Mvvm
Imports DXSample.Data

Namespace DXSample.ViewModels

    Public Class SchedulingViewModel
        Inherits ViewModelBase

        Private context As SchedulingContext

        Public ReadOnly Property Appts As ObservableCollection(Of AppointmentEntity)
            Get
                Return context.Appointments.Local
            End Get
        End Property

        Public ReadOnly Property Calendars As ObservableCollection(Of ResourceEntity)
            Get
                Return context.Resources.Local
            End Get
        End Property

        Public Property Status As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Sub New()
            context = New SchedulingContext()
            context.Appointments.Load()
            context.Resources.Load()
        End Sub

        Public ReadOnly Property SaveCommand As ICommand
            Get
                Return New DelegateCommand(Sub()
                    context.SaveChanges()
                    Status = $"Changes are saved to database. {Date.Now.ToLongTimeString()}."
                End Sub)
            End Get
        End Property
    End Class
End Namespace
