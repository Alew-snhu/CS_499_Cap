﻿#pragma checksum "..\..\..\..\View\UpdateOrDeleteHabitat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D51F278B3656BCA5882411E161D0DDF4E6604B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AnimalMonitoringSystem1.View;
using AnimalMonitoringSystem1.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AnimalMonitoringSystem1.View {
    
    
    /// <summary>
    /// UpdateOrDeleteHabitat
    /// </summary>
    public partial class UpdateOrDeleteHabitat : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox HabitatsFromDbList;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HabitatType;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HabTemp;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FoodSrc;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Clean;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AnimalMonitoringSystem1;component/view/updateordeletehabitat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.HabitatsFromDbList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.HabitatType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.HabTemp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.FoodSrc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Clean = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 34 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_GoBack);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 35 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_UpdateRecords);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 36 "..\..\..\..\View\UpdateOrDeleteHabitat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_DeleteRecord);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
