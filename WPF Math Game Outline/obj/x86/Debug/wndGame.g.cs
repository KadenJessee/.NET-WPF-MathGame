﻿#pragma checksum "..\..\..\wndGame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3768C9E2E0EAC993B24310FFF6AF7D5ADC4BDE17DF16EE94CDBAF8B07F544DC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WPF_Math_Game_Outline {
    
    
    /// <summary>
    /// wndGame
    /// </summary>
    public partial class wndGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGameHeader;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdEndGame;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGameEnded;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdFinalScore;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQuestion;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdBeginGame;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserGuess;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMyTimer;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdSubmitAnswer;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\wndGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRightWrong;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF Math Game Outline;component/wndgame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\wndGame.xaml"
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
            
            #line 4 "..\..\..\wndGame.xaml"
            ((WPF_Math_Game_Outline.wndGame)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblGameHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cmdEndGame = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\wndGame.xaml"
            this.cmdEndGame.Click += new System.Windows.RoutedEventHandler(this.cmdEndGame_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblGameEnded = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cmdFinalScore = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\wndGame.xaml"
            this.cmdFinalScore.Click += new System.Windows.RoutedEventHandler(this.cmdHighScores_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblQuestion = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cmdBeginGame = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\wndGame.xaml"
            this.cmdBeginGame.Click += new System.Windows.RoutedEventHandler(this.cmdBeginGame_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtUserGuess = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\wndGame.xaml"
            this.txtUserGuess.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtUserGuess_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lblMyTimer = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cmdSubmitAnswer = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\wndGame.xaml"
            this.cmdSubmitAnswer.Click += new System.Windows.RoutedEventHandler(this.cmdSubmitAnswer_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lblRightWrong = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

