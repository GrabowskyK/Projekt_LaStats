﻿using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt_LaStats.Service
{
    public class MatchesService : IMatchesService
    {
        private readonly DatabaseContext databaseContext;

        public MatchesService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Match> GetAllMatches() => databaseContext.Matches.Include(m => m.GuestTeam).Include(m => m.HomeTeam);
    }
}
