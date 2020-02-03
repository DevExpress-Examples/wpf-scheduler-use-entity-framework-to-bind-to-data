using System;
using System.Collections.Generic;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.Xml;

namespace DXSample.Data {
    public class DataHelper {
        #region Appointments
        static Random random { get; set; } = new Random();
        static DateTime Start { get; set; } = GetMonday(DateTime.Today);
        public static IEnumerable<AppointmentEntity> Gym() {
            DateTime start = Start.AddMonths(-1).AddHours(18);

            TimeSpan patternTimeOfDay = start.TimeOfDay;
            DateTime patternStartDate = DateTimeHelper.GetStartOfWeekUI(start.Date, DayOfWeek.Monday).Date;
            DateTime patternStart = patternStartDate + patternTimeOfDay;

            TimeSpan patternDuration = TimeSpan.FromHours(1.5);
            AppointmentEntity pattern = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Pattern,
                Start = patternStart,
                End = patternStart + patternDuration,
                Subject = "Gym",
                Label = 3,
                ResourceId = 1
            };

            RecurrenceInfo info = (RecurrenceInfo)RecurrenceBuilder.Weekly(patternStart).ByDay(WeekDays.Monday | WeekDays.Wednesday | WeekDays.Friday).Build();
            pattern.RecurrenceInfo = info.ToXml();
            DateTime weekStartDate = DateTimeHelper.GetStartOfWeekUI(Start.Date, DayOfWeek.Monday).Date;
            DateTime changedStart = weekStartDate + patternTimeOfDay + TimeSpan.FromHours(-1);
            int changedOccurrenceIndex = (weekStartDate - patternStartDate).Days / 7 * 3;
            if (changedOccurrenceIndex < 0)
                return new List<AppointmentEntity>(1) { pattern };

            AppointmentEntity changedOccurrence = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.ChangedOccurrence,
                Start = changedStart,
                End = changedStart + patternDuration,
                Subject = "Gym",
                Label = 3,
                ResourceId = 1
            };

            changedOccurrence.RecurrenceInfo = new PatternReferenceXmlPersistenceHelper(new PatternReference(info.Id, changedOccurrenceIndex)).ToXml();
            int deletedOccurrenceIndex = changedOccurrenceIndex + 1;
            DateTime deletedStart = weekStartDate + patternTimeOfDay + TimeSpan.FromDays(2);

            AppointmentEntity deletedOccurrence = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.DeletedOccurrence,
                Start = deletedStart,
                End = deletedStart + patternDuration,
                Subject = "Gym",
                Label = 3,
                ResourceId = 1
            };

            deletedOccurrence.RecurrenceInfo = new PatternReferenceXmlPersistenceHelper(new PatternReference(info.Id, deletedOccurrenceIndex)).ToXml();
            return new List<AppointmentEntity>(3) { pattern, changedOccurrence, deletedOccurrence };
        }
        public static AppointmentEntity Dentist() {
            DateTime start = Start.AddDays(3).AddHours(19);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = start,
                End = start.AddHours(1),
                Subject = "Dentist",
                Label = 1,
                ResourceId = 1
            };
            return appt;
        }
        public static AppointmentEntity Dinner() {
            DateTime start = Start.AddDays(1).AddHours(20);
            DateTime newStart = start.AddMinutes(random.Next(0, 4) * 15);
            DateTime newEnd = newStart.AddMinutes(random.Next(4, 8) * 20);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,                 
                Subject = "Family Dinner",
                Label = 3,
                ResourceId = 1
            };
            return appt;
        }
        public static AppointmentEntity Disneyland() {
            DateTime start = Start.AddDays(6);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddDays(1);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                Subject = "Disneyland",                
                ResourceId = 1,
                Label = 1,
                Description = "It better be the happiest place on earth - I could sure use a nice day with the kids.",
            };
            return appt;
        }
        public static AppointmentEntity RR() {
            DateTime start = Start.AddDays(6);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddDays(1);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                Subject = "R&R",                
                ResourceId = 3,
                Label = 3,
                Description = "Nothing to do but relax and enjoy the day with family. Need to take my foot off the gas pedal and enjoy the day.",
            };
            return appt;
        }
        public static AppointmentEntity DayOff() {
            DateTime start = Start;
            DateTime newStart = start;
            DateTime newEnd = newStart.AddDays(1);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 2,
                Label = 3,
                Subject = "Day off"
            };
            return appt;
        }
        public static AppointmentEntity SecondShift() {
            DateTime start = Start;
            DateTime newStart = start;
            DateTime newEnd = newStart.AddDays(5);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 3,
                Label = 2,
                Subject = "Second shift"
            };
            return appt;
        }
        public static AppointmentEntity ConferenceCompanyMeeting() {
            DateTime start = Start.AddDays(1).AddHours(10);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(1);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 3,
                Subject = "Company-wide meeting",
                Label = 1,
                Description = "Everyone must be ready to ask questions and inform leadership team why they are not performing as expected and what we need to do as a team to improve morale.",
            };
            return appt;
        }
        public static AppointmentEntity ConferenceCustomerRetentionReview() {
            DateTime start = Start.AddDays(2).AddHours(9);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(1);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 3,
                Subject = "Customer retention review",
                Label = 1,
                Description = "Discuss ways in which we can improve our relationship with customers and prove to them that we are the long term source for all their A/V needs.",
            };
            return appt;
        }
        public static AppointmentEntity ConferenceDatabaseAndWebsiteReview() {
            DateTime start = Start.AddDays(3).AddHours(9);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(3);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 3,
                Subject = "Database and website review",
                Label = 1,
                Description = "It's time to launch our new website. Management can no longer tolerate delays nor accept excuses. We've been waiting long enough for the overhaul.",
            };
            return appt;
        }
        public static AppointmentEntity ConferenceWeeklyMeeting() {
            DateTime start = Start.AddDays(4).AddHours(17);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(1);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 3,
                Label = 1,
                Subject = "Weekly meeting"
            };
            return appt;
        }
        public static AppointmentEntity TrainingFrenchLesson() {
            DateTime start = Start.AddDays(-7).AddHours(11).AddMinutes(10);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(1.5);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Pattern,
                Start = newStart,
                End = newEnd,
                ResourceId = 2,
                Subject = "French lesson",
                Label = 3,
                Description = "Another french lesson.Once again, without mastering French, our success on the Continent will be less likely.Everyone needs to learn French.",
            };
            appt.RecurrenceInfo = RecurrenceBuilder.Weekly(newStart, 10).ByDay(WeekDays.Monday | WeekDays.Wednesday).Build().ToXml();
            return appt;
        }
        public static AppointmentEntity TrainingGermanLesson() {
            DateTime start = Start.AddHours(15).AddMinutes(40);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(1.5);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Pattern,
                Start = newStart,
                End = newEnd,
                ResourceId = 2,
                Subject = "German lesson",
                Label = 3,
                Description = "We're learning French but we also need to become fluent in German. The German market for A/V products is huge. We need to be able to communicate in German if we are to have any luck in Germany."
            };
            appt.RecurrenceInfo = RecurrenceBuilder.Weekly(newStart, 10).ByDay(WeekDays.Tuesday | WeekDays.Friday).Build().ToXml();
            return appt;
        }
        public static AppointmentEntity TrainingTrainStaffOnNewRemoteControls() {
            DateTime start = Start.AddDays(3).AddHours(10).AddMinutes(10);
            DateTime newStart = start;
            DateTime newEnd = newStart.AddHours(1).AddMinutes(50);
            var appt = new AppointmentEntity() {
                AppointmentType = (int)AppointmentType.Normal,
                Start = newStart,
                End = newEnd,
                ResourceId = 3,
                Subject = "Train staff on new remote controls",
                Label = 2,
                Description = "Our newest remote controls are ready for production. Everyone needs to understand how our new universal remote works and our long term plans for better automation."
            };
            return appt;
        }
        public static DateTime GetMonday(DateTime date) {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Monday)
                return date.Date;
            if (dayOfWeek == DayOfWeek.Saturday)
                return date.Date.AddDays(2);
            if (dayOfWeek == DayOfWeek.Sunday)
                return date.Date.AddDays(1);
            return date.Date.AddDays(-((int)dayOfWeek - 1));
        }
        #endregion
        #region Resources
        public static ResourceEntity Personal() {
            return new ResourceEntity() { Description = "Personal", Id = 1 };
        }
        public static ResourceEntity Education() {
            return new ResourceEntity() { Description = "Education", Id = 2 };
        }
        public static ResourceEntity Work() {
            return new ResourceEntity() { Description = "Work", Id = 3 };
        }
        #endregion
    }
}
