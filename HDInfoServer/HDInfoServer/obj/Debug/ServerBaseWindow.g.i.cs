﻿#pragma checksum "..\..\ServerBaseWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4331C080FF14521E8F5F4A25D4CD6600"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using NikitaServer;
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


namespace HDInfoServer {
    
    
    /// <summary>
    /// ServerBaseWindow
    /// </summary>
    public partial class ServerBaseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\ServerBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CompRoomLabel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ServerBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CompNameLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ServerBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ComputersListView;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ServerBaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboRoomBox;
        
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
            System.Uri resourceLocater = new System.Uri("/NikitaServer;component/serverbasewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ServerBaseWindow.xaml"
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
            
            #line 7 "..\..\ServerBaseWindow.xaml"
            ((HDInfoServer.ServerBaseWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.App_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\ServerBaseWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ServerConfig_btn);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\ServerBaseWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Btn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CompRoomLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.CompNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ComputersListView = ((System.Windows.Controls.ListView)(target));
            
            #line 24 "..\..\ServerBaseWindow.xaml"
            this.ComputersListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComputerSelected);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ComboRoomBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\ServerBaseWindow.xaml"
            this.ComboRoomBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboRoomBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

