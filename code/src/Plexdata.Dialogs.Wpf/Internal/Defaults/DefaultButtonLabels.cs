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

using System;
using System.Collections.Generic;

namespace Plexdata.Dialogs.Internal.Defaults
{
    internal static class DefaultButtonLabels
    {
        #region Private fields

        private const String OkButtonLabelText = "_OK";
        private const String YesButtonLabelText = "_Yes";
        private const String NoButtonLabelText = "_No";
        private const String CloseButtonLabelText = "Cl_ose";
        private const String CancelButtonLabelText = "_Cancel";

        private static Dictionary<DialogButton, String> labels;

        #endregion

        #region Construction

        static DefaultButtonLabels()
        {
            DefaultButtonLabels.labels = new Dictionary<DialogButton, String>()
            {
                { DialogButton.Ok,     DefaultButtonLabels.OkButtonLabelText     },
                { DialogButton.Yes,    DefaultButtonLabels.YesButtonLabelText    },
                { DialogButton.No,     DefaultButtonLabels.NoButtonLabelText     },
                { DialogButton.Close,  DefaultButtonLabels.CloseButtonLabelText  },
                { DialogButton.Cancel, DefaultButtonLabels.CancelButtonLabelText }
            };
        }

        #endregion

        #region Internal methods

        internal static IDictionary<DialogButton, String> CreateLabels()
        {
            return DefaultButtonLabels.labels;
        }

        internal static String LabelFor(DialogButton button)
        {
            if ((button & (button - 1)) != 0) // Magical ;)
            {
                throw new ArgumentOutOfRangeException(nameof(button), "Apply only one single button flag.");
            }

            return DefaultButtonLabels.labels[button];
        }

        internal static Boolean IsDefaultButtonLabel(DialogButton button, String label)
        {
            if (String.IsNullOrWhiteSpace(label))
            {
                return false;
            }

            String x = DefaultButtonLabels.LabelFor(button).Replace("_", String.Empty);
            String y = label.Trim().Replace("_", String.Empty);

            return String.Compare(x, y, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        #endregion
    }
}
