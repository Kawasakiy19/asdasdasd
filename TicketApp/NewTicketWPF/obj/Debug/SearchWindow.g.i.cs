﻿#pragma checksum "..\..\SearchWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4DC7D0F3E5FC03A50E7236E09A5672A97C8EB8A45C7679AB1B687A26403C06F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NewTicketWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NewTicketWPF {
    
    
    /// <summary>
    /// SearchWindow
    /// </summary>
    public partial class SearchWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TicketId;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton AllPf;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ActualPf;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProfileBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProfileText;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\SearchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TicketApp;component/searchwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SearchWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TicketId = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\SearchWindow.xaml"
            this.TicketId.KeyDown += new System.Windows.Input.KeyEventHandler(this.TicketId_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AllPf = ((System.Windows.Controls.RadioButton)(target));
            
            #line 27 "..\..\SearchWindow.xaml"
            this.AllPf.Checked += new System.Windows.RoutedEventHandler(this.AllPf_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ActualPf = ((System.Windows.Controls.RadioButton)(target));
            
            #line 28 "..\..\SearchWindow.xaml"
            this.ActualPf.Checked += new System.Windows.RoutedEventHandler(this.AllPf_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ProfileBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\SearchWindow.xaml"
            this.ProfileBox.DropDownClosed += new System.EventHandler(this.ProfileBox_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProfileText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Search = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\SearchWindow.xaml"
            this.Search.Click += new System.Windows.RoutedEventHandler(this.SearchClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\SearchWindow.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.CancelClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
