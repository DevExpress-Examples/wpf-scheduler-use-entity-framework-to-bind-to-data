namespace EntityFrameworkCodeFirstBindingExample
{
    using System.Data.Entity;

    public partial class MySchedulerModel : DbContext
    {
        public MySchedulerModel()
            : base("name=MySchedulerModelContext")  { }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarScheduling> CarSchedulings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CarScheduling>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);
        }
    }
}
