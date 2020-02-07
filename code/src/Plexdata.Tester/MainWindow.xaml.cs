/*
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
using System.Windows;

namespace Plexdata.Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnShowMessageDialog(Object sender, RoutedEventArgs args)
        {
            String message = @"
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

            //DialogBox.Show(this, message, DialogButton.YesNoCancel | DialogButton.OkClose);
            //DialogBox.Show(this, message, DialogButton.OkClose);
            //DialogBox.Show(this, message, DialogButton.YesNoCancel);
            //DialogBox.Show(this, message, DialogButton.YesNo);



            //DialogBox.Show(this, message, DialogButton.Ok | DialogButton.No);
            //DialogBox.Show(this, message, DialogButton.Ok | DialogButton.No | DialogButton.Yes, new DialogOption(DialogButton.Ok, "  _Heimer_ ", false), new DialogOption(DialogButton.No, false), new DialogOption(DialogButton.Yes, true));
            DialogBox.Show(this, message, DialogSymbol.Exclamation, DialogButton.Ok | /*DialogButton.No | */DialogButton.Yes, DialogOption.DefaultButtonYes, DialogOption.DefaultButtonNo);
        }

        private void OnShowOpenFolderDialog(Object sender, RoutedEventArgs args)
        {
            OpenFolderDialog dialog = new OpenFolderDialog(this)
            {
                Message = "This is a pretty long message. This is a pretty long message. This is a pretty long message. This is a pretty long message. This is a pretty long message.",
                InitialPath = @"C:\Users"
            };

            if (dialog.ShowDialog() == true)
            {
                DialogBox.Show(this, dialog.SelectedFolder.FullName);
            }
        }
    }
}
