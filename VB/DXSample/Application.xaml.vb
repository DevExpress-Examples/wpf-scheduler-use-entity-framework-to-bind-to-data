Imports System.Data.Entity
Imports System.Windows
Imports DXSample.Data

Namespace DXSample
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			Database.SetInitializer(Of SchedulingContext)(New SchedulingContextInitializer())
			MyBase.OnStartup(e)
		End Sub
	End Class
End Namespace
