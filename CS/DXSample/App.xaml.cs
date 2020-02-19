using DevExpress.Internal;
using DXSample.Data;
using System.Data.Entity;
using System.Windows;

namespace DXSample {    
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            DbEngineDetector.PatchConnectionStringsAndConfigureEntityFrameworkDefaultConnectionFactory();
            Database.SetInitializer<SchedulingContext>(new SchedulingContextInitializer());
            base.OnStartup(e);
        }
    }
}
