using MXLab.Prefs.Internal;

namespace MXLab.Prefs
{
    public class DefaultEncrypter : IEncrypter
    {
        public string Encrypt(string data)
        {
            ValidationUtils.NullArgument(data, nameof(data));

            return data;
        }

        public string Decrypt(string data)
        {
            ValidationUtils.NullArgument(data, nameof(data));

            return data;
        }
    }
}