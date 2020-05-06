using System;
using MXLab.Prefs.Internal;
using UnityEngine;

namespace MXLab.Prefs
{
    public class UnityJsonUtilitySerializer : ISerializer
    {
        public string Serialize(object value, Type type)
        {
            ValidationUtils.NullArgument(value, nameof(value));
            ValidationUtils.NullArgument(type, nameof(type));

            Type dataType = typeof(Data<>).MakeGenericType(type);
            object obj = Activator.CreateInstance(dataType, value, type);
            string json = JsonUtility.ToJson(obj);
            return json;
        }

        public object Deserialize(string data, Type type)
        {
            ValidationUtils.NullArgument(data, nameof(data));
            ValidationUtils.NullArgument(type, nameof(type));
            
            Type dataType = typeof(Data<>).MakeGenericType(type);
            var result = (IData) JsonUtility.FromJson(data, dataType);

            ValidationUtils.WrongTypeArgument(result.Type != type.FullName, nameof(type));

            return result.Value;
        }

        private interface IData
        {
            object Value { get; }
            string Type { get; }
        }

        [Serializable]
        private struct Data<T> : IData
        {
            [SerializeField]
            private T _value;

            [SerializeField]
            private string _type;

            public Data(T value, Type type)
            {
                _value = value;
                _type = type.FullName;
            }

            public object Value => _value;
            public string Type => _type;
        }
    }
}