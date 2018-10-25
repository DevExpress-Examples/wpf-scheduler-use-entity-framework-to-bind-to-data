namespace EntityFrameworkCodeFirstBindingExample
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CarScheduling")]
    public partial class CarScheduling
    {
        public int ID { get; set; }

        public int? CarId { get; set; }

        public int? UserId { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        public string Description { get; set; }

        public int? Label { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public bool AllDay { get; set; }

        public int? EventType { get; set; }

        public string RecurrenceInfo { get; set; }

        public string ReminderInfo { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }

        public string ContactInfo { get; set; }
    }
}
