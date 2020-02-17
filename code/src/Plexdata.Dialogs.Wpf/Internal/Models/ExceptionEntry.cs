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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Plexdata.Dialogs.Internal.Models
{
    internal class ExceptionEntry
    {
        #region Private fields

        private const String Null = "null";

        #endregion

        #region Construction

        public ExceptionEntry(String name, Object value, Type type)
        {
            this.Name = (name ?? ExceptionEntry.Null).ToString();
            this.Value = (value ?? ExceptionEntry.Null);
            this.Type = type;

            if (value is Int32 && this.Name.Equals(nameof(Exception.HResult)))
            {
                this.Value = $"{((Int32)value).ToString()} (0x{((Int32)value).ToString("X8")})";
                return;
            }

            if (value is Exception)
            {
                this.Elements = ExceptionEntry.FromException(value as Exception);
                return;
            }

            if (value is IDictionary)
            {
                this.Elements = ExceptionEntry.FromDictionary(value as IDictionary);
                return;
            }

            if (value is MethodBase)
            {
                this.Elements = ExceptionEntry.FromMethodBase(value as MethodBase);
                return;
            }

            if (this.Name.Equals(nameof(MethodBase.CustomAttributes)))
            {
                // It doesn't really make any sense to resolve all those custom attributes.
                IEnumerable<CustomAttributeData> helper = (value as IEnumerable<CustomAttributeData>);
                this.Value = $"Count = {(helper is null ? ExceptionEntry.Null : helper.Count().ToString())}";
                return;
            }
        }

        #endregion

        #region Public properties

        public String Name { get; private set; }

        public Object Value { get; private set; }

        public Type Type { get; private set; }

        public IEnumerable<ExceptionEntry> Elements { get; private set; }

        #endregion

        #region Public methods

        public static IEnumerable<ExceptionEntry> FromException(Exception source)
        {
            if (source is null)
            {
                return null;
            }

            try
            {
                return ExceptionEntry.FromAssignments(ExceptionEntry.GetProperties(source));
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error);
                return null;
            }
        }

        #endregion

        #region Private methods

        private static IEnumerable<ExceptionEntry> FromDictionary(IDictionary source)
        {
            if (source is null)
            {
                return null;
            }

            try
            {
                List<ExceptionEntry> result = new List<ExceptionEntry>();

                foreach (Object key in source.Keys)
                {
                    String name = (key ?? ExceptionEntry.Null).ToString();
                    Object value = source[key];
                    Type type = value?.GetType();

                    result.Add(new ExceptionEntry(name, value, type));
                }

                return result;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error);
                return null;
            }
        }

        private static IEnumerable<ExceptionEntry> FromMethodBase(MethodBase source)
        {
            if (source is null)
            {
                return null;
            }

            return ExceptionEntry.FromAssignments(ExceptionEntry.GetProperties(source));
        }

        private static IEnumerable<ExceptionEntry> FromAssignments(IEnumerable<KeyValuePair<String, Object>> source)
        {
            if (source is null)
            {
                return null;
            }

            try
            {
                List<ExceptionEntry> result = new List<ExceptionEntry>();

                foreach (KeyValuePair<String, Object> current in source)
                {
                    result.Add(new ExceptionEntry(current.Key, current.Value, current.Value?.GetType()));
                }

                return result;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error);
                return null;
            }
        }

        private static IEnumerable<KeyValuePair<String, Object>> GetProperties(Object source)
        {
            if (source is null)
            {
                return null;
            }

            try
            {
                // KNOWN BUGS: It should be the type of the property itself 
                //             but it is the type of the property's value.
                return source
                    .GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)
                    .Select(x => new KeyValuePair<String, Object>(x.Name, x.GetValue(source)));
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error);
                return null;
            }
        }

        #endregion
    }
}
