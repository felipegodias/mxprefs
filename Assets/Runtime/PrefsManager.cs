using System;
using MXLab.Prefs.Internal;

namespace MXLab.Prefs
{
    public class PrefsManager : IPrefsManager
    {
        private readonly IEncrypter _encrypter;
        private readonly ISerializer _serializer;
        private readonly IStorage _storage;

        public PrefsManager() : this(new UnityPlayerPrefsStorage(), new DefaultEncrypter(), new UnityJsonUtilitySerializer())
        {
        }

        public PrefsManager(IStorage storage, IEncrypter encrypter, ISerializer serializer)
        {
            ValidationUtils.NullArgument(storage, nameof(storage));
            ValidationUtils.NullArgument(encrypter, nameof(encrypter));
            ValidationUtils.NullArgument(serializer, nameof(serializer));

            _storage = storage;
            _encrypter = encrypter;
            _serializer = serializer;
        }

        public bool Has(string key)
        {
            ValidationUtils.NullArgument(key, nameof(key));

            return _storage.Exists(key);
        }

        public T Get<T>(string key)
        {
            ValidationUtils.NullArgument(key, nameof(key));
            ValidationUtils.KeyNotFound(Has(key), key);

            return (T) Get(key, typeof(T));
        }

        public object Get(string key, Type type)
        {
            ValidationUtils.NullArgument(key, nameof(key));
            ValidationUtils.NullArgument(type, nameof(type));
            ValidationUtils.KeyNotFound(Has(key), key);

            string data = _storage.Read(key);
            data = _encrypter.Decrypt(data);
            object value = _serializer.Deserialize(data, type);
            return value;
        }

        public void Set<T>(string key, T value)
        {
            ValidationUtils.NullArgument(key, nameof(key));
            ValidationUtils.NullArgument(value, nameof(value));

            Set(key, value, typeof(T));
        }

        public void Set(string key, object value, Type type)
        {
            ValidationUtils.NullArgument(key, nameof(key));
            ValidationUtils.NullArgument(value, nameof(value));
            ValidationUtils.NullArgument(type, nameof(type));

            string data = _serializer.Serialize(value, type);
            data = _encrypter.Encrypt(data);
            _storage.Write(key, data);
        }

        public void Delete(string key)
        {
            ValidationUtils.NullArgument(key, nameof(key));
            ValidationUtils.KeyNotFound(Has(key), key);

            _storage.Delete(key);
        }
    }
}