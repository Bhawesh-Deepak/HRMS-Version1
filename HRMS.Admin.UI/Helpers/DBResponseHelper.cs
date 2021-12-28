using HRMS.Core.Entities.Common;
using HRMS.Core.ReqRespVm.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Helpers
{
    public class DBResponseHelper<TEntity, T> where TEntity : class
    {
        public IEnumerable<TEntity> Entities { get; set; }
        public TEntity Entity { get; set; }
        public bool IsDBException { get; set; }

        public (string message, DBResponseHelper<TEntity, T>) GetDBResponseHelper( GenericResponse<TEntity, T> response)
        {
            var dbResponseHelper = new DBResponseHelper<TEntity, T>();

            string message = string.Empty;

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Deleted:
                    message = "Record deleted successfuly !!!";
                    dbResponseHelper.Entity = response.Entity;
                    dbResponseHelper.Entities = response.Entities;
                    break;

                case ResponseStatus.Success:
                    message = "Action perform successfully !!!";
                    dbResponseHelper.Entity = response.Entity;
                    dbResponseHelper.Entities = response.Entities;
                    break;

                case ResponseStatus.AlreadyExists:
                    message = "Record already exists !!!";
                    dbResponseHelper.Entity = response.Entity;
                    dbResponseHelper.Entities = response.Entities;
                    break;

                case ResponseStatus.Created:
                    message = "Record created successfully !!!";
                    dbResponseHelper.Entity = response.Entity;
                    dbResponseHelper.Entities = response.Entities;
                    break;

                case ResponseStatus.Updated:
                    message = "Record updated successfully !!!";
                    dbResponseHelper.Entity = response.Entity;
                    dbResponseHelper.Entities = response.Entities;
                    break;

                case ResponseStatus.DataBaseException:
                    message = "Database exception occured !!!";
                    dbResponseHelper.Entity = response.Entity;
                    dbResponseHelper.Entities = response.Entities;
                    break;

            }

            return (message, dbResponseHelper);
        }
    }
}
