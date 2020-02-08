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

namespace Plexdata.Dialogs
{
    /// <summary>
    /// The enumeration of all possible dialog box results.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// The message box returns no result.
        /// </summary>
        None = 0,

        /// <summary>
        /// The result value of the message box is OK.
        /// </summary>
        OK = 1,

        /// <summary>
        /// The result value of the message box is Close.
        /// </summary>
        Close = 2,

        /// <summary>
        /// The result value of the message box is Cancel.
        /// </summary>
        Cancel = 3,

        /// <summary>
        /// The result value of the message box is Yes.
        /// </summary>
        Yes = 4,

        /// <summary>
        /// The result value of the message box is No.
        /// </summary>
        No = 5
    }
}
