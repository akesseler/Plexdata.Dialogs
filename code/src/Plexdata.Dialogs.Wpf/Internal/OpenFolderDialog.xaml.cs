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

using Plexdata.Dialogs.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Plexdata.Dialogs.Internal
{
    /// <summary>
    /// Interaction logic for OpenFolderDialog.xaml
    /// </summary>
    /// <remarks>
    /// This class is intended to be used internally only.
    /// </remarks>
    public partial class OpenFolderDialog : Window
    {
        #region Private fields

        private DirectoryInfo initialFolder = null;

        #endregion

        #region Construction

        /// <summary>
        /// This constructor initialize a new instance of this class.
        /// </summary>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="folder">
        /// The directory information to be used as initial folder.
        /// </param>
        public OpenFolderDialog(Window owner, String message, String caption, DirectoryInfo folder)
            : base()
        {
            Mouse.OverrideCursor = Cursors.AppStarting;

            this.InitializeComponent();

            base.Owner = owner;
            base.WindowStartupLocation = (base.Owner is null) ? WindowStartupLocation.CenterScreen : WindowStartupLocation.CenterOwner;
            base.ShowInTaskbar = (base.Owner is null ? true : false);

            base.MinHeight = 450;
            base.MaxHeight = SystemParameters.WorkArea.Height;
            base.MinWidth = 450;
            base.MaxWidth = SystemParameters.WorkArea.Width;
            base.Height = 450;
            base.Width = 450;

            this.RootFolders = this.LoadRootFolders();
            this.Message = this.FixMessage(message);
            base.Title = this.FixCaption(caption);
            this.InitialFolder = folder;

            base.DataContext = this;

            this.folderTreeView.AddHandler(TreeViewItem.ExpandedEvent, new RoutedEventHandler(OnTreeViewItemExpanded));
            this.folderTreeView.AddHandler(TreeViewItem.CollapsedEvent, new RoutedEventHandler(OnTreeViewItemCollapsed));
            this.folderTreeView.SelectedItemChanged += this.OnTreeViewSelectedItemChanged;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the list of assigned root folders.
        /// </summary>
        /// <remarks>
        /// This property should not be used directly.
        /// </remarks>
        public ObservableCollection<FolderEntry> RootFolders
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the message's visibility state.
        /// </summary>
        /// <remarks>
        /// This property should not be used directly.
        /// </remarks>
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
        /// Gets and sets the message to be displayed.
        /// </summary>
        /// <remarks>
        /// This property should not be used directly.
        /// </remarks>
        public String Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the directory information of selected folder.
        /// </summary>
        /// <remarks>
        /// This property should not be used directly.
        /// </remarks>
        public DirectoryInfo SelectedFolder
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets and sets the directory information of initial folder.
        /// </summary>
        /// <remarks>
        /// This property should not be used directly.
        /// </remarks>
        public DirectoryInfo InitialFolder
        {
            get
            {
                return this.initialFolder;
            }
            set
            {
                if (this.initialFolder != value)
                {
                    this.initialFolder = value;

                    this.ExpandInitialPath();
                }
            }
        }

        #endregion

        #region Protected overrides

        /// <summary>
        /// Raises the content rendered event.
        /// </summary>
        /// <param name="args">
        /// The event arguments containing the event data.
        /// </param>
        protected override void OnContentRendered(EventArgs args)
        {
            base.OnContentRendered(args);

            Mouse.OverrideCursor = null;

            this.folderTreeView.Focus();
        }

        /// <summary>
        /// Raises the source initialized event.
        /// </summary>
        /// <param name="args">
        /// The event arguments containing the event data.
        /// </param>
        protected override void OnSourceInitialized(EventArgs args)
        {
            base.OnSourceInitialized(args);

            WindowButtonHelper.SetAdditionalButtons(this, true);
        }

        #endregion

        #region Event handlers

        private void OnTreeViewItemExpanded(Object sender, RoutedEventArgs args)
        {
            if (args.OriginalSource is TreeViewItem affected)
            {
                if (affected.Header is FolderEntry source)
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    try
                    {
                        source.IsExpanded = true;
                    }
                    catch (UnauthorizedAccessException exception)
                    {
                        Dialogs.DialogBox.Show(this, exception.Message, this.Title, DialogSymbol.Error);
                    }
                    catch (Exception exception)
                    {
                        System.Diagnostics.Debug.WriteLine(exception);
                    }
                    finally
                    {
                        args.Handled = true;
                        Mouse.OverrideCursor = null;
                    }
                }
            }
        }

        private void OnTreeViewItemCollapsed(Object sender, RoutedEventArgs args)
        {
            if (args.OriginalSource is TreeViewItem affected)
            {
                if (affected.Header is FolderEntry source)
                {
                    try
                    {
                        source.IsExpanded = false;
                    }
                    catch (Exception exception)
                    {
                        System.Diagnostics.Debug.WriteLine(exception);
                    }
                    finally
                    {
                        args.Handled = true;
                    }
                }
            }
        }

        private void OnTreeViewSelectedItemChanged(Object sender, RoutedPropertyChangedEventArgs<Object> args)
        {
            if (args.NewValue is FolderEntry affected)
            {
                this.SelectedFolder = affected.Folder;
            }
        }

        private void OnDialogButtonClick(Object sender, RoutedEventArgs args)
        {
            if (sender is Button button)
            {
                // An exception is thrown if window was shown 
                // using method Show() instead of ShowDialog().
                try { this.DialogResult = !button.IsCancel; } catch { }
            }

            this.Close();
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

        private ObservableCollection<FolderEntry> LoadRootFolders()
        {
            ObservableCollection<FolderEntry> result = new ObservableCollection<FolderEntry>();

            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        result.Add(new FolderEntry(drive));
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }

            return result;
        }

        private void ExpandInitialPath()
        {
            if (this.InitialFolder is null || !this.InitialFolder.Exists)
            {
                return;
            }

            this.ExpandInitialPath(this.InitialFolder.FullName.Split(Path.DirectorySeparatorChar).ToList(), this.RootFolders, null);
        }

        private void ExpandInitialPath(List<String> pieces, ObservableCollection<FolderEntry> children, FolderEntry parent)
        {
            if (pieces is null || !pieces.Any())
            {
                if (!(parent is null))
                {
                    parent.IsSelected = true;
                }

                return;
            }

            if (children is null || !children.Any())
            {
                return;
            }

            String piece = pieces[0];
            pieces.RemoveAt(0);

            foreach (FolderEntry child in children)
            {
                if (String.Equals(child.Folder.Name.TrimEnd(Path.DirectorySeparatorChar), piece, StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        child.IsExpanded = true;

                        if (!child.Children.Any())
                        {
                            child.IsSelected = true;
                            return;
                        }

                        this.ExpandInitialPath(pieces, child.Children, child);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        child.IsSelected = true;
                    }
                    catch (Exception exception)
                    {
                        System.Diagnostics.Debug.WriteLine(exception);
                    }
                }
            }
        }

        #endregion
    }
}
