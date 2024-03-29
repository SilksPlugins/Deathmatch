﻿using Deathmatch.API.Matches.Registrations;
using System.Collections.Generic;

namespace Deathmatch.API.Matches
{
    public interface IMatchProvider
    {
        IReadOnlyCollection<IMatchRegistration> GetMatchRegistrations();
    }
}
