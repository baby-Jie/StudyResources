/*
反射工具类
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Utils.OtherUtils
{
    public static class ReflegUtil
    {
        #region Field Relations

        public static object GetPrivateField(object owner, string fieldStr)
        {
            return GetField(owner, fieldStr, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static object GetField(object owner, string fieldStr, BindingFlags bindFlags)
        {
            object ret = null;
            try
            {
                var type = owner.GetType();
                ret = GetField(owner, type, fieldStr, bindFlags);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ret;
        }

        public static object GetField(object owner, Type type, string fieldStr, BindingFlags bindFlags)
        {
            object ret = null;
            try
            {
                var fieldInfo = type?.GetField(fieldStr, bindFlags);
                
                ret = fieldInfo?.GetValue(owner);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ret;
        }

        #endregion Field Relations	

        #region Property Relations

        public static object GetProperty(object owner, string propertyName)
        {
            return GetProperty(owner, propertyName, BindingFlags.Instance | BindingFlags.Public);
        }

        public static object GetPrivateProperty(object owner, string propertyName)
        {
            return GetProperty(owner, propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static object GetProperty(object owner, string propertyName, BindingFlags flags)
        {
            object ret = null;

            try
            {
                var type = owner.GetType();

                ret = GetProperty(owner, type, propertyName, flags);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ret;
        }

        public static object GetProperty(object owner, Type type, string propertyName, BindingFlags flags)
        {
            object ret = null;

            try
            {
                var propertyInfo = type?.GetProperty(propertyName, flags);
                ret = propertyInfo?.GetValue(owner);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ret;
        }

        #endregion Property Relations	

        #region Method Relations

        public static object InvokeMethod(object owner, string methodName)
        {
            object[] parameters = new object[]{};
            return InvokeMethod(owner, methodName, parameters);
        }

        public static object InvokeMethod(object owner, string methodName, object[] parameters)
        {
            return InvokeMethod(owner, methodName, BindingFlags.Instance | BindingFlags.Public, parameters);
        }

        public static object InvokePrivateMethod(object owner, string methodName)
        {
            object[] parameters = new object[]{};
            return InvokeMethod(owner, methodName, BindingFlags.Instance | BindingFlags.NonPublic, parameters);
        }

        public static object InvokePrivateMethod(object owner, string methodName, object[] parameters)
        {
            return InvokeMethod(owner, methodName, BindingFlags.Instance | BindingFlags.NonPublic, parameters);
        }

        public static object InvokeMethod(object owner, string methodStr, BindingFlags bindFlags, object[] parameters)
        {
            object ret = null;

            try
            {
                var type = owner.GetType();
                ret = InvokeMethod(owner, type, methodStr, bindFlags, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ret;
        }

        public static object InvokeMethod(object owner, Type type, string methodStr, BindingFlags bindFlags,
                                          object[] parameters)
        {
            object ret = null;

            try
            {
                var methodInfo = type?.GetMethod(methodStr, bindFlags);
                ret = methodInfo?.Invoke(owner, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ret;
        }

        #endregion Method Relations	
    }
}
