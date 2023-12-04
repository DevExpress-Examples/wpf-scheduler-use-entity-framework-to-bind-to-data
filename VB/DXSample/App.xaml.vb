Imports DevExpress.Internal
Imports DXSample.Data
Imports System.Data.Entity
Imports System.Windows

Namespace DXSample

    Public Partial Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            Call DbEngineDetector.PatchConnectionStringsAndConfigureEntityFrameworkDefaultConnectionFactory()
            Call Database.SetInitializer(New SchedulingContextInitializer())
            MyBase.OnStartup(e)
        End Sub
    End Class
End Namespace
