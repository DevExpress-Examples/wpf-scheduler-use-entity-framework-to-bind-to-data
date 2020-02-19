using System;
using System.Data.Entity;

namespace DXSample.Data {
    public class SchedulingContext : DbContext {
        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<ResourceEntity> Resources { get; set; }
    }

    public class AppointmentEntity {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int AppointmentType { get; set; }
        public string RecurrenceInfo { get; set; }
        public int ResourceId { get; set; }
        public int Label { get; set; }
    }
    public class ResourceEntity {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class SchedulingContextInitializer : DropCreateDatabaseIfModelChanges<SchedulingContext> {
        protected override void Seed(SchedulingContext context) {
            base.Seed(context);

            context.Resources.Add(DataHelper.Personal());
            context.Resources.Add(DataHelper.Education());
            context.Resources.Add(DataHelper.Work());

            context.Appointments.AddRange(DataHelper.Gym());
            context.Appointments.Add(DataHelper.Dentist());
            context.Appointments.Add(DataHelper.Dinner());
            context.Appointments.Add(DataHelper.Disneyland());
            context.Appointments.Add(DataHelper.RR());
            context.Appointments.Add(DataHelper.DayOff());
            context.Appointments.Add(DataHelper.SecondShift());
            context.Appointments.Add(DataHelper.ConferenceCompanyMeeting());
            context.Appointments.Add(DataHelper.ConferenceCustomerRetentionReview());
            context.Appointments.Add(DataHelper.ConferenceDatabaseAndWebsiteReview());
            context.Appointments.Add(DataHelper.ConferenceWeeklyMeeting());
            context.Appointments.Add(DataHelper.TrainingFrenchLesson());
            context.Appointments.Add(DataHelper.TrainingGermanLesson());
            context.Appointments.Add(DataHelper.TrainingTrainStaffOnNewRemoteControls());

            context.SaveChanges();
        }
    }
}
