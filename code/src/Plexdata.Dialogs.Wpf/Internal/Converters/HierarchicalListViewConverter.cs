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

using Plexdata.Dialogs.Internal.Controls;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Plexdata.Dialogs.Internal.Converters
{
    internal class HierarchicalListViewConverter : IValueConverter
    {
        #region Private fields

        private readonly HierarchicalListViewDefaults defaults = null;

        #endregion

        #region Construction

        internal HierarchicalListViewConverter()
            : base()
        {
            this.defaults = new HierarchicalListViewDefaults();
        }

        #endregion

        #region Public methods

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            if (targetType == typeof(Double) && typeof(DependencyObject).IsAssignableFrom(value.GetType()))
            {
                DependencyObject element = value as DependencyObject;

                Int32 depth = -1;

                while ((element = VisualTreeHelper.GetParent(element)) != null)
                {
                    if (typeof(TreeViewItem).IsAssignableFrom(element?.GetType()))
                    {
                        depth++;
                    }
                }

                return this.GetIndentation(depth);
            }

            throw new NotSupportedException(String.Format("Conversion of type {0} into type {1} is not supported.", value.GetType(), targetType));
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Back conversion is not supported at all.");
        }

        #endregion

        #region Private methods

        private Double GetIndentation(Int32 depth)
        {
            return this.defaults.ExpanderSize.Width * (depth < 0 ? 0 : depth);
        }

        #endregion
    }
}
