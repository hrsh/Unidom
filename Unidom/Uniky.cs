using System;

namespace Unidom
{
    public class Uniky : IEquatable<Uniky>
    {
        public string Value { get; }

        public Uniky(string value) => Value = value;

        public bool Equals(Uniky other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Uniky) obj);
        }

        public override int GetHashCode() =>
            Value.GetHashCode();

        public override string ToString() => Value;

        public static implicit operator string(Uniky value) => value.Value;

        public static implicit operator Uniky(string uuid) => new Uniky(uuid);

        public static bool operator ==(Uniky left, Uniky right) =>
            left?.Equals(right) ?? Equals(right, null);

        public static bool operator !=(Uniky left, Uniky right) =>
            !(left == right);
    }
}