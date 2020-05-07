using MXLab.Prefs.Internal;

namespace MXLab.Prefs
{
    public class DummyEncrypter : IEncrypter
    {
        public string Encrypt(string data)
        {
            ValidationUtils.ArgumentNotNull(data, nameof(data));

            return data;
        }

        public string Decrypt(string data)
        {
            ValidationUtils.ArgumentNotNull(data, nameof(data));

            return data;
        }
    }
}