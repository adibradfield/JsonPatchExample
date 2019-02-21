using System;

namespace JsonPatchHelper
{
    public abstract class PropertyDelta
    {
        public abstract bool HasChanged { get; }
    }

    public class PropertyDelta<T> : PropertyDelta where T : IEquatable<T>
    {
        public PropertyDelta(T initialValue, T newValue)
        {
            OldValue = initialValue;
            NewValue = newValue;
        }

        public T OldValue { get; private set; }
        public T NewValue { get; private set; }

        public override bool HasChanged => !OldValue.Equals(NewValue);
    }
}
