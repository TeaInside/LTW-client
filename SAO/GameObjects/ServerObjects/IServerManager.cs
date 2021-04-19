// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using WotoProvider.Interfaces;
using SAO.Security;
using SAO.LoadingService;
using SAO.GameObjects.Item;
using SAO.GameObjects.Heroes;
using SAO.GameObjects.Players;
using SAO.GameObjects.Kingdoms;
using SAO.GameObjects.Chatting;

namespace SAO.GameObjects.ServerObjects
{
    public interface IServerManager
    {
        //-------------------------------------------------
        #region Properties Region

        #endregion
        //-------------------------------------------------
        #region Method's Region
        IServerProvider<QString, DataBaseClient> Get_Main_Server();
        IServerProvider<QString, DataBaseClient> Get_Channel_Server(ChatChannels _channel_);
        IServerProvider<QString, DataBaseClient> Get_Kingdom_Server(SAO_Kingdoms _kingdom_);
        IServerProvider<QString, DataBaseClient> Get_UID_Server(in StrongString _username_);
        IServerProvider<QString, DataBaseClient> Get_UID_Generation_Server(in int _index_);
        IServerProvider<QString, DataBaseClient> Get_UID_Server(in int _index_);
        IServerProvider<QString, DataBaseClient> Get_UID_Server(in UID _id_);
        IServerProvider<QString, DataBaseClient> Get_Login_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_PlayerInfo_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_Me_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_Player_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_Troops_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_MagicalTroops_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_Resources_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_PlayerHeroSocket_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_SecuredMe_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_PlayerItemsSocket_Server(in IPlayerSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_GeneralItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_WeaponsItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_WarExtraItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_CurrencyItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_EventItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_HeroesShardsItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_GiftItems_Server(in IItemSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_HeroInfo_Server(in IHeroSocket _socket_);
        IServerProvider<QString, DataBaseClient> Get_NPCInfo_Server();
        #endregion
        //-------------------------------------------------
    }
}
