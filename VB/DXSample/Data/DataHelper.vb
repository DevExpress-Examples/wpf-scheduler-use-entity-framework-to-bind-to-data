Imports System
Imports System.Collections.Generic
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Native
Imports DevExpress.XtraScheduler.Xml

Namespace DXSample.Data
	Public Class DataHelper
		#Region "Appointments"
		Private Shared Property random() As New Random()
		Private Shared Property Start() As DateTime = GetMonday(DateTime.Today)
		Public Shared Function Gym() As IEnumerable(Of AppointmentEntity)
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddMonths(-1).AddHours(18)

			Dim patternTimeOfDay As TimeSpan = start_Conflict.TimeOfDay
			Dim patternStartDate As DateTime = DateTimeHelper.GetStartOfWeekUI(start_Conflict.Date, DayOfWeek.Monday).Date
			Dim patternStart As DateTime = patternStartDate.Add(patternTimeOfDay)

			Dim patternDuration As TimeSpan = TimeSpan.FromHours(1.5)
			Dim pattern As New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Pattern)),
				.Start = patternStart,
				.End = patternStart.Add(patternDuration),
				.Subject = "Gym",
				.Label = 3,
				.ResourceId = 1
			}

			Dim info As RecurrenceInfo = CType(RecurrenceBuilder.Weekly(patternStart).ByDay(WeekDays.Monday Or WeekDays.Wednesday Or WeekDays.Friday).Build(), RecurrenceInfo)
			pattern.RecurrenceInfo = info.ToXml()
			Dim weekStartDate As DateTime = DateTimeHelper.GetStartOfWeekUI(Start.Date, DayOfWeek.Monday).Date
			Dim changedStart As DateTime = weekStartDate.Add(patternTimeOfDay.Add(TimeSpan.FromHours(-1)))
			Dim changedOccurrenceIndex As Integer = (weekStartDate.Subtract(patternStartDate)).Days \ 7 * 3
			If changedOccurrenceIndex < 0 Then
				Return New List(Of AppointmentEntity)(1) From {pattern}
			End If

			Dim changedOccurrence As New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.ChangedOccurrence)),
				.Start = changedStart,
				.End = changedStart.Add(patternDuration),
				.Subject = "Gym",
				.Label = 3,
				.ResourceId = 1
			}

			changedOccurrence.RecurrenceInfo = (New PatternReferenceXmlPersistenceHelper(New PatternReference(info.Id, changedOccurrenceIndex))).ToXml()
			Dim deletedOccurrenceIndex As Integer = changedOccurrenceIndex + 1
			Dim deletedStart As DateTime = weekStartDate.Add(patternTimeOfDay.Add(TimeSpan.FromDays(2)))

			Dim deletedOccurrence As New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.DeletedOccurrence)),
				.Start = deletedStart,
				.End = deletedStart.Add(patternDuration),
				.Subject = "Gym",
				.Label = 3,
				.ResourceId = 1
			}

			deletedOccurrence.RecurrenceInfo = (New PatternReferenceXmlPersistenceHelper(New PatternReference(info.Id, deletedOccurrenceIndex))).ToXml()
			Return New List(Of AppointmentEntity)(3) From {pattern, changedOccurrence, deletedOccurrence}
		End Function
		Public Shared Function Dentist() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(3).AddHours(19)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = start_Conflict,
				.End = start_Conflict.AddHours(1),
				.Subject = "Dentist",
				.Label = 1,
				.ResourceId = 1
			}
			Return appt
		End Function
		Public Shared Function Dinner() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(1).AddHours(20)
			Dim newStart As DateTime = start_Conflict.AddMinutes(random.Next(0, 4) * 15)
			Dim newEnd As DateTime = newStart.AddMinutes(random.Next(4, 8) * 20)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.Subject = "Family Dinner",
				.Label = 3,
				.ResourceId = 1
			}
			Return appt
		End Function
		Public Shared Function Disneyland() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(6)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddDays(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.Subject = "Disneyland",
				.ResourceId = 1,
				.Label = 1,
				.Description = "It better be the happiest place on earth - I could sure use a nice day with the kids."
			}
			Return appt
		End Function
		Public Shared Function RR() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(6)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddDays(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.Subject = "R&R",
				.ResourceId = 3,
				.Label = 3,
				.Description = "Nothing to do but relax and enjoy the day with family. Need to take my foot off the gas pedal and enjoy the day."
			}
			Return appt
		End Function
		Public Shared Function DayOff() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddDays(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 2,
				.Label = 3,
				.Subject = "Day off"
			}
			Return appt
		End Function
		Public Shared Function SecondShift() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddDays(5)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 3,
				.Label = 2,
				.Subject = "Second shift"
			}
			Return appt
		End Function
		Public Shared Function ConferenceCompanyMeeting() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(1).AddHours(10)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 3,
				.Subject = "Company-wide meeting",
				.Label = 1,
				.Description = "Everyone must be ready to ask questions and inform leadership team why they are not performing as expected and what we need to do as a team to improve morale."
			}
			Return appt
		End Function
		Public Shared Function ConferenceCustomerRetentionReview() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(2).AddHours(9)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 3,
				.Subject = "Customer retention review",
				.Label = 1,
				.Description = "Discuss ways in which we can improve our relationship with customers and prove to them that we are the long term source for all their A/V needs."
			}
			Return appt
		End Function
		Public Shared Function ConferenceDatabaseAndWebsiteReview() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(3).AddHours(9)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(3)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 3,
				.Subject = "Database and website review",
				.Label = 1,
				.Description = "It's time to launch our new website. Management can no longer tolerate delays nor accept excuses. We've been waiting long enough for the overhaul."
			}
			Return appt
		End Function
		Public Shared Function ConferenceWeeklyMeeting() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(4).AddHours(17)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 3,
				.Label = 1,
				.Subject = "Weekly meeting"
			}
			Return appt
		End Function
		Public Shared Function TrainingFrenchLesson() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(-7).AddHours(11).AddMinutes(10)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(1.5)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Pattern)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 2,
				.Subject = "French lesson",
				.Label = 3,
				.Description = "Another french lesson.Once again, without mastering French, our success on the Continent will be less likely.Everyone needs to learn French."
			}
			appt.RecurrenceInfo = RecurrenceBuilder.Weekly(newStart, 10).ByDay(WeekDays.Monday Or WeekDays.Wednesday).Build().ToXml()
			Return appt
		End Function
		Public Shared Function TrainingGermanLesson() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddHours(15).AddMinutes(40)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(1.5)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Pattern)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 2,
				.Subject = "German lesson",
				.Label = 3,
				.Description = "We're learning French but we also need to become fluent in German. The German market for A/V products is huge. We need to be able to communicate in German if we are to have any luck in Germany."
			}
			appt.RecurrenceInfo = RecurrenceBuilder.Weekly(newStart, 10).ByDay(WeekDays.Tuesday Or WeekDays.Friday).Build().ToXml()
			Return appt
		End Function
		Public Shared Function TrainingTrainStaffOnNewRemoteControls() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Conflict As DateTime = Start.AddDays(3).AddHours(10).AddMinutes(10)
			Dim newStart As DateTime = start_Conflict
			Dim newEnd As DateTime = newStart.AddHours(1).AddMinutes(50)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(Math.Truncate(AppointmentType.Normal)),
				.Start = newStart,
				.End = newEnd,
				.ResourceId = 3,
				.Subject = "Train staff on new remote controls",
				.Label = 2,
				.Description = "Our newest remote controls are ready for production. Everyone needs to understand how our new universal remote works and our long term plans for better automation."
			}
			Return appt
		End Function
		Public Shared Function GetMonday(ByVal [date] As DateTime) As DateTime
			Dim dayOfWeek As DayOfWeek = [date].DayOfWeek
			If dayOfWeek = System.DayOfWeek.Monday Then
				Return [date].Date
			End If
			If dayOfWeek = System.DayOfWeek.Saturday Then
				Return [date].Date.AddDays(2)
			End If
			If dayOfWeek = System.DayOfWeek.Sunday Then
				Return [date].Date.AddDays(1)
			End If
			Return [date].Date.AddDays(-(CInt(dayOfWeek) - 1))
		End Function
		#End Region
		#Region "Resources"
		Public Shared Function Personal() As ResourceEntity
			Return New ResourceEntity() With {
				.Description = "Personal",
				.Id = 1
			}
		End Function
		Public Shared Function Education() As ResourceEntity
			Return New ResourceEntity() With {
				.Description = "Education",
				.Id = 2
			}
		End Function
		Public Shared Function Work() As ResourceEntity
			Return New ResourceEntity() With {
				.Description = "Work",
				.Id = 3
			}
		End Function
		#End Region
	End Class
End Namespace
