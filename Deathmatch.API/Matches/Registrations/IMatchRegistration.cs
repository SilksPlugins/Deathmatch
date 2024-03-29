﻿using OpenMod.API.Prioritization;
using System;
using System.Collections.Generic;
using Autofac;

namespace Deathmatch.API.Matches.Registrations
{
    public interface IMatchRegistration
    {
        /// <summary>
        /// The unique ID of this match.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Describes whether or not this registration is enabled.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets the type of the match.
        /// </summary>
        Type Type { get; set; }

        /// <summary>
        /// The priority of this match. Used to compare against others with same title.
        /// </summary>
        Priority Priority { get; set; }

        /// <summary>
        /// The title and primary identifier of this match.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The description of this match.
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// The aliases for identifying this match.
        /// </summary>
        List<string> Aliases { get; set; }
    }
}
