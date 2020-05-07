using System;
using MXLab.Prefs.Internal;
using UnityEngine;

namespace MXLab.Prefs
{
    public class UnityJsonUtilitySerializer : ISerializer
    {
        public string Serialize<T>(T value)
        {
            ValidationUtils.ArgumentNotNull(value, nameof(value));

            var data = new Data<T>(value);
            string json = JsonUtility.ToJson(data);

            return json;
        }

        public T Deserialize<T>(string data)
        {
            ValidationUtils.ArgumentNotNull(data, nameof(data));

            var result = JsonUtility.FromJson<Data<T>>(data);

            ValidationUtils.ArgumentWrongType(result.Type != typeof(T).FullName, nameof(T));

            return result.Value;
        }

        public object Deserialize(string data, Type type)
        {
            ValidationUtils.ArgumentNotNull(data, nameof(data));
            ValidationUtils.ArgumentNotNull(type, nameof(type));

            Type genericDataType = typeof(Data<>).MakeGenericType(type);
            var result = (IData) JsonUtility.FromJson(data, genericDataType);

            ValidationUtils.ArgumentWrongType(result.Type != type.FullName, nameof(type));

            return result.ObjValue;
        }

        private interface IData
        {
            object ObjValue { get; }
            string Type { get; }
        }

        [Serializable]
        private struct Data<T> : IData
        {
            [SerializeField]
            private T _value;

            [SerializeField]
            private string _type;

            public Data(T value)
            {
                _value = value;
                _type = value.GetType().FullName;
            }

            public T Value => _value;
            public object ObjValue => _value;
            public string Type => _type;
        }
    }
}