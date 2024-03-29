﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonesVM
{
    public struct Bit
    {
        /// <summary>
        /// Creates a new instance with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public Bit(int value) : this()
        {
            Value = value == 0 ? 0 : 1;
        }

        /// <summary>
        /// Gets the value of the bit, 0 or 1.
        /// </summary>
        public int Value { get; private set; }

        #region Implicit conversions

        public static implicit operator Bit(int value)
        {
            return new Bit(value);
        }

        public static implicit operator int(Bit value)
        {
            return value.Value;
        }

        public static implicit operator bool(Bit value)
        {
            return value.Value == 1;
        }

        public static implicit operator Bit(bool value)
        {
            return new Bit(value ? 1 : 0);
        }

        #endregion

        #region Arithmetic operators

        public static Bit operator |(Bit value1, Bit value2)
        {
            return value1.Value | value2.Value;
        }

        public static Bit operator &(Bit value1, Bit value2)
        {
            return value1.Value & value2.Value;
        }

        public static Bit operator ^(Bit value1, Bit value2)
        {
            return value1.Value ^ value2.Value;
        }

        public static Bit operator ~(Bit value)
        {
            return new Bit(value.Value ^ 1);
        }

        public static Bit operator !(Bit value)
        {
            return ~value;
        }

        #endregion

        #region The true and false operators

        public static bool operator true(Bit value)
        {
            return value.Value == 1;
        }

        public static bool operator false(Bit value)
        {
            return value.Value == 0;
        }

        #endregion

        #region Comparison operators

        public static bool operator ==(Bit bitValue, int intValue)
        {
            return
              (bitValue.Value == 0 && intValue == 0) ||
              (bitValue.Value == 1 && intValue != 0);
        }

        public static bool operator !=(Bit bitValue, int intValue)
        {
            return !(bitValue == intValue);
        }

        public override bool Equals(object obj)
        {
            if (obj is int)
                return this == (int)obj;
            else
                return base.Equals(obj);
        }

        #endregion
    }
}
