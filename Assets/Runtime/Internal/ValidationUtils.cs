using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MXLab.Prefs.Internal
{
    internal static class ValidationUtils
    {
        [Conditional("DEBUG")]
        public static void NullArgument(object value, string argName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argName, string.Format(ErrorMsg.NullArgumentExceptionFormat, argName));
            }
        }

        [Conditional("DEBUG")]
        public static void WrongTypeArgument(bool isWrongType, string argName)
        {
            if (isWrongType)
            {
                throw new ArgumentException(string.Format(ErrorMsg.WrongTypeArgumentExceptionFormat, argName), argName);
            }
        }

        [Conditional("DEBUG")]
        public static void KeyNotFound(bool hasKey, string value)
        {
            if (!hasKey)
            {
                throw new KeyNotFoundException(string.Format(ErrorMsg.KeyNotFoundExceptionFormat, value));
            }
        }
    }
}