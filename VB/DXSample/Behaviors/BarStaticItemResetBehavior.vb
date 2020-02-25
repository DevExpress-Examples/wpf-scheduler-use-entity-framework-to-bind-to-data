Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Bars
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Threading

Namespace DXSample.Behaviors
	Public Class BarStaticItemResetBehavior
		Inherits Behavior(Of BarStaticItem)

		Private timer As DispatcherTimer
		Public Property Value() As String
			Get
				Return DirectCast(GetValue(ValueProperty), String)
			End Get
			Set(ByVal value As String)
				SetValue(ValueProperty, value)
			End Set
		End Property
		Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(String), GetType(BarStaticItemResetBehavior), New PropertyMetadata(String.Empty, AddressOf OnChanged))
		Protected Overrides Sub OnAttached()
			timer = New DispatcherTimer()
			timer.Interval = TimeSpan.FromSeconds(5)
			AddHandler timer.Tick, AddressOf Timer_Tick
			MyBase.OnAttached()
		End Sub

		Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			AssociatedObject.SetValue(BarStaticItem.ContentProperty, Nothing)
			timer.Stop()
		End Sub
		Protected Overrides Sub OnDetaching()
			timer.Stop()
			MyBase.OnDetaching()
		End Sub
		Private Shared Overloads Sub OnChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
'INSTANT VB NOTE: The variable barStaticItemResetBehavior was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
			Dim barStaticItemResetBehavior_Conflict As BarStaticItemResetBehavior = (TryCast(d, BarStaticItemResetBehavior))
			If barStaticItemResetBehavior_Conflict.IsAttached Then
				barStaticItemResetBehavior_Conflict.AssociatedObject.SetValue(BarStaticItem.ContentProperty, e.NewValue)
				barStaticItemResetBehavior_Conflict.timer.Start()
			End If
		End Sub
	End Class
End Namespace
