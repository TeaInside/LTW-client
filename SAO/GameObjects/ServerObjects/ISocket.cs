// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Security;

namespace SAO.GameObjects.ServerObjects
{
    /// <summary>
    /// an interface for Sockets.
    /// </summary>
    public interface ISocket
    {
        //-------------------------------------------------
        #region Properties Region

        #endregion
        //-------------------------------------------------
        #region Method's Region
        StrongString GetForServer();
        #endregion
        //-------------------------------------------------
    }
}
