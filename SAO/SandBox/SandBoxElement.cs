// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SAO.Controls;
using SAO.Controls.Elements;
using SAO.GameObjects.Resources;

namespace SAO.SandBox
{
    public abstract partial class SandBoxElement : GraphicElements
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// The Woto Resources Manager of this Sandbox.
        /// NOTICE: the sandbox elements, should have 
        /// separate <see cref="WotoRes"/>, and will not 
        /// accept passed-by values of <see cref="IRes"/>.
        /// </summary>
        public override WotoRes MyRes { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public SandBoxElement() : base()
        {

        }
        #endregion
        //-------------------------------------------------
    }
}
