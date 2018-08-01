using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace RBACdemo.Utility
{
  public static class ExtentionMethods
    {
        public static byte[] ToBase64Bytes(this byte[] base64Bytes)
        {
            string base64String = Encoding.UTF8.GetString(base64Bytes, 0, base64Bytes.Length);
            return Convert.FromBase64String(base64String);
        }
        public static string ToMaskAsterisk(this string str, int startIndex, int NumberOfChar)
        {
            var aStringBuilder = new StringBuilder(str);
            aStringBuilder.Remove(startIndex, NumberOfChar);
            string astrisk = new String('*', NumberOfChar);
            aStringBuilder.Insert(startIndex, astrisk);
            return aStringBuilder.ToString();
        }


        #region DataSet
        // usage: List<Employee> lst = ds.Tables[0].ToList<Employee>();
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    if (property.PropertyType == typeof(System.DayOfWeek))
                    {
                        DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                        property.SetValue(item, day, null);
                    }
                    else
                    {
                        if (row[property.Name] == DBNull.Value)
                            property.SetValue(item, null, null);
                        else
                            property.SetValue(item, row[property.Name], null);
                    }
                }
            }
            return item;
        }
        #endregion

    }
}
