﻿#pragma checksum "..\..\TransportPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2AD32D67CEFEB6818910166E0F5C4C3947791CA21BF456D79941BE3387BD10BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using slavasRabota;


namespace slavasRabota {
    
    
    /// <summary>
    /// TransportPage
    /// </summary>
    public partial class TransportPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TransportDG;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CarNomberTbx;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox VoditelCB;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox VmestimostTbx;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SostoyanieCB;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtm;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtm;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtm;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnullBtm;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\TransportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OtchetBtm;
        
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
            System.Uri resourceLocater = new System.Uri("/slavasRabota;component/transportpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TransportPage.xaml"
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
            this.TransportDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\TransportPage.xaml"
            this.TransportDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TransportDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CarNomberTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.VoditelCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.VmestimostTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SostoyanieCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.AddBtm = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\TransportPage.xaml"
            this.AddBtm.Click += new System.Windows.RoutedEventHandler(this.AddBtm_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EditBtm = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\TransportPage.xaml"
            this.EditBtm.Click += new System.Windows.RoutedEventHandler(this.EditBtm_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DeleteBtm = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\TransportPage.xaml"
            this.DeleteBtm.Click += new System.Windows.RoutedEventHandler(this.DeleteBtm_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.bnullBtm = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\TransportPage.xaml"
            this.bnullBtm.Click += new System.Windows.RoutedEventHandler(this.bnullBtm_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.OtchetBtm = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\TransportPage.xaml"
            this.OtchetBtm.Click += new System.Windows.RoutedEventHandler(this.OtchetBtm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

