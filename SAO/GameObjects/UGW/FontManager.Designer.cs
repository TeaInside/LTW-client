// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Drawing.Text;
using Microsoft.Xna.Framework.Graphics;
using SAO.Client;
using SAO.Constants;
using SAO.GameObjects.Resources;

namespace SAO.GameObjects.UGW
{
    partial class FontManager
    {
        //-------------------------------------------------
        #region Initialize Method's Region
        private void InitializeComponents()
        {
            //---------------------------------------------
            //news:
            this.MyRes = new WotoRes(typeof(FontManager));
            if (Universe.IsWindows)
            {
                this._collection = new PrivateFontCollection();   
            }
            this._ranges = GetRange();
            //---------------------------------------------
            //collections:
            // TODO:
            this._collection?.AddFontFile(FoDir + this.MyRes.GetString(SAOFontFileNameInRes).GetValue());
            this._collection?.AddFontFile(FoDir + this.MyRes.GetString(OldStoryFileNameInRes).GetValue());
            //---------------------------------------------
        }
        private Font BuildFont(FontFamily family, float size, FontStyle style)
        {
            return new Font(family, size, style);
        }
        /// <summary>
        /// 8 - 25 => Spacing: 0.0;
        /// 26 => Spacing : 1.2;
        /// 27 - 28 => Spacing : 2.4;
        /// 29 => 3.2;
        /// 30 => 3.6;
        /// </summary>
        /// <param name="resName"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private SpriteFont BuildFont(string resName, float size)
        {
            SpriteFont _font = 
                this.Client.Content.Load<SpriteFont>(GeneratePath(resName) + ((int)size).ToString());
            return _font;
        }
        private string GeneratePath(string res)
        {
            return F_M_G + res + ThereIsConstants.Path.DoubleSlash + res;
        }
        private CharacterRange[] GetRange()
        {
#if MORE_CHARS
return new[] 
            {
                CharacterRange.BasicLatin,
                CharacterRange.Latin1Supplement,
                CharacterRange.LatinExtendedA,
                CharacterRange.Cyrillic,
            };
#else
            return new[]
            {
                CharacterRange.SAO_Chars,
            };
#endif
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Method's Region
        public void Dispose()
        {
            if (this.MyRes != null)
            {
                this.MyRes = null;
            }
            if (this._collection != null)
            {
                this._collection = null;
            }
        }
        public bool Contains(char c)
        {
            for (int i = 0; i < _ranges.Length; i++)
            {
                if (_ranges[i].Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        //-------------------------------------------------
    }
}