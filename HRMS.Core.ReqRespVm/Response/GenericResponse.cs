using HRMS.Core.Entities.Common;
using System.Collections.Generic;
using System.Net;

namespace HRMS.Core.ReqRespVm.Response
{
    /// <summary>
    /// Code to generate the custom out put response to the end user,
    /// So that we will change as per the end client requirement
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class GenericResponse<TEntity, T> where TEntity : class
    {
        public IEnumerable<TEntity> Entities { get; set; }
        public TEntity Entity { get; set; }
        public string Message { get; set; }
        public T EntityId { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public GenericResponse<TEntity, T> GetGenericResponse(
            IEnumerable<TEntity> entities, TEntity entity, string message, T entityId,
            ResponseStatus status)
        {
            return new GenericResponse<TEntity, T>()
            {
                Entities = entities,
                Entity = entity,
                Message = message,
                EntityId = entityId,
                ResponseStatus = status
            };
        }
    }
}
