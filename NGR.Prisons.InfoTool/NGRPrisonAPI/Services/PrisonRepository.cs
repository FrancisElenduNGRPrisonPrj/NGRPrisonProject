using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NGRPrisonAPI.DataContext;
using NGRPrisonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Services
{
    public class PrisonRepository : IPrisonRepository
    {
        private readonly Context _context;
        private readonly ILogger<PrisonRepository> _logger;

        public PrisonRepository(Context context, ILogger<PrisonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}.");
            _context.Remove(entity);
        }

        public async Task<Inmate> GetInmate(int inmateId)
        {
            _logger.LogInformation($"Getting inmates records for id {inmateId}.");
            var query = _context.Inmates.Where(x => x.Id == inmateId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Inmate[]> GetInmatesByPrison(int prisonId)
        {
            _logger.LogInformation($"Getting inmates records for prison id {prisonId}.");
            var query = _context.Inmates.Where(x => x.Prison.Id == prisonId);

            return await query.ToArrayAsync();
        }

        public async Task<Inmate[]> GetInmatesByState(int stateId)
        {
            _logger.LogInformation($"Getting inmates records for state id {stateId}.");
            var query = _context.Inmates.Where(x => x.State.Id == stateId);

            return await query.ToArrayAsync();
        }

        public async Task<Prison> GetPrison(int prisonId, bool includeInmates = false)
        {
            _logger.LogInformation($"Getting Prison records for id {prisonId}.");

            var query = _context.Prisons.AsQueryable();
            if (includeInmates)
            {
                query = query.Include(i => i.Inmates);
            }

            query = query.Where(x => x.Id == prisonId).Include(x => x.State);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Prison[]> GetPrisonByState(int stateId, bool includeInmates = false)
        {
            _logger.LogInformation($"Getting Prison records for state id {stateId}.");

            var query = _context.Prisons.AsQueryable();
            if (includeInmates)
            {
                query = query.Include(i => i.Inmates);
            }

            query = query.Where(x => x.State.Id == stateId).Include(x=>x.State);

            return await query.ToArrayAsync();
        }

        public async Task<Prison[]> GetPrisons(bool includeInmates = false)
        {
            _logger.LogInformation("Getting all Prison records.");
            var query = _context.Prisons.AsQueryable();

            if (includeInmates)
            {
                query = query.Include(i => i.Inmates);
            }

            return await query.Include(x => x.State).ToArrayAsync();
        }

        //public Task<State> GetState(int stateId, bool includeInmates = false, bool includePrisons = false)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<State[]> GetStates(bool includePrisons = false, bool includeInmates = false)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving Changes.");
            
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}.");
            _context.Update(entity);
        }
    }
}
