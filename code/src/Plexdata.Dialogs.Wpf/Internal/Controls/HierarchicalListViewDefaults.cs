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
using System.Windows;

namespace Plexdata.Dialogs.Internal.Controls
{
    internal class HierarchicalListViewDefaults
    {
        #region Construction

        internal HierarchicalListViewDefaults()
            : base()
        {
            this.ExpanderWidth = 11;
            this.ExpanderHeight = 11;
            this.ExpanderMargin = new Thickness(0, 4, 6, 0);

            this.ExpanderSize = new Size(
                this.ExpanderWidth + this.ExpanderMargin.Left + this.ExpanderMargin.Right,
                this.ExpanderHeight + this.ExpanderMargin.Top + this.ExpanderMargin.Bottom
            );
        }

        #endregion

        #region Public properties

        public Size ExpanderSize
        {
            get;
            private set;
        }

        public Double ExpanderWidth
        {
            get;
            private set;
        }

        public Double ExpanderHeight
        {
            get;
            private set;
        }

        public Thickness ExpanderMargin
        {
            get;
            private set;
        }

        #endregion
    }
}
