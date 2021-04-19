// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Drawing.Text;
using Microsoft.Xna.Framework.Graphics;
using SAO.Client;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Resources;

namespace SAO.GameObjects.UGW
{
    public sealed partial class FontManager : IRes, IDisposable
    {
        //-------------------------------------------------
        #region Constant's Region
        public const string SAOFontFileNameInRes        = "FirstFontFile_Name";
        public const string OldStoryFileNameInRes       = "SecondFontFile_Name";
        public const string OldStoryBoldFileInRes       = "Old Story Bold";
        public const string OldStoryBoldItalicFileInRes = "Old Story Bold Italic";
        public const string SAOTTBoldFileInRes          = "SAOWelcomeTT-Bold";
        public const string SAOTTRegularFileInRes       = "SAOWelcomeTT-Regular";
        public const string F_M_G                       = @"F_M_G\";
        public const string FO_DIRECROTEY               = @"\fo\";
        public const int FontBitmapWidth                = 1024;
        public const int FontBitmapHeight               = 1024;
        public const int OLDSTORY_INDEX                 = 0;
        public const int SAO_INDEX                      = 1;
        #endregion
        //-------------------------------------------------
        #region static Properties Region
        public static string FoDir
        {
            get => ThereIsConstants.Path.Here + FO_DIRECROTEY;
        }
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public WotoRes MyRes { get; set; }
        public GameClient Client { get; }
        #endregion
        //-------------------------------------------------
        #region field's Region
        private CharacterRange[] _ranges;
        private System.Drawing.Text.PrivateFontCollection _collection;
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        private FontManager(GameClient _client)
        {
            Client = _client;
            InitializeComponents();
        }
        #endregion
        //-------------------------------------------------
        #region Destructor's Region
        ~FontManager()
        {
            Dispose();
            if (_ranges != null)
            {
                _ranges = null;
            }
            if (_collection != null)
            {
                _collection = null;
            }
            return;
        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public SpriteFont GetSprite(SAO_SFonts _s_font, float size)
        {
            return _s_font switch
            {
                SAO_SFonts.sao_tt_bold => BuildFont(SAOTTBoldFileInRes, size),
                SAO_SFonts.sao_tt_regular => BuildFont(SAOTTRegularFileInRes, size),
                SAO_SFonts.old_story_bold => BuildFont(OldStoryBoldFileInRes, size),
                SAO_SFonts.old_story_bold_italic => BuildFont(OldStoryBoldItalicFileInRes, size),
                _ => null,
            };
        }
        public Font GetFont(SAO_Fonts _s_font, float size)
        {
            FontFamily f;
            switch (_s_font)
            {
                case SAO_Fonts.old_story_italic_bold:
                    f = _collection.Families[OLDSTORY_INDEX];
                    return new Font(f, size, FontStyle.Italic | FontStyle.Bold);
                case SAO_Fonts.sao_tt_bold:
                    f = _collection.Families[SAO_INDEX];
                    return new Font(f, size, FontStyle.Bold);
                default:
                    return null;
            }
        }
        #endregion
        //-------------------------------------------------
        #region static Method's Region
        public static FontManager GenerateManager(GameClient _client)
        {
            if (_client == null)
            {
                return null;
            }
            if (_client.FontManager != null)
            {
                return _client.FontManager;
            }
            return new FontManager(_client);
        }
        #endregion
        //-------------------------------------------------
    }
}
