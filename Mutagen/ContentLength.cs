﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen
{
    public struct ContentLength : IEquatable<ContentLength>
    {
        public static readonly ContentLength Zero = new ContentLength(0);
        public static readonly ContentLength Invalid = new ContentLength(-1);
        public readonly int Value;

        public ContentLength(int length)
        {
            this.Value = length;
        }

        public override string ToString()
        {
            return $"0x{this.Value.ToString("X")}";
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ContentLength rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(ContentLength other)
        {
            return this.Value == other.Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator int(ContentLength len)
        {
            return len.Value;
        }

        public static bool operator ==(ContentLength c1, ContentLength c2)
        {
            return c1.Value == c2.Value;
        }

        public static bool operator !=(ContentLength c1, ContentLength c2)
        {
            return c1.Value != c2.Value;
        }

        public static bool operator <(ContentLength c1, ContentLength c2)
        {
            return c1.Value < c2.Value;
        }

        public static bool operator >(ContentLength c1, ContentLength c2)
        {
            return c1.Value > c2.Value;
        }

        public static bool operator >=(ContentLength c1, ContentLength c2)
        {
            return c1.Value >= c2.Value;
        }

        public static bool operator <=(ContentLength c1, ContentLength c2)
        {
            return c1.Value <= c2.Value;
        }

        public static ContentLength operator +(ContentLength c1, ContentLength c2)
        {
            return new ContentLength(c1.Value + c2.Value);
        }

        public static ContentLength operator -(ContentLength c1, ContentLength c2)
        {
            return new ContentLength(c1.Value - c2.Value);
        }
    }
}
