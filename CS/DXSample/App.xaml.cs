using System.Data.Entity;
using System.Windows;
using DXSample.Data;

namespace DXSample {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            Database.SetInitializer<SchedulingContext>(new SchedulingContextInitializer());            
            base.OnStartup(e);
        }
    }
}
