Imports System
Imports System.Data.Entity

Namespace DXSample.Data

	Public Class SchedulingContext
		Inherits DbContext

		Public Property Appointments() As DbSet(Of AppointmentEntity)
		Public Property Resources() As DbSet(Of ResourceEntity)
	End Class

	Public Class AppointmentEntity
		Public Property Id() As Integer
		Public Property Subject() As String
		Public Property Description() As String
		Public Property Start() As Date
		Public Property [End]() As Date
		Public Property AppointmentType() As Integer
		Public Property RecurrenceInfo() As String
		Public Property ResourceId() As Integer
		Public Property Label() As Integer
	End Class
	Public Class ResourceEntity
		Public Property Id() As Integer
		Public Property Description() As String
	End Class

	Public Class SchedulingContextInitializer
		Inherits DropCreateDatabaseIfModelChanges(Of SchedulingContext)

		Protected Overrides Sub Seed(ByVal context As SchedulingContext)
			MyBase.Seed(context)

			context.Resources.Add(DataHelper.Personal())
			context.Resources.Add(DataHelper.Education())
			context.Resources.Add(DataHelper.Work())

			context.Appointments.AddRange(DataHelper.Gym())
			context.Appointments.Add(DataHelper.Dentist())
			context.Appointments.Add(DataHelper.Dinner())
			context.Appointments.Add(DataHelper.Disneyland())
			context.Appointments.Add(DataHelper.RR())
			context.Appointments.Add(DataHelper.DayOff())
			context.Appointments.Add(DataHelper.SecondShift())
			context.Appointments.Add(DataHelper.ConferenceCompanyMeeting())
			context.Appointments.Add(DataHelper.ConferenceCustomerRetentionReview())
			context.Appointments.Add(DataHelper.ConferenceDatabaseAndWebsiteReview())
			context.Appointments.Add(DataHelper.ConferenceWeeklyMeeting())
			context.Appointments.Add(DataHelper.TrainingFrenchLesson())
			context.Appointments.Add(DataHelper.TrainingGermanLesson())
			context.Appointments.Add(DataHelper.TrainingTrainStaffOnNewRemoteControls())

			context.SaveChanges()
		End Sub
	End Class
End Namespace
