using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NutritionUI.Services
{
    public interface IApiManager
    {
        //request definitions
        Task<HttpResponseMessage> GetItems(string query);
    }
}
