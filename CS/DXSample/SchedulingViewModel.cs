using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;
using DevExpress.Mvvm;
using DXSample.Data;

namespace DXSample {
    public class SchedulingViewModel : ViewModelBase {        
        SchedulingContext context;
        public ObservableCollection<AppointmentEntity> Appts { get { return context.Appointments.Local; } }
        public ObservableCollection<ResourceEntity> Calendars { get { return context.Resources.Local; } }
        public string Status {
            get { return GetValue<string>(); }
            set { SetValue(value); }

        }               
        public SchedulingViewModel() {
            context = new SchedulingContext();
            context.Appointments.Load();
            context.Resources.Load();
        }
        public ICommand SaveCommand {
            get {
                return new DelegateCommand(() => {
                    context.SaveChanges();
                    Status = $"Changes are saved to database. {DateTime.Now.ToLongTimeString()}.";
                });
            }
        }
    }
}
