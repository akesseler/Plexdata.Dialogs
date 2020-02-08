﻿/*
 * MIT License
 *
 * Copyright(c) 2020 plexdata.de
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Plexdata.Dialogs;
using System;
using System.IO;
using System.Windows;

namespace Plexdata.Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Privates

        private readonly String message = @"
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. This is a very long message. 
".Replace(Environment.NewLine, String.Empty);

        #endregion

        public MainWindow()
            : base()
        {
            this.InitializeComponent();
        }

        private void OnShowDialogBoxSimple(Object sender, RoutedEventArgs args)
        {
            DialogBox.Show(this, message);
        }

        private void OnShowDialogBoxOkCancel(Object sender, RoutedEventArgs args)
        {
            DialogBox.Show(this, message, DialogSymbol.Information, DialogButton.OkCancel);
        }

        private void OnShowDialogBoxOkCancelOkDefault(Object sender, RoutedEventArgs args)
        {
            DialogBox.Show(this, message, DialogSymbol.Warning, DialogButton.OkCancel, DialogOption.DefaultButtonOk);
        }

        private void OnShowDialogBoxYesNoCancel(Object sender, RoutedEventArgs args)
        {
            DialogBox.Show(this, message, DialogSymbol.Question, DialogButton.YesNoCancel);
        }

        private void OnShowDialogBoxYesNoCancelNoDefault(Object sender, RoutedEventArgs args)
        {
            DialogBox.Show(this, message, DialogSymbol.Error, DialogButton.YesNoCancel, DialogOption.DefaultButtonNo);
        }

        private void OnShowOpenFolderDialogSimple(Object sender, RoutedEventArgs args)
        {
            OpenFolderDialog.Show(this);
        }

        private void OnShowOpenFolderDialogMessage(Object sender, RoutedEventArgs args)
        {
            OpenFolderDialog.Show(this, this.message.Substring(0, this.message.Length / 3));
        }

        private void OnShowOpenFolderDialogFolder(Object sender, RoutedEventArgs args)
        {
            OpenFolderDialog.Show(this, new DirectoryInfo(@"C:\Users"));
        }

        private void OnShowOpenFolderDialogComplex(Object sender, RoutedEventArgs args)
        {
            OpenFolderDialog.Show(this, this.message.Substring(0, this.message.Length / 3), "Choose what ever you want!", new DirectoryInfo(@"C:\Users"));
        }
    }
}
