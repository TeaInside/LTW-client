// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.GameObjects.WMath;

namespace SAO.Controls.Moving
{
    public sealed partial class MoveList : ListW<IMoveable>
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region Properties Region
        public MoveManager MoveManager { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        internal MoveList(in MoveManager _manager_)
        {
            MoveManager = _manager_;
        }
        #endregion
        //-------------------------------------------------
    }
}
