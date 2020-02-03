'====================================================================================================
'The Free Edition of Instant VB limits conversion output to 100 lines per file.

'To subscribe to the Premium Edition, visit our website:
'https://www.tangiblesoftwaresolutions.com/order/order-instant-vb.html
'====================================================================================================

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
		Private Shared Property Start() As Date = GetMonday(Date.Today)
		Public Shared Function Gym() As IEnumerable(Of AppointmentEntity)
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Renamed As Date = Start.AddMonths(-1).AddHours(18)

			Dim patternTimeOfDay As TimeSpan = start_Renamed.TimeOfDay
			Dim patternStartDate As Date = DateTimeHelper.GetStartOfWeekUI(start_Renamed.Date, DayOfWeek.Monday).Date
			Dim patternStart As Date = patternStartDate.Add(patternTimeOfDay)

			Dim patternDuration As TimeSpan = TimeSpan.FromHours(1.5)
			Dim pattern As New AppointmentEntity() With {
				.AppointmentType = CInt(AppointmentType.Pattern),
				.Start = patternStart,
				.End = patternStart.Add(patternDuration),
				.Subject = "Gym",
				.Label = 3,
				.ResourceId = 1
			}

			Dim info As RecurrenceInfo = DirectCast(RecurrenceBuilder.Weekly(patternStart).ByDay(WeekDays.Monday Or WeekDays.Wednesday Or WeekDays.Friday).Build(), RecurrenceInfo)
			pattern.RecurrenceInfo = info.ToXml()
			Dim weekStartDate As Date = DateTimeHelper.GetStartOfWeekUI(Start.Date, DayOfWeek.Monday).Date
			Dim changedStart As Date = weekStartDate.Add(patternTimeOfDay.Add(TimeSpan.FromHours(-1)))
			Dim changedOccurrenceIndex As Integer = (weekStartDate.Subtract(patternStartDate)).Days \ 7 * 3
			If changedOccurrenceIndex < 0 Then
				Return New List(Of AppointmentEntity)(1) From {pattern}
			End If

			Dim changedOccurrence As New AppointmentEntity() With {
				.AppointmentType = CInt(AppointmentType.ChangedOccurrence),
				.Start = changedStart,
				.End = changedStart.Add(patternDuration),
				.Subject = "Gym",
				.Label = 3,
				.ResourceId = 1
			}

			changedOccurrence.RecurrenceInfo = (New PatternReferenceXmlPersistenceHelper(New PatternReference(info.Id, changedOccurrenceIndex))).ToXml()
			Dim deletedOccurrenceIndex As Integer = changedOccurrenceIndex + 1
			Dim deletedStart As Date = weekStartDate.Add(patternTimeOfDay.Add(TimeSpan.FromDays(2)))

			Dim deletedOccurrence As New AppointmentEntity() With {
				.AppointmentType = CInt(AppointmentType.DeletedOccurrence),
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
			Dim start_Renamed As Date = Start.AddDays(3).AddHours(19)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(AppointmentType.Normal),
				.Start = start_Renamed,
				.End = start_Renamed.AddHours(1),
				.Subject = "Dentist",
				.Label = 1,
				.ResourceId = 1
			}
			Return appt
		End Function
		Public Shared Function Dinner() As AppointmentEntity
'INSTANT VB NOTE: The variable start was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim start_Renamed As Date = Start.AddDays(1).AddHours(20)
			Dim newStart As Date = start_Renamed.AddMinutes(random.Next(0, 4) * 15)
			Dim newEnd As Date = newStart.AddMinutes(random.Next(4, 8) * 20)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(AppointmentType.Normal),
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
			Dim start_Renamed As Date = Start.AddDays(6)
			Dim newStart As Date = start_Renamed
			Dim newEnd As Date = newStart.AddDays(1)
			Dim appt = New AppointmentEntity() With {
				.AppointmentType = CInt(AppointmentType.Normal),
				.Start = newStart,
				.End = newEnd,
				.Subject = "Disneyland",
				.ResourceId = 1,
				.Label = 1,
				.Description = "It better be the happiest place on earth - I could sure use a nice day with the kids."
			}
			Return appt

'====================================================================================================
'End of the allowed output for the Free Edition of Instant VB.

'To subscribe to the Premium Edition, visit our website:
'https://www.tangiblesoftwaresolutions.com/order/order-instant-vb.html
'====================================================================================================
