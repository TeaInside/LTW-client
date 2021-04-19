// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using WotoProvider.Interfaces;
using SAO.Constants;
using SAO.GameObjects.WMath;
// ReSharper disable StringIndexOfIsCultureSpecific.1
// ReSharper disable InconsistentNaming
// ReSharper disable SuggestVarOrType_Elsewhere

namespace SAO.Security
{
#pragma warning disable IDE0032
    public sealed class StrongString : IStringProvider<StrongString>, ISessionData
    {
        //-------------------------------------------------
        #region Constants Region
        // ReSharper disable once MemberCanBePrivate.Global
        public const string ToStringValue   = "-- StrongString -- || BY wotoTeam (C)";
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        public const char UNSIGNED_CHAR1    = '\b';
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        public const char UNSIGNED_CHAR2    = '\r';
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        public const char SIGNED_CHAR1      = '\n';
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        public const char SIGNED_CHAR2      = ' ';
        #endregion
        //-------------------------------------------------
        #region fields Region
        private byte[] _myValue;
        private bool _isDisposed;
        private static StrongString _empty;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public static StrongString Empty
        {
            get
            {
                if (_empty is null)
                {
                    _empty = new StrongString(string.Empty);
                }
                return _empty;
            }
        }
        public int Length { get => GetValue().Length; }
        public bool IsDisposed { get => _isDisposed; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        /// <summary>
        /// convert an ordinary string to the byte.
        /// please don't use encrypted string.
        /// </summary>
        /// <param name="theValue"></param>
        public StrongString(string theValue)
        {
            _myValue =
                ThereIsConstants.AppSettings.DECoder.TheEncoderValue.GetBytes(theValue);
        }
        /// <summary>
        /// create a new instance of a strong string by passing the 
        /// bytes of an ordinary string value.
        /// </summary>
        /// <param name="theValue">
        /// bytes of an ordinary string.
        /// NOTICE: the ordinary string means a string which is not in coded
        /// format.
        /// </param>
        public StrongString(byte[] theValue)
        {
            _myValue = theValue;
        }
        public char this[int index]
        {
            get
            {
                return GetValue()[index];
            }
        }
        public StrongString this[int startIndex, int length]
        {
            get
            {
                return Substring(startIndex, length);
            }
        }
        public StrongString this[bool first]
        {
            get
            {
                if (first)
                {
                    return this[0, 1];
                }
                else
                {
                    return this[Length - 2, 1];
                }
                
            }
        }
        ~StrongString()
        {
            _myValue = null; 
            // nothing is here for-now.
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public void ChangeValue(string anotherValue)
        {
            _myValue =
                ThereIsConstants.AppSettings.DECoder.TheEncoderValue.GetBytes(anotherValue);
        }
        public string GetValue()
        {
            return
                ThereIsConstants.AppSettings.DECoder.TheEncoderValue.GetString(_myValue);
        }
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            _myValue = null;
            _isDisposed = true;
        }
        public StrongString[] Split(params string[] separator)
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            StrongString[] strongStrings;
            var myStrings =
                GetValue().Split(separator, ThereIsConstants.AppSettings.SplitOption);
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            strongStrings = new StrongString[myStrings.Length];
            for (int i = 0; i < myStrings.Length; i++)
            {
                strongStrings[i] = new StrongString(myStrings[i]);
            }
            return strongStrings;
        }
        public StrongString[] Split(params StrongString[] strongStrings)
        {
            string[] myStrings = new string[strongStrings.Length];
            for (int i = 0; i < strongStrings.Length; i++)
            {
                myStrings[i] = strongStrings[i].GetValue();
            }
            return Split(myStrings);
        }
        public byte[] GetByteData()
        {
            return _myValue;
        }
        public StrongString GetStrong() => this;
        public int IndexOf(string value)
        {
            return GetValue().IndexOf(value);
        }
        public bool IndexOf(params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (IndexOf(values[i]) != -1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IndexOf(params char[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (IndexOf(values[i]) != -1)
                {
                    return true;
                }
            }
            return false;
        }
        public int[] IndexesOf(params string[] values)
        {
            int[] myInts = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                myInts[i] = IndexOf(values[i]);
            }
            return myInts;
        }
        public int IndexOf(char value)
        {
            return GetValue().IndexOf(value);
        }
        public int IndexOf(StrongString value)
        {
            return GetValue().IndexOf(value.GetValue());
        }
        public int ToInt32()
        {
            return Convert.ToInt32(GetValue());
        }
        public float ToSingle()
        {
            return Convert.ToSingle(GetValue());
        }
        public ushort ToUInt16()
        {
            return Convert.ToUInt16(GetValue());
        }
        public ulong ToUInt64()
        {
            return Convert.ToUInt64(GetValue());
        }
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">
        /// The zero-based starting character position of a substring in this instance.
        /// </param>
        /// <param name="length">
        /// The number of characters in the substring.
        /// </param>
        /// <returns>
        /// A string that is equivalent to the substring of length length that begins at
        /// startIndex in this instance, or System.String.Empty if startIndex is equal to
        /// the length of this instance and length is zero.
        /// </returns>
        public StrongString Substring(in int startIndex, in int length)
        {
            return GetValue().Substring(startIndex, length);
        }
        public StrongString Substring(in int startIndex)
        {
            return Substring(startIndex , Length - startIndex - 1);
        }
        public StrongString Remove(in char value)
        {
            return GetValue().Replace(value.ToString(), string.Empty);
        }
        public StrongString Remove(in int startIndex, in int count)
        {
            return GetValue().Remove(startIndex, count);
        }
        public StrongString Append(in char value)
        {
            return GetValue() + value;
        }
        public StrongString Append(in string value)
        {
            return GetValue() + value;
        }
        public StrongString Append(in string value, int count)
        {
            StrongString myString = Empty;
            for (int i = 0; i < count; i++)
            {
                myString += value;
            }
            return GetValue() + myString;
        }
        public StrongString Append(params string[] values)
        {
            string myString = string.Empty;
            for (int i = 0; i < values.Length; i++)
            {
                myString += values[i];
            }
            return GetValue() + myString;
        }
        public StrongString Append(in StrongString value)
        {
            return this + value;
        }
        public StrongString Append(in StrongString value, int count)
        {
            StrongString myString = string.Empty;
            for (int i = 0; i < count; i++)
            {
                myString += value;
            }
            return GetValue() + myString;
        }
        public StrongString Append(params StrongString[] values)
        {
            StrongString myString = Empty;
            for (int i = 0; i < values.Length; i++)
            {
                myString += values[i];
            }
            return GetValue() + myString;
        }
        public StrongString Append(in char value, int count)
        {
            return Append(value.ToString(), count);
        }
        public StrongString ToLower()
        {
            return GetValue().ToLower();
        }
        public StrongString ToUpper()
        {
            return GetValue().ToUpper();
        }
        /// <summary>
        /// Fix this <see cref="StrongString"/>.
        /// if this strong string has not contain special
        /// characters, then this method will 
        /// fix it by measuring the length with the
        /// specified font and compare it with
        /// max width which should be passed as second arg.
        /// </summary>
        /// <param name="f">
        /// the specified font.
        /// </param>
        /// <param name="maxWidth">
        /// the maximum width of the strong string.
        /// </param>
        /// <returns>
        /// itself, if this <see cref="StrongString"/> contains
        /// special characters; otherwise return fixed-size strong string.
        /// </returns>
        public StrongString FixMe(SpriteFont f, float maxWidth)
        {
            if (HasSpecial() || confirmedMe())
            {
                return this;
            }
            ListW<StrongString> finalList = new ListW<StrongString>();
            // ReSharper disable once HeapView.ObjectAllocation
            StrongString[] myStrings = Split(SIGNED_CHAR1.ToString());
            StrongString[] bySpace;
            char[] chars;
            StrongString rString = Empty;
            StrongString lastRString = rString;
            foreach (var n in myStrings)
            {
                // var ns = n.GetValue();
                if (confirmed(n))
                {
                    finalList.Add(n);
                    clear();
                    continue;
                }
                bySpace = n.Split(SIGNED_CHAR2.ToString());
                if (bySpace.Length == 1)
                {
                    if (confirmed(bySpace[0]))
                    {
                        finalList.Add(lastRString);
                        clear();
                    }
                    else
                    {
                        clear();
                        chars = bySpace[0].GetValue().ToCharArray();
                        for(int i = 0; i < chars.Length; i++)
                        {
                            var c = chars[i];
                            rString += c;
                            if (confirmed(rString))
                            {
                                lastRString = rString;
                                if (i == chars.Length - 1)
                                {
                                    finalList.Add(lastRString);
                                    clear();
                                    // ReSharper disable once RedundantJumpStatement
                                    continue;
                                }
                            }
                            else
                            {
                                finalList.Add(lastRString);
                                clear();
                                if (i == chars.Length - 1)
                                {
                                    finalList.Add(c.ToString());
                                }
                                else
                                {
                                    rString += c;
                                }
                            }
                        }
                    }
                }
                else
                {
                    bool charWorked = false;
                    // by space
                    for(int i = 0; i < bySpace.Length; i++)
                    {
                        var s = bySpace[i];
                        if (!confirmed(s))
                        {
                            charWorker(s);
                            charWorked = true;
                            continue;
                        }
                        rString += SIGNED_CHAR2 + s;
                        if (confirmed(rString))
                        {
                            lastRString = rString;
                            if (i == bySpace.Length - 1)
                            {
                                if (charWorked)
                                {
                                    var m = finalList[^1] + SIGNED_CHAR2 + lastRString;
                                    if (confirmed(m))
                                    {
                                        finalList[^1] = m;
                                    }
                                    else
                                    {
                                        finalList.Add(lastRString);
                                    }
                                    clear();
                                    charWorked = false;
                                }
                                else
                                {
                                    finalList.Add(lastRString);
                                    clear();
                                }
                            }
                        }
                        else
                        {
                            if (charWorked)
                            {
                                var m = finalList[^1] + SIGNED_CHAR2 + lastRString;
                                if (confirmed(m))
                                {
                                    finalList[^1] = m;
                                }
                                else
                                {
                                    finalList.Add(lastRString);
                                }
                                clear();
                                charWorked = false;
                            }
                            else
                            {
                                finalList.Add(lastRString);
                                clear();
                            }
                            if (i == bySpace.Length - 1)
                            {
                                finalList.Add(s);
                            }
                            else if (hasSpace(s))
                            {
                                if (i == bySpace.Length - 2)
                                {
                                    finalList.Add(s);
                                }
                            }
                            else
                            {
                                rString += SIGNED_CHAR2 + s;
                            }
                        }
                    }
                }
            }
            return buildMe();
            StrongString buildMe()
            {
                StrongString myString = Empty;
                for (int i = 0; i < finalList.Length; i++)
                {
                    // var s = finalList[i].GetValue();
                    myString += SIGNED_CHAR1 + finalList[i];
                }
                // string test = myString.GetValue();
                if (hasSpaceMe())
                {
                    if (!hasSpace(myString))
                    {
                        myString += SIGNED_CHAR2;
                    }
                }
                return myString;
            }
            bool confirmed(in StrongString s)
            {
                return f.MeasureString(s.GetValue()).X < maxWidth;
            }
            bool confirmedMe()
            {
                return confirmed(this);
            }
            void clear()
            {
                lastRString = rString = Empty;
            }
            bool hasSpace(StrongString s)
            {
                return s[^1] == SIGNED_CHAR2;
            }
            bool hasSpaceMe()
            {
                return this[Length - 1] == SIGNED_CHAR2;
            }
            void charWorker(StrongString rs)
            {
                if (confirmed(rs))
                {
                    finalList.Add(rs);
                    return;
                }
                StrongString frString = Empty;
                StrongString flastRString = frString;
                var fake_chars = rs.GetValue().ToCharArray();
                for (int i = 0; i < fake_chars.Length; i++)
                {
                    var fc = fake_chars[i];
                    frString += fc;
                    if (confirmed(frString))
                    {
                        flastRString = frString;
                        if (i == fake_chars.Length - 1)
                        {
                            finalList.Add(flastRString);
                            clearFakes();
                            // continue to another turn of loop
                            // ReSharper disable once RedundantJumpStatement
                            continue;
                        }
                    }
                    else
                    {
                        finalList.Add(flastRString);
                        clearFakes();
                        if (i == fake_chars.Length - 1)
                        {
                            finalList.Add(fc.ToString());
                        }
                        else
                        {
                            frString += fc;
                        }
                    }
                }
                return;
                void clearFakes()
                {
                    flastRString = frString = Empty;
                }
            }
        }
        public SizeF Measure(Font f, Graphics g, float minWidth, float maxWidth)
        {
            int lines;
            return new SizeF(getWidth(), getHeight());

            float getWidth()
            {
                SizeF measure1 = g.MeasureString(GetValue(), f);
                lines =
                    (int)Math.Ceiling(measure1.Width / maxWidth);
                return Math.Max(Math.Min(measure1.Width, maxWidth), minWidth);
            }
            float getHeight()
            {
                return (lines + 1) * f.Height;
            }
        }
        /// <summary>
        /// check if this <see cref="StrongString"/>'s <see cref="Length"/>
        /// is equal to 0 or not.
        /// </summary>
        /// <returns>
        /// true if the <see cref="Length"/> is 0;
        /// otherwise return false.
        /// </returns>
        public bool IsEmpty()
        {
            return GetValue().Length == 0;
        }
        /// <summary>
        /// check if this <see cref="StrongString"/> is Healthy or not.
        /// if it's disposed or it's empty, then it means
        /// it's not healthy.
        /// </summary>
        /// <returns>
        /// false if the <see cref="StrongString"/> is empty or is
        /// disposed; otherwise return true.
        /// </returns>
        public bool IsHealthy()
        {
            return !IsEmpty() && !IsDisposed;
        }
        /// <summary>
        /// check if this StrongString contains special characters or not.
        /// NOTICE: Special characters, are the characters which are not included in the
        /// Character Range of FontManager.
        /// </summary>
        /// <returns></returns>
        public bool HasSpecial()
        {
            var manager = ThereIsConstants.Forming.GameClient.FontManager;
            var chars = GetValue().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!manager.Contains(chars[i]) && !IsSignedChar(chars[i]))
                {
                    return true;
                }
            }
            return false;
            static bool IsSignedChar(in char c)
            {
                switch (c)
                {
                    case SIGNED_CHAR1:
                    {
                            return true;
                    }
                    default:
                        return false;
                }
            }
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static implicit operator StrongString(string v)
        {
            if (v != null)
            {
                return new StrongString(v);
            }
            return Empty;
        }
        #endregion
        //-------------------------------------------------
        #region overrided Methods Region
        public override string ToString()
        {
#if !DEBUG
            return GetValue();
#else
            return ToStringValue;
#endif
        }
        public override bool Equals(object obj)
        {
            if (obj is StrongString s)
            {
                return this == s;
            }
            else if (obj is string str)
            {
                return this == str;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }
        #endregion
        //-------------------------------------------------
        #region Operator's Region
        public static StrongString operator +(StrongString left, StrongString right)
        {
            return left.GetValue() + right.GetValue();
        }
        public static StrongString operator +(StrongString left, string right)
        {
            return left.GetValue() + right;
        }
        public static StrongString operator +(string left, StrongString right)
        {
            return left + right.GetValue();
        }
        public static StrongString operator +(StrongString left, char right)
        {
            StrongString s = left;
            switch (right)
            {
                case UNSIGNED_CHAR1:
                    {
                        if (s.Length <= 0)
                        {
                            return s;
                        }
                        return s.Remove(s.Length - 1, 1);
                    }
                case UNSIGNED_CHAR2:
                    {
                        if (s.Length > 0)
                        {
                            s += "\n";
                        }
                        break;
                    }
                default:
                    s += right.ToString();
                    break;
            }
            return s;
        }
        public static StrongString operator +(char left, StrongString right)
        {
            return right + left;
        }
        public static bool operator ==(StrongString left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() == right.GetValue();
        }
        public static bool operator ==(StrongString left, string right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() == right;
        }
        public static bool operator ==(string left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left == right.GetValue();
        }
        public static bool operator !=(StrongString left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return true;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() != right.GetValue();
        }
        public static bool operator !=(StrongString left, string right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return true;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() != right;
        }
        public static bool operator !=(string left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return true;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left != right.GetValue();
        }
        #endregion
        //-------------------------------------------------
    }
#pragma warning restore IDE0032
}
