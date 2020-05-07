using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MXLab.Prefs.Internal
{
    internal static class ValidationUtils
    {
        [Conditional("DEBUG")]
        public static void ArgumentNotNull(object value, string argName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argName, ErrorMsg.ArgumentNullExceptionMsg);
            }
        }

        [Conditional("DEBUG")]
        public static void ArgumentWrongType(bool isWrongType, string argName)
        {
            if (isWrongType)
            {
                throw new ArgumentException(ErrorMsg.ArgumentWrongTypeExceptionMsg, argName);
            }
        }

        [Conditional("DEBUG")]
        public static void KeyNotFound(bool hasKey, string value)
        {
            if (!hasKey)
            {
                throw new KeyNotFoundException(string.Format(ErrorMsg.KeyNotFoundExceptionMsg, value));
            }
        }
    }
}