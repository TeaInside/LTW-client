// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace SAO.GameObjects.Heroes
{
    class FlatHeroSocket : IHeroSocket
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region Properties Region
        public int ServerIndex { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public FlatHeroSocket(int _server_index)
        {
            ServerIndex = _server_index;
        }
        #endregion
        //-------------------------------------------------
    }
}
