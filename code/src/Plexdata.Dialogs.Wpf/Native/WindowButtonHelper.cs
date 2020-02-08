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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Plexdata.Dialogs.Native
{
    /// <summary>
    /// The static helper class to allow the modification of the window button 
    /// `Minimize` and `Maximize`.
    /// </summary>
    public static class WindowButtonHelper
    {
        #region Public methods

        /// <summary>
        /// Enables or disables the `Minimize` and `Maximize` buttons for provided 
        /// window.
        /// </summary>
        /// <param name="window">
        /// The window to modify those buttons for.
        /// </param>
        /// <param name="disabled">
        /// True to disable those buttons and false to enable them.
        /// </param>
        /// <returns>
        /// True it the Win32 API call was successful and false otherwise.
        /// </returns>
        public static Boolean SetAdditionalButtons(Window window, Boolean disabled)
        {
            if (window is null)
            {
                return false;
            }

            try
            {
                WindowInteropHelper helper = new WindowInteropHelper(window);
                return WindowButtonHelper.SetWindowStyleFlags(helper.Handle, disabled, WindowButtonHelper.WS_MINIMIZEBOX | WindowButtonHelper.WS_MAXIMIZEBOX);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Enables or disables the `Minimize` button for provided window.
        /// </summary>
        /// <param name="window">
        /// The window to modify this button for.
        /// </param>
        /// <param name="disabled">
        /// True to disable this button and false to enable it.
        /// </param>
        /// <returns>
        /// True it the Win32 API call was successful and false otherwise.
        /// </returns>
        public static Boolean SetMinimizeButton(Window window, Boolean disabled)
        {
            if (window is null)
            {
                return false;
            }

            try
            {
                WindowInteropHelper helper = new WindowInteropHelper(window);
                return WindowButtonHelper.SetWindowStyleFlags(helper.Handle, disabled, WindowButtonHelper.WS_MINIMIZEBOX);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return false;
            }
        }

        /// <summary>
        /// Enables or disables the `Maximize` button for provided window.
        /// </summary>
        /// <param name="window">
        /// The window to modify this button for.
        /// </param>
        /// <param name="disabled">
        /// True to disable this button and false to enable it.
        /// </param>
        /// <returns>
        /// True it the Win32 API call was successful and false otherwise.
        /// </returns>
        public static Boolean SetMaximizeButton(Window window, Boolean disabled)
        {
            if (window is null)
            {
                return false;
            }

            try
            {
                WindowInteropHelper helper = new WindowInteropHelper(window);
                return WindowButtonHelper.SetWindowStyleFlags(helper.Handle, disabled, WindowButtonHelper.WS_MAXIMIZEBOX);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return false;
            }
        }

        #endregion

        #region Private methods

        private static Boolean SetWindowStyleFlags(IntPtr handle, Boolean disabled, Int32 flags)
        {
            if (handle == IntPtr.Zero || handle == WindowButtonHelper.INVALID_HANDLE_VALUE)
            {
                return false;
            }

            Int32 style = WindowButtonHelper.GetWindowLongPtr(handle, WindowButtonHelper.GWL_STYLE).ToInt32();

            if (disabled)
            {
                style &= ~flags;
            }
            else
            {
                style |= flags;
            }

            return WindowButtonHelper.SetWindowLongPtr(handle, WindowButtonHelper.GWL_STYLE, new IntPtr(style)) != IntPtr.Zero;
        }

        #endregion

        #region Win32 stuff

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        private const Int32 GWL_STYLE = -16;

        private const Int32 WS_MAXIMIZEBOX = 0x00010000;

        private const Int32 WS_MINIMIZEBOX = 0x00020000;

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
        private extern static IntPtr GetWindowLongPtr(IntPtr hWnd, Int32 nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private extern static IntPtr SetWindowLongPtr(IntPtr hWnd, Int32 nIndex, IntPtr dwValue);

        #endregion
    }
}
