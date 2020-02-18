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
using System.Windows.Controls;

namespace Plexdata.Dialogs.Internal.Controls
{
    class HierarchicalListView : TreeView
    {
        // KNOWN BUGS: The base treeview scrolls their selected treeview items "into view" 
        //             with the effect that current selection "jumps". At the moment, there 
        //             is no way know to fix this behavior. 
        //             Another issue is the fact that scrolling down brings the header out 
        //             of view. This is for sure pretty ugly.

        #region Static dependency properties

        public static readonly DependencyProperty EnableColumnReorderProperty = DependencyProperty.Register(
            "EnableColumnReorder",
            typeof(Boolean),
            typeof(HierarchicalListView),
            new UIPropertyMetadata(null));

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
            "Columns",
            typeof(GridViewColumnCollection),
            typeof(HierarchicalListView),
            new UIPropertyMetadata(null));

        #endregion

        #region Construction

        public HierarchicalListView()
            : base()
        {
            this.Columns = new GridViewColumnCollection();
        }

        static HierarchicalListView()
        {
            TreeView.DefaultStyleKeyProperty.OverrideMetadata(
                typeof(HierarchicalListView), new FrameworkPropertyMetadata(typeof(HierarchicalListView)));
        }

        #endregion

        #region Public properties

        public Boolean EnableColumnReorder
        {
            get { return (Boolean)base.GetValue(HierarchicalListView.EnableColumnReorderProperty); }
            set { base.SetValue(HierarchicalListView.EnableColumnReorderProperty, value); }
        }

        public GridViewColumnCollection Columns
        {
            get { return (GridViewColumnCollection)base.GetValue(HierarchicalListView.ColumnsProperty); }
            set { base.SetValue(HierarchicalListView.ColumnsProperty, value); }
        }

        #endregion
    }
}
