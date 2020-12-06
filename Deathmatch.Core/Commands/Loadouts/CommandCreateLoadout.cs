﻿using Cysharp.Threading.Tasks;
using Deathmatch.API.Loadouts;
using Deathmatch.API.Players;
using Microsoft.Extensions.Localization;
using OpenMod.API.Commands;
using OpenMod.API.Permissions;
using OpenMod.API.Prioritization;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using System;
using Deathmatch.Core.Loadouts;

namespace Deathmatch.Core.Commands.Loadouts
{
    [Command("createloadout", Priority = Priority.Normal)]
    [CommandAlias("createl")]
    [CommandAlias("cloadout")]
    [CommandAlias("cl")]
    [CommandAlias("addloadout")]
    [CommandAlias("addl")]
    [CommandAlias("aloadout")]
    [CommandAlias("al")]
    [CommandSyntax("<game mode> <loadout>")]
    [CommandDescription("Creates a loadout from your current inventory.")]
    [CommandActor(typeof(UnturnedUser))]
    public class CommandCreateLoadout : UnturnedCommand
    {
        private readonly IGamePlayerManager _playerManager;
        private readonly ILoadoutManager _loadoutManager;
        private readonly IStringLocalizer _stringLocalizer;

        public CommandCreateLoadout(IGamePlayerManager playerManager,
            ILoadoutManager loadoutManager,
            IStringLocalizer stringLocalizer,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _playerManager = playerManager;
            _loadoutManager = loadoutManager;
            _stringLocalizer = stringLocalizer;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var player = _playerManager.GetPlayer((UnturnedUser)Context.Actor);

            var gameMode = await Context.Parameters.GetAsync<string>(0);
            var loadoutTitle = await Context.Parameters.GetAsync<string>(1);

            var category = _loadoutManager.GetCategory(gameMode);

            if (category == null)
                throw new UserFriendlyException(_stringLocalizer["commands:loadout:no_gamemode"]);

            var oldLoadout = category.GetLoadout(loadoutTitle);

            var newLoadout = Loadout.FromPlayer(player);

            if (oldLoadout != null)
            {
                category.RemoveLoadout(oldLoadout);
            }

            category.AddLoadout(newLoadout);

            await category.SaveLoadouts();

            await PrintAsync(_stringLocalizer[
                "commands:create_loadout:success" + (oldLoadout == null ? "" : "_overwrite"),
                new {Loadout = newLoadout.Title, GameMode = category.Title}]);
        }
    }
}