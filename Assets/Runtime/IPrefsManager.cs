using System;

namespace MXLab.Prefs
{
    /// <summary>
    /// </summary>
    public interface IPrefsManager
    {
        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Has(string key);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Get(string key, Type type);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        void Set<T>(string key, T value);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        void Set(string key, object value, Type type);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);
    }
}