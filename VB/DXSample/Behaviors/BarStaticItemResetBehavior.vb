Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Bars
Imports System
Imports System.Windows
Imports System.Windows.Threading

Namespace DXSample.Behaviors

    Public Class BarStaticItemResetBehavior
        Inherits Behavior(Of BarStaticItem)

        Private timer As DispatcherTimer

        Public Property Value As String
            Get
                Return CStr(GetValue(ValueProperty))
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
            AssociatedObject.SetValue(BarItem.ContentProperty, Nothing)
            timer.Stop()
        End Sub

        Protected Overrides Sub OnDetaching()
            timer.Stop()
            MyBase.OnDetaching()
        End Sub

        Private Shared Overloads Sub OnChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            Dim barStaticItemResetBehavior As BarStaticItemResetBehavior = TryCast(d, BarStaticItemResetBehavior)
            If barStaticItemResetBehavior.IsAttached Then
                barStaticItemResetBehavior.AssociatedObject.SetValue(BarItem.ContentProperty, e.NewValue)
                barStaticItemResetBehavior.timer.Start()
            End If
        End Sub
    End Class
End Namespace
