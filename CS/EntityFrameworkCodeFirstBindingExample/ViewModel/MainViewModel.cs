using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Scheduling;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace EntityFrameworkCodeFirstBindingExample
{
    [POCOViewModel]
    public class MainViewModel {

        #region #instances
        MySchedulerModel mySchedulerContext;
        public virtual ObservableCollection<Car> Resources { get; set; }
        public virtual ObservableCollection<CarScheduling> Appointments { get; set; }
        #endregion #instances

        #region #savechanges
        public void AppointmentsUpdated()
        {
            mySchedulerContext.SaveChanges();
        }
        #endregion #savechanges

        #region #InitNewAppointment
        public void InitNewAppointment(AppointmentItemEventArgs args)
        {
            args.Appointment.Reminders.Clear();
        }
        #endregion #InitNewAppointment

        #region #filldata
        protected MainViewModel() {
            mySchedulerContext = new MySchedulerModel();
            mySchedulerContext.Cars.Load();
            Resources = mySchedulerContext.Cars.Local;
            mySchedulerContext.CarSchedulings.Load();
            Appointments = mySchedulerContext.CarSchedulings.Local;
        }
        #endregion #filldata
        public static MainViewModel Create() {
            return ViewModelSource.Create(() => new MainViewModel());
        }
    }
}
