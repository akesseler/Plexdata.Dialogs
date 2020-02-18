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

using Plexdata.Dialogs.Internal.Models;
using Plexdata.Dialogs.Native;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Plexdata.Dialogs.Internal.Widgets
{
    internal partial class ExceptionBox : Window
    {
        // TODO: Implement some kind of "copy to clipboard" functionality.

        #region Construction

        internal ExceptionBox(Window owner, Exception exception, String message, String caption)
        {
            this.InitializeComponent();

            base.Owner = owner;
            base.WindowStartupLocation = (base.Owner is null) ? WindowStartupLocation.CenterScreen : WindowStartupLocation.CenterOwner;
            base.ShowInTaskbar = (base.Owner is null ? true : false);

            base.MinHeight = 450;
            base.MaxHeight = SystemParameters.WorkArea.Height;
            base.MinWidth = 450;
            base.MaxWidth = SystemParameters.WorkArea.Width;
            base.Height = 450;
            base.Width = 800;

            this.Message = this.FixMessage(message);
            this.Exception = exception;
            base.Title = this.FixCaption(caption);

            base.DataContext = this;
            this.treeView.ItemsSource = new ObservableCollection<ExceptionEntry>(ExceptionEntry.FromException(this.Exception));
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the visibility state of the additional dialog box message.
        /// </summary>
        public Visibility IsMessageVisible
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.Message))
                {
                    return Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
        }

        /// <summary>
        /// Gets the additional dialog box message to be displayed.
        /// </summary>
        public String Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the exception instance assigned to this dialog box.
        /// </summary>
        public Exception Exception
        {
            get;
            private set;
        }

        #endregion

        #region Protected overrides

        /// <summary>
        /// Raises the Source Initialized event.
        /// </summary>
        /// <param name="args">
        /// An An instance of class `EventArgs` containing event data.
        /// </param>
        protected override void OnSourceInitialized(EventArgs args)
        {
            base.OnSourceInitialized(args);

            WindowButtonHelper.SetAdditionalButtons(this, true);
        }

        #endregion

        #region Event handlers

        private void OnCloseButtonClick(Object sender, RoutedEventArgs args)
        {
            base.Close();
        }

        #endregion

        #region Private methods

        private String FixMessage(String message)
        {
            return (message ?? String.Empty).Trim();
        }

        private String FixCaption(String caption)
        {
            if (String.IsNullOrWhiteSpace(caption))
            {
                caption = base.Title;
            }

            return (caption ?? String.Empty).Trim();
        }

        #endregion
    }
}
