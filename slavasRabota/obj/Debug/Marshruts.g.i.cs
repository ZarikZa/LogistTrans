﻿#pragma checksum "..\..\Marshruts.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1218BDB29755DCCB47441B90942E572A38F9E3F990C19BCF171DEB1763051DAD"
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
    /// Marshruts
    /// </summary>
    public partial class Marshruts : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MarshrutsDG;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox OrderCB;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OtprovlenieTbx;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DostavkaTbx;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProtiajennostTbx;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TransportCB;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusCB;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtm;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtm;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Marshruts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnullBtm;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Marshruts.xaml"
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
            System.Uri resourceLocater = new System.Uri("/slavasRabota;component/marshruts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Marshruts.xaml"
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
            this.MarshrutsDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\Marshruts.xaml"
            this.MarshrutsDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MarshrutsDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OrderCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.OtprovlenieTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DostavkaTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ProtiajennostTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TransportCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.StatusCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.AddBtm = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\Marshruts.xaml"
            this.AddBtm.Click += new System.Windows.RoutedEventHandler(this.AddBtm_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.EditBtm = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\Marshruts.xaml"
            this.EditBtm.Click += new System.Windows.RoutedEventHandler(this.EditBtm_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.bnullBtm = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\Marshruts.xaml"
            this.bnullBtm.Click += new System.Windows.RoutedEventHandler(this.bnullBtm_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.OtchetBtm = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\Marshruts.xaml"
            this.OtchetBtm.Click += new System.Windows.RoutedEventHandler(this.OtchetBtm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

