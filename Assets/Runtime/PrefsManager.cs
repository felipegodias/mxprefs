using System;
using MXLab.Prefs.Internal;

namespace MXLab.Prefs
{
    public class PrefsManager : IPrefsManager
    {
        private readonly IStorage _storage;
        private readonly IEncrypter _encrypter;
        private readonly ISerializer _serializer;

        public PrefsManager() : this(new UnityPlayerPrefsStorage(), new DummyEncrypter(),
            new UnityJsonUtilitySerializer())
        {
        }

        public PrefsManager(IStorage storage, IEncrypter encrypter, ISerializer serializer)
        {
            ValidationUtils.ArgumentNotNull(storage, nameof(storage));
            ValidationUtils.ArgumentNotNull(encrypter, nameof(encrypter));
            ValidationUtils.ArgumentNotNull(serializer, nameof(serializer));

            _storage = storage;
            _encrypter = encrypter;
            _serializer = serializer;
        }

        public bool Has(string key)
        {
            ValidationUtils.ArgumentNotNull(key, nameof(key));

            return _storage.Exists(key);
        }

        public T Get<T>(string key)
        {
            ValidationUtils.ArgumentNotNull(key, nameof(key));
            ValidationUtils.KeyNotFound(Has(key), key);

            return (T) Get(key, typeof(T));
        }

        public object Get(string key, Type type)
        {
            ValidationUtils.ArgumentNotNull(key, nameof(key));
            ValidationUtils.ArgumentNotNull(type, nameof(type));
            ValidationUtils.KeyNotFound(Has(key), key);

            string data = _storage.Read(key);
            data = _encrypter.Decrypt(data);
            object value = _serializer.Deserialize(data, type);
            return value;
        }

        public void Set<T>(string key, T value)
        {
            ValidationUtils.ArgumentNotNull(key, nameof(key));
            ValidationUtils.ArgumentNotNull(value, nameof(value));

            Set(key, value, typeof(T));
        }

        public void Set(string key, object value, Type type)
        {
            ValidationUtils.ArgumentNotNull(key, nameof(key));
            ValidationUtils.ArgumentNotNull(value, nameof(value));
            ValidationUtils.ArgumentNotNull(type, nameof(type));

            string data = _serializer.Serialize(value, type);
            data = _encrypter.Encrypt(data);
            _storage.Write(key, data);
        }

        public void Delete(string key)
        {
            ValidationUtils.ArgumentNotNull(key, nameof(key));
            ValidationUtils.KeyNotFound(Has(key), key);

            _storage.Delete(key);
        }
    }
}