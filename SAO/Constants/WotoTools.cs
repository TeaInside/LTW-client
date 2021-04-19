// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SAO.Security;
using SAO.Controls.Elements;

namespace SAO.Constants
{
    /// <summary>
    /// this class, contains main extension methods 
    /// for sao game.
    /// </summary>
    public static class WotoTools
    {
        /// <summary>
        /// get a strong value of this string.
        /// </summary>
        /// <param name="value">
        /// the string.
        /// </param>
        /// <returns>
        /// a strong value of this string.
        /// </returns>
        public static StrongString ToStrong(this string value)
        {
            return new StrongString(value);
        }
        /// <summary>
        /// calculate the absolute value of this vector2.
        /// </summary>
        /// <param name="_v">
        /// the vector.
        /// </param>
        /// <returns>
        /// a non-negative <see cref="Vector2"/>.
        /// </returns>
        public static Vector2 Abs(this Vector2 _v)
        {
            float _i1 = _v.X, _i2 = _v.Y;
            _i1 = MathF.Abs(_i1);
            _i2 = MathF.Abs(_i2);
            if (_i1 != _v.X || _i2 != _v.Y)
            {
                return new(_i1, _i2);
            }
            return _v;
        }
        /// <summary>
        /// calculate the absolute value of this point.
        /// </summary>
        /// <param name="_v">
        /// the point.
        /// </param>
        /// <returns>
        /// a non-negative <see cref="Point"/>.
        /// </returns>
        public static Point Abs(this Point _v)
        {
            int _i1 = _v.X, _i2 = _v.Y;
            _i1 = Math.Abs(_i1);
            _i2 = Math.Abs(_i2);
            if (_i1 != _v.X || _i2 != _v.Y)
            {
                return new(_i1, _i2);
            }
            return _v;
        }
		
	
	}

}
