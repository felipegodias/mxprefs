namespace MXLab.Prefs
{
    public interface IEncrypter
    {
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Encrypt(string data);

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Decrypt(string data);
    }
}