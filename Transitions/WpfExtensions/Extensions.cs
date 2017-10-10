using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;


namespace Transitions
{
    public class ComplexProperty
    {
        private static object m_lock = new object();

        public static object SetComplexValue(object target, string propertyPath, object value)
        {
            lock (m_lock)
            {
                return SetComplexValue(target, propertyPath.Split('.'), value);
            }
        }

        private static object SetComplexValue(object target, string[] propertyArray, object value)
        {
            var type = target.GetType();

            var pi = type.GetProperty(propertyArray[0]);
            if (pi == null)
                throw new NullReferenceException(string.Format("Target property not found at {0}", propertyArray[0]));

            var property = pi.GetValue(target, null);

            if (propertyArray.Length == 0)
                throw new Exception("");
            if (propertyArray.Length == 1)
            {
                pi.SetValue(target, value, null);
                return target;
            }
            var ret = SetComplexValue(property, propertyArray.Skip(1).ToArray(), value);
            pi.SetValue(target, ret, null);
            return target;
        }

        public static object GetComplexValue(object target, string property)
        {
            lock (m_lock)
            {
                var propertyArray = property.Split('.');
                var type = target.GetType();
                object ret = null;
                for (var i = 0; i < propertyArray.Length; i++)
                {
                    var pi = type.GetProperty(propertyArray[i]);

                    target = pi.GetValue(target, null);
                    type = target.GetType();
                    if (i == propertyArray.Length - 1)
                    {
                        ret = target.ToString();
                    }
                }
                return ret;
            }
        }

        public static Type GetExtremityPropertyType(object target , string propertyPath)
        {
            var propertyArray = propertyPath.Split('.');
            var type = target.GetType();
            for (var i = 0; i < propertyArray.Length; i++)
            {
                var pi = type.GetProperty(propertyArray[i]);
                target = pi.GetValue(target, null);
                type = target.GetType();
            }
            return type;
        }
    }


    public static class Extensions
    {
        public static PropertyInfo GetPropertyEx(this Type type,string strPropertyName)
        {
            if (!strPropertyName.Contains("."))
                return type.GetProperty(strPropertyName);

            PropertyInfo pinfo = null;
            var propertyArray = strPropertyName.Split('.');
            pinfo = type.GetProperty(propertyArray[0]);
            var subType = pinfo.PropertyType;
            return subType.GetPropertyEx(string.Join(".", propertyArray.Skip(1)));
        }
    }
}