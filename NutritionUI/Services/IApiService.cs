using System;
using Fusillade;

namespace NutritionUI.Services
{
    public interface IApiService<T>
    {
        T GetApi(Priority priority);

    }
}
