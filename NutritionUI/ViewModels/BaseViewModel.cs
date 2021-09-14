using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using NutritionUI.Services;

namespace NutritionUI.ViewModels
{
    //handles property chnaged
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IUserDialogs PageDialog = UserDialogs.Instance;
        public IApiManager ApiManager;
        //instantiate api service passing the api url
        IApiService<IItemApi> itemApi = new ApiService<IItemApi>(Config.ApiUrl);
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy { get; set; }
        public BaseViewModel()
        {
            //instantiate APIManager padding to api service
            ApiManager = new ApiManager(itemApi);

        }

        public async Task RunSafe(Task task, bool ShowLoading = true, string loadinMessage = null)
        {
            try
            {
                //requests to handles crashes
                if (IsBusy) return;

                IsBusy = true;
                //shows loading by default in all requests
                if (ShowLoading) UserDialogs.Instance.ShowLoading(loadinMessage ?? "Loading");

                await task;
            }
            catch (Exception e)
            {
                //handles exceptions
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
                Debug.WriteLine(e.ToString());
                await App.Current.MainPage.DisplayAlert("Eror", "Check your internet connection", "Ok");

            }
            finally
            {
                IsBusy = false;
                if (ShowLoading) UserDialogs.Instance.HideLoading();
            }
        }

    }
}
