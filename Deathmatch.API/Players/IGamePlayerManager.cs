﻿using OpenMod.API.Ioc;
using OpenMod.API.Users;
using OpenMod.Unturned.Players;
using OpenMod.Unturned.Users;
using Steamworks;
using System;
using System.Collections.Generic;
using SDG.Unturned;

namespace Deathmatch.API.Players
{
    [Service]
    public interface IGamePlayerManager
    {
        IReadOnlyCollection<IGamePlayer> GetPlayers();
        IReadOnlyCollection<IGamePlayer> GetPlayers(Predicate<IGamePlayer> predicate);

        IGamePlayer GetPlayer(Predicate<IGamePlayer> predicate);
        IGamePlayer GetPlayer(CSteamID steamId);
        IGamePlayer GetPlayer(Player player);
        IGamePlayer GetPlayer(UnturnedPlayer player);
        IGamePlayer GetPlayer(UnturnedUser user);
        IGamePlayer GetPlayer(string searchString, UserSearchMode searchMode);
    }
}
