﻿#pragma checksum "..\..\..\..\View\UpdateOrDeleteAnimal.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33E334D32CCB1FDB83EA3D8E977EEA0745B18622"
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
    /// UpdateOrDeleteAnimal
    /// </summary>
    public partial class UpdateOrDeleteAnimal : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AnimalsFromDbList;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnimalType;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnimalName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnimalAge;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Health;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Feed;
        
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
            System.Uri resourceLocater = new System.Uri("/AnimalMonitoringSystem1;component/view/updateordeleteanimal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
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
            this.AnimalsFromDbList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.AnimalType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AnimalName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AnimalAge = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Health = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Feed = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 33 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_GoBack);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 34 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Update_Record);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 35 "..\..\..\..\View\UpdateOrDeleteAnimal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Delete_Record);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

