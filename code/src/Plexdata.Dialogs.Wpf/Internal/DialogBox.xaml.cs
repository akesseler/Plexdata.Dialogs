﻿/*
 * MIT License
 * 
 * Copyright (c) 2020 plexdata.de
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

using Plexdata.Dialogs.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Plexdata.Dialogs.Internal
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        #region Private fields

        private readonly IDictionary<DialogButton, String> labels;

        #endregion

        #region Construction

        public DialogBox(Window owner, String message, String caption, DialogButton buttons, DialogSymbol symbol, DialogOption[] options)
        {
            base.MinHeight = 180;
            base.MaxHeight = SystemParameters.WorkArea.Height;
            base.MinWidth = 550; // Don't change! Otherwise the link is covered by buttons if all of them are visible.
            base.MaxWidth = 800;
            base.Height = 180;
            base.Width = 550;

            this.Message = this.FixMessage(message);
            base.Title = this.FixCaption(owner, caption);
            this.Symbol = this.GetSymbol(symbol);
            this.Buttons = buttons;
            this.Result = Dialogs.DialogResult.None;

            this.labels = DefaultButtonLabels.CreateLabels();

            this.ApplyOptions(options);
            this.ApplyDefaults(options);

            this.InitializeComponent();

            base.Owner = owner;
            base.WindowStartupLocation = (base.Owner is null) ? WindowStartupLocation.CenterScreen : WindowStartupLocation.CenterOwner;
            base.ShowInTaskbar = (base.Owner is null ? true : false);

            base.DataContext = this;
        }

        #endregion

        #region Public properties

        public String Message
        {
            get;
            private set;
        }

        public DialogButton Buttons
        {
            get;
            private set;
        }

        public BitmapSource Symbol
        {
            get;
            private set;
        }

        public DialogResult Result
        {
            get;
            private set;
        }

        #endregion

        #region Symbol Visibility

        public Visibility SymbolVisibility
        {
            get
            {
                if (this.Symbol is null)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
        }

        #endregion

        #region Button visibility

        public Visibility OkButtonVisibility
        {
            get
            {
                if ((this.Buttons & DialogButton.Ok) == DialogButton.Ok)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        public Visibility CloseButtonVisibility
        {
            get
            {
                if ((this.Buttons & DialogButton.Close) == DialogButton.Close)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        public Visibility CancelButtonVisibility
        {
            get
            {
                if ((this.Buttons & DialogButton.Cancel) == DialogButton.Cancel)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        public Visibility YesButtonVisibility
        {
            get
            {
                if ((this.Buttons & DialogButton.Yes) == DialogButton.Yes)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        public Visibility NoButtonVisibility
        {
            get
            {
                if ((this.Buttons & DialogButton.No) == DialogButton.No)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        #endregion

        #region Button labels

        public String OkButtonLabel
        {
            get
            {
                return this.labels[DialogButton.Ok];
            }
        }

        public String CloseButtonLabel
        {
            get
            {
                return this.labels[DialogButton.Close];
            }
        }

        public String CancelButtonLabel
        {
            get
            {
                return this.labels[DialogButton.Cancel];
            }
        }

        public String YesButtonLabel
        {
            get
            {
                return this.labels[DialogButton.Yes];
            }
        }

        public String NoButtonLabel
        {
            get
            {
                return this.labels[DialogButton.No];
            }
        }

        #endregion

        #region Button defaults

        public Boolean OkButtonDefault
        {
            get;
            private set;
        }

        public Boolean CloseButtonDefault
        {
            get;
            private set;
        }

        public Boolean CancelButtonDefault
        {
            get;
            private set;
        }

        public Boolean YesButtonDefault
        {
            get;
            private set;
        }

        public Boolean NoButtonDefault
        {
            get;
            private set;
        }

        #endregion

        #region Link labels

        public String CopyClipboardLabel
        {
            get
            {
                return "Copy to Clipboard";
            }

        }

        #endregion

        #region Protected overrides

        protected override void OnSourceInitialized(EventArgs args)
        {
            base.OnSourceInitialized(args);

            WindowButtonHelper.SetAdditionalButtons(this, true);
        }

        #endregion

        #region Event handlers

        private void OnOkButtonClick(Object sender, RoutedEventArgs args)
        {
            this.HandleClosing(Dialogs.DialogResult.OK);
        }

        private void OnCloseButtonClick(Object sender, RoutedEventArgs args)
        {
            this.HandleClosing(Dialogs.DialogResult.Close);
        }

        private void OnCancelButtonClick(Object sender, RoutedEventArgs args)
        {
            this.HandleClosing(Dialogs.DialogResult.Cancel);
        }

        private void OnYesButtonClick(Object sender, RoutedEventArgs args)
        {
            this.HandleClosing(Dialogs.DialogResult.Yes);
        }

        private void OnNoButtonClick(Object sender, RoutedEventArgs args)
        {
            this.HandleClosing(Dialogs.DialogResult.No);
        }

        private void OnCopyClipboardClick(Object sender, RoutedEventArgs args)
        {
            try
            {
                Clipboard.SetText(this.Message);
            }
            catch { }
        }

        #endregion

        #region Private methods

        private String FixMessage(String message)
        {
            return (message ?? String.Empty).Trim();
        }

        private String FixCaption(Window owner, String caption)
        {
            if (String.IsNullOrWhiteSpace(caption) && !(owner is null))
            {
                try
                {
                    caption = owner.Title;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception);
                }
            }

            return (caption ?? String.Empty).Trim();
        }

        private void HandleClosing(Dialogs.DialogResult result)
        {
            this.Hide();
            this.Result = result;
            this.Close();
        }

        private BitmapSource GetSymbol(DialogSymbol symbol)
        {
            IntPtr handle;

            switch (symbol)
            {
                case DialogSymbol.Application:
                    handle = SystemIcons.Application.Handle;
                    break;
                case DialogSymbol.Asterisk:
                    handle = SystemIcons.Asterisk.Handle;
                    break;
                case DialogSymbol.Error:
                    handle = SystemIcons.Error.Handle;
                    break;
                case DialogSymbol.Exclamation:
                    handle = SystemIcons.Exclamation.Handle;
                    break;
                case DialogSymbol.Hand:
                    handle = SystemIcons.Hand.Handle;
                    break;
                case DialogSymbol.Information:
                    handle = SystemIcons.Information.Handle;
                    break;
                case DialogSymbol.Question:
                    handle = SystemIcons.Question.Handle;
                    break;
                case DialogSymbol.Shield:
                    handle = SystemIcons.Shield.Handle;
                    break;
                case DialogSymbol.Warning:
                    handle = SystemIcons.Warning.Handle;
                    break;
                case DialogSymbol.WinLogo:
                    handle = SystemIcons.WinLogo.Handle;
                    break;
                default:
                    return null;
            }

            return Imaging.CreateBitmapSourceFromHIcon(handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void ApplyOptions(DialogOption[] options)
        {
            if (options is null || options.Length < 1)
            {
                return;
            }

            foreach (DialogOption option in options)
            {
                if (!DefaultButtonLabels.IsDefaultButtonLabel(option.Button, option.Label))
                {
                    this.labels[option.Button] = option.Label;
                }
            }
        }

        private void ApplyDefaults(DialogOption[] options)
        {
            this.OkButtonDefault = false;
            this.CloseButtonDefault = false;
            this.CancelButtonDefault = false;
            this.YesButtonDefault = false;
            this.NoButtonDefault = false;

            if (options is null || options.Length < 1)
            {
                switch (this.Buttons)
                {
                    case DialogButton.OkCancel:
                    case DialogButton.YesNoCancel:
                        this.CancelButtonDefault = true;
                        return;
                    case DialogButton.OkClose:
                        this.CloseButtonDefault = true;
                        return;
                    case DialogButton.YesNo:
                        this.NoButtonDefault = true;
                        return;
                }

                if (this.Buttons.HasFlag(DialogButton.Cancel))
                {
                    this.CancelButtonDefault = true;
                    return;
                }

                if (this.Buttons.HasFlag(DialogButton.Close))
                {
                    this.CloseButtonDefault = true;
                    return;
                }

                if (this.Buttons.HasFlag(DialogButton.No))
                {
                    this.NoButtonDefault = true;
                    return;
                }

                return;
            }

            DialogOption option = options.Where(x => x.IsDefault).FirstOrDefault();

            if (option is null)
            {
                return;
            }

            switch (option.Button)
            {
                case DialogButton.Ok:
                    this.OkButtonDefault = true;
                    return;
                case DialogButton.Yes:
                    this.YesButtonDefault = true;
                    return;
                case DialogButton.No:
                    this.NoButtonDefault = true;
                    return;
                case DialogButton.Close:
                    this.CloseButtonDefault = true;
                    return;
                case DialogButton.Cancel:
                    this.CancelButtonDefault = true;
                    return;
            }
        }

        #endregion
    }
}
