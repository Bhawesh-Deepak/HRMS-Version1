using HRMS.Core.ReqRespVm.Response;
using System;
using System.Threading.Tasks;

namespace HRMS.Services.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity,T> where TEntity: class
    {
        Task<GenericResponse<TEntity, T>> GetAllEntities(Func<TEntity, bool> where);
        Task<GenericResponse<TEntity, T>> GetAllEntityById(Func<TEntity, bool> where);
        Task<GenericResponse<TEntity, T>> CreateEntities(TEntity[] model);
        Task<GenericResponse<TEntity, T>> CreateEntity(TEntity model);
        Task<GenericResponse<TEntity, T>> UpdateEntity(TEntity model);
        Task<GenericResponse<TEntity, T>> DeleteEntity(TEntity items);
        Task<GenericResponse<TEntity, T>> DeleteEntities(TEntity[] items);
        Task<GenericResponse<TEntity, T>> CheckIsExists(Func<TEntity, bool> where);
        Task<GenericResponse<TEntity,T>> UpdateMultipleEntity(params TEntity[] items);
    }
}
