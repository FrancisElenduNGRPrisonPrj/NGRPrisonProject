using NGRPrisonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGRPrisonAPI.Services
{
    public interface IPrisonRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> Save();


        //Prison
        Task<Prison[]> GetPrisons(bool includeInmates = false);
        Task<Prison> GetPrison(int prisonId, bool includeInmates = false);
        Task<Prison[]> GetPrisonByState(int stateId, bool includeInmates = false);

        ////States
        //Task<State[]> GetStates(bool includePrisons = false, bool includeInmates = false);
        //Task<State> GetState(int stateId, bool includeInmates = false, bool includePrisons = false);

        //Inmates
        Task<Inmate[]> GetInmatesByPrison(int prisonId);
        Task<Inmate[]> GetInmatesByState(int stateId);
        Task<Inmate> GetInmate(int inmateId);


    }
}
