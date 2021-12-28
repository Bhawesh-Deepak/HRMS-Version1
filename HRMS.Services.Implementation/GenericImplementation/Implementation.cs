using HRMS.Core.Entities.Common;
using HRMS.Core.ReqRespVm.Response;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Implementation.GenericImplementation
{
    public class Implementation<TEntity, T> : IGenericRepository<TEntity, T> where TEntity : class
    {
        private readonly HRMSContext context;
        private readonly DbSet<TEntity> TEntities;
        /// <summary>
        /// Constructore to configure the Data base connection string
        /// </summary>
        /// <param name="configuration"></param>
        public Implementation(IConfiguration configuration)
        {
            context = new HRMSContext(configuration);
            TEntities = context.Set<TEntity>();
        }

        /// <summary>
        /// Check the Item present on to the data base or not
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> CheckIsExists(Func<TEntity, bool> where)
        {
            try
            {
                TEntity item = null;
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                item = dbQuery.AsNoTracking().FirstOrDefault(where);

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                    .GetGenericResponse(null, item, "success", default,
                    ResponseStatus.Success));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
               
            }
        }

        /// <summary>
        /// Create multitple entity to the database object
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> CreateEntities(TEntity[] model)
        {
            try
            {
                await TEntities.AddRangeAsync(model);
                await context.SaveChangesAsync();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                    .GetGenericResponse(null, null, "success", default,
                    ResponseStatus.Success));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }

        /// <summary>
        /// Create single entity to the data base
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> CreateEntity(TEntity model)
        {
            try
            {
                await TEntities.AddAsync(model);
                await context.SaveChangesAsync();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                    .GetGenericResponse(null, null, "success", default,
                    ResponseStatus.Success));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }

        public async Task<GenericResponse<TEntity, T>> DeleteEntities(TEntity[] items)
        {
            try
            {
                context.UpdateRange(items);
                await context.SaveChangesAsync();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                 .GetGenericResponse(null, null, "success", default,
                 ResponseStatus.Deleted));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }

        /// <summary>
        /// Remove entity from Data base object
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> DeleteEntity(TEntity items)
        {
            try
            {
                
                context.Update(items);
                await context.SaveChangesAsync();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                 .GetGenericResponse(null, null, "success", default,
                 ResponseStatus.Deleted));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }

      

        /// <summary>
        /// Get All active entity from Data base
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> GetAllEntities(Func<TEntity, bool> where)
        {
            try
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                var tList = dbQuery.AsNoTracking().Where(where).ToList<TEntity>();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                 .GetGenericResponse(tList, null, "success", default,
                 ResponseStatus.Success));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }

        /// <summary>
        /// Get Specific entity from the Data base
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> GetAllEntityById(Func<TEntity, bool> where)
        {
            try
            {
                TEntity item = null;
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                   .GetGenericResponse(null, item, "Success", default,
                   ResponseStatus.Success));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);

            }
        }

        /// <summary>
        /// Update the entity to the data base
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<GenericResponse<TEntity, T>> UpdateEntity(TEntity model)
        {
            try
            {
                context.Update(model);
                await context.SaveChangesAsync();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                 .GetGenericResponse(null, null, "success", default,
                 ResponseStatus.Updated));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }
       

        public async Task<GenericResponse<TEntity, T>> UpdateMultipleEntity(params TEntity[] items)
        {
            try
            {
                context.UpdateRange(items);
                await context.SaveChangesAsync();

                return await Task.Run(() => new GenericResponse<TEntity, T>()
                 .GetGenericResponse(null, null, "success", default,
                 ResponseStatus.Updated));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Db Exception", ex);
            }
        }
    }
}
