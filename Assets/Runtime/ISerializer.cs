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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string Serialize<T>(T value);

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Deserialize<T>(string data);

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Deserialize(string data, Type type);
    }
}