﻿#pragma checksum "..\..\VoditeliOkno.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3038DAC83F14DA1BE234C090386A212C4B8CB27E43922DBEB329027875FDEB0"
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
    /// VoditeliOkno
    /// </summary>
    public partial class VoditeliOkno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\VoditeliOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBtm;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\VoditeliOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MarshrutsDG;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\VoditeliOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusCB;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\VoditeliOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtm;
        
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
            System.Uri resourceLocater = new System.Uri("/slavasRabota;component/voditeliokno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VoditeliOkno.xaml"
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
            this.ExitBtm = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\VoditeliOkno.xaml"
            this.ExitBtm.Click += new System.Windows.RoutedEventHandler(this.ExitBtm_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MarshrutsDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\VoditeliOkno.xaml"
            this.MarshrutsDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MarshrutsDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StatusCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.EditBtm = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\VoditeliOkno.xaml"
            this.EditBtm.Click += new System.Windows.RoutedEventHandler(this.EditBtm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

