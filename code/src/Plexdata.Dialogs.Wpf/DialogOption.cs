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
    /// <summary>
    /// The model for customizing the dialog box.
    /// </summary>
    /// <remarks>
    /// With this model it becomes possible to change for example a particular button label. 
    /// Additionally, it becomes possible to change the button's default behaviour.
    /// </remarks>
    public class DialogOption
    {
        #region Public fields

        /// <summary>
        /// This field represents the configuration of button `OK` as default button.
        /// </summary>
        public readonly static DialogOption DefaultButtonOk = new DialogOption(DialogButton.Ok, true);

        /// <summary>
        /// This field represents the configuration of button `Yes` as default button.
        /// </summary>
        public readonly static DialogOption DefaultButtonYes = new DialogOption(DialogButton.Yes, true);

        /// <summary>
        /// This field represents the configuration of button `No` as default button.
        /// </summary>
        public readonly static DialogOption DefaultButtonNo = new DialogOption(DialogButton.No, true);

        /// <summary>
        /// This field represents the configuration of button `Close` as default button.
        /// </summary>
        public readonly static DialogOption DefaultButtonClose = new DialogOption(DialogButton.Close, true);

        /// <summary>
        /// This field represents the configuration of button `Cancel` as default button.
        /// </summary>
        public readonly static DialogOption DefaultButtonCancel = new DialogOption(DialogButton.Cancel, true);

        #endregion

        #region Private fields

        private DialogButton button;

        private String label;

        #endregion

        #region Construction

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>
        /// This constructor uses button `OK` as assigned button.
        /// </remarks>
        public DialogOption()
            : this(DialogButton.Ok)
        { }

        /// <summary>
        /// The constructor to apply provided <paramref name="button"/>.
        /// </summary>
        /// <remarks>
        /// The provided button's default behaviour is disabled.
        /// </remarks>
        /// <param name="button">
        /// The button to be used.
        /// </param>
        public DialogOption(DialogButton button)
            : this(button, false)
        { }

        /// <summary>
        /// The constructor to apply provided <paramref name="button"/>.
        /// </summary>
        /// <remarks>
        /// The provided button's default behaviour is applied according value of 
        /// <paramref name="isDefault"/>.
        /// </remarks>
        /// <param name="button">
        /// The button to be used.
        /// </param>
        /// <param name="isDefault">
        /// True to enable default behaviour and false to disable it.
        /// </param>
        public DialogOption(DialogButton button, Boolean isDefault)
            : this(button, null, isDefault)
        { }

        /// <summary>
        /// The constructor to apply provided <paramref name="button"/>.
        /// </summary>
        /// <remarks>
        /// The button's default label is replaced by provided <paramref name="label"/>.
        /// </remarks>
        /// <param name="button">
        /// The button to be used.
        /// </param>
        /// <param name="label">
        /// The label to be used.
        /// </param>
        public DialogOption(DialogButton button, String label)
            : this(button, label, false)
        { }

        /// <summary>
        /// The constructor to apply provided <paramref name="button"/>.
        /// </summary>
        /// <remarks>
        /// The provided button's default behaviour is applied according value of 
        /// <paramref name="isDefault"/> as well as its default label is replaced by 
        /// provided <paramref name="label"/>.
        /// </remarks>
        /// <param name="button">
        /// The button to be used.
        /// </param>
        /// <param name="label">
        /// The label to be used.
        /// </param>
        /// <param name="isDefault">
        /// True to enable default behaviour and false to disable it.
        /// </param>
        public DialogOption(DialogButton button, String label, Boolean isDefault)
        {
            this.Button = button;
            this.Label = label ?? DefaultButtonLabels.LabelFor(button);
            this.IsDefault = isDefault;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets and sets the corresponding button flag.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown if provided value consists of more that one single 
        /// button flag.
        /// </exception>
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

        /// <summary>
        /// Gets and sets the corresponding button label.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// This exception is thrown if provided value is invalid.
        /// </exception>
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

        /// <summary>
        /// Gets and sets the button's default behaviour.
        /// </summary>
        public Boolean IsDefault
        {
            get;
            set;
        }

        #endregion
    }
}
