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

using Plexdata.Dialogs.Internal;
using System;

namespace Plexdata.Dialogs
{
    public class DialogOption
    {
        #region Public fields

        public static DialogOption DefaultButtonOk = new DialogOption(DialogButton.Ok, true);
        public static DialogOption DefaultButtonYes = new DialogOption(DialogButton.Yes, true);
        public static DialogOption DefaultButtonNo = new DialogOption(DialogButton.No, true);
        public static DialogOption DefaultButtonClose = new DialogOption(DialogButton.Close, true);
        public static DialogOption DefaultButtonCancel = new DialogOption(DialogButton.Cancel, true);

        #endregion

        #region Private fields

        private DialogButton button;

        private String label;

        #endregion

        #region Construction

        public DialogOption()
            : this(DialogButton.Ok)
        { }

        public DialogOption(DialogButton button)
            : this(button, false)
        { }

        public DialogOption(DialogButton button, Boolean isDefault)
            : this(button, null, isDefault)
        { }

        public DialogOption(DialogButton button, String label)
            : this(button, label, false)
        { }

        public DialogOption(DialogButton button, String label, Boolean isDefault)
        {
            this.Button = button;
            this.Label = label ?? DefaultButtonLabels.LabelFor(button);
            this.IsDefault = isDefault;
        }

        #endregion

        #region Public properties

        public DialogButton Button
        {
            get
            {
                return this.button;
            }
            set
            {
                if ((value & (value - 1)) != 0) // Magical ;)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Button), "Apply only one single button flag.");
                }

                this.button = value;
            }
        }

        public String Label
        {
            get
            {
                return this.label;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Label), "The label may not be null, empty or consists only of white spaces.");
                }

                this.label = value.Trim();
            }
        }

        public Boolean IsDefault
        {
            get;
            set;
        }

        #endregion
    }
}
