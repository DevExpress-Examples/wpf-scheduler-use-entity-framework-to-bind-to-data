﻿#ExternalChecksum("..\..\MainWindow.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","A569EF858E9FE2198C20087BAA9762B9D8DB7FAE636F957A75D46C83D669B89A")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports DevExpress.Core
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.ConditionalFormatting
Imports DevExpress.Xpf.Core.DataSources
Imports DevExpress.Xpf.Core.Serialization
Imports DevExpress.Xpf.Core.ServerMode
Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Docking.Base
Imports DevExpress.Xpf.DXBinding
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Editors.DataPager
Imports DevExpress.Xpf.Editors.DateNavigator
Imports DevExpress.Xpf.Editors.ExpressionEditor
Imports DevExpress.Xpf.Editors.Filtering
Imports DevExpress.Xpf.Editors.Flyout
Imports DevExpress.Xpf.Editors.Popups
Imports DevExpress.Xpf.Editors.Popups.Calendar
Imports DevExpress.Xpf.Editors.RangeControl
Imports DevExpress.Xpf.Editors.Settings
Imports DevExpress.Xpf.Editors.Settings.Extension
Imports DevExpress.Xpf.Editors.Validation
Imports DevExpress.Xpf.LayoutControl
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Scheduling
Imports DevExpress.Xpf.Scheduling.Common
Imports DevExpress.Xpf.Scheduling.Editors
Imports DXSample.Views
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell

Namespace DXSample
    
    '''<summary>
    '''MainWindow
    '''</summary>
    <Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
    Partial Public Class MainWindow
        Inherits DevExpress.Xpf.Core.ThemedWindow
        Implements System.Windows.Markup.IComponentConnector
        
        
        #ExternalSource("..\..\MainWindow.xaml",25)
        <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
        Friend WithEvents view As DXSample.Views.SchedulingView
        
        #End ExternalSource
        
        Private _contentLoaded As Boolean
        
        '''<summary>
        '''InitializeComponent
        '''</summary>
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
        Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
            If _contentLoaded Then
                Return
            End If
            _contentLoaded = true
            Dim resourceLocater As System.Uri = New System.Uri("/DXSample;component/mainwindow.xaml", System.UriKind.Relative)
            
            #ExternalSource("..\..\MainWindow.xaml",1)
            System.Windows.Application.LoadComponent(Me, resourceLocater)
            
            #End ExternalSource
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
         System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
        Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
            If (connectionId = 1) Then
                Me.view = CType(target,DXSample.Views.SchedulingView)
                Return
            End If
            Me._contentLoaded = true
        End Sub
    End Class
End Namespace

