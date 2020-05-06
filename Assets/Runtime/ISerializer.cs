using System;

namespace MXLab.Prefs
{
    /// <summary>
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        string Serialize(object value, Type type);

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Deserialize(string data, Type type);
    }
}