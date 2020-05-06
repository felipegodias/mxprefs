namespace MXLab.Prefs
{
    /// <summary>
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        bool Exists(string entry);

        /// <summary>
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        string Read(string entry);

        /// <summary>
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="data"></param>
        void Write(string entry, string data);

        /// <summary>
        /// </summary>
        /// <param name="entry"></param>
        void Delete(string entry);
    }
}