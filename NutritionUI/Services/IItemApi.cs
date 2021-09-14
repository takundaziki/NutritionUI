using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NutritionUI.Models;
using Refit;

namespace NutritionUI.Services
{
    [Headers("x-Api-Key:vWGBxOf5khMSVS9e78bppF7VeXQKHmOq1vjg5tcm" , "Content-Type:application/json" )]
    public interface IItemApi
    {
        //request method
        [Get("/v1/nutrition?query={query}")]
        //HTTP Message allows us to detect an error in the server before
        //deserializing the JSON into an object
        Task<HttpResponseMessage> GetItems(string query);
    }
}
