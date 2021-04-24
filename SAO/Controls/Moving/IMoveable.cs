﻿// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using Microsoft.Xna.Framework;
using SAO.Controls.Elements;

namespace SAO.Controls.Moving
{
    public interface IMoveable
    {
        //-------------------------------------------------
        #region Properties Region
        bool IsDisposed { get; }
		bool Visible { get; }
        Vector2 LastPoint { get; }
        ElementMovements Movements { get; }
        IMoveManager MoveManager { get; }
        #endregion
        //-------------------------------------------------
        #region event field's Region
        event EventHandler MouseMove;
        #endregion
        //-------------------------------------------------
        #region Method's Region
        void Shocker();
        void Discharge();
        void MoveMe();
        void MoveMe(in float divergeX, in float divergeY);
        void ChangeLocation(in Vector2 location);
        void ChangeLocation(in float x, in float y);
        void ChangeLocation(in int x, in int y);
        bool ContainsChild(in IMoveable moveable);
        #endregion
        //-------------------------------------------------
    }
}
