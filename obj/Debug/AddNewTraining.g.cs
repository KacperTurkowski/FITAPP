﻿#pragma checksum "..\..\AddNewTraining.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0A2BC0FFCFE1D7D128ECF8ABCD33F3318C4ACFA3D4923051D958D26C598C5248"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using FITAPP;
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


namespace FITAPP {
    
    
    /// <summary>
    /// AddNewTraining
    /// </summary>
    public partial class AddNewTraining : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwa_treningu;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl lista_cwiczen;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox opis_treningu;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox wybierz_tag;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodaj_tag;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel tagi;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodaj_trening;
        
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
            System.Uri resourceLocater = new System.Uri("/FITAPP;component/addnewtraining.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddNewTraining.xaml"
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
            
            #line 8 "..\..\AddNewTraining.xaml"
            ((FITAPP.AddNewTraining)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nazwa_treningu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lista_cwiczen = ((System.Windows.Controls.TabControl)(target));
            return;
            case 4:
            this.opis_treningu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.wybierz_tag = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.dodaj_tag = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\AddNewTraining.xaml"
            this.dodaj_tag.Click += new System.Windows.RoutedEventHandler(this.dodaj_tag_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tagi = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 8:
            this.dodaj_trening = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\AddNewTraining.xaml"
            this.dodaj_trening.Click += new System.Windows.RoutedEventHandler(this.dodaj_trening_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

