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
using System.Windows;

namespace Plexdata.Dialogs
{
    /// <summary>
    /// The static class to allow a simple access to the exception dialog box.
    /// </summary>
    public static class ExceptionBox
    {
        /// <summary>
        /// Shows the exception dialog box with provided exception.
        /// </summary>
        /// <remarks>
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="exception">
        /// An exception instance to be assigned.
        /// </param>
        public static void Show(Exception exception)
        {
            ExceptionBox.Show(null, exception, null, null);
        }

        /// <summary>
        /// Shows the exception dialog box with provided exception.
        /// </summary>
        /// <remarks>
        /// The dialog box is centered within the owner's bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner window of this dialog box.
        /// </param>
        /// <param name="exception">
        /// An exception instance to be assigned.
        /// </param>
        public static void Show(Window owner, Exception exception)
        {
            ExceptionBox.Show(owner, exception, null, null);
        }

        /// <summary>
        /// Shows the exception dialog box with provided exception.
        /// </summary>
        /// <remarks>
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="exception">
        /// An exception instance to be assigned.
        /// </param>
        /// <param name="message">
        /// An additional message to be displayed.
        /// </param>
        public static void Show(Exception exception, String message)
        {
            ExceptionBox.Show(null, exception, message, null);
        }

        /// <summary>
        /// Shows the exception dialog box with provided exception.
        /// </summary>
        /// <remarks>
        /// The dialog box is centered within the owner's bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner window of this dialog box.
        /// </param>
        /// <param name="exception">
        /// An exception instance to be assigned.
        /// </param>
        /// <param name="message">
        /// An additional message to be displayed.
        /// </param>
        public static void Show(Window owner, Exception exception, String message)
        {
            ExceptionBox.Show(owner, exception, message, null);
        }

        /// <summary>
        /// Shows the exception dialog box with provided exception.
        /// </summary>
        /// <remarks>
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="exception">
        /// An exception instance to be assigned.
        /// </param>
        /// <param name="message">
        /// An additional message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The caption of the dialog box.
        /// </param>
        public static void Show(Exception exception, String message, String caption)
        {
            ExceptionBox.Show(null, exception, message, caption);
        }

        /// <summary>
        /// Shows the exception dialog box with provided exception.
        /// </summary>
        /// <remarks>
        /// The dialog box is centered within the owner's bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner window of this dialog box.
        /// </param>
        /// <param name="exception">
        /// An exception instance to be assigned.
        /// </param>
        /// <param name="message">
        /// An additional message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The caption of the dialog box.
        /// </param>
        public static void Show(Window owner, Exception exception, String message, String caption)
        {
            Internal.ExceptionBox dialog = new Internal.ExceptionBox(owner, exception, message, caption);
            dialog.ShowDialog();
        }
    }
}
