﻿#pragma checksum "..\..\..\Pages\Page2.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "847DB35D24787289AA2B997993C25DD92D4B4FD7C7C305C979CEAC16A25EA1AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using XMCLN;


namespace XMCLN {
    
    
    /// <summary>
    /// Page2
    /// </summary>
    public partial class Page2 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\Pages\Page2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Frame;
        
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
            System.Uri resourceLocater = new System.Uri("/XMCL;component/pages/page2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Page2.xaml"
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
            
            #line 18 "..\..\..\Pages\Page2.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SubPage1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\..\Pages\Page2.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TreeViewItem_PreviewMouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\..\Pages\Page2.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TreeViewItem_PreviewMouseUp_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 27 "..\..\..\Pages\Page2.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TreeViewItem_PreviewMouseUp_2);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Frame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

