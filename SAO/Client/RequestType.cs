// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace SAO.Client
{
    /// <summary>
    /// Provide the types of the internal requests
    /// between Universe and GameClient.
    /// </summary>
    internal enum RequestType
    {
        /// <summary>
        /// it means there is no request here
        /// and all requests are done.
        /// </summary>
        None = 0,
        /// <summary>
        /// the request for acitvating the holy planet of woto.
        /// </summary>
        Activate = 1,
    }
}
