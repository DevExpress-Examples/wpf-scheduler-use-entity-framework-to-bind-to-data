Imports System.Data.Entity

Namespace EntityFrameworkCodeFirstBindingExample

    Partial Public Class MySchedulerModel
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=MySchedulerModelContext")
        End Sub

        Public Overridable Property Cars() As DbSet(Of Car)
        Public Overridable Property CarSchedulings() As DbSet(Of CarScheduling)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of Car)().Property(Function(e) e.Price).HasPrecision(19, 4)

            modelBuilder.Entity(Of CarScheduling)().Property(Function(e) e.Price).HasPrecision(10, 4)
        End Sub
    End Class
End Namespace
