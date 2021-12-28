using HRMS.Core.Entities.Common;


namespace HRMS.UI.Helpers
{
    public static class ResponseMessageHelper
    {
        public static (string message, bool isSuccess) GetResponseMessage(ResponseStatus status,string moduleName, string actionName)
        {
            string message = string.Empty;
            bool isSuccess = false;

            switch (status)
            {
                case ResponseStatus.DataBaseException:
                    Serilog.Log.Information($"Data base exception occured. {moduleName} and {actionName}");
                    message = "Something wents wrong, Please contact Admin!!";
                    break;

                case ResponseStatus.CodeException:
                    Serilog.Log.Error($"Code base exception occured. {moduleName} and {actionName}");
                    message = "Something wents wrong, Please contact Admin!!";
                    break;

                case ResponseStatus.AlreadyExists:
                    Serilog.Log.Error($"Data Already Exists. {moduleName} and {actionName}");
                    message = "Data already exists!!";
                    isSuccess = true;
                    break;

                case ResponseStatus.Created:
                    Serilog.Log.Information($"Data Created. {moduleName} and {actionName}");
                    message = "Data save successfully !!!";
                    isSuccess = true;
                    break;

                case ResponseStatus.Deleted:
                    Serilog.Log.Information($"Data Deleted. {moduleName} and {actionName}");
                    message = "Data deleted successfully !!!";
                    isSuccess = true;
                    break;

                case ResponseStatus.Updated:
                    Serilog.Log.Information($"Data Updated. {moduleName} and {actionName}");
                    message = "Data updated successfully !!!";
                    isSuccess = true;
                    break;

                case ResponseStatus.Success:
                    Serilog.Log.Information($"Data success. {moduleName} and {actionName}");
                    message = "Success !!!";
                    isSuccess = true;
                    break;
            }

            return (message, isSuccess);

        }
    }
}
