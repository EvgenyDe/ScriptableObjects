using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class FloatVeriable : ScriptableObject,ISerializationCallbackReceiver
    {
        public event Action<float> OnValueChanged;
        [SerializeField] private float initialValue;

        private float value;

        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            value = initialValue;
        }
    }
}