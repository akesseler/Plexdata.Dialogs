/*
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

using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Plexdata.Dialogs
{
    /// <summary>
    /// The static class to allow a simple access to the open folder dialog.
    /// </summary>
    public static class OpenFolderDialog
    {
        /// <summary>
        /// Just shows the open folder dialog with default settings.
        /// </summary>
        /// <remarks>
        /// No additional message is shown, the initial folder is not set and 
        /// the dialog caption is set to `Open Folder`. Furthermore, the dialog 
        /// window is centered on screen.
        /// </remarks>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show()
        {
            return OpenFolderDialog.Show(null, null, null, null);
        }

        /// <summary>
        /// Just shows the open folder dialog with default settings.
        /// </summary>
        /// <remarks>
        /// No additional message is shown, the initial folder is not set and 
        /// the dialog caption is set to `Open Folder`. Furthermore, the dialog 
        /// window is centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(Window owner)
        {
            return OpenFolderDialog.Show(owner, null, null, null);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/>.
        /// </summary>
        /// <remarks>
        /// The initial folder is not set and the dialog caption is set to `Open Folder`. 
        /// Furthermore, the dialog window is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(String message)
        {
            return OpenFolderDialog.Show(null, message, null, null);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/>.
        /// </summary>
        /// <remarks>
        /// The initial folder is not set and the dialog caption is set to `Open Folder`. 
        /// Furthermore, the dialog window is centered within the <paramref name="owner"/>'s 
        /// bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(Window owner, String message)
        {
            return OpenFolderDialog.Show(owner, message, null, null);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/> 
        /// as well as provided <paramref name="caption"/>.
        /// </summary>
        /// <remarks>
        /// The initial folder is not set. Furthermore, the dialog window is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(String message, String caption)
        {
            return OpenFolderDialog.Show(null, message, caption, null);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/> 
        /// as well as provided <paramref name="caption"/>.
        /// </summary>
        /// <remarks>
        /// The initial folder is not set. Furthermore, the dialog window is centered within 
        /// the <paramref name="owner"/>'s 
        /// bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(Window owner, String message, String caption)
        {
            return OpenFolderDialog.Show(owner, message, caption, null);
        }

        /// <summary>
        /// Shows the open folder dialog and pre-selects provided <paramref name="folder"/>.
        /// </summary>
        /// <remarks>
        /// No additional message is shown and the dialog caption is set to `Open Folder`. 
        /// Furthermore, the dialog window is centered on screen.
        /// </remarks>
        /// <param name="folder">
        /// The directory information to be used as initial folder.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(DirectoryInfo folder)
        {
            return OpenFolderDialog.Show(null, null, null, folder);
        }

        /// <summary>
        /// Shows the open folder dialog and pre-selects provided <paramref name="folder"/>.
        /// </summary>
        /// <remarks>
        /// No additional message is shown and the dialog caption is set to `Open Folder`. 
        /// Furthermore, the dialog window is centered within the <paramref name="owner"/>'s 
        /// bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="folder">
        /// The directory information to be used as initial folder.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(Window owner, DirectoryInfo folder)
        {
            return OpenFolderDialog.Show(owner, null, null, folder);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/> 
        /// as well as pre-selects provided <paramref name="folder"/>.
        /// </summary>
        /// <remarks>
        /// The dialog caption is set to `Open Folder`. Furthermore, the dialog window is 
        /// centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="folder">
        /// The directory information to be used as initial folder.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(String message, DirectoryInfo folder)
        {
            return OpenFolderDialog.Show(null, message, null, folder);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/> 
        /// as well as pre-selects provided <paramref name="folder"/>.
        /// </summary>
        /// <remarks>
        /// The dialog caption is set to `Open Folder`. Furthermore, the dialog window is 
        /// centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="folder">
        /// The directory information to be used as initial folder.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(Window owner, String message, DirectoryInfo folder)
        {
            return OpenFolderDialog.Show(owner, message, null, folder);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/> 
        /// as well as provided <paramref name="caption"/> as well as pre-selects provided 
        /// <paramref name="folder"/>.
        /// </summary>
        /// <remarks>
        /// The dialog window is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="folder">
        /// The directory information to be used as initial folder.
        /// </param>
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(String message, String caption, DirectoryInfo folder)
        {
            return OpenFolderDialog.Show(null, message, caption, folder);
        }

        /// <summary>
        /// Shows the open folder dialog using provided additional <paramref name="message"/> 
        /// as well as provided <paramref name="caption"/> as well as pre-selects provided 
        /// <paramref name="folder"/>.
        /// </summary>
        /// <remarks>
        /// The dialog window is centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
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
        /// <returns>
        /// The information of selected directory or null in case of cancellation.
        /// </returns>
        public static DirectoryInfo Show(Window owner, String message, String caption, DirectoryInfo folder)
        {
            Mouse.OverrideCursor = null;

            Internal.OpenFolderDialog dialog = new Internal.OpenFolderDialog(owner, message, caption, folder);

            if (dialog.ShowDialog() == true)
            {
                return dialog.SelectedFolder;
            }

            return null;
        }
    }
}
