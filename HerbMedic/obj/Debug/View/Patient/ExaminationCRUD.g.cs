#pragma checksum "..\..\..\..\View\Patient\ExaminationCRUD.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F6B71A94BAB0DFED9BF5E9E45611F4ADED22C0B4D4BFE5BACB11D1B2AF69C917"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HerbMedic.View.Patient;
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


namespace HerbMedic.View.Patient {
    
    
    /// <summary>
    /// ExaminationCRUD
    /// </summary>
    public partial class ExaminationCRUD : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_username;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_examinations;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combobox1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Datepicker1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox2;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox3;
        
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
            System.Uri resourceLocater = new System.Uri("/HerbMedic;component/view/patient/examinationcrud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
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
            this.Textbox_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 16 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonGoBack);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dg_examinations = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.Textbox1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Textbox1.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocusTextbox);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Textbox1.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocusTextbox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Combobox1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Combobox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combobox1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Datepicker1 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.Textbox2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Textbox2.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocusTextbox);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Textbox2.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocusTextbox);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Textbox3 = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Textbox3.GotFocus += new System.Windows.RoutedEventHandler(this.OnGotFocusTextbox);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            this.Textbox3.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocusTextbox);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 38 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCreate);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 39 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonUpdate);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 40 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDelete);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 41 "..\..\..\..\View\Patient\ExaminationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonReadAll);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

