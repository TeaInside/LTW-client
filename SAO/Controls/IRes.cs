// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.GameObjects.Resources;

namespace SAO.Controls
{
    /// <summary>
    /// Woto Resources Provider.
    /// </summary>
    public interface IRes
    {
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// Woto ResourceManager.
        /// </summary>
        WotoRes MyRes { get; set; }
        #endregion
        //-------------------------------------------------
    }
}
