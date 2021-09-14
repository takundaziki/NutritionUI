using System;
using System.Text.RegularExpressions;

namespace NutritionUI
{
    /* Static values placed in this class so it's easy to change incase
     the API URL changes or there is a need to manage and deploy in multiple environments*/
    public static class Config
    {
        public static string ApiUrl = "https://calorieninjas.com";
        //Api hostname used by connectivity plugin to check if URL is responding
        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
