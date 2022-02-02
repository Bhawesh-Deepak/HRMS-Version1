using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Entities.Payroll;
using HRMS.Core.ReqRespVm.RequestVm;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace HRMS.Core.Helpers.ExcelHelper
{
    public class ReadLeadData
    {
        public IEnumerable<CustomerDetail> GetCustomerDetail(IFormFile inputFile)
        {
            var dataResult = ReadExcelDataHelper.GetDataTableFromExcelFile(inputFile);
            var models = new List<CustomerDetail>();

            for (int i = 1; i < dataResult.dtResult.Rows.Count; i++)
            {
                var model = new CustomerDetail();
                model.Description_Project = dataResult.dtResult.Rows[i][0].ToString();
                model.InterestedToBuy = dataResult.dtResult.Rows[i][1].ToString();
                model.LeadName = dataResult.dtResult.Rows[i][2].ToString();
                model.Email = dataResult.dtResult.Rows[i][3].ToString();
                model.Phone = dataResult.dtResult.Rows[i][4].ToString();
                model.Location = dataResult.dtResult.Rows[i][5].ToString();
                model.SpecialRemarks = dataResult.dtResult.Rows[i][6].ToString();
                model.Country = string.Empty;
                model.State = string.Empty;
                model.City = string.Empty;
                model.ZipCode = string.Empty;
                model.CompanyName = string.Empty;
                model.Website = string.Empty;
                model.Industry = string.Empty;
                model.EmpCode = string.Empty;

                model.FinancialYear = 1;
                models.Add(model);
            }

            return models;
        }
        public IEnumerable<CustomerDetail> GetCustomerDetailWithEmpCode(IFormFile inputFile)
        {
            var dataResult = ReadExcelDataHelper.GetDataTableFromExcelFile(inputFile);
            var models = new List<CustomerDetail>();

            for (int i = 1; i < dataResult.dtResult.Rows.Count; i++)
            {
                var model = new CustomerDetail();
                model.EmpCode = dataResult.dtResult.Rows[i][0].ToString();
                model.Description_Project = dataResult.dtResult.Rows[i][1].ToString();
                model.InterestedToBuy = dataResult.dtResult.Rows[i][2].ToString();
                model.LeadName = dataResult.dtResult.Rows[i][3].ToString();
                model.Email = dataResult.dtResult.Rows[i][4].ToString();
                model.Phone = dataResult.dtResult.Rows[i][5].ToString();
                model.Location = dataResult.dtResult.Rows[i][6].ToString();
                model.SpecialRemarks = dataResult.dtResult.Rows[i][7].ToString();
                model.Country = string.Empty;
                model.State = string.Empty;
                model.City = string.Empty;
                model.ZipCode = string.Empty;
                model.CompanyName = string.Empty;
                model.Website = string.Empty;
                model.Industry = string.Empty;
                model.FinancialYear = 1;
                models.Add(model);
            }

            return models;
        }
        public IEnumerable<UploadActivityExcelVM> GetLeadActivity(IFormFile inputFile)
        {
            var dataResult = ReadExcelDataHelper.GetDataTableFromExcelFile(inputFile);
            var models = new List<UploadActivityExcelVM>();
            try
            {
                for (int i = 1; i < dataResult.dtResult.Rows.Count; i++)
                {
                    var model = new UploadActivityExcelVM();
                    model.LeadName = dataResult.dtResult.Rows[i][0].ToString();
                    model.LeadType = dataResult.dtResult.Rows[i][7].ToString();
                    model.IntractionDate = Convert.ToDateTime(dataResult.dtResult.Rows[i][8]);
                    model.IntractionTime = TimeSpan.Parse(Convert.ToDateTime(string.Format(Convert.ToDateTime(dataResult.dtResult.Rows[i][9]).ToString(), "HH:mm")).ToString("HH:mm"));
                    model.Activity = dataResult.dtResult.Rows[i][10].ToString();
                    model.NextIntractionDate = Convert.ToDateTime(dataResult.dtResult.Rows[i][11]);
                    model.NextIntractionTime = TimeSpan.Parse(Convert.ToDateTime(string.Format(Convert.ToDateTime(dataResult.dtResult.Rows[i][12]).ToString(), "HH:mm")).ToString("HH:mm")); //TimeSpan.Parse(dataResult.dtResult.Rows[i][12].ToString());
                    model.NextIntractionActivity = dataResult.dtResult.Rows[i][13].ToString();
                    model.Comment = dataResult.dtResult.Rows[i][14].ToString();

                    models.Add(model);
                }
                return models;
            }
            catch (Exception ex)
            {
                return models;
            }
        }
    }
}
