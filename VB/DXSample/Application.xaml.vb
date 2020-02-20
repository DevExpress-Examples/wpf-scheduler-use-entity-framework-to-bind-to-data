Imports DevExpress.Internal
Imports DXSample.Data
Imports System.Data.Entity
Imports System.Windows

Namespace DXSample
	Partial Public Class App
		Inherits Application

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			DbEngineDetector.PatchConnectionStringsAndConfigureEntityFrameworkDefaultConnectionFactory()
			Database.SetInitializer(Of SchedulingContext)(New SchedulingContextInitializer())
			MyBase.OnStartup(e)
		End Sub
	End Class
End Namespace
