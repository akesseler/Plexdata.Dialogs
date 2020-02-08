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
using System.Windows.Input;

namespace Plexdata.Dialogs
{
    /// <summary>
    /// The static class to allow a simple access to the dialog box.
    /// </summary>
    public static class DialogBox
    {
        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>.
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message)
        {
            return DialogBox.Show((Window)null, message);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>.
        /// The dialog box is centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message)
        {
            return DialogBox.Show(owner, message, null);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="symbol"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="symbol"/>.
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, DialogSymbol symbol)
        {
            return DialogBox.Show((Window)null, message, symbol);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="symbol"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="symbol"/>.
        /// The dialog box is centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, DialogSymbol symbol)
        {
            return DialogBox.Show(owner, message, owner?.Title, symbol, DialogButton.Close);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="caption"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="caption"/>.
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, String caption)
        {
            return DialogBox.Show(null, message, caption);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="caption"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="caption"/>.
        /// The dialog box is centered within the <paramref name="owner"/>'s bounds.
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
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, String caption)
        {
            return DialogBox.Show(owner, message, caption, DialogSymbol.None);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="caption"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="caption"/>. The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, String caption, DialogSymbol symbol)
        {
            return DialogBox.Show(null, message, caption, symbol);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="caption"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="caption"/>. The dialog box is centered within the <paramref name="owner"/>'s bounds.
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
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, String caption, DialogSymbol symbol)
        {
            return DialogBox.Show(owner, message, caption, symbol, DialogButton.Close);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>. 
        /// The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, DialogButton buttons)
        {
            return DialogBox.Show((Window)null, message, buttons);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>. 
        /// The dialog box is centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, DialogButton buttons)
        {
            return DialogBox.Show(owner, message, owner?.Title, DialogSymbol.None, buttons);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>,
        /// as well as applying provided <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>,
        /// as well as applying provided <paramref name="options"/>. The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show((Window)null, message, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>,
        /// as well as applying provided <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/> and <paramref name="buttons"/>,
        /// as well as applying provided <paramref name="options"/>. The dialog box is centered within the 
        /// <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show(owner, message, owner?.Title, DialogSymbol.None, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>. The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, String caption, DialogButton buttons)
        {
            return DialogBox.Show(null, message, caption, DialogSymbol.None, buttons, null);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>. The dialog box is centered within the <paramref name="owner"/>'s bounds.
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
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, String caption, DialogButton buttons)
        {
            return DialogBox.Show(owner, message, caption, DialogSymbol.None, buttons, null);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>. The dialog box 
        /// is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, String caption, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show(null, message, caption, DialogSymbol.None, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>. The dialog box 
        /// is centered within the <paramref name="owner"/>'s bounds.
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
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, String caption, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show(owner, message, caption, DialogSymbol.None, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/> and <paramref name="buttons"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/> and <paramref name="buttons"/>. The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, String caption, DialogSymbol symbol, DialogButton buttons)
        {
            return DialogBox.Show(null, message, caption, symbol, buttons, null);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/> and <paramref name="buttons"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/> and <paramref name="buttons"/>. The dialog box is centered within the 
        /// <paramref name="owner"/>'s bounds.
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
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, String caption, DialogSymbol symbol, DialogButton buttons)
        {
            return DialogBox.Show(owner, message, caption, symbol, buttons, null);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>. The dialog box 
        /// is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, DialogSymbol symbol, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show((Window)null, message, symbol, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="symbol"/> 
        /// and <paramref name="buttons"/>, as well as applying provided <paramref name="options"/>. The dialog box 
        /// is centered within the <paramref name="owner"/>'s bounds.
        /// </remarks>
        /// <param name="owner">
        /// The owner of the dialog box.
        /// </param>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, DialogSymbol symbol, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show(owner, message, owner?.Title, symbol, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/>, and <paramref name="buttons"/>, as well as applying provided 
        /// <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/>, and <paramref name="buttons"/>, as well as applying provided 
        /// <paramref name="options"/>. The dialog box is centered on screen.
        /// </remarks>
        /// <param name="message">
        /// The message to be displayed.
        /// </param>
        /// <param name="caption">
        /// The dialog box caption to be used.
        /// </param>
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(String message, String caption, DialogSymbol symbol, DialogButton buttons, params DialogOption[] options)
        {
            return DialogBox.Show(null, message, caption, symbol, buttons, options);
        }

        /// <summary>
        /// Shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/>, and <paramref name="buttons"/>, as well as applying provided 
        /// <paramref name="options"/>.
        /// </summary>
        /// <remarks>
        /// This method shows the dialog box using provided <paramref name="message"/>, <paramref name="caption"/>, 
        /// <paramref name="symbol"/>, and <paramref name="buttons"/>, as well as applying provided 
        /// <paramref name="options"/>. The dialog box is centered within the <paramref name="owner"/>'s bounds.
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
        /// <param name="symbol">
        /// The dialog box symbol to be shown.
        /// </param>
        /// <param name="buttons">
        /// The set of flags describing the used buttons.
        /// </param>
        /// <param name="options">
        /// The list of additional dialog box options.
        /// </param>
        /// <returns>
        /// The dialog result according to the pressed button.
        /// </returns>
        public static DialogResult Show(Window owner, String message, String caption, DialogSymbol symbol, DialogButton buttons, params DialogOption[] options)
        {
            Mouse.OverrideCursor = null;

            Internal.DialogBox dialog = new Internal.DialogBox(owner, message, caption, buttons, symbol, options);

            dialog.ShowDialog();

            return dialog.Result;
        }
    }
}
