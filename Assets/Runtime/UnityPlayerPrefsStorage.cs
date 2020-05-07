using MXLab.Prefs.Internal;
using UnityEngine;

namespace MXLab.Prefs
{
    public class UnityPlayerPrefsStorage : IStorage
    {
        public bool Exists(string entry)
        {
            ValidationUtils.ArgumentNotNull(entry, nameof(entry));

            string key = MountKey(entry);
            bool hasKey = PlayerPrefs.HasKey(key);
            return hasKey;
        }

        public string Read(string entry)
        {
            ValidationUtils.ArgumentNotNull(entry, nameof(entry));

            string key = MountKey(entry);
            string value = PlayerPrefs.GetString(key);
            return value;
        }

        public void Write(string entry, string data)
        {
            ValidationUtils.ArgumentNotNull(entry, nameof(entry));
            ValidationUtils.ArgumentNotNull(data, nameof(data));

            string key = MountKey(entry);
            PlayerPrefs.SetString(key, data);
        }

        public void Delete(string entry)
        {
            ValidationUtils.ArgumentNotNull(entry, nameof(entry));

            string key = MountKey(entry);
            PlayerPrefs.DeleteKey(key);
        }

        private static string MountKey(string entry)
        {
            return $"MXPrefs/{entry}";
        }
    }
}