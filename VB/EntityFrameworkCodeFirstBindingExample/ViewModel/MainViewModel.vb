Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Xpf.Scheduling
Imports System.Collections.ObjectModel
Imports System.Data.Entity

Namespace EntityFrameworkCodeFirstBindingExample
    <POCOViewModel> _
    Public Class MainViewModel

        #Region "#instances"
        Private mySchedulerContext As MySchedulerModel
        Public Overridable Property Resources() As ObservableCollection(Of Car)
        Public Overridable Property Appointments() As ObservableCollection(Of CarScheduling)
        #End Region ' #instances

        #Region "#savechanges"
        Public Sub AppointmentsUpdated()
            mySchedulerContext.SaveChanges()
        End Sub
        #End Region ' #savechanges

        #Region "#InitNewAppointment"
        Public Sub InitNewAppointment(ByVal args As AppointmentItemEventArgs)
            args.Appointment.Reminders.Clear()
        End Sub
        #End Region ' #InitNewAppointment

        #Region "#filldata"
        Protected Sub New()
            mySchedulerContext = New MySchedulerModel()
            mySchedulerContext.Cars.Load()
            Resources = mySchedulerContext.Cars.Local
            mySchedulerContext.CarSchedulings.Load()
            Appointments = mySchedulerContext.CarSchedulings.Local
        End Sub
        #End Region ' #filldata
        Public Shared Function Create() As MainViewModel
            Return ViewModelSource.Create(Function() New MainViewModel())
        End Function
    End Class
End Namespace
