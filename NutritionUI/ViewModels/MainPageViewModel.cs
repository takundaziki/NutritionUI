using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using NutritionUI.Models;
using Xamarin.Forms;

namespace NutritionUI.ViewModels

    //request to call done here
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ICommand GetDataCommand { get; set; }

        public MainPageViewModel()
        {
            GetDataCommand = new Command(async () => await RunSafe(GetData()));
        }

        async Task GetData()
        {

            var itemsResponse = await ApiManager.GetItems("mango");

            if (itemsResponse.IsSuccessStatusCode)
            {
                var response = await itemsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<List<Item>>(response));
                Items = new ObservableCollection<Item>(json);
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }
    }
}
