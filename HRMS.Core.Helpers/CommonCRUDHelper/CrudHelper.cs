using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Helpers.CommonCRUDHelper
{
    public static class CrudHelper
    {
        public static TEntity CreateHelper<TEntity>(TEntity entity)
        {
            Type modelType = entity.GetType();
            PropertyInfo[] pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {
                if (prop.Name == "FinancialYear")
                {
                    prop.SetValue(entity, FinancialYear.FinancialYearDetail);
                }
            }
            return entity;
        }

        public static T DeleteHelper<T>(T entity, int userId)
        {

            Type modelType = entity.GetType();
            PropertyInfo[] pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {
                if (prop.Name == "IsDeleted")
                {
                    prop.SetValue(entity, true, null);
                }
                else if (prop.Name == "IsActive")
                {
                    prop.SetValue(entity, false, null);
                }
                else if (prop.Name == "UpdatedBy")
                {
                    prop.SetValue(entity, userId, null);
                }
                else if (prop.Name == "UpdatedDate")
                {
                    prop.SetValue(entity, DateTime.Now.Date, null);
                }
                else if (prop.Name == "FinancialYear")
                {
                    prop.SetValue(entity, FinancialYear.FinancialYearDetail);
                }
            }
            return entity;
        }

        public static T UpdateHelper<T>(T entity, int userId)
        {
            Type modelType = entity.GetType();
            PropertyInfo[] pinfos = modelType.GetProperties();
            foreach (var prop in pinfos)
            {

                if (prop.Name == "UpdatedBy")
                {
                    prop.SetValue(entity, userId, null);
                }
                else if (prop.Name == "UpdatedDate")
                {
                    prop.SetValue(entity, DateTime.Now.Date, null);
                }
                else if (prop.Name == "FinancialYear")
                {
                    prop.SetValue(entity, FinancialYear.FinancialYearDetail);
                }
            }
            return entity;
        }

        public static class FinancialYear
        {
            public static int FinancialYearDetail { get; set; }
        }
    }
}
